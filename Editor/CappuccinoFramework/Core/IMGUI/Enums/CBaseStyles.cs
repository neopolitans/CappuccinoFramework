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
        /// <see langword="Cappuccino:"/> Options which return Basic Cappuccino style for use. <br></br>
        /// </summary>
        public enum BaseStyle
        {
            None,

            /// <summary>
            /// A basic style that contains the flat background color [51, 51, 51] - RGB Color Space.
            /// </summary>
            DarkStormGrey,

            /// <summary>
            /// A basic style that contains the flat background color [41, 41, 41] - RGB Color Space.
            /// </summary>
            EveningGrey,

            /// <summary>
            /// A basic style that contains the flat background color [44, 44, 44] - RGB Color Space.
            /// </summary>
            GreyBlack,

            /// <summary>
            /// A legacy option ported forward from Hierarchy Redux for use in Cappuccino. <br></br>
            /// This style is used for buttons when they aren't hovered, active or selected.
            /// </summary>
            SelectionNormal,

            /// <summary>
            /// A legacy option ported forward from Hierarchy Redux for use in Cappuccino. <br></br>
            /// This style is used for buttons when they are hovered over.
            /// </summary>
            SelectionHover,

            /// <summary>
            /// A legacy option ported forward from Hierarchy Redux for use in Cappuccino. <br></br>
            /// This style is used for buttons when they are active.
            /// </summary>
            SelectionActive,

            /// <summary>
            /// A legacy option ported forward from Hierarchy Redux for use in Cappuccino. <br></br>
            /// This style is used for buttons when they are active and selected.
            /// </summary>
            SelectionActiveSelected,

            /// <summary>
            /// Documentation Pending. <br></br><br></br>
            /// <see langword="Cappuccino:"/> This style was used at one point for an editor window which <br></br>
            /// was being considered as a possible inclusion as an example plugin.
            /// </summary>
            InteractionButtonHierarchy,

            /// <summary>
            /// A style for buttons to use so they can blend in with the default stylization of the <br></br>
            /// <see cref="UI.Header(string)">Header</see> methods that Cappuccino provides.
            /// </summary>
            HeaderButtonDark,

            /// <summary>
            /// A style for buttons within Handles GUI calls that has additional transparency to not obscure <br></br>
            /// elements within the scene that are behind the GUI. This is for buttons that aren't hovered, active or selected.
            /// </summary>
            HandlesNormal,

            /// <summary>
            /// A style for buttons within Handles GUI calls that has additional transparency to not obscure <br></br>
            /// elements within the scene that are behind the GUI. This is for buttons that are being hovered over.
            /// </summary>
            HandlesHover,

            /// <summary>
            /// A style for buttons within Handles GUI calls that has additional transparency to not obscure <br></br>
            /// elements within the scene that are behind the GUI. This is for buttons that are active.
            /// </summary>
            HandlesActive
        }

        /// <summary>
        /// <see langword="Cappuccino:"/> Options which return Interactible styles for use. <br></br>
        /// </summary>
        public enum InteractiveStyle
        {
            None,

            /// <summary>
            /// Return a button style for a button that's used for Cappuccino's Tab Bars.
            /// </summary>
            WindowTopbarButton,

            /// <summary>
            /// Return a button style for a button in an array list.
            /// </summary>
            ArrayListButton,

            /// <summary>
            /// Return a button style for a button for an option that's selected in an array list.
            /// </summary>
            ArrayListSelectedButton,

            /// <summary>
            /// Return a button style for a button that modifies an array or list.
            /// </summary>
            ArrayModifyButton,

            /// <summary>
            /// Return a button style for navigating an array when used with Handles.BeginGUI() and Handles.EndGUI().
            /// </summary>
            HandlesButton
        }

        /// <summary>
        /// <see langword="Cappuccino:"/> Options which return Unity-like styles for basic use. <br></br>
        /// Alternatively, UnityEditor.<seealso cref="EditorStyles"/> contains all common UnityEditor styles.
        /// </summary>
        public enum UnityStyle
        {
            None,

            /// <summary>
            /// Return a base style that has the default dark-mode grey of unity.
            /// </summary>
            UnityGrey,

            /// <summary>
            /// Return a base style that has the default dark-mode light-grey of the Unity Scene Hierarcy.
            /// </summary>
            SceneHeaderGrey,

            /// <summary>
            /// Return a base style that has the default dark-mode grey of the Scene Hierarchy's Gutter section (for buttons).
            /// </summary>
            HierarchyDark,

            /// <summary>
            /// Return a base style that has the default blue color that Unity uses to <br></br>
            /// highlight the currently selected tab in the currently focused window.
            /// </summary>
            WindowSelectionRibbon,

            /// <summary>
            /// Returns a base-style that has similar behaviour to Unity's built-in <br></br>
            /// <see cref="EditorStyles.centeredGreyMiniLabel">centeredGreyMiniLabel</see> without the font size or <see cref="TextAlignment"></see> <br></br>
            /// settings of the aforementioned Editor Style.
            /// </summary>
            GreyLabel
        }
    }
}