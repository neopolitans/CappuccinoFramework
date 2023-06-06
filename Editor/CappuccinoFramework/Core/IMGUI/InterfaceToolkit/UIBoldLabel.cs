using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This script builds "UI.BoldLabel" into Cappuccino.Core.UI.
// Makes creating a bold label quicker, not comaptible with GUIStyle as it uses UnityEngine's built-in Bold Label style.

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
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="text">The text to display.</param>
            public static void BoldLabel(string text)
            {
                EditorGUILayout.LabelField(text, EditorStyles.boldLabel);
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="image">The Texture to display.</param>
            public static void BoldLabel(Texture image)
            {
                EditorGUILayout.LabelField(new GUIContent(image), EditorStyles.boldLabel);
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="content">The GUIContent to display.</param>
            public static void BoldLabel(GUIContent content)
            {
                EditorGUILayout.LabelField(content, EditorStyles.boldLabel);
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="text">The text to display.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            public static void BoldLabel(string text, params GUILayoutOption[] options)
            {
                EditorGUILayout.LabelField(text, EditorStyles.boldLabel, options);
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="image">The Texture to display.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            public static void BoldLabel(Texture image, params GUILayoutOption[] options)
            {
                EditorGUILayout.LabelField(new GUIContent(image), EditorStyles.boldLabel, options);
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="content">The GUIContent to display.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            public static void BoldLabel(GUIContent content, params GUILayoutOption[] options)
            {
                EditorGUILayout.LabelField(content, EditorStyles.boldLabel, options);
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="position">The position to place the Label in the Editor Window.</param>
            /// <param name="text">The text to display.</param>
            public static void BoldLabel(Rect position, string text)
            {
                EditorGUI.LabelField(position, text, EditorStyles.boldLabel);
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="position">The position to place the Label in the Editor Window.</param>
            /// <param name="image">The Texture to display.</param>
            public static void BoldLabel(Rect position, Texture image)
            {
                EditorGUI.LabelField(position, new GUIContent(image), EditorStyles.boldLabel);
            }

            /// <summary>
            /// Draw a Label in the editor.
            /// </summary>
            /// <param name="position">The position to place the Label in the Editor Window.</param>
            /// <param name="content">The GUIContent to display.</param>
            public static void BoldLabel(Rect position, GUIContent content)
            {
                EditorGUI.LabelField(position, content, EditorStyles.boldLabel);
            }

        }
    }
}