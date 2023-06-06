using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

using System.Reflection;
using System.Reflection.Emit;
using System;

using Cappuccino.Core;

// This script translates Byte Arrays to CIL (Common Intermediate Language (formerly Microsoft Intermediate Language)) -> Heavily referencing (and deriving from) Sorin Serban's works (circa 2007).
// Because of the complex nature of doing this, I've commented everything extensively - otherwise I couldn't prove I did it.

// Resources used or referenced for information:
// PRIMARY  -   https://www.codeproject.com/Articles/14058/Parsing-the-IL-of-a-Method-Body
//          -   https://learn.microsoft.com/en-us/dotnet/api/system.reflection.emit.opcodes.nop?view=net-7.0
//          -   https://learn.microsoft.com/en-us/dotnet/api/system.reflection.fieldinfo?view=net-8.0
//          -   https://learn.microsoft.com/en-us/dotnet/api/system.reflection.fieldinfo.getvalue?view=net-8.0#system-reflection-fieldinfo-getvalue(system-object)
//          -   https://learn.microsoft.com/en-us/dotnet/api/system.sbyte?view=net-7.0
//          -   https://learn.microsoft.com/en-us/dotnet/api/system.reflection.module.resolvemethod?view=net-7.0
//          -   https://learn.microsoft.com/en-us/dotnet/api/system.reflection.emit.operandtype?view=net-7.0
//          -   https://www.sciencedirect.com/topics/computer-science/branch-target-address#:~:text=The%20branch%20target%20address%20%28BTA%29%20is%20the%20address,Code%20Example%206.28%20Calculating%20the%20Branch%20Target%20Address
//          -   https://www.bbc.co.uk/bitesize/guides/zbk8jty/revision/2 (for trying to find out the meaning of OPERAND)
//          -   https://www.youtube.com/watch?v=Mv2XQgpbTNE (for trying to found out the meaning of OPERAND)
//          -   https://www.ieee.org/
//          -   https://www.scribbr.co.uk/stats/ordinal-data-meaning/ (for trying to find out the context and meaning of ORDINAL)
//          -   https://stats.oarc.ucla.edu/other/mult-pkg/whatstat/what-is-the-difference-between-categorical-ordinal-and-interval-variables/ (for trying to find out the context and meaning of ORDINAL)

// THIRD-PARTY LICENSES INVOLVED:
//          -   https://www.codeproject.com/info/cpol10.aspx

// NOTICE:
//      This code had to reference the source code provided by Sorin Serban (28 June 2007). The original article did not include many aspects of his source code nor
//      some of it's intracacies. I was able to follow the article, up until READINT32, in which no direct or indirect suggestion or notice was made about the method.
//      From there, I was unable to further assume elements of the source code to be n or y and had to rely directly on the source code provided. As such, this MSIL
//      interpreter now falls under the restrictions of the The Code Project Open License (CPOL) 1.02 - wherein this interpreter, being heavily based off of the one
//      found in Serban's original work(s), is being assuemd as wholesale restricted to the license governed by CPOL 1.02.

//      It is the case that the whole of the original "Work" has been changed to be compacted into a single script, with documentation therein. Terms [3.b] and [3.c] govern this.

//      This interpreter, as per [5d], is not separated into it's own package and is used EXCLUSVIELY for the assitance of custom attribute abilities and method calling detection.

//      Although [5a] specifies that "You agree not to remove any of the original copyright, patent, trademark, and attribution notices and associated disclaimers that may appear in the Source Code or Executable Files."
//      No such copyright, patent, trademarking or attribution notices appear in the source code files referenced below. No other files were used (nor necessary) for the intended functionality.
//                  -- SDIL/SDILReader/MethodBodyReader.cs      [Direct-Use Reference]
//                  -- SDIL/SDILReader/ILInstruction.cs         [Direct-Use Reference]
//                  -- SDIL/SDILReader/Globals.cs               [Read-Only, none of the methods were required by me and all relevant materials were found within the Article(s)]

