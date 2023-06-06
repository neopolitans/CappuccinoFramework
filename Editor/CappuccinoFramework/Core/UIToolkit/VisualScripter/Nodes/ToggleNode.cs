using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cappuccino.Graphing;
using Cappuccino.Interpreters.Languages.USS;
using Cappuccino.Core;

namespace Cappuccino
{
    namespace VisualScripting
    {
        /// <summary>
        /// A function node is a Graph Node used as the basis for defining the start of a function body.
        /// </summary>
        public class ToggleNode : GraphNode
        {
            // Node Variables
            protected string toggle_name = "";
            protected bool toggle = false;

            public GraphNode nextNode2 = null;

            // Internal Variables
            new public const string NodeClass = "cappuccino-node__branch";

            new protected static Color main_container_color = C255.Color(60, 150, 255, 128);

            new public static ToggleNode New(string name, Vector2 position, CGraphInstance graphView)
            {
                ToggleNode node = new ToggleNode();
                node.graph = graphView;

                node.AddToClassList("cappuccino-imgui-toggle-node");

                node.AddSheets();

                node.Initialize(name, position);

                node.Ports();

                node.Title();
                node.Contents();

                return node;
            }

            public override void Ports()
            {
                AddExecuteInput("exec");
                AddDataInput("Label", typeof(string));

                AddExecuteOutput("then");
                AddDataOutput("Toggle", typeof(bool));
            }

            // The reason why the data persistence "works" is because although UIElements persistence for ports is nearly entirely unreliable, for at least one frame of the IMGUI there *is* data at that port.
            // After that point, there is no data and it'll assume that the data port is null afterwards, never resetting it's own value. The result is that it doesn't know there's an error at all,
            // going about it's day with the last known value held.

            public override void Execute()
            {
                // Resolve all input port connections first.
                base.Execute();

                // Unpack the string value held in the input port "Label".
                GetDataFromPort("Label", typeof(string), out object text);
                if (text != null && text.GetType() == typeof(string))
                {
                    toggle_name = (string)text;
                }

                // create the IMGUI toggle.
                toggle = UI.Toggle(toggle_name, toggle);

                // Set the value of the  "Toggle" output node based on what the toggle name is.
                SetDataInPort("Toggle", typeof(bool), toggle);

                // Execute the next node.   
                if (nextNode != null)
                {
                    nextNode.Execute();
                }
            }



            #region Style
            public override void AddSheets()
            {
                base.AddSheets();

                styleSheets.Add(AssetLoader.GetStyleSheet("Core/UIToolkit/GraphWindow/StyleSheets/CappuccinoNodePortsStyle"));
                styleSheets.Add(AssetLoader.GetStyleSheet("Core/UIToolkit/VisualScripter/StyleSheets/CapppuccinoFunctionNodeStyle"));
            }

            [ExportSheet(FrameworkUtilities.dirInAssets + "Core/UIToolkit/VisualScripter/StyleSheets", true)]
            public static Sheet FunctionNodeSheet() => new Sheet("CapppuccinoIMGUINodeStyle",
                ComplexSelector.Child(new SimpleSelector[] {
                    SimpleSelector.Class("cappuccino-imgui-toggle-node"),
                    SimpleSelector.Name("node-border")
                    },
                    Rules.BackgroundColor(main_container_color)
                    )
                );

            #endregion
        }
    }
}