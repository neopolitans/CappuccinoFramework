using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.SceneManagement;
using System.Drawing.Drawing2D;

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
            /// <see langword="Cappuccino:"/> Draw a Header with the Scene name and a Unity Logo.
            /// </summary>
            public static void SceneHeader()
            {
                Scene activeScene = SceneManager.GetActiveScene();
                string SceneName = activeScene.isDirty ? activeScene.name + "*" : activeScene.name;

                string headerTT = "The current scene.";
                GUILayout.BeginVertical(UI.GetStyle(BaseStyle.GreyBlack));
                GUILayout.Label(new GUIContent(SceneName, headerTT), EditorStyles.boldLabel, GUILayout.Height(WindowUtilities.defaultHeaderSize));
                GUILayout.EndHorizontal();
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a Header in the style of a SceneHeader with custom text only.
            /// </summary>
            /// <param name="text"> The string to display as the header text.</param>
            public static void Header(string text)
            {
                GUILayout.BeginVertical(UI.GetStyle(BaseStyle.GreyBlack));
                GUILayout.Label(new GUIContent(text), EditorStyles.boldLabel, GUILayout.Height(WindowUtilities.defaultHeaderSize));
                GUILayout.EndHorizontal();
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a Header in the style of a SceneHeader with custom text and tooltip.
            /// </summary>
            /// <param name="text"> The string to display as the header text.</param>
            /// <param name="tooltip"> The string to display when hovering over the header text as a tooltip. </param>
            public static void Header(string text, string tooltip)
            {
                GUILayout.BeginVertical(UI.GetStyle(BaseStyle.GreyBlack));
                GUILayout.Label(new GUIContent(text, tooltip), EditorStyles.boldLabel, GUILayout.Height(WindowUtilities.defaultHeaderSize));
                GUILayout.EndHorizontal();
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a Header in the style of SceneHeader.
            /// </summary>
            /// <param name="text"> The string to display as the header text.</param>
            /// <param name="icon"> The icon to display before the header text. </param>
            public static void Header(string text, Texture2D icon)
            {
                GUILayout.BeginVertical(UI.GetStyle(BaseStyle.GreyBlack));
                GUILayout.Label(new GUIContent(text, icon), EditorStyles.boldLabel, GUILayout.Height(WindowUtilities.defaultHeaderSize));
                GUILayout.EndHorizontal();
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a Header in the style of UI.SceneHeader.
            /// </summary>
            /// <param name="text"> The string to display as the header text.</param>
            /// <param name="icon"> The icon to display before the header text. </param>
            /// <param name="baseStyle"> The preferred style to use for the Header background. Uses Cappuccino.Core.<seealso cref="BaseStyle"/> </param>
            public static void Header(string text, Texture2D icon, BaseStyle baseStyle)
            {
                GUILayout.BeginVertical(UI.GetStyle(baseStyle));
                GUILayout.Label(new GUIContent(text, icon), EditorStyles.boldLabel, GUILayout.Height(WindowUtilities.defaultHeaderSize));
                GUILayout.EndHorizontal();
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a Header in the style of UI.SceneHeader.
            /// </summary>
            /// <param name="text"> The string to display as the header text.</param>
            /// <param name="icon"> The icon to display before the header text. </param>
            /// <param name="unityStyle"> The preferred style to use for the Header background. Uses Cappuccino.Core.<seealso cref="UnityStyle"/> </param>
            public static void Header(string text, Texture2D icon, UnityStyle unityStyle)
            {
                GUILayout.BeginVertical(UI.GetStyle(unityStyle));
                GUILayout.Label(new GUIContent(text, icon), EditorStyles.boldLabel, GUILayout.Height(WindowUtilities.defaultHeaderSize));
                GUILayout.EndHorizontal();
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a Header in the style of SceneHeader.
            /// </summary>
            /// <param name="text"> The string to display as the header text.</param>
            /// <param name="tooltip"> The string to display when hovering over the header text as a tooltip. </param>
            /// <param name="icon"> The icon to display before the header text. </param>
            /// <param name="baseStyle"> The preferred style to use for the Header background. Uses Cappuccino.Core.<seealso cref="BaseStyle"/> </param>
            public static void Header(string text, string tooltip, Texture2D icon, BaseStyle baseStyle)
            {
                GUILayout.BeginVertical(UI.GetStyle(baseStyle));
                GUILayout.Label(new GUIContent(text, icon, tooltip), EditorStyles.boldLabel, GUILayout.Height(WindowUtilities.defaultHeaderSize));
                GUILayout.EndHorizontal();
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a Header in the style of SceneHeader. Requires the current width of the window.
            /// </summary>
            /// <param name="text"> The string to display as the header text.</param>
            /// <param name="tooltip"> The string to display when hovering over the header text as a tooltip. </param>
            /// <param name="icon"> The icon to display before the header text. </param>
            /// <param name="unityStyle"> The preferred style to use for the Header background. Uses Cappuccino.Core.<seealso cref="UnityStyle"/> </param>
            public static void Header(string text, string tooltip, Texture2D icon, UnityStyle unityStyle)
            {
                GUILayout.BeginVertical(UI.GetStyle(unityStyle));
                GUILayout.Label(new GUIContent(text, icon, tooltip), EditorStyles.boldLabel, GUILayout.Height(WindowUtilities.defaultHeaderSize));
                GUILayout.EndHorizontal();
            }
        }
    }
}