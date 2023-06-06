using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This script builds "UI.Vertical" into Cappuccino.Core.UI. - UI.Vertical is entirely optional.
// If you prefer to not have to separate the contents of your Editor into multiple methods, use GUILayout.BeginVertical() and GUILayout.EndVertical()

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
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements around a Vertical Area. <br></br>
            /// <see langword="Unity:"/> If you prefer UI Elements in the main Draw method, wrap the calls around GUILayout.BeginVertical() and GUILayout.EndVertical(); <br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements.<br></br>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            public static void Vertical(UIContent content)
            {
                if (content != null)
                {
                    GUILayout.BeginVertical();
                    content();
                    GUILayout.EndVertical();
                }
                else
                {
                    Diag.Violation("No content to draw within the Vertical UI Area.");
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements around a Vertical Area. <br></br>
            /// <see langword="Unity:"/> If you prefer UI Elements in the main Draw method, wrap the calls around GUILayout.BeginVertical() and GUILayout.EndVertical(); <br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements. <br></br>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="style">The GUIStyle to use for UI Drawing.</param>
            public static void Vertical(UIContent content, GUIStyle style)
            {
                if (content != null)
                {
                    GUILayout.BeginVertical(style);
                    content();
                    GUILayout.EndVertical();
                }
                else
                {
                    Diag.Violation("No content to draw within the Vertical UI Area.");
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements around a Vertical Area. <br></br>
            /// <see langword="Unity:"/> If you prefer UI Elements in the main Draw method, wrap the calls around GUILayout.BeginVertical() and GUILayout.EndVertical(); <br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements. <br></br>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            public static void Vertical(UIContent content, params GUILayoutOption[] options)
            {
                if (content != null)
                {
                    GUILayout.BeginVertical(options);
                    content();
                    GUILayout.EndVertical();
                }
                else
                {
                    Diag.Violation("No content to draw within the Vertical UI Area.");
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements around a Vertical Area. <br></br>
            /// <see langword="Unity:"/> If you prefer UI Elements in the main Draw method, wrap the calls around GUILayout.BeginVertical() and GUILayout.EndVertical(); <br></br><br></br>
            /// <b><i><see langword="Notice:"/></i></b> Not compatible with manually positioned UI Elements. <br></br>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            /// <param name="style">The GUIStyle to use for UI Drawing.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            public static void Vertical(UIContent content, GUIStyle style, params GUILayoutOption[] options)
            {
                if (content != null)
                {
                    GUILayout.BeginVertical(style, options);
                    content();
                    GUILayout.EndVertical();
                }
                else
                {
                    Diag.Violation("No content to draw within the Vertical UI Area.");
                }
            }
        }
    }
}