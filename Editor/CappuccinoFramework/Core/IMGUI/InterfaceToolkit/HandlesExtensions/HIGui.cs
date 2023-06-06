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
        /// <see langword="Cappuccino:"/> This static class is the Handles Interface Toolkit. It contains common UI drawing methods for working with Handles. <br></br>
        /// </summary>
        public static partial class HI
        {
            /// <summary>
            /// <see langword="Cappuccino:"/> Wrap a method that contains UI Elements within a Handles GUI Area. <br></br>
            /// <see langword="Unity:"/> If you prefer UI Elements in the main Draw method, wrap the calls around Handles.BeginGUI() and Handles.EndGUI(); <br></br><br></br>
            /// </summary>
            /// <param name="content">The delegate containing your UI Drawing Calls.</param>
            public static void GUI(UI.UIContent content)
            {
                Handles.BeginGUI();
                if (content != null)
                {
                    content();
                }
                else
                {
                    Debug.LogWarning("[Cappuccino - Handles Interface] HI.GUI has been unable to draw content to the screen. \n Provide a working delegate method to trigger.");
                }
                Handles.EndGUI();
            }
        }
    }
}