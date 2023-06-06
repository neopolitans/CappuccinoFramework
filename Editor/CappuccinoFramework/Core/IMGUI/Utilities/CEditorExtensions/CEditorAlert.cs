using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;


// CEditor is a partial class so I can separate elements from it.
// This script stores abstracted, simplified calls to access Cappuccino.Core.CWarning from.

namespace Cappuccino
{
    namespace Core
    {
        public partial class CEditor : EditorWindow
        {
            /// <summary>
            /// <see langword="Cappuccino:"/> Draw an alert message to the panel. 
            /// </summary>
            /// <param name="message"> The message to display.</param>
            public void Alert(string message)
            {
                CWarning.Draw(this, message);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw an alert message to the panel. 
            /// </summary>
            /// <param name="message"> The message to display.</param>
            /// <param name="offsetY"> The vertical offset to account for. used for centering the alert in the editor window.</param>
            public void Alert(string message, int offsetY)
            {
                CWarning.Draw(this, message, offsetY);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw an alert message to the panel. 
            /// </summary>
            /// <param name="message"> The message to display.</param>
            /// <param name="image"> The image to display with the alert message.</param>
            public void Alert(string message, Texture image)
            {
                CWarning.Draw(this, message, image);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw an alert message to the panel. 
            /// </summary>
            /// <param name="message"> The message to display.</param>
            /// <param name="image"> The image to display with the alert message.</param>
            /// <param name="offsetY"> The vertical offset to account for. used for centering the alert in the editor window.</param>
            public void Alert(string message, Texture image, int offsetY)
            {
                CWarning.Draw(this, message, image, offsetY);
            }
        }
    }
}