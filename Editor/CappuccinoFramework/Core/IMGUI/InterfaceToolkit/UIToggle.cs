using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This script builds "UI.Toggle" into Cappuccino.Core.UI. - entirely optional.

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> This static class is the User Interface Toolkit. It contains common UI drawing methods for Editors. <br></br>
        /// </summary>
        public static partial class UI
        {
            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Toggle UI Element for your Editor.
            /// </summary>
            /// <param name="value">The value of the current boolean.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            /// <returns><see langword="boolean"/></returns>
            public static bool Toggle(bool value, params GUILayoutOption[] options)
            {
                return EditorGUILayout.Toggle(value, options);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Toggle UI Element for your Editor.
            /// </summary>
            /// <param name="text">The text to display on the toggle label.</param>
            /// <param name="value">The value of the current boolean.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            /// <returns><see langword="boolean"/></returns>
            public static bool Toggle(string text, bool value, params GUILayoutOption[] options)
            {
                return EditorGUILayout.Toggle(text, value, options);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Toggle UI Element for your Editor.
            /// </summary>
            /// <param name="label">The GUIContent to use as the label.</param>
            /// <param name="value">The value of the current boolean.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            /// <returns><see langword="boolean"/></returns>
            public static bool Toggle(GUIContent label, bool value, params GUILayoutOption[] options)
            {
                return EditorGUILayout.Toggle(label, value, options);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Toggle UI Element for your Editor.
            /// </summary>
            /// <param name="value">The value of the current boolean.</param>
            /// <param name="style">The GUIStyle to draw with.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            /// <returns><see langword="boolean"/></returns>
            public static bool Toggle(bool value, GUIStyle style, params GUILayoutOption[] options)
            {
                return EditorGUILayout.Toggle(value, style, options);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Toggle UI Element for your Editor.
            /// </summary>
            /// <param name="text">The text to display on the toggle label.</param>
            /// <param name="value">The value of the current boolean.</param>
            /// <param name="style">The GUIStyle to draw with.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            /// <returns><see langword="boolean"/></returns>
            public static bool Toggle(string text, bool value, GUIStyle style, params GUILayoutOption[] options)
            {
                return EditorGUILayout.Toggle(text, value, style, options);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Toggle UI Element for your Editor.
            /// </summary>
            /// <param name="label">The GUIContent to use as the label.</param>
            /// <param name="value">The value of the current boolean.</param>
            /// <param name="style">The GUIStyle to draw with.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            /// <returns><see langword="boolean"/></returns>
            public static bool Toggle(GUIContent label, bool value, GUIStyle style, params GUILayoutOption[] options)
            {
                return EditorGUILayout.Toggle(label, value, style, options);
            }

            // ToggleLeft-inclusive methods.

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Toggle UI Element for your Editor.
            /// </summary>
            /// <param name="text">The text to display on the toggle label.</param>
            /// <param name="value">The value of the current boolean.</param>
            /// <param name="toggleLeft">Draw the toggle to the left side instead.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            /// <returns><see langword="boolean"/></returns>
            public static bool Toggle(string text, bool value, bool toggleLeft, params GUILayoutOption[] options)
            {
                if (toggleLeft)
                {
                    return EditorGUILayout.ToggleLeft(text, value, options);
                }
                else
                {
                    return EditorGUILayout.Toggle(text, value, options);
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Toggle UI Element for your Editor.
            /// </summary>
            /// <param name="label">The GUIContent to use as the label.</param>
            /// <param name="value">The value of the current boolean.</param>
            /// <param name="toggleLeft">Draw the toggle to the left side instead.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            /// <returns><see langword="boolean"/></returns>
            public static bool Toggle(GUIContent label, bool value, bool toggleLeft, params GUILayoutOption[] options)
            {
                if (toggleLeft)
                {
                    return EditorGUILayout.ToggleLeft(label, value, options);
                }
                else
                {
                    return EditorGUILayout.Toggle(label, value, options);
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Toggle UI Element for your Editor.
            /// </summary>
            /// <param name="text">The text to display on the toggle label.</param>
            /// <param name="value">The value of the current boolean.</param>
            /// <param name="toggleLeft">Draw the toggle to the left side instead.</param>
            /// <param name="style">The GUIStyle to draw with.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            /// <returns><see langword="boolean"/></returns>
            public static bool Toggle(string text, bool value, bool toggleLeft, GUIStyle style, params GUILayoutOption[] options)
            {
                if (toggleLeft)
                {
                    return EditorGUILayout.ToggleLeft(text, value, style, options);
                }
                else
                {
                    return EditorGUILayout.Toggle(text, value, style, options);
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Toggle UI Element for your Editor.
            /// </summary>
            /// <param name="label">The GUIContent to use as the label.</param>
            /// <param name="value">The value of the current boolean.</param>
            /// <param name="toggleLeft">Draw the toggle to the left side instead.</param>
            /// <param name="style">The GUIStyle to draw with.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            /// <returns><see langword="boolean"/></returns>
            public static bool Toggle(GUIContent label, bool value, bool toggleLeft, GUIStyle style, params GUILayoutOption[] options)
            {
                if (toggleLeft)
                {
                    return EditorGUILayout.ToggleLeft(label, value, style, options);
                }
                else
                {
                    return EditorGUILayout.Toggle(label, value, style, options);
                }
            }

            // Manual-Layout methods

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Toggle UI Element for your Editor.
            /// </summary>
            /// <param name="position">The position of the toggle.</param>
            /// <param name="value">The value of the current boolean.</param>
            /// <returns><see langword="boolean"/></returns>
            public static bool Toggle(Rect position, bool value)
            {
                return EditorGUI.Toggle(position, value);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Toggle UI Element for your Editor.
            /// </summary>
            /// <param name="position">The position of the toggle.</param>
            /// <param name="text">The text to display on the toggle label.</param>
            /// <param name="value">The value of the current boolean.</param>
            /// <returns><see langword="boolean"/></returns>
            public static bool Toggle(Rect position, string text, bool value)
            {
                return EditorGUI.Toggle(position, text, value);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Toggle UI Element for your Editor.
            /// </summary>
            /// <param name="position">The position of the toggle.</param>
            /// <param name="label">The GUIContent to use as the label.</param>
            /// <param name="value">The value of the current boolean.</param>
            /// <returns><see langword="boolean"/></returns>
            public static bool Toggle(Rect position, GUIContent label, bool value)
            {
                return EditorGUI.Toggle(position, label, value);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Toggle UI Element for your Editor.
            /// </summary>
            /// <param name="position">The position of the toggle.</param>
            /// <param name="value">The value of the current boolean.</param>
            /// <param name="style">The GUIStyle to draw with.</param>
            /// <returns><see langword="boolean"/></returns>
            public static bool Toggle(Rect position, bool value, GUIStyle style)
            {
                return EditorGUI.Toggle(position, value, style);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Toggle UI Element for your Editor.
            /// </summary>
            /// <param name="position">The position of the toggle.</param>
            /// <param name="text">The text to display on the toggle label.</param>
            /// <param name="value">The value of the current boolean.</param>
            /// <param name="style">The GUIStyle to draw with.</param>
            /// <returns><see langword="boolean"/></returns>
            public static bool Toggle(Rect position, string text, bool value, GUIStyle style)
            {
                return EditorGUI.Toggle(position, text, value, style);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Toggle UI Element for your Editor.
            /// </summary>
            /// <param name="position">The position of the toggle.</param>
            /// <param name="label">The GUIContent to use as the label.</param>
            /// <param name="value">The value of the current boolean.</param>
            /// <param name="style">The GUIStyle to draw with.</param>
            /// <returns><see langword="boolean"/></returns>
            public static bool Toggle(Rect position, GUIContent label, bool value, GUIStyle style)
            {
                return EditorGUI.Toggle(position, label, value, style);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Toggle UI Element for your Editor.
            /// </summary>
            /// <param name="position">The position of the toggle.</param>
            /// <param name="value">The value of the current boolean.</param>
            /// <param name="toggleLeft">Draw the toggle to the left side instead.</param>
            /// <returns><see langword="boolean"/></returns>
            public static bool Toggle(Rect position, bool value, bool toggleLeft)
            {
                if (toggleLeft)
                {
                    return EditorGUI.ToggleLeft(position, "",value);
                }
                else
                {
                    return EditorGUI.Toggle(position, value);
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Toggle UI Element for your Editor.
            /// </summary>
            /// <param name="position">The position of the toggle.</param>
            /// <param name="text">The text to display on the toggle label.</param>
            /// <param name="value">The value of the current boolean.</param>
            /// <param name="toggleLeft">Draw the toggle to the left side instead.</param>
            /// <returns><see langword="boolean"/></returns>
            public static bool Toggle(Rect position, string text, bool value, bool toggleLeft)
            {
                if (toggleLeft)
                {
                    return EditorGUI.ToggleLeft(position, text, value);
                }
                else
                {
                    return EditorGUI.Toggle(position, text, value);
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Toggle UI Element for your Editor.
            /// </summary>
            /// <param name="position">The position of the toggle.</param>
            /// <param name="label">The GUIContent to use as the label.</param>
            /// <param name="value">The value of the current boolean.</param>
            /// <param name="toggleLeft">Draw the toggle to the left side instead.</param>
            /// <returns><see langword="boolean"/></returns>
            public static bool Toggle(Rect position, GUIContent label, bool value, bool toggleLeft)
            {
                if (toggleLeft)
                {
                    return EditorGUI.ToggleLeft(position, label, value);
                }
                else
                {
                    return EditorGUI.Toggle(position, label, value);
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Toggle UI Element for your Editor.
            /// </summary>
            /// <param name="position">The position of the toggle.</param>
            /// <param name="value">The value of the current boolean.</param>
            /// <param name="style">The GUIStyle to draw with.</param>
            /// <param name="toggleLeft">Draw the toggle to the left side instead.</param>
            /// <returns><see langword="boolean"/></returns>
            public static bool Toggle(Rect position, bool value, bool toggleLeft, GUIStyle style)
            {
                if (toggleLeft)
                {
                    return EditorGUI.ToggleLeft(position, "", value, style);
                }
                else
                {
                    return EditorGUI.Toggle(position, value, style);
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Toggle UI Element for your Editor.
            /// </summary>
            /// <param name="position">The position of the toggle.</param>
            /// <param name="text">The text to display on the toggle label.</param>
            /// <param name="value">The value of the current boolean.</param>
            /// <param name="toggleLeft">Draw the toggle to the left side instead.</param>
            /// <param name="style">The GUIStyle to draw with.</param>
            /// <returns><see langword="boolean"/></returns>
            public static bool Toggle(Rect position, string text, bool value, bool toggleLeft, GUIStyle style)
            {
                if (toggleLeft)
                {
                    return EditorGUI.ToggleLeft(position, text, value, style);
                }
                else
                {
                    return EditorGUI.Toggle(position, text, value, style);
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Toggle UI Element for your Editor.
            /// </summary>
            /// <param name="position">The position of the toggle.</param>
            /// <param name="label">The GUIContent to use as the label.</param>
            /// <param name="value">The value of the current boolean.</param>
            /// <param name="toggleLeft">Draw the toggle to the left side instead.</param>
            /// <param name="style">The GUIStyle to draw with.</param>
            /// <returns><see langword="boolean"/></returns>
            public static bool Toggle(Rect position, GUIContent label, bool value, bool toggleLeft, GUIStyle style)
            {
                if (toggleLeft)
                {
                    return EditorGUI.ToggleLeft(position, label, value, style);
                }
                else
                {
                    return EditorGUI.Toggle(position, label, value, style);
                }
            }
        }
    }
}