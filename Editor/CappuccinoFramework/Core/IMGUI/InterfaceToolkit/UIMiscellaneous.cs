using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This script contains redirects to GUI & EditorGUI properties 
// Examples: GUI.enabled, EditorGUI.indentLevel;

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> This static class is the User Interface Toolkit. It contains common UI drawing methods for Editors. <br></br>
        /// <see langword="Unity:"/> Redirect to: GUI.enabled.
        /// </summary>
        public static partial class UI
        {
            /// <summary>
            /// <see langword="Cappuccino:"/> Enable or Disable the input controls for the following UI Element(s).
            /// </summary>
            public static bool enabled
            {
                get { return GUI.enabled; }
                set { GUI.enabled = value; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Increase (or decrease) the indent level of the following UI Element(s). <br></br><br></br>
            /// <see langword="Unity:"/> Redirect to: EditorGUI.IndentLevel.
            /// </summary>
            public static int indent
            {
                get { return EditorGUI.indentLevel; }
                set { EditorGUI.indentLevel = value; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a space between two UI Elements. <br></br><br></br>
            /// </summary>
            public static void Space()
            {
                EditorGUILayout.Space();
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a space between two UI Elements. <br></br><br></br>
            /// </summary>
            /// <param name="pixels">The amount of pixels to create a gap between the last UI Element and the next.</param>
            public static void Space(float pixels)
            {
                GUILayout.Space(pixels);
            }
        }
    }
}