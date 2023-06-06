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
using System.Text;
using UnityEngine.Windows;

namespace Cappuccino
{
    namespace Graphing
    {
        /// <summary>
        /// A class deriving from the <see cref="NodePort"/> type for nodes. <br></br> 
        /// Used for defining a node connection to pass data through <br></br><br></br>
        /// This port sub-class exists for GetCompatiblePorts and port filtering.
        /// </summary>
        public partial class DataPort : NodePort
        {
            // The data port types that this port can match with.
            public Type m_typeRestriction;

            /// <summary>
            /// The data type for this data-port.
            /// </summary>
            public Type DataType { get { return m_typeRestriction; } }

            /// <summary>
            /// The data object being stored through this port. <br></br>
            /// <see langword="Cappuccino:"/> Data ports have a value object that gets passed between nodes.
            /// </summary>
            public object value;

            /// <summary>
            /// The conected data port to receive information from, if this node is an input port.
            /// </summary>
            public DataPort connected_output_port = null;

            /// <summary>
            /// The entry field for data if there is no existing port connection.
            /// </summary>
            VisualElement m_EntryField;
            object lastFieldValue = null;

            /// <summary>
            /// Constructor for an Execte Port.
            /// </summary>
            /// <param name="portOrientation">The port's orientation.</param>
            /// <param name="portDirection">The port's direction.</param>
            /// <param name="portCapacity">The port's capcity.</param>
            protected DataPort(Orientation portOrientation, Direction portDirection, Capacity portCapacity) : base(portOrientation, portDirection, portCapacity){ }

            /// <summary>
            /// A drop-in replacement for <see cref="Port.Create{TEdge}(Orientation, Direction, Capacity, Type)"/>. <br></br>
            /// This does not do anything explicitly different from the aforementioned. Required for some behaviours.
            /// </summary>
            /// <typeparam name="TEdge">This isn't explicitly explained.</typeparam>
            /// <param name="orientation">The orientation for the port's direction.</param>
            /// <param name="direction">The flow direction of the port (is it an input or an output)</param>
            /// <param name="capacity">Whether the port can take one or more connections.</param>
            /// <returns></returns>
            public static DataPort CreatePort<TEdge>(Type dataType, Orientation orientation, Direction direction, Capacity capacity) where TEdge : Edge, new()
            {
                // Create the new listener
                EdgeConnectorListener listener = new EdgeConnectorListener();

                // create the new port.
                DataPort port = new DataPort(orientation, direction, capacity)
                {
                    // add the edge connector listener to port.
                    m_EdgeConnector = new EdgeConnector<TEdge>(listener)
                };

                // Add the edge connector as a manipulator to the port.
                port.AddManipulator(port.m_EdgeConnector);
                port.portColor = DataTypeColor(dataType);
                port.m_typeRestriction = dataType;

                if (direction is Direction.Input)
                {
                    // Add entry field style sheets and create the type data-entry field.
                    port.AddEntryFieldSheets();
                    port.CreateField();
                }

                return port;
            }

            /// <summary>
            /// This can't use a switch case as typeof() arguements are not constant and cannot be forcefully assigned to a constant variable.
            /// </summary>
            /// <param name="type"></param>
            /// <returns></returns>
            public static Color DataTypeColor(Type type)
            {
                switch (type)
                {
                    case Type boolean when boolean == typeof(bool):
                        return Color.red;

                    case Type str when str == typeof(string):
                        return C255.Color(251, 0, 209);

                    case Type vec3 when vec3 == typeof(Vector3):
                        return Color.green;

                    default:
                        return Color.white;
                }
            }

            #region Connection Methods

            public void ResolveValueFromConnection()
            {
                if (connected_output_port == null) { return; }
                else
                {
                    value = connected_output_port.value;
                }
            }

            public override void OnOutputConnection(NodePort output)
            {
                // Remove the data entry field if it's not null.

                if (m_EntryField != null) 
                {
                    Remove(m_EntryField);
                }
                m_EntryField = null;

                connected_output_port = (DataPort)output;
                value = ((DataPort)output).value; // pull the value held by the output port.
            }

            public override void OnOutputDisconnect()
            {
                value = null;
                connected_output_port = null;
                value = lastFieldValue;

                CreateField();
            }

            #endregion
        }
    }
}