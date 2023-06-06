using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

using System.Reflection;
using System.Reflection.Emit;
using System.Linq;

using Cappuccino.Interpreters.BytesToMSIL;
using Cappuccino.Interpreters;

// This script executes any (and all) Cappuccino Attributes.
// These attributes are used to denote any special notices for anything contained in Cappuccino.
// Because of the complex nature of doing this, I've commented everything extensively - otherwise I couldn't prove I did it.

// References I used to create and understand this:
//          -   https://learn.microsoft.com/en-US/dotnet/csharp/tutorials/attributes
//          -   https://stackoverflow.com/questions/3512679/how-to-find-all-occurrences-of-a-custom-attribute-in-assemblies
//          -   https://learn.microsoft.com/en-us/dotnet/api/system.reflection.assembly.gettypes?view=net-7.0
//          -   https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.selectmany?view=net-7.0
//          -   https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-7.0
//          -   https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.union?view=net-7.0
//          -   https://stackoverflow.com/questions/8699053/how-to-check-if-a-class-inherits-another-class-without-instantiating-it
//          -   https://learn.microsoft.com/en-us/dotnet/api/system.reflection.memberinfo?view=net-7.0
//          -   https://learn.microsoft.com/en-us/dotnet/api/system.reflection.methodinfo?view=net-7.0
//          -   https://learn.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/how-to-define-and-execute-dynamic-methods
//          -   https://learn.microsoft.com/en-us/dotnet/api/system.reflection.methodbody?view=net-8.0
//          -   https://learn.microsoft.com/en-us/dotnet/api/system.reflection.methodbody.getilasbytearray?view=net-8.0#system-reflection-methodbody-getilasbytearray
//          -   https://stackoverflow.com/a/3282407/19106689
//          -   https://learn.microsoft.com/en-us/dotnet/api/system.reflection.emit.opcodes.call?view=net-8.0
//          -   https://www.codeproject.com/Articles/14058/Parsing-the-IL-of-a-Method-Body
//          -   https://learn.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.methodimploptions?view=net-7.0

namespace Cappuccino
{
    namespace Attributes
    {
        /// <summary>
        /// A representation of an assembly method which has one (or more) CappuccinoAttribute. <br></br>
        /// Contains the member, the attribute(s) for execution and a MethodInfo list for all methods that call the member (if it is a method/constructor). <br></br><br></br>
        /// 
        /// <see langword="[internal]"/> This class is provided as a public class for transparency, however is only ever used for the <see cref="AttributeExecutor"/>. <br></br>
        /// <i>This is an internal class.</i>
        /// </summary>
        public class CappuccinoAttributeHolder
        {
            /// <summary>
            /// The member in the Assembly with this attribute.
            /// </summary>
            public MemberInfo member;

            /// <summary>
            /// The CappuccinoAttribute attributes attached to the member.
            /// </summary>
            public List<CappuccinoAttribute> attribs = new List<CappuccinoAttribute>();

            /// <summary>
            /// The method members in the project assembly calling this method.
            /// </summary>
            public List<MethodInfo> callerMethods = new List<MethodInfo>();

            public bool isAMethod = false;

            /// <summary>
            /// Create an AttributeUsageInfo object for a member and it's attached CappuccinoAttribute
            /// </summary>
            /// <param name="attachedMember">The member that has the attribute(s).</param>
            /// <param name="attributes">All the attributes to add to the AttributeUsageInfo object.</param>
            public CappuccinoAttributeHolder(MemberInfo attachedMember, params CappuccinoAttribute[] attributes)
            {
                member = attachedMember;

                foreach (CappuccinoAttribute atrb in attributes)
                {
                    attribs.Add(atrb);
                }
            }
        }

        public class AttributeExecutor 
        {
            // Modifiable Settings Variables

            /// <summary>
            /// Whether or not to execute any and all Cappuccino Attributes.
            /// </summary>
            public static bool doNotExecute = false;

            /// <summary>
            /// Whether or not to display any failed conversions from byte arrays to CIL conversions. <br></br><br></br>
            /// <see langword="Notice:"/> <i>Some conversions from .GetILAsByteArray() will fail regardless. This is due to UnityEngine's namespaces and some can't be filtered out.</i> <br></br>
            /// <b>Excluding Managed-flagged methods will not work like excluding Internal Call or Runtime. A majority of scripts are assigned the Managed method implementation flag.</b>
            /// </summary>
            public static bool displayFailedCILConverisons = false;

