using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This script builds "UI.Label" into Cappuccino.Core.UI.
// EditorGUI and EditorGUILayout methods are combined here for ease of use and quicker changes.

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> This static class is the User Interface Toolkit. It contains common UI drawing methods for Editors. <br></br>
        /// </summary>
        public static partial class UI
        {
            // Auto-layout

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="text">The text to display.</param>
            public static void Label(string text)
            {
                EditorGUILayout.LabelField(text);
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="image">The Texture to display.</param>
            public static void Label(Texture image)
            {
                EditorGUILayout.LabelField(new GUIContent(image));
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="label">The GUIContent to display.</param>
            public static void Label(GUIContent label)
            {
                EditorGUILayout.LabelField(label);
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="text">The text to display.</param>
            /// <param name="style">The GUIStyle to use.</param>
            public static void Label(string text, GUIStyle style)
            {
                EditorGUILayout.LabelField(text, style);
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="image">The Texture to display.</param>
            /// <param name="style">The GUIStyle to use.</param>
            public static void Label(Texture image, GUIStyle style)
            {
                EditorGUILayout.LabelField(new GUIContent(image), style);
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="label">The GUIContent to display.</param>
            /// <param name="style">The GUIStyle to use.</param>
            public static void Label(GUIContent label, GUIStyle style)
            {
                EditorGUILayout.LabelField(label, style);
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="text">The text to display.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            public static void Label(string text, params GUILayoutOption[] options)
            {
                EditorGUILayout.LabelField(text, options);
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="image">The Texture to display.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            public static void Label(Texture image, params GUILayoutOption[] options)
            {
                EditorGUILayout.LabelField(new GUIContent(image), options);
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="label">The GUIContent to display.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            public static void Label(GUIContent label, params GUILayoutOption[] options)
            {
                EditorGUILayout.LabelField(label, options);
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="text">The text to display.</param>
            /// <param name="style">The GUIStyle to use.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            public static void Label(string text, GUIStyle style, params GUILayoutOption[] options)
            {
                EditorGUILayout.LabelField(text, style, options);
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="image">The Texture to display.</param>
            /// <param name="style">The GUIStyle to use.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            public static void Label(Texture image, GUIStyle style, params GUILayoutOption[] options)
            {
                EditorGUILayout.LabelField(new GUIContent(image), style, options);
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="label">The GUIContent to display.</param>
            /// <param name="style">The GUIStyle to use.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            public static void Label(GUIContent label, GUIStyle style, params GUILayoutOption[] options)
            {
                EditorGUILayout.LabelField(label, style, options);
            }

            // Manual Layout

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="position">The position to place the Label in the Editor Window.</param>
            /// <param name="text">The text to display.</param>
            public static void Label(Rect position, string text)
            {
                EditorGUI.LabelField(position, text);
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="position">The position to place the Label in the Editor Window.</param>
            /// <param name="image">The Texture to display.</param>
            public static void Label(Rect position, Texture image)
            {
                EditorGUI.LabelField(position, new GUIContent(image));
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="position">The position to place the Label in the Editor Window.</param>
            /// <param name="label">The GUIContent to display.</param>
            public static void Label(Rect position, GUIContent label)
            {
                EditorGUI.LabelField(position, label);
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="position">The position to place the Label in the Editor Window.</param>
            /// <param name="text">The text to display.</param>
            /// <param name="style">The GUIStyle to use.</param>
            public static void Label(Rect position, string text, GUIStyle style)
            {
                EditorGUI.LabelField(position, text, style);
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="position">The position to place the Label in the Editor Window.</param>
            /// <param name="image">The Texture to display.</param>
            /// <param name="style">The GUIStyle to use.</param>
            public static void Label(Rect position, Texture image, GUIStyle style)
            {
                EditorGUI.LabelField(position, new GUIContent(image), style);
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="position">The position to place the Label in the Editor Window.</param>
            /// <param name="label">The GUIContent to display.</param>
            /// <param name="style">The GUIStyle to use.</param>
            public static void Label(Rect position, GUIContent label, GUIStyle style)
            {
                EditorGUI.LabelField(position, label, style);
            }
        }
    }
}