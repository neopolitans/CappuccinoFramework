using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This script builds "UI.ScrollArea" into Cappuccino.Core.UI. - entirely optional.
// If you prefer to not have to separate the contents of your Editor into multiple methods, use EditorGUILayout.BeginScrollView() and GUILayout.EndScrollView()

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
            /// <see langword="Cappuccino:"/> Create a Scroll Area for the content to display in the Editor Window.<br></br>
            /// <see langword="Unity:"/> If you prefer UI Elements in the main Draw method, use EditorGUILayout.BeginScrollView() and GUILayout.EndScrollView();
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="scrollPosition">The current scroll position of the ScrollArea.</param>
            /// <returns></returns>
            public static Vector2 ScrollArea(UIContent content, Vector2 scrollPosition)
            {
                scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
                if (content != null)
                {
                    content();
                }
                else
                {

                    Diag.Violation("No content to draw within the UI Scroll Area.");
                }
                EditorGUILayout.EndScrollView();

                return scrollPosition;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Scroll Area for the content to display in the Editor Window.<br></br>
            /// <see langword="Unity:"/> If you prefer UI Elements in the main Draw method, use EditorGUILayout.BeginScrollView() and GUILayout.EndScrollView();
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="scrollPosition">The current scroll position of the ScrollArea.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            /// <returns></returns>
            public static Vector2 ScrollArea(UIContent content, Vector2 scrollPosition, params GUILayoutOption[] options)
            {
                scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, options);
                if (content != null)
                {
                    content();
                }
                else
                {
                    Diag.Violation("No content to draw within the UI Scroll Area.");
                }
                EditorGUILayout.EndScrollView();

                return scrollPosition;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Scroll Area for the content to display in the Editor Window.<br></br>
            /// <see langword="Unity:"/> If you prefer UI Elements in the main Draw method, use EditorGUILayout.BeginScrollView() and GUILayout.EndScrollView(); <br></br><br></br>
            /// <b><see langword="Notice:"/></b> In some versions of Unity Engine, both scrollbars will always draw even if only one is selected to appear.
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="scrollPosition">The current scroll position of the ScrollArea.</param>
            /// <param name="drawStyle">Which Scrollbars to</param>
            /// <param name="options">The auto-layout options to apply.</param>
            /// <returns></returns>
            public static Vector2 ScrollArea(UIContent content, Vector2 scrollPosition, ScrollBarDraw drawStyle, params GUILayoutOption[] options)
            {
                switch (drawStyle)
                {
                    default:
                        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, false, false, options);
                        if (content != null)
                        {
                            content();
                        }
                        else
                        {
                            Diag.Violation("No content to draw within the UI Scroll Area.");
                        }
                        EditorGUILayout.EndScrollView();
                        return scrollPosition;

                    case ScrollBarDraw.Vertical:
                        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, false, true, options);
                        if (content != null)
                        {
                            content();
                        }
                        else
                        {
                            Diag.Violation("No content to draw within the UI Scroll Area.");
                        }
                        EditorGUILayout.EndScrollView();
                        return scrollPosition;

                    case ScrollBarDraw.Horizontal:
                        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, true, false, options);
                        if (content != null)
                        {
                            content();
                        }
                        else
                        {
                            Diag.Violation("No content to draw within the UI Scroll Area.");
                        }
                        EditorGUILayout.EndScrollView();
                        return scrollPosition;

                    case ScrollBarDraw.Both:
                        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, false, true, options);
                        if (content != null)
                        {
                            content();
                        }
                        else
                        {
                            Diag.Violation("No content to draw within the UI Scroll Area.");
                        }
                        EditorGUILayout.EndScrollView();
                        return scrollPosition;
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Scroll Area for the content to display in the Editor Window.<br></br>
            /// Alternative to the variation that uses the ScrollBarDraw enum to determine the drawing style. <br></br>
            /// <see langword="Unity:"/> If you prefer UI Elements in the main Draw method, use EditorGUILayout.BeginScrollView() and GUILayout.EndScrollView(); <br></br><br></br>
            /// <b><see langword="Notice:"/></b> In some versions of Unity Engine, both scrollbars will always draw even if only one is selected to appear.
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="scrollPosition">The current scroll position of the ScrollArea.</param>
            /// <param name="alwaysShowHorizontal">Should the Horizontal Scrollbar always display.</param>
            /// <param name="alwaysShowHorizontal">Should the Vertical Scrollbar always display.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            /// <returns></returns>
            public static Vector2 ScrollArea(UIContent content, Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, params GUILayoutOption[] options)
            {
                scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, alwaysShowHorizontal, alwaysShowVertical, options);
                if (content != null)
                {
                    content();
                }
                else
                {
                    Diag.Violation("No content to draw within the UI Scroll Area.");
                }
                EditorGUILayout.EndScrollView();

                return scrollPosition;
            }
        }
    }
}