            /// <summary>
            /// Whether or not to announce any method calls found in the Common Intermediate Language conversion that matched a method with a CappuccinoAttribute.
            /// </summary>
            public static bool announceMethodMatches = false;

            /// <summary>
            /// Whether or not to display Log Errors instead of exceptions when an issue has occured with Cappuccino Attributes.
            /// </summary>
            public static bool replaceExceptionsWithLogErrors = false;

            /// <summary>
            /// The execution level for the Attribute Executor. <br></br>
            /// Whether you want only specific stages of attribute execution or none at all.
            /// </summary>
            public static AttributeExecutionLevel attributeExecutionLevel = AttributeExecutionLevel.Full;

            // Internal Information Variables

            /// <summary>
            /// Any namespaces that are blacklisted from being decompiled. <br></br><br></br>
            /// <b><see langword="Notice:"/></b> Members declared in UnityEngine and UnityEditor are not allowed to be decompiled for legal concerns.
            /// </summary>
            public static readonly string[] blacklistedNamespaces = new string[]
            {
                "UnityEngine",
                "UnityEditor"
            };

            /// <summary>
            /// Any method implementation flags that are blacklisted from being called.
            /// </summary>
            public static readonly MethodImplAttributes[] blacklistedAttributeFlags = new MethodImplAttributes[]
            {
                MethodImplAttributes.InternalCall
            };

            public static readonly string[] internalNamespaces = new string[]
            {
                "Cappuccino"
            };

            /// <summary>
            /// Execute all the attached Cappuccino Attributes. <br></br>
            /// Launches on runtime.
            /// </summary>
            [InitializeOnLoadMethod][CappuccinoInternalMethod]
            public static void ExecuteAllCappuccinoAttributes()
            {
                // If the developer wants to disable these attribute executions, they can.
                if (doNotExecute || attributeExecutionLevel is AttributeExecutionLevel.None) { return; }

                // Load all CIL Operation Codes
                CILTranslator.LoadCILOperationCodes();

                // Get the project assembly - incidentally tied to this class.
                Assembly asm = Assembly.GetAssembly(typeof(AttributeExecutor));

                // Get all the types in the assembly.
                System.Type[] containedTypes = asm.GetTypes();

                // Get an IEnumerable for all the members within the assembly's contained types.
                // The provided System.Func (type => type.GetMembers) returns the IEnumerable<MemberInfo>.
                IEnumerable<MemberInfo> baseMembers = containedTypes.SelectMany(type => type.GetMembers());

                // Get all the methods in the Project Assembly
                IEnumerable<MethodInfo> allMethods = containedTypes.SelectMany(type => type.GetMethods());

                // Get the IEnumerable combination of the members and the contained types in the namespace.
                //      [!] This is an assumption based on documentation and the nomenclature of all related members.
                IEnumerable<MemberInfo> unionedMembers = baseMembers.Union(containedTypes);

                // Get the IEnumerable of all members that have the provided attribute defined and repeat for any methods with the attribute defintiion.
                // The second is done because we want to be able to mark any member that is a method.
                //      [!] This is an assumption based on documentation and the intellisense info.
                IEnumerable<MemberInfo> assemblyMembers = unionedMembers.Where(type => System.Attribute.IsDefined(type, typeof(CappuccinoAttribute)));
                IEnumerable<MethodInfo> assemblyMethods = allMethods.Where(type => System.Attribute.IsDefined(type, typeof(CappuccinoAttribute)));

                // Create a list for all the Cappuccino Attribute Usage Info and go through all "simple" attributes first.
                // Execute Simple Attributes first.
                ExecuteSimpleAttributes(assemblyMembers, assemblyMethods, out List<CappuccinoAttributeHolder>  membersWithAttributes);

                // If we're at the full attribute execution level, execute all complex attributes.
                if (attributeExecutionLevel is AttributeExecutionLevel.Full)
                {
                    ExecuteComplexAttributes(allMethods, membersWithAttributes);
                }
            }

