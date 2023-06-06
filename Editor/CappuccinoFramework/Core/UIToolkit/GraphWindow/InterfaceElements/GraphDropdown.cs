using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

using UnityEditor.Experimental.GraphView;

using Cappuccino.Core;
using Cappuccino.Interpreters.Languages.USS;

namespace Cappuccino
{
    namespace Graphing
    {
        public class GraphDropdown : VisualElement
        {
            protected CGraphInstance graph;

            /// <summary>
            /// Whether or not the dropdown is in focus.
            /// </summary>
            public bool mouseInElement;
            public bool hasFocus;

            // Variables
            // - Private Variables
            #region Dropdown Color Values
            /// <summary>
            /// The background color for the default graph toolbar.
            /// </summary>
            protected static Color dropdown_background_color = C255.Color(0, 0, 0, 140);

            /// <summary>
            /// The background color for the default graph toolbar.
            /// </summary>
            protected static Color dropdown_border_color = C255.Color(52, 52, 52, 192);

            /// <summary>
            /// The background color for the text on the zoom label.
            /// </summary>
            protected static Color dropdown_zoom_label_color = C255.Color(210, 210, 210, 128);

            /// <summary>
            /// The base color for a toolbar button when it is not hovered, focused or active.
            /// </summary>
            protected static Color dropdown_button_base_color = C255.Color(255, 255, 255, 64);

            /// <summary>
            /// The base color for a toolbar button when it is hovered.
            /// </summary>
            protected static Color dropdown_button_hover_color = C255.Color(255, 255, 255, 128);

            /// <summary>
            /// The base color for a toolbar button when it is hovered, focused or active.
            /// </summary>
            protected static Color dropdown_button_active_color = C255.Color(255, 255, 255, 220);
            #endregion

            // Constructors
            /// <summary>
            /// Create a GraphToolbar instance for the provided CGraphInstance.
            /// </summary>
            /// <param name="graph"></param>
            public GraphDropdown(CGraphInstance graph)
            {
                this.focusable = true;

                this.graph = graph;
                AddToClassList("cappuccino-graph__toolbar-dropdown");
                this.StretchToParentWidth();
                AddMouseCallbacks();

                Content();
            }

            /// <summary>
            /// Add mouse-based callbacks to this visual element.
            /// </summary>
            protected virtual void AddMouseCallbacks()
            {
                // Whenever the mouse has entered the dropdown, set mouseInElement to true.
                // Whenever the mouse has exited the dropdown, set mouseInElement to false.
                RegisterCallback(delegate (MouseEnterEvent evt) { mouseInElement = true; });
                RegisterCallback(delegate (MouseLeaveEvent evt) { mouseInElement = false;  });

                // Used for tracking when the graph is in focus or not.
                // If the mouse clicks on the element, the dropdown is in focus. If it clicks on anything else, it loses focus.
                RegisterCallback(delegate (FocusEvent f_evt) { hasFocus = true; });
                RegisterCallback(delegate (BlurEvent b_evt) { hasFocus = false; });

                // OnMouseDownConstant is custom-made, not provided by Unity. 
                // If the graph generates a click event but the mouse isn't in the dropdown, remove the dropdown.
                graph.contentContainer.OnMouseDownConstant(delegate (MouseDownEvent evt)
                {
                    if (!mouseInElement && graph.toolbar.currentDropdown == this)
                    {
                        graph.toolbar.RemoveDropdown();
                    }
                });
            }

            // Methods
            /// <summary>
            /// The contents to fill the dropdown with.
            /// </summary>
            protected virtual void Content()
            {
                AddDivider();
            }

            /// <summary>
            /// Add a divider to the dropdown menu.
            /// </summary>
            protected virtual void AddDivider()
            {
                VisualElement divider = new VisualElement();
                divider.AddToClassList("cappuccino-graph__toolbar-dropdown__divider");

                Insert(childCount, divider);
            }

            /// <summary>
            /// Add a button to the dropdown with the provided display text, which triggers a delegate on clicked.
            /// </summary>
            /// <param name="displayText">The text to display on the button</param>
            /// <param name="onClicked">The action to execute when the button is clicked.</param>
            /// <returns></returns>
            protected virtual void AddButton(string name, System.Action onClicked)
            {
                Button newButton = new Button(onClicked) { text = name };
                newButton.AddToClassList("cappuccino-graph__toolbar-dropdown__button");

                Insert(childCount, newButton);
            }

            /// <summary>
            /// Add a button to the dropdown with the provided display text, which triggers a delegate on clicked.
            /// </summary>
            /// <param name="displayText">The text to display on the button</param>
            /// <param name="onClicked">The action to execute when the button is clicked.</param>
            /// <returns></returns>
            protected virtual void AddButton(string name, string tip, System.Action onClicked)
            {
                Button newButton = new Button(onClicked) { text = name, tooltip = tip };
                newButton.AddToClassList("cappuccino-graph__toolbar-dropdown__button");

                Insert(childCount, newButton);
            }

            #region Style Sheets

