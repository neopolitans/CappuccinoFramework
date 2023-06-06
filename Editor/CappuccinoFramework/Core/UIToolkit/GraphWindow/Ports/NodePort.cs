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

namespace Cappuccino
{
    namespace Graphing
    {
        /// <summary>
        /// A class deriving from the <see cref="Port"/> type for nodes. <br></br> 
        /// Used for overriding some of the core, privated members of <b>Port</b> by Unity Technologies. These implementations are near-identical and the source belongs to Unity Technolgies.<br></br><br></br>
        /// This port sub-class exists for GetCompatiblePorts and port filtering.
        /// </summary>
        public class NodePort : Port
        {
            /// <summary>
            /// The underlying port name. <br></br>
            /// This is the port name that is enclosed and used for comparisons if, for example, the portName value is "exec" or "then".
            /// </summary>
            public string enclosedPortName;

            /// <summary>
            /// Constructor for an Execte Port.
            /// </summary>
            /// <param name="portOrientation">The port's orientation.</param>
            /// <param name="portDirection">The port's direction.</param>
            /// <param name="portCapacity">The port's capcity.</param>
            protected NodePort(Orientation portOrientation, Direction portDirection, Capacity portCapacity) : base(portOrientation, portDirection, portCapacity, typeof(bool)) { }

            /// <summary>
            /// A reimplementation of <see cref="Port.DefaultEdgeConnectorListener"/>, a private class which is necessary for Port.Create(). <br></br><br></br>
            /// Credit to <b>Unity Technologies</b> for this. Taking it apart and learning is really insightful.
            /// </summary>
            protected class EdgeConnectorListener : IEdgeConnectorListener
            {
                private GraphViewChange m_graphViewChange;  // Changes in the graph that can be intercepted
                private List<Edge> m_EdgesToCreate;
                private List<GraphElement> m_EdgesToDelete;

                public EdgeConnectorListener()
                {
                    m_EdgesToCreate = new List<Edge>(); // The edges to create in the graph element.
                    m_EdgesToDelete = new List<GraphElement>(); // The edges to delete from the graph element.
                    m_graphViewChange.edgesToCreate = m_EdgesToCreate;  // A list of edges about to be created.
                }
                
                /// <summary>
                /// The behaviour when a port's connection has been dropped on/in another port.
                /// </summary>
                /// <param name="graph"></param>
                /// <param name="edge"></param>
                public void OnDrop(GraphView graph, Edge edge)
                {
                    // Clear the lists beforehand and add the new edge to be created.
                    m_EdgesToCreate.Clear();
                    m_EdgesToCreate.Add(edge);
                    m_EdgesToDelete.Clear();

                    // If the edge being targeted can only take one node, find all the other incoming connections and add them to the deletion list.
                    if (edge.input.capacity is Capacity.Single)
                    {
                        foreach (Edge inputConnection in edge.input.connections)
                        {
                            if (inputConnection != edge)
                            {
                                m_EdgesToDelete.Add(inputConnection);
                            }
                        }
                    }

                    // If the edge being targeted can only take link to one node, find all the other outgoing connections and add them to the deletion list.
                    if (edge.output.capacity is Capacity.Single)
                    {
                        foreach (Edge outputConnection in edge.output.connections)
                        {
                            if (outputConnection != edge)
                            {
                                m_EdgesToDelete.Add(outputConnection);
                            }
                        }
                    }

                    // Delete all invalid connections we found.
                    // [Custom] Send disconnect notifications to all input and output ports affected first.
                    if (m_EdgesToDelete.Count > 0) { graph.DeleteElements(m_EdgesToDelete); }

                    List<Edge> edgesToCreate = m_EdgesToCreate; // set the edges to create to the list of edges we have in the listener.

                    // I believe this overrides the graphViewChanged object that previously existed, if one did, for the one created in this listener. Then overrides edgesToCreate above with the contents.
                    if (graph.graphViewChanged != null) { edgesToCreate = graph.graphViewChanged(m_graphViewChange).edgesToCreate; }

                    // Add all edges to the graph and connect them.
                    foreach (Edge item in edgesToCreate)
                    {
                        graph.AddElement(item);
                        edge.input.Connect(item);
                        edge.output.Connect(item);
                    }

                }

