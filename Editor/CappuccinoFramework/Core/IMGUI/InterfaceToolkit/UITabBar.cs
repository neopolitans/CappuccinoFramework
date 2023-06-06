using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This script adds Tab Bar functionality for Editor Windows to use

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
            /// <see langword="Cappuccino:"/> Create a Tab Bar that allows users to select one of the tabs provided. <br></br><br></br>
            /// <b><see langword="Notice:"/></b> This variation expects you to have the equivalent of "No Tab" as the value <b>[-1]</b>.
            /// </summary>
            /// <param name="editor">The Editor to reference for size information.</param>
            /// <param name="y">The Y Position to draw the header at.</param>
            /// <param name="current">The current tab selected (as integer).</param>
            /// <param name="tabNames"> The tab names to use for buttons.</param>
            /// <returns></returns>
            public static int TabBar(CEditor editor, float y, int current, string[] tabNames)
            {
                // Draw the autolayout color block background for the TabBar buttons.
                Horizontal(delegate { Space(1f); }, UI.GetStyle(BaseStyle.EveningGrey), GUILayout.Height(22f));

                float currentX = 1.0f;

                for (int i = 0; i < tabNames.Length; i++)
                {
                    // Draw the button for the current int.
                    if (GUI.Button(new Rect(currentX, y, (editor.size.x / tabNames.Length - 1f), 19.5f), new GUIContent(tabNames[i]), UI.GetStyle(InteractiveStyle.WindowTopbarButton)))
                    {
                        current = current == i ? -1 : i;
                    }

                    // If this button is currently selected, draw an indication ribbon on top of it. This is always drawn, but the style is set to [GUIStyle.none] if not selected.
                    Label(new Rect(currentX, y, (editor.size.x / tabNames.Length - 1f), 2f), "", current == i ? UI.GetStyle(UnityStyle.WindowSelectionRibbon) : GUIStyle.none);

                    // Account for added width for this button.
                    currentX += (editor.size.x / tabNames.Length);
                }

                return current;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Tab Bar that allows users to select one of the tabs provided. <br></br><br></br>
            /// <b><see langword="Notice:"/></b> This variation expects you to have the equivalent of "No Tab" as the value <b>[-1]</b>.
            /// </summary>
            /// <param name="editor">The Editor to reference for size information.</param>
            /// <param name="y">The Y Position to draw the header at.</param>
            /// <param name="current">The current tab selected (as integer).</param>
            /// <param name="tabNames"> The tab names to use for buttons.</param>
            /// <param name="buttonStyle">The style to draw with for each Button.</param>
            /// <returns></returns>
            public static int TabBar(CEditor editor, float y, int current, string[] tabNames, GUIStyle buttonStyle)
            {
                Horizontal(delegate { Space(1f); }, UI.GetStyle(BaseStyle.EveningGrey), GUILayout.Height(22f));

                float currentX = 1.0f;

                for (int i = 0; i < tabNames.Length; i++)
                {
                    if (GUI.Button(new Rect(currentX, y, (editor.size.x / tabNames.Length - 1f), 19.5f), new GUIContent(tabNames[i]), buttonStyle))
                    {
                        current = current == i ? -1 : i;
                    }

                    Label(new Rect(currentX, y, (editor.size.x / tabNames.Length - 1f), 2f), "", current == i ? UI.GetStyle(UnityStyle.WindowSelectionRibbon) : GUIStyle.none);

                    currentX += (editor.size.x / tabNames.Length);
                }

                return current;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Tab Bar that allows users to select one of the tabs provided. <br></br><br></br>
            /// <b><see langword="Notice:"/></b> This variation expects you to have the equivalent of "No Tab" as the value <b>[-1]</b>.
            /// </summary>
            /// <param name="editor">The Editor to reference for size information.</param>
            /// <param name="y">The Y Position to draw the header at.</param>
            /// <param name="current">The current tab selected (as integer).</param>
            /// <param name="tabNames"> The tab names to use for buttons.</param>
            /// <param name="buttonStyle">The style to draw with for each Button.</param>
            /// <param name="ribbonStyle">The style to draw a tab's selected indication ribbon with.</param>
            /// <returns></returns>
            public static int TabBar(CEditor editor, float y, int current, string[] tabNames, GUIStyle buttonStyle, GUIStyle ribbonStyle)
            {
                Horizontal(delegate { Space(1f); }, UI.GetStyle(BaseStyle.EveningGrey), GUILayout.Height(22f));

                float currentX = 1.0f;

                for (int i = 0; i < tabNames.Length; i++)
                {
                    if (GUI.Button(new Rect(currentX, y, (editor.size.x / tabNames.Length - 1f), 19.5f), new GUIContent(tabNames[i]), buttonStyle))
                    {
                        current = current == i ? -1 : i;
                    }

                    Label(new Rect(currentX, y, (editor.size.x / tabNames.Length - 1f), 2f), "", current == i ? ribbonStyle : GUIStyle.none);

                    currentX += (editor.size.x / tabNames.Length);
                }

                return current;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Tab Bar that allows users to select one of the tabs provided. <br></br><br></br>
            /// <b><see langword="Notice:"/></b> This variation expects you to have the equivalent of "No Tab" as the value <b>[-1]</b>.
            /// </summary>
            /// <param name="editor">The Editor to reference for size information.</param>
            /// <param name="y">The Y Position to draw the header at.</param>
            /// <param name="current">The current tab selected (as integer).</param>
            /// <param name="tabNames"> The tab names to use for buttons.</param>
            /// <param name="buttonsPerRow">The amount of buttons per row to draw.</param>
            /// <returns></returns>
            public static int TabBar(CEditor editor, float y, int current, string[] tabNames, int buttonsPerRow)
            {
                // Draw the autolayout color block background for the TabBar buttons.
                Horizontal(delegate { Space(1f); }, UI.GetStyle(BaseStyle.EveningGrey), GUILayout.Height((22f * Mathf.Ceil(tabNames.Length / (float)buttonsPerRow))));

                float currentX = 1.0f;
                float currentY = y;

                for (int i = 1; i < tabNames.Length + 1; i++)
                {
                    // Draw the button for the current int.
                    if (GUI.Button(new Rect(currentX, currentY, (editor.size.x / buttonsPerRow - 1f), 20f), new GUIContent(tabNames[i - 1]), UI.GetStyle(InteractiveStyle.WindowTopbarButton)))
                    {
                        current = current == i - 1 ? -1 : i - 1;
                    }

                    // If this button is currently selected, draw an indication ribbon on top of it. This is always drawn, but the style is set to [GUIStyle.none] if not selected.
                    Label(new Rect(currentX, currentY, (editor.size.x / buttonsPerRow - 1f), 2f), "", current == i - 1 ? UI.GetStyle(UnityStyle.WindowSelectionRibbon) : GUIStyle.none);

                    // Account for added width for this button and descending height if the remainder of i % buttons per row hits zero.
                    currentY = (i % buttonsPerRow > 0) ? currentY : currentY + 22f;
                    currentX = (i % buttonsPerRow > 0) ? currentX + (editor.size.x / buttonsPerRow) : 1f;
                }

                return current;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Tab Bar that allows users to select one of the tabs provided. <br></br><br></br>
            /// <b><see langword="Notice:"/></b> This variation expects you to have the equivalent of "No Tab" as the value <b>[-1]</b>.
            /// </summary>
            /// <param name="editor">The Editor to reference for size information.</param>
            /// <param name="y">The Y Position to draw the header at.</param>
            /// <param name="current">The current tab selected (as integer).</param>
            /// <param name="tabNames"> The tab names to use for buttons.</param>
            /// <param name="buttonsPerRow">The amount of buttons per row to draw.</param>
            /// <param name="buttonStyle">The style to draw with for each Button.</param>
            /// <returns></returns>
            public static int TabBar(CEditor editor, float y, int current, string[] tabNames, int buttonsPerRow, GUIStyle buttonStyle)
            {
                // Draw the autolayout color block background for the TabBar buttons.
                Horizontal(delegate { Space(1f); }, UI.GetStyle(BaseStyle.EveningGrey), GUILayout.Height((22f * Mathf.Ceil(tabNames.Length / (float)buttonsPerRow))));

                float currentX = 1.0f;
                float currentY = y;

                for (int i = 1; i < tabNames.Length + 1; i++)
                {
                    // Draw the button for the current int.
                    if (GUI.Button(new Rect(currentX, currentY, (editor.size.x / buttonsPerRow - 1f), 20f), new GUIContent(tabNames[i - 1]), buttonStyle))
                    {
                        current = current == i - 1 ? -1 : i - 1;
                    }

                    // If this button is currently selected, draw an indication ribbon on top of it. This is always drawn, but the style is set to [GUIStyle.none] if not selected.
                    Label(new Rect(currentX, currentY, (editor.size.x / buttonsPerRow - 1f), 2f), "", current == i - 1 ? UI.GetStyle(UnityStyle.WindowSelectionRibbon) : GUIStyle.none);

                    // Account for added width for this button and descending height if the remainder of i % buttons per row hits zero.
                    currentY = (i % buttonsPerRow > 0) ? currentY : currentY + 22f;
                    currentX = (i % buttonsPerRow > 0) ? currentX + (editor.size.x / buttonsPerRow) : 1f;
                }

                return current;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Tab Bar that allows users to select one of the tabs provided. <br></br><br></br>
            /// <b><see langword="Notice:"/></b> This variation expects you to have the equivalent of "No Tab" as the value <b>[-1]</b>.
            /// </summary>
            /// <param name="editor">The Editor to reference for size information.</param>
            /// <param name="y">The Y Position to draw the header at.</param>
            /// <param name="current">The current tab selected (as integer).</param>
            /// <param name="tabNames"> The tab names to use for buttons.</param>
            /// <param name="buttonsPerRow">The amount of buttons per row to draw.</param>
            /// <param name="buttonStyle">The style to draw with for each Button.</param>
            /// <param name="ribbonStyle">The style to draw a tab's selected indication ribbon with.</param>
            /// <returns></returns>
            public static int TabBar(CEditor editor, float y, int current, string[] tabNames, int buttonsPerRow, GUIStyle buttonStyle, GUIStyle ribbonStyle)
            {
                // Draw the autolayout color block background for the TabBar buttons.
                Horizontal(delegate { Space(1f); }, UI.GetStyle(BaseStyle.EveningGrey), GUILayout.Height((22f * Mathf.Ceil(tabNames.Length / (float)buttonsPerRow))));

                float currentX = 1.0f;
                float currentY = y;

                for (int i = 1; i < tabNames.Length + 1; i++)
                {
                    // Draw the button for the current int.
                    if (GUI.Button(new Rect(currentX, currentY, (editor.size.x / buttonsPerRow - 1f), 20f), new GUIContent(tabNames[i - 1]), buttonStyle))
                    {
                        current = current == i - 1 ? -1 : i - 1;
                    }

                    // If this button is currently selected, draw an indication ribbon on top of it. This is always drawn, but the style is set to [GUIStyle.none] if not selected.
                    Label(new Rect(currentX, currentY, (editor.size.x / buttonsPerRow - 1f), 2f), "", current == i - 1 ? ribbonStyle : GUIStyle.none);

                    // Account for added width for this button and descending height if the remainder of i % buttons per row hits zero.
                    currentY = (i % buttonsPerRow > 0) ? currentY : currentY + 22f;
                    currentX = (i % buttonsPerRow > 0) ? currentX + (editor.size.x / buttonsPerRow) : 1f;
                }

                return current;
            }

            // Experimental, can be re-enabled.
            // Not comaptible with buttonsPerRow, an arguably more important and useful feature.
            /*
            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Tab Bar that allows users to select one of the tabs provided.
            /// </summary>
            /// <param name="editor">The Editor to reference for size information.</param>
            /// <param name="y">The Y Position to draw the header at.</param>
            /// <param name="current">The current tab selected (as integer).</param>
            /// <param name="tabNames"> The tab names to use for buttons.</param>
            /// <param name="isZeroDefault">Is the integer 0 used as the default tab (None or Generic) - For Enum or Int type.</param>
            /// <returns></returns>
            public static int TabBar(CEditor editor, float y, int current, string[] tabNames, bool isZeroDefault)
            {
                if (isZeroDefault)
                {
                    UI.Horizontal(delegate { UI.Space(1f); }, CUtil.GetStyle(BaseStyle.EveningGrey), GUILayout.Height(22f));

                    float currentX = 1.0f;

                    for (int i = 1; i < tabNames.Length + 1; i++)
                    {
                        if (GUI.Button(new Rect(currentX, y, (editor.size.x / tabNames.Length - 1f), 19.5f), new GUIContent(tabNames[i - 1]), CUtil.GetStyle(InteractiveStyle.WindowTopbarButton)))
                        {
                            current = current == i ? 0 : i;
                        }

                        UI.Label(new Rect(currentX, y, (editor.size.x / tabNames.Length - 1f), 2f), "", current == i ? CUtil.GetStyle(UnityStyle.WindowSelectionRibbon) : GUIStyle.none);

                        currentX += (editor.size.x / tabNames.Length);
                    }

                    return current;
                }
                else
                {
                    UI.Horizontal(delegate { UI.Space(1f); }, CUtil.GetStyle(BaseStyle.EveningGrey), GUILayout.Height(22f));

                    float currentX = 1.0f;

                    for (int i = 0; i < tabNames.Length; i++)
                    {
                        if (GUI.Button(new Rect(currentX, y, (editor.size.x / tabNames.Length - 1f), 19.5f), new GUIContent(tabNames[i]), CUtil.GetStyle(InteractiveStyle.WindowTopbarButton)))
                        {
                            current = current == i ? -1 : i;
                        }

                        UI.Label(new Rect(currentX, y, (editor.size.x / tabNames.Length - 1f), 2f), "", current == i ? CUtil.GetStyle(UnityStyle.WindowSelectionRibbon) : GUIStyle.none);

                        currentX += (editor.size.x / tabNames.Length);
                    }

                    return current;
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Tab Bar that allows users to select one of the tabs provided.
            /// </summary>
            /// <param name="editor">The Editor to reference for size information.</param>
            /// <param name="y">The Y Position to draw the header at.</param>
            /// <param name="current">The current tab selected (as integer).</param>
            /// <param name="tabNames"> The tab names to use for buttons.</param>
            /// <param name="isZeroDefault">Is the integer 0 used as the default tab (None or Generic) - For Enum or Int type.</param>
            /// <param name="buttonStyle">The style to draw with for each Button.</param>
            /// <returns></returns>
            public static int TabBar(CEditor editor, float y, int current, string[] tabNames, bool isZeroDefault, GUIStyle buttonStyle)
            {
                if (isZeroDefault)
                {
                    UI.Horizontal(delegate { UI.Space(1f); }, CUtil.GetStyle(BaseStyle.EveningGrey), GUILayout.Height(22f));

                    float currentX = 1.0f;

                    for (int i = 1; i < tabNames.Length + 1; i++)
                    {
                        if (GUI.Button(new Rect(currentX, y, (editor.size.x / tabNames.Length - 1f), 19.5f), new GUIContent(tabNames[i - 1]), buttonStyle))
                        {
                            current = current == i ? 0 : i;
                        }

                        UI.Label(new Rect(currentX, y, (editor.size.x / tabNames.Length - 1f), 2f), "", current == i ? CUtil.GetStyle(UnityStyle.WindowSelectionRibbon) : GUIStyle.none);

                        currentX += (editor.size.x / tabNames.Length);
                    }

                    return current;
                }
                else
                {
                    UI.Horizontal(delegate { UI.Space(1f); }, CUtil.GetStyle(BaseStyle.EveningGrey), GUILayout.Height(22f));

                    float currentX = 1.0f;

                    for (int i = 0; i < tabNames.Length; i++)
                    {
                        if (GUI.Button(new Rect(currentX, y, (editor.size.x / tabNames.Length - 1f), 19.5f), new GUIContent(tabNames[i]), buttonStyle))
                        {
                            current = current == i ? -1 : i;
                        }

                        UI.Label(new Rect(currentX, y, (editor.size.x / tabNames.Length - 1f), 2f), "", current == i ? CUtil.GetStyle(UnityStyle.WindowSelectionRibbon) : GUIStyle.none);

                        currentX += (editor.size.x / tabNames.Length);
                    }

                    return current;
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Create a Tab Bar that allows users to select one of the tabs provided.
            /// </summary>
            /// <param name="editor">The Editor to reference for size information.</param>
            /// <param name="y">The Y Position to draw the header at.</param>
            /// <param name="current">The current tab selected (as integer).</param>
            /// <param name="tabNames"> The tab names to use for buttons.</param>
            /// <param name="isZeroDefault">Is the integer 0 used as the default tab (None or Generic) - For Enum or Int type.</param>
            /// <param name="buttonStyle">The style to draw with for each Button.</param>
            /// <param name="ribbonStyle">The style to draw a tab's selected indication ribbon with.</param>
            /// <returns></returns>
            public static int TabBar(CEditor editor, float y, int current, string[] tabNames, bool isZeroDefault, GUIStyle buttonStyle, GUIStyle ribbonStyle)
            {
                if (isZeroDefault)
                {
                    UI.Horizontal(delegate { UI.Space(1f); }, CUtil.GetStyle(BaseStyle.EveningGrey), GUILayout.Height(22f));

                    float currentX = 1.0f;

                    for (int i = 1; i < tabNames.Length + 1; i++)
                    {
                        if (GUI.Button(new Rect(currentX, y, (editor.size.x / tabNames.Length - 1f), 19.5f), new GUIContent(tabNames[i - 1]), buttonStyle))
                        {
                            current = current == i ? 0 : i;
                        }

                        UI.Label(new Rect(currentX, y, (editor.size.x / tabNames.Length - 1f), 2f), "", current == i ? ribbonStyle : GUIStyle.none);

                        currentX += (editor.size.x / tabNames.Length);
                    }

                    return current;
                }
                else
                {
                    UI.Horizontal(delegate { UI.Space(1f); }, CUtil.GetStyle(BaseStyle.EveningGrey), GUILayout.Height(22f));

                    float currentX = 1.0f;

                    for (int i = 0; i < tabNames.Length; i++)
                    {
                        if (GUI.Button(new Rect(currentX, y, (editor.size.x / tabNames.Length - 1f), 19.5f), new GUIContent(tabNames[i]), buttonStyle))
                        {
                            current = current == i ? -1 : i;
                        }

                        UI.Label(new Rect(currentX, y, (editor.size.x / tabNames.Length - 1f), 2f), "", current == i ? ribbonStyle : GUIStyle.none);

                        currentX += (editor.size.x / tabNames.Length);
                    }

                    return current;
                }
            }*/
        }
    }
}