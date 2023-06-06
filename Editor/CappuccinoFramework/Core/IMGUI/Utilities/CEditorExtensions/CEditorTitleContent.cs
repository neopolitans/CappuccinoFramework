using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This script extends CEditor, adding abstracted and simplified methods for renaming the window title and icon contents.

namespace Cappuccino
{
    namespace Core
    {
        public partial class CEditor : EditorWindow
        {
            protected string windowName = "";
            protected Texture windowIcon;

            /// <summary>
            /// Rename the editor window.
            /// </summary>
            /// <param name="name">New window name.</param>
            public void Rename(string name)
            {
                windowName = name;
                UpdateTitleContent();
            }

            /// <summary>
            /// Change the editor window icon.
            /// </summary>
            /// <param name="icon">New window icon.</param>
            public void Icon(Texture icon)
            {
                windowIcon = icon;
                UpdateTitleContent();
            }

            protected void UpdateTitleContent()
            {
                titleContent = new GUIContent(windowName, windowIcon);
            }
        }
    }
}