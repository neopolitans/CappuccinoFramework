using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;
using System;

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> CInspector is a simple Inspector layout that displays buttons to editor windows. <br></br>
        /// This is only recommended if you have an Editor Window specific to your object that you wish to be initializable from the inspector. <br></br><br></br>
        /// If you don't want to use the custom inspector, you can still use Capppucino methods inside default Unity Editor classes.
        /// </summary>
        public class CInspector : Editor
        {
            /// <summary>
            /// The Asset Loader to use for all subsequent assets. <br></br>
            /// <see langword="Cappuccino:"/> This has to be created during OnInspectorGUI and checked progressively if null or created on instantiation.
            /// </summary>
            protected CAssetLoader assetLoader;

            /// <summary>
            /// The name of the plugin to display on the header.
            /// </summary>
            protected string pluginName;

            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();
            }

            /// <summary>
            /// Draw a list of buttons for an Inspector which can trigger a range of functionality. <br></br><br></br>
            /// <see langword="Default:"/> This method defualts to displaying three buttons on a row, add an integer after the last parameter to change this.
            /// </summary>
            /// <param name="icon">The icon to use for the UI Box Element.</param>
            /// <param name="buttons">The buttons to draw and the delegates they call on activation.</param>
            protected void DrawEditorList(Texture icon, (UI.UIContent onButtonAction, string buttonName)[] buttons) => DrawEditorList(icon, buttons, 3);

            /// <summary>
            /// Draw a list of buttons for an Inspector which can trigger a range of functionality.
            /// </summary>
            /// <param name="icon">The icon to use for the UI Box Element.</param>
            /// <param name="buttons">The buttons to draw and the delegates they call on activation.</param>
            /// <param name="buttonsPerRow">The buttons </param>
            protected void DrawEditorList(Texture icon, (UI.UIContent onButtonAction, string buttonName)[] buttons, int buttonsPerRow)
            {
                // If there are no or less than 0 button contents, do not draw the editor list.
                if (buttons == null || buttons.Length <= 0)
                {
                    Diag.Violation("DrawEditorList cancelled. No supplied buttons to draw.");
                }

                UI.Horizontal(delegate
                {
                    // Draw Inspector Icon
                    GUILayout.Box(new GUIContent(icon), GUILayout.Width(48), GUILayout.Height(48));
                    UI.Space(10f);

                    // The index we'll be working with to assign buttons to.
                    int index = 0;

                    // The buttons left for the row we need to raw;
                    int buttonsLeftForRow;

                    // The amount of buttons to draw per iteration.
                    int iterations = buttons.Length > 1 ? Mathf.RoundToInt(buttons.Length / buttonsPerRow) : 1;

                    // Draw Info Panel
                    UI.Vertical(delegate
                    {
                        UI.Space(8f);
                        UI.Label(pluginName, EditorStyles.boldLabel);

                        // for all the iterations that
                        for (int n = 0; n < iterations; n++)
                        {
                            // if the index has hit or surpassed the size of the buttons to draw array, stop the loop.
                            if (index >= buttons.Length)
                            {
                                break;
                            }

                            // Reset the buttons per row per iteration
                            buttonsLeftForRow = buttonsPerRow;

                            // Draw the row of buttons for this iteration.
                            UI.Horizontal(delegate
                            {
                                // While our remaining buttons to draw is greater than 0 and our index is less than the length of the buttons to draw array
                                while (buttonsLeftForRow > 0 && index < buttons.Length)
                                {
                                    // if this button doesn't have an index associated, skip to the next button instead.
                                    // Does not decrease buttonsLefFrowRow, increases index to skip the button.
                                    if (buttons[index].onButtonAction == null)
                                    {
                                        Debug.LogWarning($"[Cappuccino] The following button ({buttons[index].buttonName}) doesn't have an onButtonClicked action assigned to it.");
                                        index++;

                                        continue;
                                    }

                                    if (UI.Button(buttons[index].buttonName))
                                    {
                                        buttons[index].onButtonAction();
                                    }

                                    // increment index, decrement buttonsLeftForRow.
                                    index++;
                                    buttonsLeftForRow--;
                                }
                            });
                        }

                        // Draw the spacer
                        UI.Space(12f);
                    }
                    );
                    UI.Space(15f);
                },
                UI.GetStyle(BaseStyle.DarkStormGrey), GUILayout.Width(290f));
            }

        }

    }
}