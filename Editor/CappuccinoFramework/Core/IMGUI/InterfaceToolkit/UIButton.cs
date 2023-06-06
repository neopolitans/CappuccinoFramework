using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

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
            /// <see langword="Cappuccino:"/> Draw a Text Button. <br></br><br></br>
            /// <see langword="Unity:"/> This method is a simple wrapper for <i>GUILayout.Button</i>.
            /// </summary>
            /// <param name="text">The text that will display on the button.</param>
            public static bool Button(string text)
            {
                return GUILayout.Button(text);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw an Image Button. <br></br><br></br>
            /// <see langword="Unity:"/> This method is a simple wrapper for <i>GUILayout.Button</i>.
            /// </summary>
            /// <param name="image">The image that will display on the button.</param>
            public static bool Button(Texture image)
            {
                return GUILayout.Button(image);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a button which is represented by a label. <br></br><br></br>
            /// <see langword="Unity:"/> This method is a simple wrapper for <i>GUILayout.Button</i>.
            /// </summary>
            /// <param name="label">The GUIContent that will display on the button.</param>
            public static bool Button(GUIContent label)
            {
                return GUILayout.Button(label);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a Text Button. <br></br><br></br>
            /// <see langword="Unity:"/> This method is a simple wrapper for <i>GUILayout.Button</i>.
            /// </summary>
            /// <param name="text">The text that will display on the button.</param>
            /// <param name="style">The GUIStyle to use for the button.</param>
            public static bool Button(string text, GUIStyle style)
            {
                return GUILayout.Button(text, style);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw an Image Button. <br></br><br></br>
            /// <see langword="Unity:"/> This method is a simple wrapper for <i>GUILayout.Button</i>.
            /// </summary>
            /// <param name="image">The image that will display on the button.</param>
            /// <param name="style">The GUIStyle to use for the button.</param>
            public static bool Button(Texture image, GUIStyle style)
            {
                return GUILayout.Button(image, style);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a button which is represented by a label. <br></br><br></br>
            /// <see langword="Unity:"/> This method is a simple wrapper for <i>GUILayout.Button</i>.
            /// </summary>
            /// <param name="label">The GUIContent that will display on the button.</param>
            /// <param name="style">The GUIStyle to use for the button.</param>
            public static bool Button(GUIContent label, GUIStyle style)
            {
                return GUILayout.Button(label, style);
            }

            // - polymorphic variations with { params GUILayoutOption[] } as the final parameter

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a Text Button. <br></br><br></br>
            /// <see langword="Unity:"/> This method is a simple wrapper for <i>GUILayout.Button</i>.
            /// </summary>
            /// <param name="text">The text that will display on the button.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            public static bool Button(string text, params GUILayoutOption[] options)
            {
                return GUILayout.Button(text, options);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw an Image Button. <br></br><br></br>
            /// <see langword="Unity:"/> This method is a simple wrapper for <i>GUILayout.Button</i>.
            /// </summary>
            /// <param name="image">The image that will display on the button.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            public static bool Button(Texture image, params GUILayoutOption[] options)
            {
                return GUILayout.Button(image, options);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a button which is represented by a label. <br></br><br></br>
            /// <see langword="Unity:"/> This method is a simple wrapper for <i>GUILayout.Button</i>.
            /// </summary>
            /// <param name="label">The GUIContent that will display on the button.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            public static bool Button(GUIContent label, params GUILayoutOption[] options)
            {
                return GUILayout.Button(label, options);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a Text Button. <br></br><br></br>
            /// <see langword="Unity:"/> This method is a simple wrapper for <i>GUILayout.Button</i>.
            /// </summary>
            /// <param name="text">The text that will display on the button.</param>
            /// <param name="style">The GUIStyle to use for the button.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            public static bool Button(string text, GUIStyle style, params GUILayoutOption[] options)
            {
                return GUILayout.Button(text, style, options);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw an Image Button. <br></br><br></br>
            /// <see langword="Unity:"/> This method is a simple wrapper for <i>GUILayout.Button</i>.
            /// </summary>
            /// <param name="image">The image that will display on the button.</param>
            /// <param name="style">The GUIStyle to use for the button.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            public static bool Button(Texture image, GUIStyle style, params GUILayoutOption[] options)
            {
                return GUILayout.Button(image, style, options);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a button which is represented by a label. <br></br><br></br>
            /// <see langword="Unity:"/> This method is a simple wrapper for <i>GUILayout.Button</i>.
            /// </summary>
            /// <param name="label">The GUIContent that will display on the button.</param>
            /// <param name="style">The GUIStyle to use for the button.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            public static bool Button(GUIContent label, GUIStyle style, params GUILayoutOption[] options)
            {
                return GUILayout.Button(label, style, options);
            }

            // - manual layout variations

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a manually positioned Text Button. <br></br><br></br>
            /// <see langword="Unity:"/> This method is a simple wrapper for <i>GUI.Button</i>.
            /// </summary>
            /// <param name="position">The position to place the button and it’s size within the Editor Window.</param>
            /// <param name="text">The text that will display on the button.</param>
            public static bool Button(Rect position, string text)
            {
                return GUI.Button(position, text);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a manually placed Image Button. <br></br><br></br>
            /// <see langword="Unity:"/> This method is a simple wrapper for <i>GUI.Button</i>.
            /// </summary>
            /// <param name="position">The position to place the button and it’s size within the Editor Window.</param>
            /// <param name="image">The image that will display on the button.</param>
            public static bool Button(Rect position, Texture image)
            {
                return GUI.Button(position, image);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a manually placed button which is represented by a label. <br></br><br></br>
            /// <see langword="Unity:"/> This method is a simple wrapper for <i>GUI.Button</i>.
            /// </summary>
            /// <param name="position">The position to place the button and it’s size within the Editor Window.</param>
            /// <param name="label">The GUIContent that will display on the button.</param>
            public static bool Button(Rect position, GUIContent label)
            {
                return GUI.Button(position, label);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a manually placed Text Button. <br></br><br></br>
            /// <see langword="Unity:"/> This method is a simple wrapper for <i>GUI.Button</i>.
            /// </summary>
            /// <param name="position">The position to place the button and it’s size within the Editor Window.</param>
            /// <param name="text">The text that will display on the button.</param>
            /// <param name="style">The GUIStyle to use for the button.</param>
            public static bool Button(Rect position, string text, GUIStyle style)
            {
                return GUI.Button(position, text, style);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a manually placed Image Button. <br></br><br></br>
            /// <see langword="Unity:"/> This method is a simple wrapper for <i>GUI.Button</i>.
            /// </summary>
            /// <param name="position">The position to place the button and it’s size within the Editor Window.</param>
            /// <param name="image">The image that will display on the button.</param>
            /// <param name="style">The GUIStyle to use for the button.</param>
            public static bool Button(Rect position, Texture image, GUIStyle style)
            {
                return GUI.Button(position, image, style);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a manually placed button which is represented by a label. <br></br><br></br>
            /// <see langword="Unity:"/> This method is a simple wrapper for <i>GUI.Button</i>.
            /// </summary>
            /// <param name="position">The position to place the button and it’s size within the Editor Window.</param>
            /// <param name="label">The GUIContent that will display on the button.</param>
            /// <param name="style">The GUIStyle to use for the button.</param>
            public static bool Button(Rect position, GUIContent label, GUIStyle style)
            {
                return GUI.Button(position, label, style);
            }
        }
    }
}