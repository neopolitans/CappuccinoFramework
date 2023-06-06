using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

using UnityEditor.Experimental.GraphView;

using Cappuccino.Core;
using Cappuccino.Interpreters.Languages.USS;
using Cappuccino.VisualScripting;

namespace Cappuccino
{
    namespace Graphing
    {
        /// <summary>
        /// A class deriving from the <see cref="NodePort"/> type for nodes. <br></br> 
        /// Used for defining a node connection that displays the flow of logic.<br></br><br></br>
        /// This port sub-class exists for GetCompatiblePorts and port filtering.
        /// </summary>
        public class ExecutePort : NodePort
        {
            /// <summary>
            /// Constructor for an Execte Port.
            /// </summary>
            /// <param name="portOrientation">The port's orientation.</param>
            /// <param name="portDirection">The port's direction.</param>
            /// <param name="portCapacity">The port's capcity.</param>
            protected ExecutePort(Orientation portOrientation, Direction portDirection, Capacity portCapacity) : base(portOrientation, portDirection, portCapacity) { }

            /// <summary>
            /// A drop-in replacement for <see cref="Port.Create{TEdge}(Orientation, Direction, Capacity, Type)"/>. <br></br>
            /// This does not do anything explicitly different from the aforementioned. Required for some behaviours.
            /// </summary>
            /// <typeparam name="TEdge">This isn't explicitly explained.</typeparam>
            /// <param name="orientation">The orientation for the port's direction.</param>
            /// <param name="direction">The flow direction of the port (is it an input or an output)</param>
            /// <param name="capacity">Whether the port can take one or more connections.</param>
            /// <returns></returns>
            new public static ExecutePort CreatePort<TEdge>(Orientation orientation, Direction direction, Capacity capacity) where TEdge : Edge, new()
            {
                // Create the new listener
                EdgeConnectorListener listener = new EdgeConnectorListener();

                // create the new port.
                ExecutePort port = new ExecutePort(orientation, direction, capacity)
                {
                    // add the edge connector listener to port.
                    m_EdgeConnector = new EdgeConnector<TEdge>(listener)
                };

                // Add the edge connector as a manipulator to the port.
                port.AddManipulator(port.m_EdgeConnector);

                return port;
            }

            // On Connection

            // Input to Output
            public override void OnOutputConnection(NodePort output)
            {
                //Debug.Log(((GraphNode)node).GetType() + " input connects to:" + ((GraphNode)output.node).GetType());
                ((GraphNode)node).SetLastNode((GraphNode)output.node);
            }

            public override void OnOutputDisconnect()
            {
                ((GraphNode)node).SetLastNode(null);
            }

            // Output to Input
            public override void OnInputConnection(NodePort input)
            {
                //Debug.Log(((GraphNode)node).GetType() + " output connects to:" + ((GraphNode)input.node).GetType());
                if (((GraphNode)node).GetType() == typeof(BranchNode))
                {
                    ((BranchNode)node).SetNextNode(this, (GraphNode)input.node);
                }
                else
                {
                    ((GraphNode)node).SetNextNode((GraphNode)input.node);
                }
            }

            public override void OnInputDisconnect()
            {
                if (((GraphNode)node).GetType() == typeof(BranchNode))
                {
                    ((BranchNode)node).SetNextNode(this, null);
                }
                else
                {
                    ((GraphNode)node).SetNextNode(null);
                }
            }

        }
    }
}