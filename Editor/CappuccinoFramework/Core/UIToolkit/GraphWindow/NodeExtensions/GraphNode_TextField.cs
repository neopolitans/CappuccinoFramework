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
        /// <summary>
        /// A custom node built directly off of GraphView.Node. <br></br><br></br>
        /// <see langword="Cappuccino:"/> This class is used exclusively with the Graphing namespace. <br></br>
        /// It contains the base node and extra behaviours for simplifying the node creation process.
        /// </summary>
        public partial class GraphNode : Node
        {
            #region Text Field Colors

            protected static Color text_field_inactive_color = C255.Color(19, 22, 19, 0);
            protected static Color text_field_border_inactive_color = C255.Color(138, 139, 138, 16);

            protected static Color text_field_hover_color = C255.Color(19, 22, 19, 32);
            protected static Color text_field_border_hover_color = C255.Color(138, 139, 138, 64);

            protected static Color text_field_focus_color = C255.Color(19, 22, 19, 64);
            protected static Color text_field_border_focus_color = C255.Color(196, 198, 196, 192);

            #endregion

            /// <summary>
            /// Create a text field with a field name. <br></br><br></br>
            /// <see langword="Cappuccino:"/> To create an EventCallback for a text field, create a <b>void</b> method which has a parameter for <see href="https://docs.unity3d.com/Manual/UIE-Events-Handling.html#:~:text=Listen%20to%20value%20changes">ChangeEvent</see>&lt;<see langword="string"/>&gt;
            /// </summary>
            /// <param name="fieldName"></param>
            /// <param name="onStringChanged"></param>
            public virtual void AddTextField(string fieldName, EventCallback<ChangeEvent<string>> onStringChanged)
            {
                TextField newTextField = new TextField()
                {
                    label = fieldName
                };

                newTextField.RegisterValueChangedCallback(onStringChanged);

                extensionContainer.Insert(extensionContainer.childCount, newTextField);
            }

            /// <summary>
            /// Create a text field with a field name, specifying which parent VisualElement to add it to. <br></br><br></br>
            /// <see langword="Cappuccino:"/> To create an EventCallback for a text field, create a <b>void</b> method which has a parameter for <see href="https://docs.unity3d.com/Manual/UIE-Events-Handling.html#:~:text=Listen%20to%20value%20changes">ChangeEvent</see>&lt;<see langword="string"/>&gt;
            /// </summary>
            /// <param name="fieldName"></param>
            /// <param name="onStringChanged"></param>
            public virtual void AddTextField(string fieldName, VisualElement parent, EventCallback<ChangeEvent<string>> onStringChanged)
            {
                TextField newTextField = new TextField()
                {
                    label = fieldName
                };

                newTextField.RegisterValueChangedCallback(onStringChanged);

                parent.Insert(extensionContainer.childCount, newTextField);
            }

            //[ExportSheet(FrameworkUtilities.dirInAssets + "Core/UIToolkit/GraphWindow/StyleSheets/InteractiveElementSheets/", true)]
            public static Sheet TextFieldSheet() => new Sheet("CappuccinoNodeExtensionContainerTextField",

                // Text Label Container - Change the min-width to 75px.
                ComplexSelector.Child(new SimpleSelector[] {
                    SimpleSelector.Class("node"),
                    SimpleSelector.Name("node-border"),
                    SimpleSelector.Name("contents"),
                    SimpleSelector.Name("collapsible-area"),
                    SimpleSelector.Name("extension"),
                    SimpleSelector.Class("unity-text-field"),
                    SimpleSelector.Class("unity-label")
                    },
                    Rules.MinWidth(new Len(75))
                    ),

                // Text Field Container - Default Behaviour
                ComplexSelector.Child(new SimpleSelector[] {
                    SimpleSelector.Class("node"),
                    SimpleSelector.Name("node-border"),
                    SimpleSelector.Name("contents"),
                    SimpleSelector.Name("collapsible-area"),
                    SimpleSelector.Name("extension"),
                    SimpleSelector.Class("unity-text-field"),
                    SimpleSelector.Name("unity-text-input")
                    },
                    Rules.BackgroundColor(text_field_inactive_color),
                    Rules.BorderTopColor(text_field_border_inactive_color),
                    Rules.BorderRightColor(text_field_border_inactive_color),
                    Rules.BorderBottomColor(text_field_border_inactive_color),
                    Rules.BorderLeftColor(text_field_border_inactive_color),
                    Rules.BorderTopWidth(new Len(1)),
                    Rules.BorderRightWidth(new Len(1)),
                    Rules.BorderBottomWidth(new Len(1)),
                    Rules.BorderLeftWidth(new Len(1)),
                    Rules.BorderTopRightRadius(new Len(2)),
                    Rules.BorderTopLeftRadius(new Len(2)),
                    Rules.BorderBottomRightRadius(new Len(2)),
                    Rules.BorderBottomLeftRadius(new Len(2))
                    ),

                // Text Field Container - Hover Behaviour
                ComplexSelector.Child(new SimpleSelector[] {
                    SimpleSelector.Class("node"),
                    SimpleSelector.Name("node-border"),
                    SimpleSelector.Name("contents"),
                    SimpleSelector.Name("collapsible-area"),
                    SimpleSelector.Name("extension"),
                    SimpleSelector.Class("unity-text-field"),
                    SimpleSelector.Name("unity-text-input", new Pseudoclass[] {Pseudoclass.Hover()})
                    },
                    Rules.BackgroundColor(text_field_hover_color),
                    Rules.BorderTopColor(text_field_border_hover_color),
                    Rules.BorderRightColor(text_field_border_hover_color),
                    Rules.BorderBottomColor(text_field_border_hover_color),
                    Rules.BorderLeftColor(text_field_border_hover_color),
                    Rules.BorderTopWidth(new Len(1)),
                    Rules.BorderRightWidth(new Len(1)),
                    Rules.BorderBottomWidth(new Len(1)),
                    Rules.BorderLeftWidth(new Len(1)),
                    Rules.BorderTopRightRadius(new Len(2)),
                    Rules.BorderTopLeftRadius(new Len(2)),
                    Rules.BorderBottomRightRadius(new Len(2)),
                    Rules.BorderBottomLeftRadius(new Len(2))
                    ),

                // Text Field Container - Focused Behaviour
                ComplexSelector.Child(new SimpleSelector[] {
                    SimpleSelector.Class("node"),
                    SimpleSelector.Name("node-border"),
                    SimpleSelector.Name("contents"),
                    SimpleSelector.Name("collapsible-area"),
                    SimpleSelector.Name("extension"),
                    SimpleSelector.Class("unity-text-field"),
                    SimpleSelector.Name("unity-text-input", new Pseudoclass[] {Pseudoclass.Hover(), Pseudoclass.Focus()})
                    },
                    Rules.BackgroundColor(text_field_focus_color),
                    Rules.BorderTopColor(text_field_border_focus_color),
                    Rules.BorderRightColor(text_field_border_focus_color),
                    Rules.BorderBottomColor(text_field_border_focus_color),
                    Rules.BorderLeftColor(text_field_border_focus_color),
                    Rules.BorderTopWidth(new Len(1)),
                    Rules.BorderRightWidth(new Len(1)),
                    Rules.BorderBottomWidth(new Len(1)),
                    Rules.BorderLeftWidth(new Len(1)),
                    Rules.BorderTopRightRadius(new Len(2)),
                    Rules.BorderTopLeftRadius(new Len(2)),
                    Rules.BorderBottomRightRadius(new Len(2)),
                    Rules.BorderBottomLeftRadius(new Len(2))
                    )
                );
        }
    }
}