            /// <summary>
            /// Execute any attributes that require no insight to run or only require insight on the method they're attached to. <br></br>
            /// Special Attributes like DecompileToCIL are marked as methods for this.
            /// </summary>
            /// <param name="assemblyMembers"> All the members of the assembly that have a Cappuccino Attribute attached.</param>
            /// <param name="assemblyMethods"> All the <i>methods</i> of the assembly that have a Cappuccino Attribute attached.</param>
            /// <param name="attributeHolders"> The resulting list of all assembly member holders that have one (or more) Cappuccino Attributes.</param>
            [CappuccinoInternalMethod]
            public static void ExecuteSimpleAttributes(IEnumerable<MemberInfo> assemblyMembers, IEnumerable<MethodInfo> assemblyMethods, out List<CappuccinoAttributeHolder> attributeHolders)
            {
                attributeHolders = new List<CappuccinoAttributeHolder>();

                // For all members in the list of obtained members that have a Cappuccino Attribute:
                //      Get all the attributes in the the member
                //      Filter all provided attributes for attributes that are specifically CappuccinoAttributes class or an inheriting subclass.
                //      Add any members and CappuccinoAttributes to the lists of target attributes and of members with attributes.

                // Go through all members with a cappuccino attribute, creating an AttributeHolder object object that
                foreach (MemberInfo member in assemblyMembers)
                {
                    IEnumerable<System.Attribute> systemAttributes = member.GetCustomAttributes();
                    CappuccinoAttributeHolder createdInfo = null;

                    // Filter through the attributes again as methods may have multiple attributes including non-system attributes.
                    foreach (System.Attribute attrib in systemAttributes)
                    {
                        if (attrib.GetType().IsSubclassOf(typeof(CappuccinoAttribute)))
                        {
                            // if the attribute is marked as Do Not Call On Load, move to the next one.
                            if (((CappuccinoAttribute)attrib).doNotCallOnLoad)
                            {
                                continue;
                            }

                            // If there is no current CappuccinoAttributeUsageInfo object, create one with the current attribute.
                            // otherwise add this attribute (cast to CappuccinoAttribute) to the list.
                            if (createdInfo == null)
                            {
                                createdInfo = new CappuccinoAttributeHolder(member, (CappuccinoAttribute)attrib);
                            }
                            else
                            {
                                createdInfo.attribs.Add((CappuccinoAttribute)attrib);
                            }
                        }
                    }

                    if (createdInfo != null)
                    {
                        // See if this member is a method too. Moved from attributes loop.
                        foreach (MethodInfo mthd in assemblyMethods)
                        {
                            createdInfo.isAMethod = mthd.Equals(member);
                            if (createdInfo.isAMethod) { break; } // If a match has been found, break;
                        }

                        attributeHolders.Add(createdInfo);
                    }
                }

                List<CappuccinoAttributeHolder> triggeredAttribHolders = new List<CappuccinoAttributeHolder>();

                // Execute any Cappuccino Attributes that do not need CIL Caller insight 
                foreach (CappuccinoAttributeHolder attribHolder in attributeHolders)
                {
                    foreach (CappuccinoAttribute capAttrib in attribHolder.attribs)
                    {
                        if (capAttrib.needsCILCallerInsight)
                        {
                            continue;
                        }

                        try
                        {
                            // Execute() is the default.
                            if (capAttrib.insightLevel is InsightRequirement.SelfAndCallerMethods || capAttrib.insightLevel is InsightRequirement.SelfAndCallerMembers)
                            {
                                Debug.LogError($"The custom attribute \"{nameof(capAttrib)}\" has an incorrect insight level. \nIt is asking for insight into itself and it's caller but is not marked as needing CIL caller insight. \n If your attribute needs both self and caller insight, set needsCILCallerInsight to true in the constructor(s). Otherwise set insightLevel to a lower value in the constructor(s).");
                            }
                            else if (capAttrib.insightLevel is InsightRequirement.Method)
                            {
                                if (attribHolder.isAMethod)
                                {
                                    capAttrib.Execute((MethodInfo)attribHolder.member);
                                }
                            }
                            else if (capAttrib.insightLevel is InsightRequirement.Member)
                            {
                                capAttrib.Execute(attribHolder.member);
                            }
                            else
                            {
                                capAttrib.Execute();
                            }

                            // Cache all attribute holders that were triggered
                            triggeredAttribHolders.Add(attribHolder);
                        }
                        catch { }
                    }
                }

                // Remove any triggered attributes holder from the main list.
                foreach (CappuccinoAttributeHolder triggered in triggeredAttribHolders)
                {
                    if (!attributeHolders.Contains(triggered)) { continue; } // skip any not contained in the attribute holders list.
                    attributeHolders.Remove(triggered); // otherwise, remove the attribute holder.
                }
            }

