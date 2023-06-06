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
        public class GraphToolbar : VisualElement
        {
            /// <summary>
            /// The graph that this toolbar is attached to.
            /// </summary>
            protected CGraphInstance graph;

            /// <summary>
            /// The button that invoked displaying the current dropdown.
            /// </summary>
            protected Button dropdownInvoker;

            /// <summary>
            /// The current dropdown 
            /// </summary>
            public GraphDropdown currentDropdown;

            // Variables
            // - Private Variables
            #region Toolbar Color Values
            /// <summary>
            /// The background color for the default graph toolbar.
            /// </summary>
            protected static Color toolbar_background_color = C255.Color(0, 0, 0, 140);

            /// <summary>
            /// The background color for the default graph toolbar.
            /// </summary>
            protected static Color toolbar_border_color = C255.Color(52, 52, 52, 192);

            /// <summary>
            /// The background color for the text on the zoom label.
            /// </summary>
            protected static Color toolbar_zoom_label_color = C255.Color(210, 210, 210, 128);

            /// <summary>
            /// The base color for a toolbar button when it is not hovered, focused or active.
            /// </summary>
            protected static Color toolbar_button_base_color = C255.Color(255, 255, 255, 64);

            /// <summary>
            /// The base color for a toolbar button when it is hovered.
            /// </summary>
            protected static Color toolbar_button_hover_color = C255.Color(255, 255, 255, 128);

            /// <summary>
            /// The base color for a toolbar button when it is hovered, focused or active.
            /// </summary>
            protected static Color toolbar_button_active_color = C255.Color(255, 255, 255, 220);
            #endregion

            #region Toolbar Margin Variables

            /// <summary>
            /// The margin size provided for the margin-left and margin-right style sheet variabes.
            /// </summary>
            protected const float toolbar_button_margins = 1f;

            #endregion

            // - Public Variables
            public bool hasFocus;

            // Constructors
            /// <summary>
            /// Create a GraphToolbar instance for the provided CGraphInstance.
            /// </summary>
            /// <param name="graph"></param>
            public GraphToolbar(CGraphInstance graph)
            {
                this.graph = graph;
                AddToClassList("cappuccino-graph__toolbar-container");
                this.StretchToParentWidth();
                AddToolbarCallbacks();

                Contents();
            }

            // Methods
            /// <summary>
            /// The contents to fill the toolbar with. <br></br><br></br>
            /// <see langword="Cappuccino:"/> If you wish to have the zoom functionality without this <see cref="CreateZoomLabel"/> exists, which this uses as the base. <br></br>
            /// CreateZoomLabel returns a label which can be either immediately added or manipulated for a desired result.
            /// </summary>
            protected virtual void Contents()
            {
                Insert(childCount, CreateZoomLabel());
            }

            protected virtual void AddToolbarCallbacks()
            {
                // Used for tracking when the graph is in focus or not.
                // If the mouse clicks on the element, the dropdown is in focus. If it clicks on anything else, it loses focus.
                RegisterCallback(delegate (FocusEvent f_evt) { hasFocus = true; });
                RegisterCallback(delegate (BlurEvent b_evt) { hasFocus = false; });
            }

            /// <summary>
            /// Create a zoom label. <br></br>
            /// This is returned to whichever function calls it so that said function can manipulate the element before inserting it.
            /// </summary>
            /// <returns></returns>
            protected virtual Label CreateZoomLabel()
            {
                // Zoom Label
                Label zoom = new Label("Zoom: " + graph.scale.ToString("F2")); // Turns out to display a floating-point with only two decimal places, you can provide a formatter in ToString.
                zoom.AddToClassList("cappuccino-graph__zoom-label");

                // When the view transform is changed, update the zoom accordingly.
                graph.viewTransformChanged += delegate (GraphView changedView)
                {
                    zoom.text = "Zoom: " + changedView.scale.ToString("F2");
                };

                return zoom;
            }

            /// <summary>
            /// Add a divider to the toolbar.<br></br>
            /// The divider will align horizontally rather than vertically by default.
            /// </summary>
            protected virtual void AddDivider()
            {
                VisualElement divider = new VisualElement();
                divider.AddToClassList("cappuccino-graph__toolbar__divider");

                Insert(childCount, divider);
            }

            /// <summary>
            /// Add a button to the toolbar with the provided display text, which triggers a delegate on clicked.
            /// </summary>
            /// <param name="displayText">The text to display on the button</param>
            /// <param name="onClicked">The action to execute when the button is clicked.</param>
            /// <returns></returns>
            protected virtual Button AddButton(string displayText, System.Action onClicked)
            {
                Button newButton = new Button(onClicked) { text = displayText };
                newButton.AddToClassList("cappuccino-graph__toolbar__button");

                Insert(childCount, newButton);

                return newButton;
            }

            /// <summary>
            /// Add a generic dropdown menu as the current focused dropdown menu. 
            /// </summary>
            /// <param name="button">The button to align the dropdown menu with.</param>
            protected virtual void AddDropdown(Button button)
            {
                if (currentDropdown != null && graph.Contains(currentDropdown))
                {
                    graph.Remove(currentDropdown);
                }

                dropdownInvoker = button;
                currentDropdown = new GraphDropdown(graph);

                currentDropdown.OnGeometryChanged(delegate
                {
                    currentDropdown.style.marginLeft = new StyleLength(button.worldBound.position.x - toolbar_button_margins);
                });

                graph.Insert(graph.childCount, currentDropdown);
            }

            /// <summary>
            /// Add a dropdown menu with the provided constructor as the current focused dropdown menu. 
            /// </summary>
            /// <param name="button">The button to align the dropdown menu with.</param>
            protected virtual void AddDropdown(Button button, DropdownConstructor constructor)
            {
                if (currentDropdown != null && graph.Contains(currentDropdown))
                {
                    graph.Remove(currentDropdown);
                }

                dropdownInvoker = button;
                currentDropdown = constructor(graph);

                currentDropdown.OnGeometryChanged(delegate
                {
                    currentDropdown.style.marginLeft = new StyleLength(button.worldBound.position.x - toolbar_button_margins - 1f);
                });

                graph.Insert(graph.childCount, currentDropdown);
            }

            /// <summary>
            /// Remove the current dropdown from the graph.
            /// </summary>
            public virtual void RemoveDropdown()
            {
                if (currentDropdown != null && graph.Contains(currentDropdown))
                {
                    graph.Remove(currentDropdown);
                }

                dropdownInvoker = null;
                currentDropdown = null;
            }

            /// <summary>
            /// A Constructor that's passed through on <see cref="AddDropdown(Button, DropdownConstructor)"/>. <br></br> 
            /// Allows the toolbar to create and setup <i>custom or context-specific</i> dropdowns.
            /// </summary>
            /// <param name="graph"></param>
            /// <returns></returns>
            public delegate GraphDropdown DropdownConstructor(CGraphInstance graph);

            #region Style Sheets

            [ExportSheet(FrameworkUtilities.dirInAssets + "Core/UIToolkit/GraphWindow/StyleSheets", true)]
            public static Sheet ToolbarStyle() => new Sheet("CappuccinoGraphToolbarStyle",

                // Cappuccino Graph Toolbar: Used to define the style of the toolbar's body.
                SimpleSelector.Class("cappuccino-graph__toolbar-container",
                    Rules.MinHeight(new Len(30)),
                    Rules.Height(new Len(30)),
                    Rules.BackgroundColor(toolbar_background_color),
                    Rules.BorderBottomColor(toolbar_border_color),
                    Rules.BorderLeftColor(toolbar_border_color),
                    Rules.BorderTopColor(toolbar_border_color),
                    Rules.BorderRightColor(toolbar_border_color),
                    Rules.BorderBottomWidth(new Len(1)),
                    Rules.BorderLeftWidth(new Len(1)),
                    Rules.BorderTopWidth(new Len(1)),
                    Rules.BorderRightWidth(new Len(1)),
                    Rules.BorderBottomLeftRadius(new Len(5)),
                    Rules.BorderTopLeftRadius(new Len(5)),
                    Rules.BorderBottomRightRadius(new Len(5)),
                    Rules.BorderTopRightRadius(new Len(5)),
                    Rules.MarginTop(new Len(4)),
                    Rules.MarginLeft(new Len(4)),
                    Rules.MarginRight(new Len(4)),
                    Rules.FlexDirection(Rules.FlexDirectionValue.row) // Horizontal alignment instead of vertical.
                    ),

                // Cappuccino Graph Toolbar - Divider: Used to define the style of the toolbar's dividers.
                SimpleSelector.Class("cappuccino-graph__toolbar__divider",
                    Rules.BackgroundColor(C255.Color(255, 255, 255, 32)),
                    Rules.MinHeight(new Len(17)),
                    Rules.Height(new Len(17)),
                    Rules.MaxHeight(new Len(17)),
                    Rules.Width(new Len(0.67f)),
                    Rules.MarginLeft(new Len(6)),
                    Rules.MarginRight(new Len(5)),
                    Rules.MarginTop(new Len(5))
                    ),

                // Cappuccino Graph Toolbar - Button (Default): Used to define the {default} state of a toolbar button.
                SimpleSelector.Class("cappuccino-graph__toolbar__button",
                    Rules.BackgroundColor(C255.Color(255, 255, 255, 0)),
                    Rules.BorderBottomColor(C255.Color(0, 0, 0, 0)),
                    Rules.BorderTopColor(C255.Color(0, 0, 0, 0)),
                    Rules.BorderLeftColor(C255.Color(0, 0, 0, 0)),
                    Rules.BorderRightColor(C255.Color(0, 0, 0, 0)),
                    Rules.BorderBottomLeftRadius(new Len(3)),
                    Rules.BorderTopLeftRadius(new Len(3)),
                    Rules.BorderBottomRightRadius(new Len(3)),
                    Rules.BorderTopRightRadius(new Len(3)),
                    Rules.PaddingLeft(new Len(4)),
                    Rules.PaddingRight(new Len(4)),
                    Rules.MarginLeft(new Len(toolbar_button_margins)),
                    Rules.MarginRight(new Len(0)),
                    Rules.MarginTop(new Len(toolbar_button_margins)),
                    Rules.Color(toolbar_button_base_color),
                    Rules.UnityFontStyle(Rules.FontStyleValue.bold),
                    Rules.TextAlign(Rules.TextAlignValue.middleLeft)
                    ),

                // Cappuccino Graph Toolbar - Button (Default): Used to define the {hover} state of a toolbar button.
                SimpleSelector.Class("cappuccino-graph__toolbar__button", new Pseudoclass[] { Pseudoclass.Hover() },
                    Rules.BackgroundColor(C255.Color(255, 255, 255, 10)),
                    Rules.BorderBottomColor(C255.Color(0, 0, 0, 0)),
                    Rules.BorderTopColor(C255.Color(0, 0, 0, 0)),
                    Rules.BorderLeftColor(C255.Color(0, 0, 0, 0)),
                    Rules.BorderRightColor(C255.Color(0, 0, 0, 0)),
                    Rules.Color(toolbar_button_hover_color)
                    ),

                // Cappuccino Graph Toolbar - Button (Default): Used to define the {hover and active} state of a toolbar button.
                SimpleSelector.Class("cappuccino-graph__toolbar__button", new Pseudoclass[] { Pseudoclass.Hover(), Pseudoclass.Active() },
                    Rules.BackgroundColor(C255.Color(255, 255, 255, 30)),
                    Rules.BorderBottomColor(C255.Color(0, 0, 0, 0)),
                    Rules.BorderTopColor(C255.Color(0, 0, 0, 0)),
                    Rules.BorderLeftColor(C255.Color(0, 0, 0, 0)),
                    Rules.BorderRightColor(C255.Color(0, 0, 0, 0)),
                    Rules.Color(toolbar_button_active_color)
                    ),

                // Cappuccino Graph Toolbar - Zoom Level: Used to define the style of the graph's zoom level label in the toolbar.
                ComplexSelector.Child(new SimpleSelector[] {
                    SimpleSelector.Class("cappuccino-graph__toolbar-container"),
                    SimpleSelector.Class("cappuccino-graph__zoom-label")
                    },
                    Rules.Color(toolbar_zoom_label_color),
                    Rules.MinHeight(new Len(26)),
                    Rules.Height(new Len(26)),
                    Rules.MinWidth(new Len(80)),
                    Rules.MaxWidth(new Len(80)),
                    Rules.MarginLeft(new Len(4)),
                    Rules.MarginTop(new Len(0.67f)),
                    Rules.FontSize(new Len(14)),
                    Rules.UnityFontStyle(Rules.FontStyleValue.bold),
                    Rules.TextAlign(Rules.TextAlignValue.middleLeft)
                    )
                );
            #endregion
        }
    }
}