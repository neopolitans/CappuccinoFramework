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
        /// The Graph Instance which allows Cappuccino Editor Windows to leverage GraphView elements. <br></br><br></br>
        /// <see langword="Cappuccino:"/> This class contains all the under-the-hood processes for creating a Graph View and it's elements. <br></br>
        /// Tampering with this class is not advised unless you know how to use GraphView, Nodes, Ports, Unity Style Sheets, UI Toolkit and various other elements.
        /// </summary>
        public partial class CGraphInstance : GraphView
        {

            /// <summary>
            /// Used by Nodes to get which input or output connections are valid.
            /// </summary>
            /// <param name="startPort">Which port have we started the connectionf rom.</param>
            /// <param name="nodeAdapter"></param>
            /// <returns></returns>
            public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
            {
                List<Port> compatiblePorts = new List<Port>();

                //Debug.Log(startPort.node.GetType() == typeof(GraphNode) || startPort.node.GetType().IsSubclassOf(typeof(GraphNode)));

                if (startPort.GetType().IsSubclassOf(typeof(ExecutePort)))
                {
                    // For each port in the ports UQueryState, check if they are compatible, if so - add them.
                    ports.ForEach(port =>
                    {
                        if (IsInvalidPort(startPort, port))
                        {
                            return;
                        }

                        compatiblePorts.Add(port);
                    });
                }
                else if (startPort.GetType().IsSubclassOf(typeof(DataPort)))
                {
                    ports.ForEach(port =>
                    {
                        if (IsInvalidPort(startPort, port) || !SameDataType((DataPort)startPort, (DataPort)port))
                        {
                            return;
                        }

                        compatiblePorts.Add(port);
                    });
                }
                else
                {
                    ports.ForEach(port =>
                    {
                        if (IsInvalidPort(startPort, port))
                        {
                            return;
                        }

                        compatiblePorts.Add(port);
                    });
                }
                

                return compatiblePorts;
            }

            /// <summary>
            /// Check whether two ports are either the same port, part of the same node or going in the same direction.
            /// </summary>
            /// <param name="start">The port that's being selected and joined to another port.</param>
            /// <param name="other">The port that's being queried.</param>
            /// <returns></returns>
            protected bool IsInvalidPort(Port start, Port other)
            {
                return start == other || start.node == other.node || start.direction == other.direction || !(start.GetType().Equals(other.GetType()));
            }

            protected bool SameDataType(DataPort start, DataPort other)
            {
                return (start.DataType.Equals(other.DataType));
            }
        }
    }
}