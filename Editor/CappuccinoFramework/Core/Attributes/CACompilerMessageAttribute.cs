using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;
using System.Reflection;

// This script adds the [CompilerMessage] attribute for any method.

namespace Cappuccino
{
    namespace Attributes
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> An attribute that is assigned to display a custom message in Unity's Console when Unity loads and when scripts are compiled. <br></br><br></br>
        /// <b><see langword="Notice:"/></b> This attribute is triggered through <i><see cref="AttributeExecutor"/></i>
        /// </summary>
        [System.AttributeUsage(System.AttributeTargets.All, AllowMultiple = true)]
        public class CompilerMessageAttribute : CappuccinoAttribute
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
            /// Display the message attached to this attribute instance.
            /// </summary>
            public override void Execute()
            {
                switch (state)
                {
                    default:
                        break;

                    case CompilerLoggingStates.Log:
                        Debug.Log($"[Cappuccino]: {message}\n");
                        break;

                    case CompilerLoggingStates.Warn:
                        Debug.LogWarning($"[Cappuccino]: {message}\n");
                        break;

                    case CompilerLoggingStates.Error:
                        Debug.LogError($"[Cappuccino]: {message}\n");
                        break;
                }
            }

            /// <summary>
            /// Create a Cappuccino Message Attribute. Displays a message.
            /// </summary>
            /// <param name="loggingState"></param>
            /// <param name="displayMessage"></param>
            public CompilerMessageAttribute(string displayMessage)
            {
                state = CompilerLoggingStates.Log;
                message = displayMessage;

                insightLevel = InsightRequirement.None;
            }

            /// <summary>
            /// Create a Cappuccino Message Attribute. Displays a message.
            /// </summary>
            /// <param name="loggingState"></param>
            /// <param name="displayMessage"></param>
            public CompilerMessageAttribute(CompilerLoggingStates loggingState, string displayMessage)
            {
                state = loggingState;
                message = displayMessage;

                insightLevel = InsightRequirement.None;
            }
        }
    }
}