//      The MSIL Interpreter is the only part of the Cappuccino Editor Framework restricted to this license by law.
//      Although this is the case, every effort to understand the missing elements of the framework. Some liberties have been taken.

//      This interpreter is as much following a guide as it is referencing the source code and (essentially) reverse engineering the source code to understand it.

namespace Cappuccino    
{
    namespace Interpreters
    {
        namespace BytesToMSIL
        {
            /// <summary>
            /// A C# object representation of an intsruction written in (or compiled to) Common Intermediate Language. <br></br>
            /// <see langword="Notice:"/> Based on Sorin Serban's direct methods.
            /// </summary>
            public class CILInstruction
            {
                /// <summary>
                /// The operation code.
                /// </summary>
                public OpCode code;

                /// <summary>
                /// The data / object defined for this operation to read, modify, delete or otherwise handle.
                /// </summary>
                public object operand;

                /// <summary>
                /// The starting position in the byte array for this instruction.
                /// </summary>
                public int offset;

                // Sorin lets control fall through multiple cases in the code.OperandType switch statement.
                // Instead, I've chosen to change this to a no-falling switch statement for my own sake.
                // Another difference is I don't use Sorin's Globals.cs types filtering method as I don't need it.
                /// <summary>
                /// Create a human-readable version of the CIL Language Instruction.
                /// </summary>
                /// <returns></returns>
                public override string ToString()
                {
                    string result = "";
                    result += GetOffset(offset) + " : " + code;
                    if (operand != null)
                    {
                        switch (code.OperandType)
                        {
                            default:
                                result += "Operand Type is not Supported";
                                break; ;

                            case OperandType.InlineField:
                                FieldInfo fOperand = ((FieldInfo)operand);
                                result += " " + fOperand.FieldType.ToString() + " " + fOperand.ReflectedType.ToString() + "::" + fOperand.Name + "";
                                break;

                            case OperandType.InlineMethod:
                                try
                                {
                                    MethodInfo mOperand = (MethodInfo)operand;
                                    result += " ";
                                    if (!mOperand.IsStatic)
                                    {
                                        result += "instance ";
                                    }

                                    result += mOperand.ReturnType.ToString() + " " + mOperand.ReflectedType.ToString() + "::" + mOperand.Name + "()";
                                }
                                catch
                                {
                                    try
                                    {
                                        ConstructorInfo cOperand = (ConstructorInfo)operand;
                                        result += " ";  
                                        if ((!cOperand.IsStatic))
                                        {
                                            result += "instance ";
                                        }
                                        result += cOperand.ReflectedType.ToString() + "::" + cOperand.Name + "()";
                                    }
                                    catch { }
                                }
                                break;

                            // The original lets control fall through ShortInlineBrTarged and to InlineBrTarget.
                            case OperandType.ShortInlineBrTarget:
                                result += " " + GetOffset((int)operand);
                                break;

                            case OperandType.InlineBrTarget:
                                result += " " + GetOffset((int)operand);
                                break;

                            case OperandType.InlineType:
                                result += " " + operand.ToString();
                                break;

                            case OperandType.InlineString:
                                if (operand.ToString() == "\r\n")
                                {
                                    result += "\"\\r\\n\"";
                                }
                                else result += " \"" + operand.ToString() + "\"";
                                break;

                            case OperandType.ShortInlineVar:
                                result += " " + operand.ToString();
                                break;

                            case OperandType.InlineI:
                                result += " " + operand.ToString();
                                break;

                            case OperandType.InlineI8:
                                result += " " + operand.ToString();
                                break;

                            case OperandType.InlineR:
                                result += " " + operand.ToString();
                                break;

                            case OperandType.ShortInlineI:
                                result += " " + operand.ToString();
                                break;

                            case OperandType.ShortInlineR:
                                result += " " + operand.ToString();
                                break;

                            case OperandType.InlineTok:
                                if (operand is Type)
                                {
                                    result += ((Type)operand).FullName;
                                }
                                else
                                {
                                    result += "Operand Type is not Supported";
                                }
                                break;
                        }
                    }

                    return result;
                }

