using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

using UnityEditor.Experimental.GraphView;

using Cappuccino.Core;

namespace Cappuccino
{
    namespace Graphing
    { 
        /// <summary>
        /// A custom node built directly off of GraphView.Node. <br></br><br></br>
        /// <see langword="Cappuccino:"/> This class is used exclusively with the Graphing namespace. <br></br>
        /// It contains the base node and extra behaviours for simplifying the node creation process.
        /// </summary>
        public partial class GraphNode : Node
        {
            #region Execute Ports
            /// <summary>
            /// Create an Input Execute Node which defaults to a Horizontal, Single-capacity node.
            /// </summary>
            /// <param name="name">The name of the Input Node.</param>
            /// <returns></returns>
            public virtual void AddExecuteInput(string name)
            {
                ExecutePort inputPort = ExecutePort.CreatePort<Edge>(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi);
                inputPort.AddToClassList("cappuccino_execute_port");
                inputPort.enclosedPortName = name;
                inputPort.portName = (name == "exec" ? " " : name);

                inputContainer.Add(inputPort);
                inputs.Add(inputPort);
            }

            /// <summary>
            /// Create an Input Execute Node with a specified orientation and capacity.
            /// </summary>
            /// <param name="name">The name of the Input Node.</param>
            /// <param name="orientation">Whether or not the node is going to be connecting horizontally or vertically.</param>
            /// <param name="capacity">Whether or not the node can only take a link from one node or multiple.</param>
            /// <returns></returns>
            public virtual void AddExecuteInput(string name, Orientation orientation, Port.Capacity capacity)
            {
                ExecutePort inputPort = ExecutePort.CreatePort<Edge>(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi);
                inputPort.AddToClassList("cappuccino_execute_port");
                inputPort.enclosedPortName = name;
                inputPort.portName = (name == "exec" ? " " : name);

                inputContainer.Add(inputPort);
                inputs.Add(inputPort);
            }

            /// <summary>
            /// Create an Output Execute Node which defaults to a Horizontal, Single-capacity node.
            /// </summary>
            /// <param name="name">The name of the Input Node.</param>
            /// <returns></returns>
            public virtual void AddExecuteOutput(string name)
            {
                ExecutePort outputPort = ExecutePort.CreatePort<Edge>(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi);
                outputPort.AddToClassList("cappuccino_execute_port");
                outputPort.enclosedPortName = name;
                outputPort.portName = (name == "then" ? " " : name);

                outputContainer.Add(outputPort);
                outputs.Add(outputPort);
            }

            /// <summary>
            /// Create an Output Execute Node with a specified orientation and capacity.
            /// </summary>
            /// <param name="name">The name of the Input Node.</param>
            /// <param name="orientation">Whether or not the node is going to be connecting horizontally or vertically.</param>
            /// <param name="capacity">Whether or not the node can only take a link from one node or multiple.</param>
            /// <returns></returns>
            public virtual void AddExecuteOutput(string name, Orientation orientation, Port.Capacity capacity)
            {
                ExecutePort outputPort = ExecutePort.CreatePort<Edge>(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi);
                outputPort.AddToClassList("cappuccino_execute_port");
                outputPort.enclosedPortName = name;
                outputPort.portName = (name == "then" ? " " : name);

                outputContainer.Add(outputPort);
                outputs.Add(outputPort);
            }
            #endregion

            #region Data Ports
            /// <summary>
            /// Create an Input Data Node which defaults to a Horizontal, Single-capacity node.
            /// </summary>
            /// <param name="name">The name of the Input Node.</param>
            /// <returns></returns>
            public virtual void AddDataInput(string name, System.Type type)
            {
                DataPort inputPort = DataPort.CreatePort<Edge>(type, Orientation.Horizontal, Direction.Input, Port.Capacity.Multi);
                inputPort.AddToClassList("cappuccino_data_port");
                inputPort.enclosedPortName = name;
                inputPort.portName = (name == "exec" ? " " : name);

                inputContainer.Add(inputPort);
                inputs.Add(inputPort);
            }

            /// <summary>
            /// Create an Input Data Node with a specified orientation and capacity.
            /// </summary>
            /// <param name="name">The name of the Input Node.</param>
            /// <param name="orientation">Whether or not the node is going to be connecting horizontally or vertically.</param>
            /// <param name="capacity">Whether or not the node can only take a link from one node or multiple.</param>
            /// <returns></returns>
            public virtual void AddDataInput(string name, System.Type type, Orientation orientation, Port.Capacity capacity)
            {
                DataPort inputPort = DataPort.CreatePort<Edge>(type, orientation, Direction.Input, capacity);
                inputPort.AddToClassList("cappuccino_data_port");
                inputPort.enclosedPortName = name;
                inputPort.portName = (name == "exec" ? " " : name);

                inputContainer.Add(inputPort);
                inputs.Add(inputPort);
            }

            /// <summary>
            /// Create an Output Data Node which defaults to a Horizontal, Single-capacity node.
            /// </summary>
            /// <param name="name">The name of the Input Node.</param>
            /// <returns></returns>
            public virtual void AddDataOutput(string name, System.Type type)
            {
                DataPort outputPort = DataPort.CreatePort<Edge>(type, Orientation.Horizontal, Direction.Output, Port.Capacity.Multi);
                outputPort.AddToClassList("cappuccino_data_port");
                outputPort.enclosedPortName = name;
                outputPort.portName = name;

                outputContainer.Add(outputPort);
                outputs.Add(outputPort);
            }

            /// <summary>
            /// Create an Output Data Node with a specified orientation and capacity.
            /// </summary>
            /// <param name="name">The name of the Input Node.</param>
            /// <param name="orientation">Whether or not the node is going to be connecting horizontally or vertically.</param>
            /// <param name="capacity">Whether or not the node can only take a link from one node or multiple.</param>
            /// <returns></returns>
            public virtual void AddDataOutput(string name, System.Type type, Orientation orientation, Port.Capacity capacity)
            {
                DataPort outputPort = DataPort.CreatePort<Edge>(type, orientation, Direction.Output, capacity);
                outputPort.AddToClassList("cappuccino_data_port");
                outputPort.enclosedPortName = name;
                outputPort.portName = name;

                outputContainer.Add(outputPort);
                outputs.Add(outputPort);
            }

            #endregion
        }
    }
}