                /// <summary>
                /// The behaviour when a port's connection has been dropped on the graph. <br></br>
                /// This will trigger a search menu that allows developers to specify special port behaviour.
                /// </summary>
                /// <param name="edge"></param>
                /// <param name="position"></param>
                public void OnDropOutsidePort(Edge edge, Vector2 position) 
                {
                    if (edge.parent.parent.parent.parent.GetType() == typeof(CGraphInstance))
                    {
                        CGraphInstance graph = (CGraphInstance)edge.parent.parent.parent.parent;
                        graph.OpenNodeSearch();
                    }
                }
            }

            /// <summary>
            /// The behaviour triggered when the port is connected to an input port. <br></br><br></br>
            /// <b><see langword="Usage:"/></b> This method is overridden for ports when they are being used as an <i>output</i> port.
            /// </summary>
            /// <param name="input">The input node port that this output port has linked to.</param>
            public virtual void OnInputConnection(NodePort input)
            {
            }

            /// <summary>
            /// The behaviour triggered when the port is connected to an output port. <br></br><br></br>
            /// <b><see langword="Usage:"/></b> This method is overridden for ports when they are being used as an <i>input</i> port.
            /// </summary>
            /// <param name="output">The output node port that this input port has linked to.</param>
            public virtual void OnOutputConnection(NodePort output)
            {
            }

            // Currently can't be used. Unity does not have any way of detecting when a port loses connection through a delegate or event.
            /// <summary>
            /// The behaviour triggered when the port is disconnected from an input port. <br></br><br></br>
            /// <b><see langword="Usage:"/></b> This method is overridden for ports when they are being used as an <i>output</i> port.
            /// </summary>
            public virtual void OnInputDisconnect()
            {
            }

            /// <summary>
            /// The behaviour triggered when the port is disconnected from an output port. <br></br><br></br>
            /// <b><see langword="Usage:"/></b> This method is overridden for ports when they are being used as an <i>input</i> port.
            /// </summary>
            public virtual void OnOutputDisconnect()
            {

            }

            public override void Connect(Edge edge)
            {
                base.Connect(edge);

                if (direction is Direction.Input)
                {
                    ((NodePort)edge.input).OnOutputConnection((NodePort)edge.output);
                }
                else if (direction is Direction.Output)
                {
                    ((NodePort)edge.output).OnInputConnection((NodePort)edge.input);
                }
            }

            public override void Disconnect(Edge edge)
            {
                base.Disconnect(edge);
                if (direction is Direction.Input)
                {
                    OnOutputDisconnect();
                }
                else if (direction is Direction.Output)
                {
                    OnInputDisconnect();
                }
            }

            /// <summary>
            /// A drop-in replacement for <see cref="Port.Create{TEdge}(Orientation, Direction, Capacity, Type)"/>. <br></br>
            /// This does not do anything explicitly different from the aforementioned. Required for some behaviours.
            /// </summary>
            /// <typeparam name="TEdge">This isn't explicitly explained.</typeparam>
            /// <param name="orientation">The orientation for the port's direction.</param>
            /// <param name="direction">The flow direction of the port (is it an input or an output)</param>
            /// <param name="capacity">Whether the port can take one or more connections.</param>
            /// <returns></returns>
            public static NodePort CreatePort<TEdge>(Orientation orientation, Direction direction, Capacity capacity) where TEdge : Edge, new()
            {
                // Create the new listener
                EdgeConnectorListener listener = new EdgeConnectorListener();

                // create the new port.
                NodePort port = new NodePort(orientation, direction, capacity)
                {
                    // add the edge connector listener to port.
                    m_EdgeConnector = new EdgeConnector<TEdge>(listener)
                };

                // Add the edge connector as a manipulator to the port.
                port.AddManipulator(port.m_EdgeConnector);

                return port;
            }
        }
    }
}