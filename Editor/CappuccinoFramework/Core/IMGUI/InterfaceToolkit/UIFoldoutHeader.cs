using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This script builds "UI.FoldoutHeader" into Cappuccino.Core.UI. - entirely optional.
// If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.BeginFoldoutHeaderGroup and EditorGUILayout.EndFoldoutHeaderGroup.

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
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout HeaderArea. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.BeginFoldoutHeaderGroup and EditorGUILayout.EndFoldoutHeaderGroup.<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements.<br></br>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="text">The text to use in the label.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            public static bool FoldoutHeader(UIContent content, string text, bool currentState)
            {
                currentState = EditorGUILayout.BeginFoldoutHeaderGroup(currentState, text);
                if (currentState)
                {
                    if (content != null)
                    {
                        content();
                    }
                    else
                    {
                        Diag.Violation("Foldout has no UIContent to draw.");
                    }
                }
                EditorGUILayout.EndFoldoutHeaderGroup();

                return currentState;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout HeaderArea. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.BeginFoldoutHeaderGroup and EditorGUILayout.EndFoldoutHeaderGroup.<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements.<br></br>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="label">The GUI Content to use for your header.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            public static bool FoldoutHeader(UIContent content, GUIContent label, bool currentState)
            {
                currentState = EditorGUILayout.BeginFoldoutHeaderGroup(currentState, label);
                if (currentState)
                {
                    if (content != null)
                    {
                        content();
                    }
                    else
                    {
                        Diag.Violation("Foldout has no UIContent to draw.");
                    }
                }
                EditorGUILayout.EndFoldoutHeaderGroup();

                return currentState;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout HeaderArea. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.BeginFoldoutHeaderGroup and EditorGUILayout.EndFoldoutHeaderGroup.<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements.<br></br>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="text">The text to use in the label.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            /// <param name="menuAction">The custom menuAction you'd like to specify.</param>
            public static bool FoldoutHeader(UIContent content, string text, bool currentState, System.Action<Rect> menuAction)
            {
                currentState = EditorGUILayout.BeginFoldoutHeaderGroup(currentState, text, null, menuAction);
                if (currentState)
                {
                    if (content != null)
                    {
                        content();
                    }
                    else
                    {
                        Diag.Violation("Foldout has no UIContent to draw.");
                    }
                }
                EditorGUILayout.EndFoldoutHeaderGroup();

                return currentState;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout HeaderArea. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.BeginFoldoutHeaderGroup and EditorGUILayout.EndFoldoutHeaderGroup.<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements.<br></br>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="label">The GUI Content to use for your header.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            /// <param name="menuAction">The custom menuAction you'd like to specify.</param>
            public static bool FoldoutHeader(UIContent content, GUIContent label, bool currentState, System.Action<Rect> menuAction)
            {
                currentState = EditorGUILayout.BeginFoldoutHeaderGroup(currentState, label, null, menuAction);
                if (currentState)
                {
                    if (content != null)
                    {
                        content();
                    }
                    else
                    {
                        Diag.Violation("Foldout has no UIContent to draw.");
                    }
                }
                EditorGUILayout.EndFoldoutHeaderGroup();

                return currentState;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout HeaderArea. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.BeginFoldoutHeaderGroup and EditorGUILayout.EndFoldoutHeaderGroup.<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements.<br></br>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="text">The text to use in the label.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            /// <param name="noDiagnostics">Whether or not to display diagnostic messages.</param>
            public static bool FoldoutHeader(UIContent content, string text, bool currentState, bool noDiagnostics)
            {
                currentState = EditorGUILayout.BeginFoldoutHeaderGroup(currentState, text);
                if (currentState)
                {
                    if (content != null)
                    {
                        content();
                    }
                    else
                    {
                        if (!noDiagnostics)
                        {
                            Diag.Violation("Foldout has no UIContent to draw.");
                        }
                    }
                }
                EditorGUILayout.EndFoldoutHeaderGroup();

                return currentState;
            }


            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout HeaderArea. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.BeginFoldoutHeaderGroup and EditorGUILayout.EndFoldoutHeaderGroup.<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements.<br></br>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="label">The GUI Content to use for your header.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            /// <param name="noDiagnostics">Whether or not to display diagnostic messages.</param>
            public static bool FoldoutHeader(UIContent content, GUIContent label, bool currentState, bool noDiagnostics)
            {
                currentState = EditorGUILayout.BeginFoldoutHeaderGroup(currentState, label);
                if (currentState)
                {
                    if (content != null)
                    {
                        content();
                    }
                    else
                    {
                        if (!noDiagnostics)
                        {
                            Diag.Violation("Foldout has no UIContent to draw.");
                        }
                    }
                }
                EditorGUILayout.EndFoldoutHeaderGroup();

                return currentState;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout HeaderArea. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.BeginFoldoutHeaderGroup and EditorGUILayout.EndFoldoutHeaderGroup.<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements.<br></br>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="text">The text to use in the label.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            /// <param name="menuAction">The custom menuAction you'd like to specify.</param>
            /// <param name="noDiagnostics">Whether or not to display diagnostic messages.</param>
            public static bool FoldoutHeader(UIContent content, string text, bool currentState, System.Action<Rect> menuAction, bool noDiagnostics)
            {
                currentState = EditorGUILayout.BeginFoldoutHeaderGroup(currentState, text, null, menuAction);
                if (currentState)
                {
                    if (content != null)
                    {
                        content();
                    }
                    else
                    {
                        if (!noDiagnostics)
                        {
                            Diag.Violation("Foldout has no UIContent to draw.");
                        }
                    }
                }
                EditorGUILayout.EndFoldoutHeaderGroup();

                return currentState;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout HeaderArea. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.BeginFoldoutHeaderGroup and EditorGUILayout.EndFoldoutHeaderGroup.<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements.<br></br>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="label">The GUI Content to use for your header.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            /// <param name="menuAction">The custom menuAction you'd like to specify.</param>
            /// <param name="noDiagnostics">Whether or not to display diagnostic messages.</param>
            public static bool FoldoutHeader(UIContent content, GUIContent label, bool currentState, System.Action<Rect> menuAction, bool noDiagnostics)
            {
                currentState = EditorGUILayout.BeginFoldoutHeaderGroup(currentState, label, null, menuAction);
                if (currentState)
                {
                    if (content != null)
                    {
                        content();
                    }
                    else
                    {
                        if (!noDiagnostics)
                        {
                            Diag.Violation("Foldout has no UIContent to draw.");
                        }
                    }
                }
                EditorGUILayout.EndFoldoutHeaderGroup();

                return currentState;
            }

        }
    }
}