            /// <summary>
            /// Execute any attributes that require insight of any method assemblies calling the attribute holders.
            /// </summary>
            /// <param name="allMethods"> All the methods within the assembly that we are filtering through to see if they contain method calls.</param>
            /// <param name="membersWithAttributes">The list of the members with cappuccino attributes.</param>
            [CappuccinoInternalMethod]
            public static void ExecuteComplexAttributes(IEnumerable<MethodInfo> allMethods, List<CappuccinoAttributeHolder> membersWithAttributes)
            {
                // For all the methods in the assembly:
                foreach (MethodInfo method in allMethods)
                {
                    // If any namespace is blacklisted from decompilation, skip it.
                    if (!IsAllowed(method))
                    {
                        continue;
                    }

                    // Try to get the method body, convert it into a Byte Array (compiled CIL) then Translate the byte-arraty to a list of human-readable CIL instructions 
                    // For each instruction in that method body, try find a match to a method or constructor that has a Cappuccino Attribute attached to it.
                    try
                    {
                        MethodBody mbod = method.GetMethodBody();
                        List<CILInstruction> instructions = CILTranslator.Translate(method, mbod.GetILAsByteArray());

                        // For every instruction, try find if any MemberInfo representation of a call to a Method or Constructor matches with the MemberInfo in any of the attribute holders.
                        // If the instruction attributeholder's callermethods list doesn't already contain this caller method, add it, otherwise break and go to the next instruction. 
                        foreach (CILInstruction instruction in instructions)
                        {
                            foreach (CappuccinoAttributeHolder attribHolder in membersWithAttributes)
                            {
                                if (instruction.IsCallToProvidedMember(attribHolder.member))
                                {
                                    attribHolder.callerMethods.Add(method);
                                    break;
                                }
                            }
                        }
                    }
                    // Some method calls are going to inevitably fail. Part of this is to do with any experimental packages a project uses or similar.
                    catch (System.Exception e)
                    {
                        if (displayFailedCILConverisons)
                        {
                            Debug.Log(method.Name + " -> Method Implementation Flags: " + method.MethodImplementationFlags.ToString());
                            Debug.LogWarning($"CIL decompilation failed.\nMethod being decompiled: {method.Name}\n Reason: {e.Message}");
                        }
                    }
                }

                // Execute all attributes with the relavent information they requested.
                foreach (CappuccinoAttributeHolder cAttribHolder in membersWithAttributes)
                {
                    foreach (CappuccinoAttribute cAttrib in cAttribHolder.attribs)
                    {
                        try
                        {
                            if (cAttrib.insightLevel is InsightRequirement.SelfAndCallerMethods)
                            {
                                if (cAttribHolder.isAMethod)
                                {
                                    foreach (MethodInfo method in cAttribHolder.callerMethods)
                                    {
                                        cAttrib.Execute((MethodInfo)cAttribHolder.member, method);
                                    }
                                }
                                else
                                {
                                    Debug.LogError($"\"[Cappuccino Internal]: \"{cAttrib.GetType()}\" is not able to be executed as it has been attached to a member that is incompatible: {cAttribHolder.member.DeclaringType}.{cAttribHolder.member.Name}");
                                }
                            }
                            else if (cAttrib.insightLevel is InsightRequirement.SelfAndCallerMembers)
                            {
                                foreach (MethodInfo method in cAttribHolder.callerMethods)
                                {
                                    cAttrib.Execute(cAttribHolder.member, method);
                                }
                            }
                            else if (cAttrib.insightLevel is InsightRequirement.Method)
                            {
                                if (cAttribHolder.isAMethod)
                                {
                                    foreach (MethodInfo method in cAttribHolder.callerMethods)
                                    {
                                        cAttrib.Execute(method);
                                    }
                                }
                                else
                                {
                                    Debug.LogError($"\"[Cappuccino Internal]: \"{cAttrib.GetType()}\" is not able to be executed as it has been attached to a member that is incompatible: {cAttribHolder.member.DeclaringType}.{cAttribHolder.member.Name}");
                                }
                            }
                            else if (cAttrib.insightLevel is InsightRequirement.Member)
                            {
                                foreach (MethodInfo method in cAttribHolder.callerMethods)
                                {
                                    cAttrib.Execute(((MemberInfo)method));
                                }
                            }
                            else
                            {
                                cAttrib.Execute();
                            }
                        }
                        catch {  }
                    }
                }
            }

