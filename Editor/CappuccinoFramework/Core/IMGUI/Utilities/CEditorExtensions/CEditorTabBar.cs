using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This script extends CEditor, adding simplified methods for accessing Cappuccino.Core.UI.TabBar.

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// A Derivable class which abstracts elements of creating an Editor Window for <see langword="Unity"/>. <br></br><br></br>
        /// <see langword="Cappuccino:"/> Methods within this class can be dervied, extended and replaced as need be.
        /// </summary>
        public partial class CEditor : EditorWindow
        {

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Tab Bar that allows users to select one of the tabs provided. <br></br><br></br>
            /// <b><see langword="Notice:"/></b> This variation expects you to have the equivalent of "No Tab" as the value <b>[-1]</b>.
            /// </summary>
            /// <param name="y">The Y Position to draw the header at.</param>
            /// <param name="current">The current tab selected (as integer).</param>
            /// <param name="tabNames"> The tab names to use for buttons.</param>
            /// <returns></returns>
            public int TabBar(float y, int current, string[] tabNames)
            {
                return UI.TabBar(this, y, current, tabNames);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Tab Bar that allows users to select one of the tabs provided. <br></br><br></br>
            /// <b><see langword="Notice:"/></b> This variation expects you to have the equivalent of "No Tab" as the value <b>[-1]</b>.
            /// </summary>
            /// <param name="y">The Y Position to draw the header at.</param>
            /// <param name="current">The current tab selected (as integer).</param>
            /// <param name="tabNames"> The tab names to use for buttons.</param>
            /// <param name="buttonStyle">The style to draw with for each Button.</param>
            /// <returns></returns>
            public int TabBar(float y, int current, string[] tabNames, GUIStyle buttonStyle)
            {
                return UI.TabBar(this, y, current, tabNames, buttonStyle);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Tab Bar that allows users to select one of the tabs provided. <br></br><br></br>
            /// <b><see langword="Notice:"/></b> This variation expects you to have the equivalent of "No Tab" as the value <b>[-1]</b>.
            /// </summary>
            /// <param name="y">The Y Position to draw the header at.</param>
            /// <param name="current">The current tab selected (as integer).</param>
            /// <param name="tabNames"> The tab names to use for buttons.</param>
            /// <param name="buttonStyle">The style to draw with for each Button.</param>
            /// <param name="ribbonStyle">The style to draw a tab's selected indication ribbon with.</param>
            /// <returns></returns>
            public int TabBar(float y, int current, string[] tabNames, GUIStyle buttonStyle, GUIStyle ribbonStyle)
            {
                return UI.TabBar(this, y, current, tabNames, buttonStyle, ribbonStyle);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Tab Bar that allows users to select one of the tabs provided. <br></br><br></br>
            /// <b><see langword="Notice:"/></b> This variation expects you to have the equivalent of "No Tab" as the value <b>[-1]</b>.
            /// </summary>
            /// <param name="y">The Y Position to draw the header at.</param>
            /// <param name="current">The current tab selected (as integer).</param>
            /// <param name="tabNames"> The tab names to use for buttons.</param>
            /// <param name="buttonsPerRow">The amount of buttons per row to draw.</param>
            /// <returns></returns>
            public int TabBar(float y, int current, string[] tabNames, int buttonsPerRow)
            {
                return UI.TabBar(this, y, current, tabNames, buttonsPerRow);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Tab Bar that allows users to select one of the tabs provided. <br></br><br></br>
            /// <b><see langword="Notice:"/></b> This variation expects you to have the equivalent of "No Tab" as the value <b>[-1]</b>.
            /// </summary>
            /// <param name="y">The Y Position to draw the header at.</param>
            /// <param name="current">The current tab selected (as integer).</param>
            /// <param name="tabNames"> The tab names to use for buttons.</param>
            /// <param name="buttonsPerRow">The amount of buttons per row to draw.</param>
            /// <param name="buttonStyle">The style to draw with for each Button.</param>
            /// <returns></returns>
            public int TabBar(float y, int current, string[] tabNames, int buttonsPerRow, GUIStyle buttonStyle)
            {
                return UI.TabBar(this, y, current, tabNames, buttonsPerRow, buttonStyle);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Tab Bar that allows users to select one of the tabs provided. <br></br><br></br>
            /// <b><see langword="Notice:"/></b> This variation expects you to have the equivalent of "No Tab" as the value <b>[-1]</b>.
            /// </summary>
            /// <param name="y">The Y Position to draw the header at.</param>
            /// <param name="current">The current tab selected (as integer).</param>
            /// <param name="tabNames"> The tab names to use for buttons.</param>
            /// <param name="buttonsPerRow">The amount of buttons per row to draw.</param>
            /// <param name="buttonStyle">The style to draw with for each Button.</param>
            /// <param name="ribbonStyle">The style to draw a tab's selected indication ribbon with.</param>
            /// <returns></returns>
            public int TabBar(float y, int current, string[] tabNames, int buttonsPerRow, GUIStyle buttonStyle, GUIStyle ribbonStyle)
            {
                return UI.TabBar(this, y, current, tabNames, buttonsPerRow, buttonStyle, ribbonStyle);
            }
        }
    }
}