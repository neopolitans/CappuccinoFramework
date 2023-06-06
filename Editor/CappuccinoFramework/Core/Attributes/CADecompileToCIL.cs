using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

using System;
using System.Reflection;

using Cappuccino.Interpreters;
using Cappuccino.Interpreters.BytesToMSIL;
using Cappuccino.Core;


// This script adds the DecompileToCIL (Common Intermediate Language) Attribute.
// It allows the user to decompile the attached method into a Common Intermediate Language script.

namespace Cappuccino
{
    namespace Attributes
    {
        /// <summary>
        /// An Attribute that allows you to decompile any method or constructor to Common Intermediate Language at the specified directory. <br></br>
        /// <b><see langword="Notice:"/></b> Can only be attached to Constructors and Methods. They are the only known suitable decompilations.
        /// </summary>
        [System.AttributeUsage(System.AttributeTargets.Constructor | System.AttributeTargets.Method, AllowMultiple = true)]
        public class DecompileToCILAttribute : CappuccinoAttribute
        {
            /// <summary>
            /// The path to ssave the decompiled Common Intermediate Language file to.
            /// </summary>
            public readonly string decompilationPath;

            public override void Execute(MethodInfo method)
            {
                // Prevent illegal decompilations of UnityEngine and UnityEditor (includes Internal namespaces by default due to StartsWith method operations).
                if (AttributeExecutor.IsAllowed(method))
                {
                    string fileName = $"{method.ReturnType.ToString().Replace('.', '-')}_{method.DeclaringType.ToString().Replace('.', '-')}_{method.Name}";    // Format the fileName into something recognizable.

                    // Try to get the method body, convert it into Common Immediate Language (as Byte Array)
                    // Translate the byte-arraty to a list of human-readable CIL instructions 
                    // For each instruction in that method body, try find a match to a method or constructor that has a Cappuccino Attribute attached to it.
                    try
                    {
                        MethodBody mbod = method.GetMethodBody();
                        List<CILInstruction> instructions = CILTranslator.Translate(method, mbod.GetILAsByteArray());
                        List<string> humanReadableInstructions = new List<string>();

                        // Add all instructions to the humanReadableInstructions string.
                        foreach (CILInstruction instruction in instructions)
                        {
                            humanReadableInstructions.Add(instruction.ToString());
                        }

                        FileHandler.ToText(humanReadableInstructions, fileName, decompilationPath, true);
                    }
                    catch
                    {
                        Debug.LogWarning($"Method Decompilation to CIL of file failed.\nMethod: {fileName}");
                    }
                }
                else
                {
                    Debug.LogError("This method is not allowed to be decompiled into Common Intermediate Language. \nAny attempt to decompile methods in the UnityEngine or UnityEditor namespace is blocked. \nAny methods with the InternalCall flag will fail due to compiler restrictions.");
                }
            }

            /// <summary>
            /// Decompile the attached method and write the contents to the provided file path.
            /// </summary>
            /// <param name="filePath">The path to save the file into.</param>
            public DecompileToCILAttribute(string filePath)
            {
                needsCILCallerInsight = true;
                decompilationPath = filePath;
                insightLevel = InsightRequirement.Method;
            }
        }

    }
}