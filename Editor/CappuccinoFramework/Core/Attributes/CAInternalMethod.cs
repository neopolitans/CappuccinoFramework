using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

using System;
using System.Reflection;

// This script contains the [CappuccinoInternalMethod] attribute.
// Used to mark any methods that are strictly used internally to assist with Cappuccino.
// This is used sparingly and only with explicit necessity. Anything is still modifiable through the source scripts.

// !! You can remove this attribute entirely from what it is attached to if it is hindering your production pipeline. !!

namespace Cappuccino
{
    namespace Attributes
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> This attribute denotes any internal method or constructor that should only be used by Cappuccino. <br></br> 
        /// If there is a case where you need to be able to access the attached method/constructor externally, remove this attribute.
        /// </summary>
        [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor)]
        public class CappuccinoInternalMethodAttribute : CappuccinoAttribute        
        {
            private readonly bool checkGenericInternalNamespaces = false;

            /// <summary>
            /// Execute any code related to the attribute, passing in the method attached to this attribute and the method calling the attached method. <br></br><br></br>
            /// <b><see langword="Notice:"/></b> A CappuccinoInternalException will throw if the method is an internal method being called from outside it's own namespace.
            /// </summary>
            /// <param name="self">The method attached to this attribute instance.</param>
            /// <param name="caller">The method that called the attached method.</param>
            /// <exception cref="AttributeNotExecutableException"/> 
            public override void Execute(MethodInfo self, MethodInfo caller)
            {
                if (self.DeclaringType.Namespace != caller.DeclaringType.Namespace)
                {
                    if (checkGenericInternalNamespaces)
                    {
                        bool matchedWithGIN = false;

                        foreach (string _namespace in AttributeExecutor.internalNamespaces)
                        {
                            matchedWithGIN = self.DeclaringType.ToString().StartsWith(_namespace) && caller.DeclaringType.ToString().StartsWith(_namespace);
                            if (matchedWithGIN) { break; }
                        }

                        if (!matchedWithGIN)
                        {
                            Debug.LogError($"The method you have tried to use \"{self.DeclaringType}.{self.Name}\" from \"{caller.DeclaringType}.{caller.Name}\" is an internal only method. This restriction is applied to prevent project corruption or other egregious errors.");
                        }
                    }
                    else
                    {
                        Debug.LogError($"The method you have tried to use \"{self.DeclaringType}.{self.Name}\" from \"{caller.DeclaringType}.{caller.Name}\" is an internal only method. This restriction is applied to prevent project corruption or other egregious errors.");

                    }
                }
            }

            public CappuccinoInternalMethodAttribute()
            {
                needsCILCallerInsight = true;
                insightLevel = InsightRequirement.SelfAndCallerMethods;
            }

            /// <summary>
            /// Create an instance of the [Cappuccino Internal Method] attribute.
            /// </summary>
            /// <param name="allowGenericInternalNamespaces">Whether or not to allow known generic internal namespaces to access the attached method/constructor.</param>
            public CappuccinoInternalMethodAttribute(bool allowGenericInternalNamespaces)
            {
                needsCILCallerInsight = true;
                insightLevel = InsightRequirement.SelfAndCallerMethods;

                checkGenericInternalNamespaces = allowGenericInternalNamespaces;
            }
        }
    }
}