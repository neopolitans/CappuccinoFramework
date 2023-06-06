using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This script contains the delegates that the UI namespace has for making GUILayout Area-related methods easier to use.

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
            /// A delegate used to pass through a method containing all the UI Elements you wish to draw. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Used to make drawing Horizontal and Vertical areas (among other things) a bit easier. <br></br>
            /// </summary>
            public delegate void UIContent();

            /// <summary>
            /// A delegate used to pass through a method containing the means of which to detemrine what item is selected for Dropdown Menus. <br></br>
            /// Takes a selection integer to help determine what the current selection is from the array of objects and names provided.
            /// </summary>
            /// <returns><see langword="boolean"/></returns>
            public delegate bool BoolComparator(int selection);
        }
    }
}