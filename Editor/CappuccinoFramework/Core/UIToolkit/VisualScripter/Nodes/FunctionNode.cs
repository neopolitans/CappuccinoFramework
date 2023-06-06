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
        public class FunctionNode : GraphNode
        {
            new public const string NodeClass = "cappuccino-node__function";

            new protected static Color main_container_color = C255.Color(152, 49, 52, 192);

            new public static FunctionNode New(string name, Vector2 position, CGraphInstance graphView)
            {
                FunctionNode node = new FunctionNode();
                node.graph = graphView;

                node.AddToClassList("cappuccino-function-node");

                node.AddSheets();

                node.Initialize(name, position);

                node.Ports();

                node.Title();
                node.Contents();

                return node;
            }

            // Because this is a function node, we move the function to the next node on the list.
            public override void Execute()
            {
                // No input connections to resolve, so we skip that.
                //Debug.Log($"Last Node: {lastNode != null} | Next Node: {nextNode != null}");

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

            public override void Ports()
            {
                AddExecuteOutput("then");
            }

            //[ExportSheet(FrameworkUtilities.dirInAssets + "Core/UIToolkit/VisualScripter/StyleSheets", true)]
            public static Sheet FunctionNodeSheet() => new Sheet("CapppuccinoFunctionNodeStyle",
                ComplexSelector.Child(new SimpleSelector[] {
                    SimpleSelector.Class("cappuccino-function-node"),
                    SimpleSelector.Name("node-border")
                    },
                    Rules.BackgroundColor(main_container_color)
                    )
                );

            #endregion
        }
    }
}