            [ExportSheet(FrameworkUtilities.dirInAssets + "Core/UIToolkit/GraphWindow/StyleSheets", true)]
            public static Sheet ToolbarStyle() => new Sheet("CappuccinoGraphToolbarDropdownStyle",

                // Cappuccino Graph Toolbar: Used to define the style of the toolbar's body.
                SimpleSelector.Class("cappuccino-graph__toolbar-dropdown",
                    Rules.MinWidth(new Len(30)),
                    Rules.Width(new Len(140f)),
                    Rules.MaxWidth(new Len(240)),
                    Rules.MinHeight(new Len(30)),
                    Rules.MaxHeight(new Len(512)),
                    Rules.BackgroundColor(dropdown_background_color),
                    Rules.BorderBottomColor(dropdown_border_color),
                    Rules.BorderLeftColor(dropdown_border_color),
                    Rules.BorderTopColor(dropdown_border_color),
                    Rules.BorderRightColor(dropdown_border_color),
                    Rules.BorderBottomWidth(new Len(1)),
                    Rules.BorderLeftWidth(new Len(1)),
                    Rules.BorderTopWidth(new Len(1)),
                    Rules.BorderRightWidth(new Len(1)),
                    Rules.BorderBottomLeftRadius(new Len(5)),
                    Rules.BorderTopLeftRadius(new Len(5)),
                    Rules.BorderBottomRightRadius(new Len(5)),
                    Rules.BorderTopRightRadius(new Len(5)),
                    Rules.MarginTop(new Len(36)),
                    Rules.MarginLeft(new Len(4)),
                    Rules.MarginRight(new Len(4)),
                    Rules.FlexDirection(Rules.FlexDirectionValue.column) // Force Vertical Alignment
                    ),

                // Cappuccino Graph Toolbar - Divider: Used to define the style of the toolbar's dividers.
                SimpleSelector.Class("cappuccino-graph__toolbar-dropdown__divider",
                    Rules.BackgroundColor(C255.Color(255, 255, 255, 32)),
                    Rules.MinWidth(new Len(30)),
                    Rules.MaxWidth(new Len(240)),
                    Rules.Height(new Len(0.67f)),     
                    Rules.MarginLeft(new Len(4)),
                    Rules.MarginRight(new Len(4)),
                    Rules.Position(Rules.PositionValue.relative) // Force the divider to position itself relative to it's neighbouring elements.
                    ),

                // Cappuccino Graph Toolbar - Button (Default): Used to define the {default} state of a toolbar button.
                SimpleSelector.Class("cappuccino-graph__toolbar-dropdown__button",
                    Rules.BackgroundColor(C255.Color(255, 255, 255, 0)),
                    Rules.BorderBottomColor(C255.Color(0, 0, 0, 0)),
                    Rules.BorderTopColor(C255.Color(0, 0, 0, 0)),
                    Rules.BorderLeftColor(C255.Color(0, 0, 0, 0)),
                    Rules.BorderRightColor(C255.Color(0, 0, 0, 0)),
                    Rules.BorderBottomLeftRadius(new Len(3)),
                    Rules.BorderTopLeftRadius(new Len(3)),
                    Rules.BorderBottomRightRadius(new Len(3)),
                    Rules.BorderTopRightRadius(new Len(3)),
                    Rules.PaddingLeft(new Len(2)),
                    Rules.PaddingRight(new Len(2)),
                    Rules.MarginLeft(new Len(2)),
                    Rules.MarginRight(new Len(2)),
                    Rules.MarginTop(new Len(2)),
                    Rules.MarginBottom(new Len(2)),
                    Rules.Color(dropdown_button_base_color),
                    Rules.UnityFontStyle(Rules.FontStyleValue.bold),
                    Rules.TextAlign(Rules.TextAlignValue.middleLeft)
                    ),

                // Cappuccino Graph Toolbar - Button (Default): Used to define the {hover} state of a toolbar button.
                SimpleSelector.Class("cappuccino-graph__toolbar-dropdown__button", new Pseudoclass[] { Pseudoclass.Hover() },
                    Rules.BackgroundColor(C255.Color(255, 255, 255, 10)),
                    Rules.BorderBottomColor(C255.Color(0, 0, 0, 0)),
                    Rules.BorderTopColor(C255.Color(0, 0, 0, 0)),
                    Rules.BorderLeftColor(C255.Color(0, 0, 0, 0)),
                    Rules.BorderRightColor(C255.Color(0, 0, 0, 0)),
                    Rules.Color(dropdown_button_hover_color),
                    Rules.UnityFontStyle(Rules.FontStyleValue.bold),
                    Rules.TextAlign(Rules.TextAlignValue.middleLeft)
                    ),

                // Cappuccino Graph Toolbar - Button (Default): Used to define the {hover and active} state of a toolbar button.
                SimpleSelector.Class("cappuccino-graph__toolbar-dropdown__button", new Pseudoclass[] { Pseudoclass.Hover(), Pseudoclass.Active() },
                    Rules.BackgroundColor(C255.Color(255, 255, 255, 30)),
                    Rules.BorderBottomColor(C255.Color(0, 0, 0, 0)),
                    Rules.BorderTopColor(C255.Color(0, 0, 0, 0)),
                    Rules.BorderLeftColor(C255.Color(0, 0, 0, 0)),
                    Rules.BorderRightColor(C255.Color(0, 0, 0, 0)),
                    Rules.Color(dropdown_button_active_color),
                    Rules.UnityFontStyle(Rules.FontStyleValue.bold),
                    Rules.TextAlign(Rules.TextAlignValue.middleLeft)
                    )
                );
            #endregion
        }
    }
}