                /// <summary>
                /// Get the instruction's method name and MethodInfo object, if it is a method call.
                /// </summary>
                /// <param name="methodName">The output string for the Method's human-readable CIL instruction as a name.</param>
                /// <param name="method">The output MethodInfo object for the Method's representation.</param>
                /// <returns><see langword="boolean"/> - False if not a method, true otherwise.</returns>
                public bool GetMethod(out string methodName, out MethodInfo method)
                {
                    methodName = "";
                    method = null;

                    if (code.OperandType == OperandType.InlineMethod)
                    {
                        try
                        {
                            method = (MethodInfo)operand;
                            methodName += " ";
                            if (!method.IsStatic)
                            {
                                methodName += "instance ";
                            }

                            methodName += method.ReturnType.ToString() + " " + method.ReflectedType.ToString() + "::" + method.Name + "()";
                            return true;
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

                /// <summary>
                /// Get the instruction's MethodInfo object, if it is a method call.
                /// </summary>
                /// <param name="method">The output MethodInfo object for the Method's representation.</param>
                /// <returns><see langword="boolean"/> - False if not a method, true otherwise.</returns>
                public bool GetMethodInfo(out MethodInfo method)
                {
                    method = null;

                    if (code.OperandType == OperandType.InlineMethod)
                    {
                        try
                        {
                            method = (MethodInfo)operand;
                            return true;
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

                /// <summary>
                /// Get the instruction's constructor name and ConstructorInfo object, if it is a constructor call.
                /// </summary>
                /// <param name="ctorName">The output string for the Constructor's human-readable CIL instruction as a name.</param>
                /// <param name="ctor">The output ConstructorInfo object for the Constructor's representation</param>
                /// <returns><see langword="boolean"/> - False if not a Constructor, true otherwise.</returns>
                public bool GetConstructor(out string ctorName, out ConstructorInfo ctor)
                {
                    ctorName = "";
                    ctor = null;

                    if (code.OperandType == OperandType.InlineMethod)
                    {
                        try
                        {
                            ctor = (ConstructorInfo)operand;
                            ctorName += " ";
                            if ((!ctor.IsStatic))
                            {
                                ctorName += "instance ";
                            }
                            ctorName += ctor.ReflectedType.ToString() + "::" + ctor.Name + "()";
                            return true;
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

                /// <summary>
                /// Get the instruction's ConstructorInfo object, if it is a constructor call.
                /// </summary>
                /// <param name="ctor">The output ConstructorInfo object for the Constructor's representation</param>
                /// <returns><see langword="boolean"/> - False if not a Constructor, true otherwise.</returns>
                public bool GetConstructorInfo(out ConstructorInfo ctor)
                {
                    ctor = null;

                    if (code.OperandType == OperandType.InlineMethod)
                    {
                        try
                        {
                            ctor = (ConstructorInfo)operand;
                            return true;
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

                /// <summary>
                /// Is this CIL Instruction calling the member? <br></br><br></br>
                /// This is the faster method, if you are looking for a detailed member see the alternative variant: <br></br>
                /// <see cref="IsCallToProvidedMember(MemberInfo, out bool)"/>
                /// </summary>
                /// <param name="memberToCheck">The member to try compare.</param>
                /// <returns><see langword="boolean"/> - True if the MemberInfo objects match, otherwise false (returns false if the Instruction Operand Type is not <see cref="OperandType.InlineMethod"/>).</returns>
                public bool IsCallToProvidedMember(MemberInfo memberToCheck)
                {
                    if (code.OperandType == OperandType.InlineMethod)
                    {
                        try
                        {
                            return ((MemberInfo)operand).Equals(memberToCheck);
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

                /// <summary>
                /// Is this CIL Instruction calling the member? <br></br><br></br>
                /// This is the slower method, if you are looking for a quicker member see the alternative variant: <br></br>
                /// <see cref="IsCallToProvidedMember(MemberInfo)"/>
                /// </summary>
                /// <param name="memberToCheck">The member to try compare.</param>
                /// <param name="isConstructor">If the member checked was a constructor or otherwise.</param>
                /// <returns><see langword="boolean"/> - True if the MemberInfo objects match, otherwise false (returns false if the Instruction Operand Type is not <see cref="OperandType.InlineMethod"/>).</returns>
                public bool IsCallToProvidedMember(MemberInfo memberToCheck, out bool isConstructor)
                {
                    isConstructor = false;

                    if (code.OperandType == OperandType.InlineMethod)
                    {
                        try
                        {
                            return ((MethodInfo)operand).Equals(memberToCheck);
                        }
                        catch
                        {
                            try
                            {
                                isConstructor = ((ConstructorInfo)operand).Equals(memberToCheck);   // We can use isConstructor to return the result in this case and return that regardless of case.
                                return isConstructor;
                            }
                            catch
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

                /// <summary>
                /// Create the string for the first four numbers representing the operation code integer (or line?), padding with zeros when there are less than four characters.
                /// </summary>
                /// <returns></returns>
                private string GetOffset(long offset)
                {
                    string result = offset.ToString();

                    for (int i = 0; result.Length < 4; i++)
                    {
                        result = "0" + result;
                    }

                    return result;
                }
            }

            /// <summary>
            /// A translator for Common Intermediate Language. <br></br>
            /// <see langword="Cappuccino:"/> Used to determine whether or not to execute CappuccinoAttribute attributes attached to methods that are called by other methods.
            /// </summary>
            public class CILTranslator
            {
                /// <summary>
                /// A list of all the single-byte operation codes for Common Intermediate Language.
                /// </summary>
                public static OpCode[] singleByteOpCodes;

                /// <summary>
                /// A list of all the multiple-byte operation codes for Common Intermediate Language.
                /// </summary>
                public static OpCode[] multiByteOpCodes;

                /// <summary>
                /// Load the Operation Codes for the Common Intermediate Language into memory. <br></br>
                /// An exception will return if an operator code was found that was invalid.
                /// </summary>
                /// <exception cref="System.Exception"></exception>
                public static void LoadCILOperationCodes()
                {
                    // Create two OpCode arrays of 256 entries. (0x100 = 256 in hex)
                    singleByteOpCodes = new OpCode[0x100];
                    multiByteOpCodes = new OpCode[0x100];

                    // Create an array of FieldInfo
                    FieldInfo[] infoArray = typeof(OpCodes).GetFields();

                    // For all FieldInfo objects, translate them into
                    foreach (FieldInfo fi in infoArray)
                    {
                        // If the fieldinfo's field type is an OpCode
                        if (fi.FieldType == typeof(OpCode))
                        {
                            // Get the operation code. Null is the arguement type because it's a static field. Source: MSDN Docs - Reference 3.
                            OpCode code = (OpCode)fi.GetValue(null);

                            // Get the value of the code as an Int16/unsigned short value.
                            ushort number = (ushort)code.Value;

                            // if the value is less than 256 add it to the single byte opcodes array array.
                            if (number < 0x100)
                            {
                                singleByteOpCodes[(int)number] = code;
                            }
                            // otherwise, we assume it's over 256.
                            else
                            {
                                // [!] This is an assumption. It might be referring to LOGICAL AND, which i'm basing this off of.
                                //          I'm believing the sum of combining value A and value B must always be [0xfe00] or 65024.
                                //          [0xff00] is 65280 in decimal/int, so it's a difference of 256.
                                //          Assuming this, if the combination of these values *isn't* 65024, then it's an invalid operation code.
                                if ((number & 0xff00) != 0xfe00)
                                {
                                    throw new System.Exception("An Invalid Operation Code (OpCode) has been found.");
                                }

                                // This is assuming it's adding the operator code here at the bitwise operaiton result, based on the assumtion of last time.
                                // Could it be working backwards, going from 256-256 to 256 - 0?
                                multiByteOpCodes[number & 0xff] = code;
                            }
                        }
                    }
                }

                // Priavte methods
                #region Private Read Methods
                /// <summary>
                /// Get the following Int16 value in the bytes array.
                /// </summary>
                /// <param name="bytes">The bytes of code representing Common Intermediate Language.</param>
                /// <param name="position">The current position in the array.</param>
                /// <returns><see langword="integer"/></returns>
                private static int ToInt16(byte[] bytes, ref int position) 
                {
                    return (bytes[position++] | (bytes[position++] << 8));
                }

                /// <summary>
                /// Get the following Unsigned Int16 value in the bytes array.
                /// </summary>
                /// <param name="bytes">The bytes of code representing Common Intermediate Language.</param>
                /// <param name="position">The current position in the array.</param>
                /// <returns><see langword="unsigned short"/></returns>
                private static ushort ToUint16(byte[] bytes, ref int position)
                {
                    return (ushort)(bytes[position++] | (bytes[position++] << 8));
                }

                /// <summary>
                /// Get the following Int32 value in the bytes array.
                /// </summary>
                /// <param name="bytes">The bytes of code representing Common Intermediate Language.</param>
                /// <param name="position">The current position in the array.</param>
                /// <returns><see langword="integer"/></returns>
                private static int ToInt32(byte[] bytes, ref int position)
                {
                    return (((bytes[position++] | (bytes[position++] << 8)) | (bytes[position++] << 0x10)) | (bytes[position++] << 0x18));
                }

                /// <summary>
                /// Get the following Int64 value in the bytes array.
                /// </summary>
                /// <param name="bytes">The bytes of code representing Common Intermediate Language.</param>
                /// <param name="position">The current position in the array.</param>
                /// <returns><see langword="unsigned long"/></returns>
                private static ulong ToInt64(byte[] bytes, ref int position)
                {
                    return (ulong)(((bytes[position++] | (bytes[position++] << 8)) | (bytes[position++] << 0x10)) | (bytes[position++] << 0x18) | (bytes[position++] << 0x20) | (bytes[position++] << 0x28) | (bytes[position++] << 0x30) | (bytes[position++] << 0x38));
                }

                /// <summary>
                /// Get the following Double value in the bytes array.
                /// </summary>
                /// <param name="bytes">The bytes of code representing Common Intermediate Language.</param>
                /// <param name="position">The current position in the array.</param>
                /// <returns><see langword="double"/></returns>
                private static double ToDouble(byte[] bytes, ref int position)
                {
                    return (((bytes[position++] | (bytes[position++] << 8)) | (bytes[position++] << 0x10)) | (bytes[position++] << 0x18) | (bytes[position++] << 0x20) | (bytes[position++] << 0x28) | (bytes[position++] << 0x30) | (bytes[position++] << 0x38));
                }

                /// <summary>
                /// Get the following Double value in the bytes array.
                /// </summary>
                /// <param name="bytes">The bytes of code representing Common Intermediate Language.</param>
                /// <param name="position">The current position in the array.</param>
                /// <returns><see langword="signed byte"/></returns>
                private static sbyte ToSByte(byte[] bytes, ref int position)
                {
                    return (sbyte)bytes[position++];
                }

                /// <summary>
                /// Get the following Double value in the bytes array.
                /// </summary>
                /// <param name="bytes">The bytes of code representing Common Intermediate Language.</param>
                /// <param name="position">The current position in the array.</param>
                /// <returns><see langword="byte"/></returns>
                private static byte ToByte(byte[] bytes, ref int position)
                {
                    return bytes[position++];
                }

                private static Single ToSingle(byte[] bytes, ref int position)
                {
                    return (Single)(((bytes[position++] | (bytes[position++] << 8)) | (bytes[position++] << 0x10)) | (bytes[position++] << 0x18));
                }
                #endregion

                /// <summary>
                /// <see langword="Cappuccino:"/> Translate a Byte Array directly to Common Intermediate Language.
                /// </summary>
                /// <param name="method">The method to get the body of and convert into readable Common Intermediate Language instructions.</param>
                /// <returns></returns>
                public static List<CILInstruction> Translate(MethodInfo method, byte[] bytes)
                {
                    List<CILInstruction> translation = new List<CILInstruction>();

                    if (method == null)
                    {
                        Debug.Log("method is null");
                        return new List<CILInstruction>();
                    }

                    if (bytes == null)
                    {
                        Debug.Log("bytes are null");
                        return new List<CILInstruction>();
                    }

                    // Set our position to 0, this is so we can track where we are in the bytes array.
                    int position = 0;

                    // Fill the MSIL Instructions array with
                    while (position < bytes.Length)
                    {
                        CILInstruction instruction = new CILInstruction();    // Create an instruction.

                        OpCode opcode = OpCodes.Nop;    // Default Value - No Operation

                        ushort value = bytes[position++];
                        if (value != 0xfe)
                        {
                            opcode = singleByteOpCodes[(int)value];
                        }
                        else
                        {
                            value = bytes[position++];
                            opcode = multiByteOpCodes[(int)value];

                            // Bitwise LOGICAL OR Operator for the value.
                            value = (ushort)(value | 0xfe00);
                        }

                        instruction.code = opcode;              // Set the new instruction's operation code.
                        instruction.offset = position - 1;      // Set the new instruction's offset from the current position in the array.

                        int metadataToken = 0;

                        // Okay, I must admit this is where I found MSIL and this entire Bytes to MSIL interpreter ABSOLUTELY AMAZING.
                        // We're using the operation code that we've found in order to determine what the compiled "metadata token" (aka the system's own definition of our method, constructor, etc)
                        // and we're using it to determine the actual method/constructor/etc from that token under the hood. Like opening a car's hood/bonnet and finding all the IDs of the components under it!

                        // I heavily referenced the Microsoft API documentation just as much as Sorin Serban's work and it is something I've fallen in love with.

                        // What the object/data for the occuring operation set is.
                        switch (opcode.OperandType)
                        {
                            // Currently based on OperandType in the MSDN documentation - only InlinePhi could lead to this as it's reserved and not for widespread use.
                            default:
                                Debug.LogWarning("[BytesToMSIL] OpCode Operand is currently not supported");
                                break;

                            // The operation data is a 32-bit integer branch target
                            // This could be referring to a Branch Target Address, if a branch target is taken.
                            // Seeing an excerpt piece by David M. Harris and Sarah L. Harris (2013) gives me this possible explanation from the information below:
                            //      -   The branch target address (BTA) is the address of the next instruction to execute if the branch is taken.
                            case OperandType.InlineBrTarget:
                                metadataToken = ToInt32(bytes, ref position);
                                metadataToken += position;
                                instruction.operand = metadataToken;
                                break;

                            // The operation data is a 32-bit metadata token for a field
                            case OperandType.InlineField:
                                metadataToken = ToInt32(bytes, ref position);
                                instruction.operand = method.Module.ResolveField(metadataToken);
                                break;

                            // The operation data is a 32-bit metadata token for a method (or member)
                            case OperandType.InlineMethod:
                                metadataToken = ToInt32(bytes, ref position);

                                // try resolve the metadata token as a reference to a method.
                                try
                                {
                                    instruction.operand = method.Module.ResolveMethod(metadataToken);
                                }
                                // otherwise try resolve the metadata token as a reference to a member.
                                catch
                                {
                                    instruction.operand = method.Module.ResolveMember(metadataToken);
                                }
                                break;

                            // The operation data is a 32-bit metadata signature token.
                            case OperandType.InlineSig:
                                metadataToken = ToInt32(bytes, ref position);
                                instruction.operand = method.Module.ResolveSignature(metadataToken);
                                break;


                            // The operation data is a Type Reference? (Unclear - InlineTok is a [FieldRef], [MethodRef] or [TypeRef] according to docs but only ResolveType is attempted.)
                            case OperandType.InlineTok:
                                metadataToken = ToInt32(bytes, ref position);

                                // See if the token is a Type Reference;
                                try
                                {
                                    instruction.operand = method.Module.ResolveType(metadataToken);
                                }
                                // Do nothing, seems there is no follow up.
                                catch { }
                                break;

                            // The operation data is a 32-bit metadata token for a type(?) - Unclear.
                            // Note: Sorin comments that this part was contributed by Code Project as a missing feature - See (SDIL/SDILREADER/MethodBodyReader.cs - Line 128 to 131)
                            case OperandType.InlineType:
                                metadataToken = ToInt32(bytes, ref position);
                                instruction.operand = method.Module.ResolveType(metadataToken, method.DeclaringType.GetGenericArguments(), method.GetGenericArguments());
                                break;

                            // The operation is a 32 bit integer.
                            case OperandType.InlineI:
                                instruction.operand = ToInt32(bytes, ref position);
                                break;

                            // The operation data is a 64 bit integer.
                            // Personal comment: It's a bit funny that a 64 bit integer is marked as I8, which would be assumable as an 8-bit integer.
                            //                   There's probably a reason some machine-code and CIL enthsiasts can send my way though.
                            case OperandType.InlineI8:
                                instruction.operand = ToInt64(bytes, ref position);
                                break;

                            // No data defined for the current operation.
                            case OperandType.InlineNone:
                                instruction.operand = null;
                                break;

                            // The operation data is an IEEE 64-Bit floating point number.
                            //      - Likely referring to Institute of Electrical and Electronics Engineers.
                            case OperandType.InlineR:
                                instruction.operand = ToDouble(bytes, ref position);
                                break;

                            // The operation data is a metadata token for a string.
                            case OperandType.InlineString:
                                metadataToken = ToInt32(bytes, ref position);
                                instruction.operand = method.Module.ResolveString(metadataToken);
                                break;

                            // The operation data is a 32-bit integer arguement to a switch instruction (MSDN docs).
                            // This isn't used to create an instruction but I think this is done so that we skip past
                            // all the switch statements represented with each 32-bit integer and go straight to the
                            // next instruction(s) in memory not related to the switch statement in question.
                            case OperandType.InlineSwitch:
                                int count = ToInt32(bytes, ref position);

                                int[] casesAddresses = new int[count];

                                for (int i = 0; i < count; i++)
                                {
                                    casesAddresses[i] = ToInt32(bytes, ref position);
                                }

                                int[] cases = new int[count];

                                for(int i = 0; i < count; i++)
                                {
                                    cases[i] = position + casesAddresses[i];
                                }
                                break;
                            
                            // The operation data is a 16-bit integer containing the ordinal of a variable/arguement.
                            // The context of what ordinal is in this case is still unclear.
                            case OperandType.InlineVar:
                                instruction.operand = ToUint16(bytes, ref position);
                                break;

                            // The operation data is a 8-bit integer branch target
                            // Like InlineBrTarget could be referring to a Branch Target Address, if a branch target is taken.
                            case OperandType.ShortInlineBrTarget:
                                instruction.operand = ToSByte(bytes, ref position) + position;
                                break;

                            // The operation data is an 8-bit integer.
                            case OperandType.ShortInlineI:
                                instruction.operand = ToSByte(bytes, ref position);
                                break;

                            // The operation data is an IEEE 32-bit floating point number.
                            //      - Similar to InlineR, Likely referring to Institute of Electrical and Electronics Engineers.
                            case OperandType.ShortInlineR:
                                instruction.operand = ToSingle(bytes, ref position);
                                break;

                            // The operation data is a 8-bit integer containing the ordinal of a variable/arguement.
                            case OperandType.ShortInlineVar:
                                instruction.operand = ToByte(bytes, ref position);
                                break;
                        }

                        translation.Add(instruction);
                    }

                    return translation;
                }
            }
        }
    }
}