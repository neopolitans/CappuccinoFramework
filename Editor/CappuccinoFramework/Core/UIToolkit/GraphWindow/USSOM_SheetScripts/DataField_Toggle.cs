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
        /// A static class dedicated to holding all static style sheets
        /// </summary>
        public static partial class FieldSheets
        {
            #region Text Field Colors

            static Color boolean_field_inactive_color = C255.Color(19, 22, 19, 0);
            static Color boolean_field_border_inactive_color = C255.Color(138, 139, 138, 16);

            static Color boolean_field_hover_color = C255.Color(19, 22, 19, 32);
            static Color boolean_field_border_hover_color = C255.Color(138, 139, 138, 64);

            static Color boolean_field_focus_color = C255.Color(19, 22, 19, 64);
            static Color boolean_field_border_focus_color = C255.Color(196, 198, 196, 192);

            #endregion


            // Goes unused because Unity Engine provides it's own custom highlighting.
            //[ExportSheet(FrameworkUtilities.dirInAssets + "Core/UIToolkit/GraphWindow/StyleSheets/GenericFields/", true)]
            public static Sheet ToggleField() => new Sheet("CappuccinoBooleanField",

                // Toggle Field Container - Default Behaviour
                ComplexSelector.Child(new SimpleSelector[] {
                    SimpleSelector.Class("cappuccino-field__toggle-field"),
                    SimpleSelector.Class("unity-toggle__input")
                    },
                    Rules.BackgroundColor(boolean_field_inactive_color),
                    Rules.BorderTopColor(boolean_field_border_inactive_color),
                    Rules.BorderRightColor(boolean_field_border_inactive_color),
                    Rules.BorderBottomColor(boolean_field_border_inactive_color),
                    Rules.BorderLeftColor(boolean_field_border_inactive_color),
                    Rules.BorderTopWidth(new Len(1)),
                    Rules.BorderRightWidth(new Len(1)),
                    Rules.BorderBottomWidth(new Len(1)),
                    Rules.BorderLeftWidth(new Len(1)),
                    Rules.BorderTopRightRadius(new Len(2)),
                    Rules.BorderTopLeftRadius(new Len(2)),
                    Rules.BorderBottomRightRadius(new Len(2)),
                    Rules.BorderBottomLeftRadius(new Len(2))
                    ),

                // Toggle Field Container - Hover Behaviour
                ComplexSelector.Child(new SimpleSelector[] {
                    SimpleSelector.Class("cappuccino-field__toggle-field"),
                    SimpleSelector.Class("unity-toggle__input", new Pseudoclass[] {Pseudoclass.Hover() })
                    },
                    Rules.BackgroundColor(boolean_field_hover_color),
                    Rules.BorderTopColor(boolean_field_border_hover_color),
                    Rules.BorderRightColor(boolean_field_border_hover_color),
                    Rules.BorderBottomColor(boolean_field_border_hover_color),
                    Rules.BorderLeftColor(boolean_field_border_hover_color),
                    Rules.BorderTopWidth(new Len(1)),
                    Rules.BorderRightWidth(new Len(1)),
                    Rules.BorderBottomWidth(new Len(1)),
                    Rules.BorderLeftWidth(new Len(1)),
                    Rules.BorderTopRightRadius(new Len(2)),
                    Rules.BorderTopLeftRadius(new Len(2)),
                    Rules.BorderBottomRightRadius(new Len(2)),
                    Rules.BorderBottomLeftRadius(new Len(2))
                    ),

                // Toggle Field Container - Focused Behaviour
                ComplexSelector.Child(new SimpleSelector[] {
                    SimpleSelector.Class("cappuccino-field__toggle-field"),
                    SimpleSelector.Class("unity-toggle__input", new Pseudoclass[] {Pseudoclass.Hover(), Pseudoclass.Focus()})
                    },
                    Rules.BackgroundColor(boolean_field_focus_color),
                    Rules.BorderTopColor(boolean_field_border_focus_color),
                    Rules.BorderRightColor(boolean_field_border_focus_color),
                    Rules.BorderBottomColor(boolean_field_border_focus_color),
                    Rules.BorderLeftColor(boolean_field_border_focus_color),
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