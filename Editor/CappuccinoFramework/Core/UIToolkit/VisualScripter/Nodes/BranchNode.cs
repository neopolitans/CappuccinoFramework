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
        public class BranchNode : GraphNode
        {
            // Node Variables
            public bool Condition = false;

            public GraphNode nextNode2 = null;

            // Internal Variables
            new public const string NodeClass = "cappuccino-node__branch";

            new protected static Color main_container_color = C255.Color(152, 49, 52, 192);

            new public static BranchNode New(string name, Vector2 position, CGraphInstance graphView)
            {
                BranchNode node = new BranchNode();
                node.graph = graphView;

                node.AddToClassList("cappuccino-branch-node");

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
                AddDataInput("Bool", typeof(bool));

                AddExecuteOutput("True");
                AddExecuteOutput("False");
            }

            // The reason why the data persistence "works" is because although UIElements persistence for ports is nearly entirely unreliable, for at least one frame of the IMGUI there *is* data at that port.
            // After that point, there is no data and it'll assume that the data port is null afterwards, never resetting it's own value. The result is that it doesn't know there's an error at all,
            // going about it's day with the last known value held.

            public override void Execute()
            {
                // Resolve all input port connections first.
                base.Execute();

                //Debug.Log($"Next Node (True): {nextNode != null} | Next Node 2 (False): {nextNode2 != null}");

                // Unpack the bool value held in the input port "Bool".
                GetDataFromPort("Bool", typeof(bool), out object cond);
                if (cond != null && cond.GetType() == typeof(bool))
                {
                    Condition = (bool)cond;
                }

                if (Condition)
                {
                    if (nextNode != null)
                    {
                        nextNode.Execute(); 
                    }
                }   
                else
                {
                    if (nextNode2 != null) 
                    {
                        nextNode2.Execute(); 
                    }
                }
            }

            // The reason we send the output node to this instead of the input node is because we want to know which output node is being linked to.
            // The input node is a blank name (" " / "exec") whereas the output node has the "true/false" names.
            public void SetNextNode(NodePort output, GraphNode node)
            {   
                if (output.portName == "True")
                {
                    nextNode = node;
                }
                else if (output.portName == "False")
                {
                    nextNode2 = node;
                }
            }

        }
    }
}