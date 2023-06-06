using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

using UnityEditor.Experimental.GraphView;

using Cappuccino.Core;
using Cappuccino.Interpreters.Languages.USS;
using System.Xml.Linq;

namespace Cappuccino
{
    namespace Graphing
    { 
        /// <summary>
        /// A class deriving from the <see cref="Group"/> type for Graph Windows.
        /// </summary>
        public class Comment : Group
        {
            // Variables
            // - Private Variables
            protected CGraphInstance graph;

            protected bool isMouseDragging;
            protected Vector2 mouseDragStartPosition;

            #region Comment Colors
            // These colors are used with the USS Object Model to quickly and easily change the color palette of the Graph Node.

            /// <summary>
            /// The node selection color when the node is hovered over <i>or</i> selected and not hovered over.<br></br><br></br>
            /// These colors cannot be overridden in code and must have a "new" implementation in the inheriting script, alongside a USSOM Sheet.
            /// </summary>
            protected static Color selection_translucent_highlight_color = C255.Color(250, 182, 59, 96);

            /// <summary>
            /// The node selection color when the node is hovered over and being dragged.<br></br><br></br>
            /// These colors cannot be overridden in code and must have a "new" implementation in the inheriting script, alongside a USSOM Sheet.
            /// </summary>
            protected static Color selection_dragging_highlight_color = C255.Color(250, 182, 59, 168);

            /// <summary>
            /// The node selection color when the node is selected and hovered over.<br></br><br></br>
            /// These colors cannot be overridden in code and must have a "new" implementation in the inheriting script, alongside a USSOM Sheet.
            /// </summary>
            protected static Color selection_highlight_color = C255.Color(250, 182, 59, 255);

            #endregion

            #region Comment Values
            /// <summary>
            /// The minimum width for the comment.
            /// </summary>
            protected static float min_width = 110f;

            /// <summary>
            /// The minimum height for the comment's header bar.
            /// </summary>
            protected static float min_header_height = 32f;
            
            /// <summary>
            /// The minimum height for the comment's main body.
            /// </summary>
            protected static float min_body_height = 51f;
            #endregion

            public Comment(string name)
            {
                // Set the provided properties.
                title = name;

                AddManipulators();
            }

            /// <summary>
            /// Create a new Comment with the provided title at the provided graph position. <br></br>
            /// Static method for the Comment constructor.
            /// </summary>
            /// <param name="name"></param>
            /// <param name="position"></param>
            /// <returns></returns>
            public static Comment New(string name, Vector2 position, CGraphInstance graph)
            {
                Comment comment = new Comment(name);
                comment.graph = graph;

                comment.SetPosition(new Rect(position, Vector2.zero));
                return comment;
            }

            protected virtual void AddManipulators()
            {
                // Create a new Resizer. (CElementResizer just removes the unnecessary elements that'll cause issues for resizing).
                ResizableElement resizer = CElementResizer.New();

                // When this comment is resized (or moved)
                // Keep the resizer at a width of 8f and set the margin to this comment's length minus the width of the resizer itself.
                this.OnGeometryChangedConstant(delegate (Rect newRect)
                {
                    resizer.style.marginLeft = newRect.size.x - CElementResizer.min_width;
                    resizer.style.width = CElementResizer.min_width;
                });

                // Prevent the Resizer from going under the minimum height.
                resizer.OnGeometryChangedConstant(delegate (Rect newRect)
                {
                    if (newRect.height < CElementResizer.min_height)
                    {
                        resizer.style.height = CElementResizer.min_height;
                    }
                    else
                    {
                        resizer.style.height = new StyleLength(StyleKeyword.Auto);
                    }
                });

                // Add the element to the container marked ".mainContainer" in the visual element. (Use UI Toolkit Debugger to see UXML-USS Class Names)
                ElementAt(0).ElementAt(1).Add(resizer);
            }


            #region Style: Unreal-Like Comment style

