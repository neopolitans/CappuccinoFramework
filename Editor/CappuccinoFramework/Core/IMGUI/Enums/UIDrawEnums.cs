using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This script contains Enums that Cappuccino.Core.UI uses.
// Enums in this script don't span for more than a handful of options, more extensive Enums will have their own class.

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
            /// The type of Foldout to draw with UI.Foldout.
            /// </summary>
            public enum FoldoutType
            {
                Default,
                Header
            }

            /// <summary>
            /// Which Scroll Bars to always draw with UI.ScrollArea.
            /// </summary>
            public enum ScrollBarDraw
            {
                None,
                Horizontal,
                Vertical,
                Both
            }
        }
    }
}