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
        /// Draw a Warning on the screen for your CEditor.
        /// </summary>
        public static class CWarning
        {
            /// <summary>
            /// Draw a Warning in the middle of the Editor Window.
            /// </summary>
            /// <param name="editor">The Editor Window to draw the message for. <br/> Required to determine the Position and Size information of the window.</param>
            /// <param name="message">The message to display.</param>
            public static void Draw(CEditor editor, string message)
            {
                GUILayout.BeginVertical();
                GUILayout.Space((editor.position.height / 2) - 32f);

                GUILayout.Space(16f);
                GUILayout.Label(message, EditorStyles.centeredGreyMiniLabel);
                GUILayout.EndVertical();
            }

            /// <summary>
            /// Draw a Warning in the middle of the Editor Window.
            /// </summary>
            /// <param name="editor">The Editor Window to draw the message for. <br/> Required to determine the Position and Size information of the window.</param>
            /// <param name="message">The message to display.</param>
            /// <param name="yOffset">The offset to account for based on header sizes.</param>
            public static void Draw(CEditor editor, string message, int yOffset)
            {
                GUILayout.BeginVertical();
                GUILayout.Space(((editor.position.height / 2) - 32f) + -yOffset);

                GUILayout.Space(16f);
                GUILayout.Label(message, EditorStyles.centeredGreyMiniLabel);
                GUILayout.EndVertical();
            }

            /// <summary>
            /// Draw a Warning in the middle of the Editor Window.
            /// </summary>
            /// <param name="editor">The Editor Window to draw the message for. <br/> Required to determine the Position and Size information of the window.</param>
            /// <param name="message">The message to display.</param>
            /// <param name="image">The image to display.</param>
            public static void Draw(CEditor editor, string message, Texture image)
            {
                GUILayout.BeginVertical();
                GUILayout.Space((editor.position.height / 2) - 64f);

                GUILayout.BeginHorizontal();
                GUILayout.Space((editor.position.width / 2) - 32f);
                GUILayout.Box(new GUIContent(image), GUIStyle.none, GUILayout.Width(64), GUILayout.Height(64f));
                GUILayout.EndHorizontal();

                GUILayout.Space(16f);
                GUILayout.Label(message, EditorStyles.centeredGreyMiniLabel);
                GUILayout.EndVertical();
            }

            /// <summary>
            /// Draw a Warning in the middle of the Editor Window.
            /// </summary>
            /// <param name="editor">The Editor Window to draw the message for. <br/> Required to determine the Position and Size information of the window.</param>
            /// <param name="message">The message to display.</param>
            /// <param name="image">The image to display.</param>
            /// <param name="yOffset">The offset to account for based on header sizes.</param>
            public static void Draw(CEditor editor, string message, Texture image, int yOffset)
            {
                GUILayout.BeginVertical();
                GUILayout.Space(((editor.position.height / 2) - 64f) + -yOffset);

                GUILayout.BeginHorizontal();
                GUILayout.Space(((editor.position.width / 2) - 32f));
                GUILayout.Box(new GUIContent(image), GUIStyle.none, GUILayout.Width(64), GUILayout.Height(64f));
                GUILayout.EndHorizontal();

                GUILayout.Space(16f);
                GUILayout.Label(message, EditorStyles.centeredGreyMiniLabel);
                GUILayout.EndVertical();
            }
        }
    }
}
