using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;
using System.Reflection;

// This script adds the [CompilerMessage] attribute for any method.
// This method

namespace Cappuccino
{
    namespace Attributes
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> An attribute that is assigned to display a custom message in Unity's Console when Unity loads and when scripts are compiled. <br></br><br></br>
        /// <b><see langword="Notice:"/></b> This attribute is triggered through <i><see cref="AttributeExecutor"/></i>
        /// </summary>
        [System.AttributeUsage(System.AttributeTargets.Method | System.AttributeTargets.Constructor, AllowMultiple = true)]
        public class MethodUsageAlertAttribute : CappuccinoAttribute
        {
            /// <summary>
            /// What is the current state for this Cappuccino Attribute?
            /// </summary>
            protected CompilerLoggingStates state = CompilerLoggingStates.None;

            /// <summary>
            /// The message to display with this attribute instance.
            /// </summary>
            protected string message;

            /// <summary>
            /// Display the message attached to this attribute instance, referenicng the method that called it.
            /// </summary>
            public override void Execute(MethodInfo attachedMethod)
            {
                switch (state)
                {
                    default:
                        break;

                    case CompilerLoggingStates.Log:
                        Debug.Log($"[Cappuccino]: {message}\nCalled In: {attachedMethod.DeclaringType.FullName}.{attachedMethod.Name}()\n");
                        break;

                    case CompilerLoggingStates.Warn:
                        Debug.LogWarning($"[Cappuccino]: {message}\nCalled In: {attachedMethod.DeclaringType.FullName}.{attachedMethod.Name}()\n");
                        break;

                    case CompilerLoggingStates.Error:
                        Debug.LogError($"[Cappuccino]: {message}\nCalled In: {attachedMethod.DeclaringType.FullName}.{attachedMethod.Name}()\n");
                        break;
                }
            }

            /// <summary>
            /// Create a Cappuccino Message Attribute. Displays a message.
            /// </summary>
            /// <param name="loggingState"></param>
            /// <param name="displayMessage"></param>
            public MethodUsageAlertAttribute(string displayMessage)
            {
                state = CompilerLoggingStates.Warn;
                message = displayMessage;

                needsCILCallerInsight = true;
                insightLevel = InsightRequirement.Method;
            }

            /// <summary>
            /// Create a Cappuccino Message Attribute. Displays a message.
            /// </summary>
            /// <param name="loggingState"></param>
            /// <param name="displayMessage"></param>
            public MethodUsageAlertAttribute(CompilerLoggingStates loggingState, string displayMessage)
            {
                state = loggingState;
                message = displayMessage;

                needsCILCallerInsight = true;
                insightLevel = InsightRequirement.Method;
            }
        }
    }
}