            #region MethodInfo Checking Methods
            /// <summary>
            /// Whether or not the current method is decompilable safely. <br></br>
            /// Combines checks to IsAllowedNamespace and HasNoBlacklistedAttributeFlags.
            /// </summary>
            /// <param name="method"></param>
            /// <returns><see langword="boolean"/> - True if allowed, false if otherwise.</returns>
            public static bool IsAllowed(MethodInfo method) => (IsAllowedNamespace(method.DeclaringType) && HasNoBlacklistedAttributeFlags(method));

            /// <summary>
            /// Does the method's declaring type contain 
            /// </summary>
            /// <param name="methodDeclaringType"></param>
            /// <returns><see langword="boolean"/> - True if the namespace of the method is valid.</returns>
            public static bool IsAllowedNamespace(System.Type methodDeclaringType)
            { 
                // Declaring type is null, return false to prevent an error and to force the method to be skipped.
                if (methodDeclaringType == null)
                {
                    return false;
                }

                string declAsString = methodDeclaringType.ToString();

                // if the method's declaring type starts wtih a blacklisted namespace, return false.
                // We use .StartsWith because it allows us to filter any namespaces regardless of suffixes (Internal, etc).
                foreach (string _namespace in blacklistedNamespaces)
                {
                    if (declAsString.StartsWith(_namespace))
                    {
                        return false;
                    }
                }

                // otherwise, no matches have been found and we can continue to execute.
                return true;
            }

            /// <summary>
            /// Does the provided MethodInfo contain any blacklisted flags?
            /// </summary>
            /// <param name="method">The MethodInfo to query.</param>
            /// <returns><see langword="boolean"/> - True if the method has no blacklisted MethodImplAttributes.</returns>
            public static bool HasNoBlacklistedAttributeFlags(MethodInfo method)
            {
                // Declaring type is null, return false to prevent an error and to force the method to be skipped.
                if (method == null)
                {
                    return false;
                }

                // if the method's declaring type starts wtih a blacklisted namespace, return false.
                foreach (MethodImplAttributes methodImplAttrib in blacklistedAttributeFlags)
                {
                    if (method.MethodImplementationFlags.HasFlag(methodImplAttrib))
                    {
                        return false;
                    }
                }

                // otherwise, no matches have been found and we can continue to execute.
                return true;
            }
            #endregion

            #region Announcement Methods
            // These methods are used to announce when a "match" between two different methods have been successfully found between a MethodInfo found in the Common Intermediate Language
            // and a MethodInfo object generated from the direct Method Definition in the assembly.

            /// <summary>
            /// Announce that a call to a method has been found.
            /// </summary>
            /// <param name="MethodInLine">The MemberInfo extrapolated from the CIL instruction.</param>
            /// <param name="MethodDefinition">The MemberInfo representation of the method declaration.</param>
            /// <param name="Caller">The calling method where the line has been found.</param>
            [CappuccinoInternalMethod]
            private static void MethodMatch(MemberInfo MethodInLine, MemberInfo MethodDefinition, MemberInfo Caller)
            {
                Debug.Log($"Matching Methods:\n     A: {MethodInLine}" +
                    $"\n          Called From: {Caller}" +
                    $"\n     B: {MethodDefinition}" +
                    $"\n          Defined In: {MethodDefinition.DeclaringType.FullName}");
            }

            /// <summary>
            /// Announce that a call to a constructor has been found.
            /// </summary>
            /// <param name="ConstructorInLine">The MemberInfo extrapolated from the CIL instruction.</param>
            /// <param name="ConstructorDefinition">The MemberInfo representation of the method declaration.</param>
            /// <param name="Caller">The calling method where the line has been found.</param>
            [CappuccinoInternalMethod]
            private static void ConstructorMatch(MemberInfo ConstructorInLine, MemberInfo ConstructorDefinition, MemberInfo Caller)
            {
                Debug.Log($"Matching Constructors:\n     A: {ConstructorInLine}" +
                    $"\n          Called From: {Caller}" +
                    $"\n     B: {ConstructorDefinition}" +
                    $"\n          Defined In: {ConstructorDefinition.DeclaringType.FullName}");
            }

            #endregion
        }
    }
}