            //[ExportSheet(FrameworkUtilities.dirInAssets + "Core/UIToolkit/GraphWindow/StyleSheets", true)]
            public static Sheet GroupStyle() => new Sheet("CappuccinoGraphGroupStyle",

                // Group Visual Element
                ComplexSelector.Child(new SimpleSelector[]{
                    SimpleSelector.Class("graphView"),
                    SimpleSelector.Type("VisualElement"),
                    SimpleSelector.Name("contentViewContainer"),
                    SimpleSelector.Type("Layer"),
                    SimpleSelector.Class("group")
                    },

                    Rules.BackgroundColor(C255.Color(255, 255, 255, 0)),
                    Rules.BorderColor(C255.Color(30, 30, 30, 32)),
                    Rules.BorderBottomLeftRadius(new Len(0)),
                    Rules.BorderBottomRightRadius(new Len(0)),
                    Rules.BorderTopLeftRadius(new Len(0)),
                    Rules.BorderTopRightRadius(new Len(0))
                ),

                // Group  Visual Element - Selection Hover
                ComplexSelector.Child(new SimpleSelector[]{
                    SimpleSelector.Class("graphView"),
                    SimpleSelector.Type("VisualElement"),
                    SimpleSelector.Name("contentViewContainer"),
                    SimpleSelector.Type("Layer"),
                    SimpleSelector.Class("group", new Pseudoclass[] { Pseudoclass.Hover() })
                    },
                    Rules.BackgroundColor(C255.Color(255, 255, 255, 0)), 
                    Rules.BorderColor(selection_translucent_highlight_color),
                    Rules.BorderBottomLeftRadius(new Len(0)),
                    Rules.BorderBottomRightRadius(new Len(0)),
                    Rules.BorderTopLeftRadius(new Len(0)),
                    Rules.BorderTopRightRadius(new Len(0))
                ),

                // Group  Visual Element - Selection Checked
                ComplexSelector.Child(new SimpleSelector[]{
                    SimpleSelector.Class("graphView"),
                    SimpleSelector.Type("VisualElement"),
                    SimpleSelector.Name("contentViewContainer"),
                    SimpleSelector.Type("Layer"),
                    SimpleSelector.Class("group", new Pseudoclass[] { Pseudoclass.Checked() })
                    },
                    Rules.BackgroundColor(C255.Color(255, 255, 255, 0)),
                    Rules.BorderColor(selection_dragging_highlight_color),
                    Rules.BorderBottomLeftRadius(new Len(0)),
                    Rules.BorderBottomRightRadius(new Len(0)),
                    Rules.BorderTopLeftRadius(new Len(0)),
                    Rules.BorderTopRightRadius(new Len(0))
                ),

                // Group  Visual Element - Selection Hover & Checked
                ComplexSelector.Child(new SimpleSelector[]{
                    SimpleSelector.Class("graphView"),
                    SimpleSelector.Type("VisualElement"),
                    SimpleSelector.Name("contentViewContainer"),
                    SimpleSelector.Type("Layer"),
                    SimpleSelector.Class("group", new Pseudoclass[] { Pseudoclass.Hover(), Pseudoclass.Checked() })
                    },
                    Rules.BackgroundColor(C255.Color(255, 255, 255, 0)),
                    Rules.BorderColor(selection_highlight_color),
                    Rules.BorderBottomLeftRadius(new Len(0)),
                    Rules.BorderBottomRightRadius(new Len(0)),
                    Rules.BorderTopLeftRadius(new Len(0)),
                    Rules.BorderTopRightRadius(new Len(0))
                ),

                // Group Main Container - This is done to directly access the main container style
                ComplexSelector.Child(new SimpleSelector[]{
                    SimpleSelector.Class("graphView"),
                    SimpleSelector.Type("VisualElement"),
                    SimpleSelector.Name("contentViewContainer"),
                    SimpleSelector.Type("Layer"),
                    SimpleSelector.Class("group"),
                    SimpleSelector.Class("mainContainer")
                    },

                    Rules.BackgroundColor(C255.Color(255, 255, 255, 64)),
                    Rules.BorderBottomLeftRadius(new Len(0)),
                    Rules.BorderBottomRightRadius(new Len(0)),
                    Rules.BorderTopLeftRadius(new Len(0)),
                    Rules.BorderTopRightRadius(new Len(0))
                ),

                // Group Header Container - This is done to directly access the header within the group's main container.
                ComplexSelector.Child(new SimpleSelector[]{
                    SimpleSelector.Class("graphView"),
                    SimpleSelector.Type("VisualElement"),
                    SimpleSelector.Name("contentViewContainer"),
                    SimpleSelector.Type("Layer"),
                    SimpleSelector.Class("group"),
                    SimpleSelector.Class("mainContainer"),
                    SimpleSelector.Name("headerContainer")
                    },
                    Rules.BackgroundColor(C255.Color(171, 171, 171, 200)),
                    Rules.BorderTopColor(C255.Color(0, 0, 0, 80)),
                    Rules.BorderBottomColor(C255.Color(0, 0, 0, 80)),
                    Rules.BorderLeftColor(C255.Color(0, 0, 0, 80)),
                    Rules.BorderRightColor(C255.Color(0, 0, 0, 80)),
                    Rules.BorderTopLeftRadius(new Len(0)),
                    Rules.BorderTopRightRadius(new Len(0)),
                    Rules.BorderTopWidth(new Len(2)),
                    Rules.BorderBottomWidth(new Len(2)),
                    Rules.BorderLeftWidth(new Len(2)),
                    Rules.BorderRightWidth(new Len(2)),
                    Rules.MinHeight(new Len(32f)),
                    Rules.MinWidth(new Len(110f))
                ),

                // Group Content VisualElement - This is done to directly access the header within the group's main container.
                ComplexSelector.Child(new SimpleSelector[]{
                    SimpleSelector.Class("graphView"),
                    SimpleSelector.Type("VisualElement"),
                    SimpleSelector.Name("contentViewContainer"),
                    SimpleSelector.Type("Layer"),
                    SimpleSelector.Class("group"),
                    SimpleSelector.Class("mainContainer"),
                    SimpleSelector.Name("centralContainer"),
                    SimpleSelector.Name("contentContainerPlaceholder")
                    },
                    Rules.PaddingTop(new Len(5)),
                    Rules.PaddingRight(new Len(5)),
                    Rules.PaddingBottom(new Len(5)),
                    Rules.PaddingLeft(new Len(5)),
                    Rules.BorderBottomLeftRadius(new Len(0)),
                    Rules.BorderBottomRightRadius(new Len(0))
                ),

                // Group Drop Area VisualElement - This is done to directly access the header within the group's main container.
                ComplexSelector.Child(new SimpleSelector[]{
                    SimpleSelector.Class("graphView"),
                    SimpleSelector.Type("VisualElement"),
                    SimpleSelector.Name("contentViewContainer"),
                    SimpleSelector.Type("Layer"),
                    SimpleSelector.Class("group"),
                    SimpleSelector.Class("mainContainer"),
                    SimpleSelector.Name("centralContainer"),
                    SimpleSelector.Name("contentContainerPlaceholder"),
                    SimpleSelector.Name("dropArea")
                    },
                    Rules.BorderBottomLeftRadius(new Len(0)),
                    Rules.BorderBottomRightRadius(new Len(0))
                ),

                // Group Title Label - This is done to directly access and modify the title's visual elements.
                ComplexSelector.Child(new SimpleSelector[]{
                    SimpleSelector.Class("graphView"),
                    SimpleSelector.Type("VisualElement"),
                    SimpleSelector.Name("contentViewContainer"),
                    SimpleSelector.Type("Layer"),
                    SimpleSelector.Class("group"),
                    SimpleSelector.Class("mainContainer"),
                    SimpleSelector.Name("headerContainer"),
                    SimpleSelector.Name("titleContainer"),
                    SimpleSelector.Name("titleLabel")
                    },
                    Rules.Color(C255.Color(253, 253, 253, 145)),
                    Rules.UnityFontStyle(Rules.FontStyleValue.bold),
                    Rules.TextAlign(Rules.TextAlignValue.upperLeft),
                    Rules.FontSize(new Len(20))
                ),

                // Group Title Label: Text Input Field - This is done to directly access and modify the title's name-changing aspect.
                ComplexSelector.Child(new SimpleSelector[]{
                    SimpleSelector.Class("graphView"),
                    SimpleSelector.Type("VisualElement"),
                    SimpleSelector.Name("contentViewContainer"),
                    SimpleSelector.Type("Layer"),
                    SimpleSelector.Class("group"),
                    SimpleSelector.Class("mainContainer"),
                    SimpleSelector.Name("headerContainer"),
                    SimpleSelector.Name("titleContainer"),
                    SimpleSelector.Name("titleField"),
                    SimpleSelector.Name("unity-text-input", new Pseudoclass[]{ Pseudoclass.Focus() })
                    },
                    Rules.BackgroundColor(C255.Color(42, 42, 42, 80)),
                    Rules.UnityFontStyle(Rules.FontStyleValue.bold)
                )
                );

            #endregion
        }
    }
}