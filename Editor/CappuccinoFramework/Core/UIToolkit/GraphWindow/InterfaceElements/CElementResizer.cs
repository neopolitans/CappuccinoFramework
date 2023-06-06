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
        // This is a "factory" for modifying ResizableElements. I could not find a way to otherwise get expected and desired behaviour for this otherwise.

        /// <summary>
        /// An Element Resizer that modifies an instantiated ResizableElement to do it's own stuff with. <br></br><br></br>
        /// <see langword="Cappuccino:"/> This element exists as there are no contextaulized examples for the Resizer class. <br></br>
        /// The only classes that exist are ResizableElement and ElementResizer (the latter of which being restricted to internal Unity namespaces).
        /// </summary>
        public class CElementResizer : ResizableElement
        {
            /// <summary>
            /// The minimum expected width of a resizableElement.
            /// </summary>
            public const float min_width = 8f;

            /// <summary>
            /// The minimum expected height of a resizableElement.
            /// </summary>
            public const float min_height = 15f;

            public static ResizableElement New()
            {
                ResizableElement newResizable = new ResizableElement();

                newResizable.RemoveAt(0);   // Remove the Left Resizers.
                newResizable.RemoveAt(0);   // Remove the Center Resizers.
                newResizable.ElementAt(0).RemoveAt(0); // Remove the Top-Right Resizer.

                newResizable.style.minWidth = min_width; 
                newResizable.style.minHeight = min_height; 

                return newResizable;
            }

            [ExportSheet(FrameworkUtilities.dirInAssets + "Core/UIToolkit/GraphWindow/StyleSheets", true)]
            public static Sheet GroupStyle() => new Sheet("CappuccinoGraphGroupResizerStyle",
                // ResizableElement VisualElement - This is done to directly access the header within the group's main container.
                ComplexSelector.Child(new SimpleSelector[]{
                    SimpleSelector.Class("graphView"),
                    SimpleSelector.Type("VisualElement"),
                    SimpleSelector.Name("contentViewContainer"),
                    SimpleSelector.Type("Layer"),
                    SimpleSelector.Class("group"),
                    SimpleSelector.Class("mainContainer"),
                    SimpleSelector.Name("centralContainer"),
                    SimpleSelector.Class("resizableElement")
                    },
                    Rules.BackgroundColor(C255.Color(255, 255, 255, 15))
                ));
        }
    }
}