using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This script builds "UI.Foldout" into Cappuccino.Core.UI. - entirely optional.
// If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.Foldout() or EditorGUILayout.BeginFoldoutHeaderGroup()/EditorGUILayout.EndFoldoutHeaderGroup()

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> This static class is the User Interface Toolkit. It contains common UI drawing methods for Editors. <br></br>
        /// </summary>
        public static partial class UI
        {
            // Automatic Drawing Methods

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout Area. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.Foldout() (or BeginFoldoutHeaderGroup and EndFoldoutHeaderGroup).<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements.<br></br>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="text">The text to use in the label.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            public static bool Foldout(UIContent content, string text, bool currentState)
            {

                currentState = EditorGUILayout.Foldout(currentState, text);
                if (currentState)
                {
                    if (content!= null)
                    {
                        content();
                    }
                    else
                    {
                        Diag.Violation("Foldout has no UIContent to draw.");
                    }
                }

                return currentState;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout Area. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.Foldout() (or BeginFoldoutHeaderGroup and EndFoldoutHeaderGroup).<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements.<br></br>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="label">The delegate containing your UI Drawing Calls.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            public static bool Foldout(UIContent content, GUIContent label, bool currentState)
            {
                currentState = EditorGUILayout.Foldout(currentState, label);
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

                return currentState;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout Area. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.Foldout() (or BeginFoldoutHeaderGroup and EndFoldoutHeaderGroup).<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements.<br></br>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="text">The text to use in the label.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            /// <param name="labelTriggersFoldout">Does clicking on the label trigger the Foldout behaviour?</param>
            public static bool Foldout(UIContent content, string text, bool currentState, bool labelTriggersFoldout)
            {
                currentState = EditorGUILayout.Foldout(currentState, text, labelTriggersFoldout);
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

                return currentState;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout Area. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.Foldout() (or BeginFoldoutHeaderGroup and EndFoldoutHeaderGroup).<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements.<br></br>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="label">The delegate containing your UI Drawing Calls.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            /// <param name="labelTriggersFoldout">Does clicking on the label trigger the Foldout behaviour?</param>
            public static bool Foldout(UIContent content, GUIContent label, bool currentState, bool labelTriggersFoldout)
            {
                currentState = EditorGUILayout.Foldout(currentState, label, labelTriggersFoldout);
                if (currentState && content != null)
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

                return currentState;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout Area. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.Foldout() (or BeginFoldoutHeaderGroup and EndFoldoutHeaderGroup).<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements.<br></br>
            /// </summary>
            /// <param name="position"> The Position and Size (as Rect) to draw the UI Element with.</param>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="text">The text to use in the label.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            /// <param name="style">The GUIStyle to use for UI Drawing.</param>
            public static bool Foldout(UIContent content, string text, bool currentState, GUIStyle style)
            {
                currentState = EditorGUILayout.Foldout(currentState, text, style);
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

                return currentState;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout Area. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.Foldout() (or BeginFoldoutHeaderGroup and EndFoldoutHeaderGroup).<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements.<br></br>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="label">The delegate containing your UI Drawing Calls.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            /// <param name="style">The GUIStyle to use for UI Drawing.</param>
            public static bool Foldout(UIContent content, GUIContent label, bool currentState, GUIStyle style)
            {
                currentState = EditorGUILayout.Foldout(currentState, label, style);
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

                return currentState;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout Area. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.Foldout() (or BeginFoldoutHeaderGroup and EndFoldoutHeaderGroup).<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements.<br></br>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="text">The text to use in the label.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            /// <param name="labelTriggersFoldout">Does clicking on the label trigger the Foldout behaviour?</param>
            /// <param name="style">The GUIStyle to use for UI Drawing.</param>
            public static bool Foldout(UIContent content, string text, bool currentState, bool labelTriggersFoldout, GUIStyle style)
            {
                currentState = EditorGUILayout.Foldout( currentState, text, labelTriggersFoldout, style);
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

                return currentState;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout Area. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.Foldout() (or BeginFoldoutHeaderGroup and EndFoldoutHeaderGroup).<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements.<br></br>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="label">The delegate containing your UI Drawing Calls.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            /// <param name="labelTriggersFoldout">Does clicking on the label trigger the Foldout behaviour?</param>
            /// <param name="style">The GUIStyle to use for UI Drawing.</param>
            public static bool Foldout(UIContent content, GUIContent label, bool currentState, bool labelTriggersFoldout, GUIStyle style)
            {
                currentState = EditorGUILayout.Foldout(currentState, label, labelTriggersFoldout, style);
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

                return currentState;
            }

            // - FoldoutType is specific to EditorGUILayout and does not support GUIStyles.

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout Area.<br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.Foldout() (or BeginFoldoutHeaderGroup and EndFoldoutHeaderGroup).<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements.<br></br>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="drawType">The style of foldout to use for drawing.</param>
            /// <param name="text">The text to use in the label.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            public static bool Foldout(UIContent content, FoldoutType drawType, string text, bool currentState)
            {
                switch (drawType)
                {
                    default:
                        currentState = EditorGUILayout.Foldout(currentState, text);
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

                        return currentState;

                    case FoldoutType.Header:
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
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout Area. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.Foldout() (or BeginFoldoutHeaderGroup and EndFoldoutHeaderGroup).<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements.<br></br>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="drawType">The style of foldout to use for drawing.</param>
            /// <param name="label">The delegate containing your UI Drawing Calls.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            public static bool Foldout(UIContent content, FoldoutType drawType, GUIContent label, bool currentState)
            {
                switch (drawType)
                {
                    default:
                        currentState = EditorGUILayout.Foldout(currentState, label);
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

                        return currentState;

                    case FoldoutType.Header:
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
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout Area.<br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.Foldout() (or BeginFoldoutHeaderGroup and EndFoldoutHeaderGroup).<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements.<br></br>
            /// <i>  +   Some Foldout Types do not use labelTriggersFoldout.</i>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="drawType">The style of foldout to use for drawing.</param>
            /// <param name="text">The text to use in the label.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            /// <param name="labelTriggersFoldout">Does clicking on the label trigger the Foldout behaviour?</param>
            public static bool Foldout(UIContent content, FoldoutType drawType, string text, bool currentState, bool labelTriggersFoldout)
            {
                switch (drawType)
                {
                    default:
                        currentState = EditorGUILayout.Foldout(currentState, text, labelTriggersFoldout);
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

                        return currentState;

                    case FoldoutType.Header:
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
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout Area. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.Foldout() (or BeginFoldoutHeaderGroup and EndFoldoutHeaderGroup).<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements.<br></br>
            /// <i>  +   Some Foldout Types do not use labelTriggersFoldout.</i>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="drawType">The style of foldout to use for drawing.</param>
            /// <param name="label">The delegate containing your UI Drawing Calls.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            /// <param name="labelTriggersFoldout">Does clicking on the label trigger the Foldout behaviour?</param>
            public static bool Foldout(UIContent content, FoldoutType drawType, GUIContent label, bool currentState, bool labelTriggersFoldout)
            {
                switch (drawType)
                {
                    default:
                        currentState = EditorGUILayout.Foldout(currentState, label, labelTriggersFoldout);
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

                        return currentState;

                    case FoldoutType.Header:
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
            }

            // Manual Drawing Methods
            // These would be used in the case where the foldout is being laid on top of an automatically drawn element or you are fully manually controlling (and tracking) the position of all UI elements.

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout Area. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.Foldout() (or BeginFoldoutHeaderGroup and EndFoldoutHeaderGroup).<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> May be used in cases where the foldout is being laid on top of an automatically drawn element or you are fully manually controlling (and tracking) the position of all UI elements.<br></br>
            /// </summary>
            /// <param name="position"> The Position and Size (as Rect) to draw the UI Element with.</param>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="text">The text to use in the label.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            public static bool Foldout(Rect position, UIContent content, string text, bool currentState)
            {
                currentState = EditorGUI.Foldout(position, currentState, text);
                if (currentState && content != null)
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

                return currentState;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout Area. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.Foldout() (or BeginFoldoutHeaderGroup and EndFoldoutHeaderGroup).<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> May be used in cases where the foldout is being laid on top of an automatically drawn element or you are fully manually controlling (and tracking) the position of all UI elements.<br></br>
            /// </summary>
            /// <param name="position"> The Position and Size (as Rect) to draw the UI Element with.</param>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="label">The delegate containing your UI Drawing Calls.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            public static bool Foldout(Rect position, UIContent content, GUIContent label, bool currentState)
            {
                currentState = EditorGUI.Foldout(position, currentState, label);
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

                return currentState;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout Area. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.Foldout() (or BeginFoldoutHeaderGroup and EndFoldoutHeaderGroup).<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> May be used in cases where the foldout is being laid on top of an automatically drawn element or you are fully manually controlling (and tracking) the position of all UI elements.<br></br>
            /// </summary>
            /// <param name="position"> The Position and Size (as Rect) to draw the UI Element with.</param>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="text">The text to use in the label.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            /// <param name="labelTriggersFoldout">Does clicking on the label trigger the Foldout behaviour?</param>
            public static bool Foldout(Rect position, UIContent content, string text, bool currentState, bool labelTriggersFoldout)
            {
                currentState = EditorGUI.Foldout(position, currentState, text, labelTriggersFoldout);
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

                return currentState;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout Area. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.Foldout() (or BeginFoldoutHeaderGroup and EndFoldoutHeaderGroup).<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> May be used in cases where the foldout is being laid on top of an automatically drawn element or you are fully manually controlling (and tracking) the position of all UI elements.<br></br>
            /// </summary>
            /// <param name="position"> The Position and Size (as Rect) to draw the UI Element with.</param>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="label">The delegate containing your UI Drawing Calls.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            /// <param name="labelTriggersFoldout">Does clicking on the label trigger the Foldout behaviour?</param>
            public static bool Foldout(Rect position, UIContent content, GUIContent label, bool currentState, bool labelTriggersFoldout)
            {
                currentState = EditorGUI.Foldout(position, currentState, label, labelTriggersFoldout);
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

                return currentState;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout Area. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.Foldout() (or BeginFoldoutHeaderGroup and EndFoldoutHeaderGroup).<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> May be used in cases where the foldout is being laid on top of an automatically drawn element or you are fully manually controlling (and tracking) the position of all UI elements.<br></br>
            /// </summary>
            /// <param name="position"> The Position and Size (as Rect) to draw the UI Element with.</param>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="text">The text to use in the label.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            /// <param name="style">The GUIStyle to use for UI Drawing.</param>
            public static bool Foldout(Rect position, UIContent content, string text, bool currentState, GUIStyle style)
            {
                currentState = EditorGUI.Foldout(position, currentState, text, style);
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

                return currentState;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout Area. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.Foldout() (or BeginFoldoutHeaderGroup and EndFoldoutHeaderGroup).<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> May be used in cases where the foldout is being laid on top of an automatically drawn element or you are fully manually controlling (and tracking) the position of all UI elements.<br></br>
            /// </summary>
            /// <param name="position"> The Position and Size (as Rect) to draw the UI Element with.</param>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="label">The delegate containing your UI Drawing Calls.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            /// <param name="style">The GUIStyle to use for UI Drawing.</param>
            public static bool Foldout(Rect position, UIContent content, GUIContent label, bool currentState, GUIStyle style)
            {
                currentState = EditorGUI.Foldout(position, currentState, label, style);
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

                return currentState;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout Area. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.Foldout() (or BeginFoldoutHeaderGroup and EndFoldoutHeaderGroup).<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> May be used in cases where the foldout is being laid on top of an automatically drawn element or you are fully manually controlling (and tracking) the position of all UI elements.<br></br>
            /// </summary>
            /// <param name="position"> The Position and Size (as Rect) to draw the UI Element with.</param>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="text">The text to use in the label.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            /// <param name="labelTriggersFoldout">Does clicking on the label trigger the Foldout behaviour?</param>
            /// <param name="style">The GUIStyle to use for UI Drawing.</param>
            public static bool Foldout(Rect position, UIContent content, string text, bool currentState, bool labelTriggersFoldout, GUIStyle style)
            {
                currentState = EditorGUI.Foldout(position, currentState, text, labelTriggersFoldout, style);
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

                return currentState;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements under a Foldout Area. <br></br>
            /// <see langword="Unity:"/> If you prefer to not separate the contents of your Editor into multiple methods, use EditorGUILayout.Foldout() (or BeginFoldoutHeaderGroup and EndFoldoutHeaderGroup).<br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> May be used in cases where the foldout is being laid on top of an automatically drawn element or you are fully manually controlling (and tracking) the position of all UI elements.<br></br>
            /// </summary>
            /// <param name="position"> The Position and Size (as Rect) to draw the UI Element with.</param>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="label">The delegate containing your UI Drawing Calls.</param>
            /// <param name="currentState">The current foldout state to render.</param>
            /// <param name="labelTriggersFoldout">Does clicking on the label trigger the Foldout behaviour?</param>
            /// <param name="style">The GUIStyle to use for UI Drawing.</param>
            public static bool Foldout(Rect position, UIContent content, GUIContent label, bool currentState, bool labelTriggersFoldout, GUIStyle style)
            {
                currentState = EditorGUI.Foldout(position, currentState, label, labelTriggersFoldout, style);
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

                return currentState;
            }

        }
    }
}