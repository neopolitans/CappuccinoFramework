using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// ! This extension makes use of the UIMiscellaneous.cs script ! //
// !   This extension makes use of the UIHorizontal.cs script  ! //
// !    This extension makes use of the UIVertical.cs script   ! //

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
            /// <see langword="Cappuccino:"/> Draw a basic divider. <br></br><br></br>
            /// <b><see langword="Notice:"/></b> Only works with Automatically laid out methods.
            /// </summary>
            public static void Divider()
            {
                UI.Space(3f);
                UI.Horizontal(delegate
                {
                    UI.Space(3f);
                    UI.Vertical(delegate { UI.Space(1f); }, UI.GetStyle(BaseStyle.EveningGrey));
                    UI.Space(3f);
                });
                UI.Space(3f);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a basic divider.<br></br><br></br>
            /// <b><see langword="Notice:"/></b> Only works with Automatically laid out methods.
            /// </summary>
            /// <param name="horizontalSpacing">The amount of space in pixels to take up with a horizontal divider.</param>
            public static void Divider(int horizontalSpacing)
            {
                UI.Space(3f);
                UI.Horizontal(delegate
                {
                    UI.Space(horizontalSpacing);
                    UI.Vertical(delegate { UI.Space(1f); }, UI.GetStyle(BaseStyle.EveningGrey));
                    UI.Space(horizontalSpacing);
                });
                UI.Space(3f);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a basic divider.<br></br><br></br>
            /// <b><see langword="Notice:"/></b> Only works with Automatically laid out methods.
            /// </summary>
            /// <param name="horizontalSpacing">The amount of space in pixels to take up with a horizontal divider.</param>
            /// <param name="spacingBetweenElements">The amount of space in pixels between the previous and next UI Elements which the divider lies between.</param>
            public static void Divider(int horizontalSpacing, int spacingBetweenElements)
            {
                UI.Space(spacingBetweenElements);
                UI.Horizontal(delegate
                {
                    UI.Space(horizontalSpacing);
                    UI.Vertical(delegate { UI.Space(1f); }, UI.GetStyle(BaseStyle.EveningGrey));
                    UI.Space(horizontalSpacing);
                });
                UI.Space(spacingBetweenElements);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a basic divider. <br></br><br></br>
            /// <b><see langword="Notice:"/></b> Only works with Automatically laid out methods.
            /// </summary>
            /// <param name="dividerStyle">The GUIStyle to draw the divider with.</param>
            public static void Divider(GUIStyle dividerStyle)
            {
                UI.Space(3f);
                UI.Horizontal(delegate
                {
                    UI.Space(3f);
                    UI.Vertical(delegate { UI.Space(1f); }, dividerStyle);
                    UI.Space(3f);
                });
                UI.Space(3f);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a basic divider.<br></br><br></br>
            /// <b><see langword="Notice:"/></b> Only works with Automatically laid out methods.
            /// </summary>
            /// <param name="horizontalSpacing">The amount of space in pixels to take up with a horizontal divider.</param>
            /// <param name="dividerStyle">The GUIStyle to draw the divider with.</param>
            public static void Divider(int horizontalSpacing, GUIStyle dividerStyle)
            {
                UI.Space(3f);
                UI.Horizontal(delegate
                {
                    UI.Space(horizontalSpacing);
                    UI.Vertical(delegate { UI.Space(1f); }, dividerStyle);
                    UI.Space(horizontalSpacing);
                });
                UI.Space(3f);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a basic divider.<br></br><br></br>
            /// <b><see langword="Notice:"/></b> Only works with Automatically laid out methods.
            /// </summary>
            /// <param name="horizontalSpacing">The amount of space in pixels to take up with a horizontal divider.</param>
            /// <param name="spacingBetweenElements">The amount of space in pixels between the previous and next UI Elements which the divider lies between.</param>
            /// <param name="dividerStyle">The GUIStyle to draw the divider with.</param>
            public static void Divider(int horizontalSpacing, int spacingBetweenElements, GUIStyle dividerStyle)
            {
                UI.Space(spacingBetweenElements);
                UI.Horizontal(delegate
                {
                    UI.Space(horizontalSpacing);
                    UI.Vertical(delegate { UI.Space(1f); }, dividerStyle);
                    UI.Space(horizontalSpacing);
                });
                UI.Space(spacingBetweenElements);
            }


            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a basic divider. <br></br><br></br>
            /// <b><see langword="Notice:"/></b> For manual layout methods, you must take into account the width and/or height for laying out elements procedurally.
            /// </summary>
            public static void Divider(Rect position)
            {
                Label(position, " ", UI.GetStyle(BaseStyle.EveningGrey));
            }
        }
    }
}