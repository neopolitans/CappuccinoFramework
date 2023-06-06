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
        /// The base Graph Node for which every function derives from.
        /// </summary>
        public partial class GraphNode : Node
        {
            protected CGraphInstance graph;

            /// <summary>
            /// The previous node that connects to this one in the blueprint.
            /// </summary>
            public GraphNode lastNode = null;

            /// <summary>
            /// The next node that connects to this one in the blueprint.
            /// </summary>
            public GraphNode nextNode = null;

            public List<NodePort> inputs = new List<NodePort>();
            public List<NodePort> outputs = new List<NodePort>();

            // - Core Vairables
            // Visual Elements already have a "name" property, used by USS Selectors.
            public string NodeName { get; set; }

            // Nomenclature for a node is done with the following: cappuccino-node__{type}__{variation}
            /// <summary>
            /// The node's class.
            /// </summary>
            public const string NodeClass = "cappuccino-node__base";

            // - Private Variables
            private Rect m_rectInfo;

            // - Protected Variables

            #region Node Colors
            // These colors are used with the USS Object Model to quickly and easily change the color palette of the Graph Node.

            /// <summary>
            /// The background color for the main container <br></br>
            /// You can see this color behind the title at the top. <br></br><br></br>
            /// These colors cannot be overridden in code and must have a "new" implementation in the inheriting script, alongside a USSOM Sheet.
            /// </summary>
            protected static Color main_container_color = C255.Color(200, 200, 200, 92);

            /// <summary>
            /// The background color for the container with the input and output ports.<br></br><br></br>
            /// These colors cannot be overridden in code and must have a "new" implementation in the inheriting script, alongside a USSOM Sheet.
            /// </summary>
            protected static Color body_background_color = C255.Color(30, 30, 30, 255);

            /// <summary>
            /// Transparency, used for any elements you wish to not see.<br></br><br></br>
            /// These colors cannot be overridden in code and must have a "new" implementation in the inheriting script, alongside a USSOM Sheet.
            /// </summary>
            protected static Color transparent_color = new Color(0f, 0f, 0f, 0f);

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

            /// <summary>
            /// The connector color of the node's execute ports.
            /// </summary>
            protected static Color node_connector_color = C255.Color(200, 200, 200, 255);


            #endregion

            // - Public Variables
            /// <summary>
            /// The size of the node.
            /// </summary>
            public Vector2 size { get { return m_rectInfo.size; }}

            /// <summary>
            /// The position of the node within the graph.
            /// </summary>
            public Vector2 pos { get { return m_rectInfo.position; } }

            public OnChangedEvent onGeometryChangedEvent;

            // Methods
            // - Unlike other scripts, this one is harder to read. Everything here was in order of linear importance instead of anything else.

            /// <summary>
            /// Create a new graph node.
            /// </summary>
            /// <param name="name">The name of the graph node.</param>
            /// <param name="position">The position of the graph node.</param>
            /// <returns></returns>
            public static GraphNode New(string name, Vector2 position, CGraphInstance graphView)
            {
                GraphNode node = new GraphNode();
                node.graph = graphView;

                node.AddSheets();   // Add core style sheets.

                node.Initialize(name, position); // Set name, position and USS classes.

                node.Ports();

                node.Title();   // Set node title.
                node.Contents(); // Set node contents.

                return node;
            }

            /// <summary>
            /// Initialise the core aspects of the node. <br></br>
            /// <see langword="Cappuccino:"/> Handles the naming, positioning and style sheets within the node.
            /// </summary>
            /// <param name="name"></param>
            /// <param name="position"></param>
            public virtual void Initialize(string name, Vector2 position)
            {
                NodeName = name;    

                SetPosition(new Rect(position, Vector2.zero));

                mainContainer.AddToClassList("cappuccino-node__main-container");
                topContainer.AddToClassList("cappuccino-node__top-container");
                extensionContainer.AddToClassList("cappuccino-node__extension-container");

                RegisterCallback<GeometryChangedEvent>(OnGeometryChanged, TrickleDown.TrickleDown);
            }

            /// <summary>
            /// Build a contextual menu. <br></br>
            /// Overrides the default node contextual menu.
            /// </summary>
            /// <param name="evt"></param>
            public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
            {
                evt.menu.AppendAction("Disconnect Inputs", actionEvent => DisconnectPorts(inputContainer));
                evt.menu.AppendAction("Disconnect Outputs", actionEvent => DisconnectPorts(outputContainer));
                base.BuildContextualMenu(evt);
            }

            /// <summary>
            /// Set the title of the Graph Node.
            /// </summary>
            public virtual void Title()
            {
                Label title = new Label(NodeName);
                titleContainer.Insert(0, title);

                title.AddToClassList("cappuccino-node__title-label");
                titleContainer.style.backgroundColor = transparent_color;
                titleButtonContainer.AddToClassList("cappuccino-node__title-button-container");
            }

            /// <summary>
            /// Set the node's input and output ports.
            /// </summary>
            public virtual void Ports()
            {
                AddExecuteInput("exec");
                AddExecuteOutput("then");
            }

            /// <summary>
            /// <see langword="Internal:"/> You can override this class, but you will need to include <see cref="Node.RefreshExpandedState"/> at the last line. <br></br>
            /// If you are looking to just change the contents being drawn in the node's extension container, instead override <see cref="Draw"/>.
            /// </summary>
            protected virtual void Contents()
            {
                Draw();
                RefreshExpandedState(); // Keeps the node expanded.
            }

            /// <summary>
            /// Draw the contents of the node. <br></br>
            /// <b><see langword="Cappuccino:"/></b> Draw requires a call to <see cref="Node.RefreshExpandedState"/>.
            /// </summary>
            protected virtual void Draw() {}

            // This method is intentionally blank for the base node. It *has no* functionality technically.
            /// <summary>
            /// Execute the function(s) built into this method. <br></br><br></br>
            /// <b><see langword="Usage:"/></b> If your node hasn't got any input data ports, <i><b>base.Execute()</b></i> does not need to be called.
            /// </summary>
            public virtual void Execute() 
            { 
                // try resolve all values for all input ports' connections, if they have one.
                foreach (NodePort p in inputs)
                {
                    if (p is DataPort port)
                    {
                        port.ResolveValueFromConnection();
                    }
                }
            }

            #region Port Methods
            // This method is directly sourced from IndieWafflus' series:
            //      -   https://www.youtube.com/watch?v=GSCY27EFR3s (12 April 2023)
            /// <summary>
            /// Disconnect the ports contained within the children of the provided container.
            /// </summary>
            /// <param name="container"></param>
            private void DisconnectPorts(VisualElement container)
            {
                foreach (Port port in container.Children())
                {
                    if (!port.connected) { continue; }
                    graph.DeleteElements(port.connections);
                }
            }

            /// <summary>
            /// Set the next node.
            /// </summary>
            /// <param name="node"></param>
            public virtual void SetNextNode(GraphNode node) => nextNode = node;

            /// <summary>
            /// Set the last node.
            /// </summary>
            /// <param name="node"></param>
            public virtual void SetLastNode(GraphNode node) => lastNode = node;

            // These next two methods thankfully I didn't need any help for - they're relatively straight forward for nodes. Experience with C++ helped to understand what I need to be doing.
            // What we need to do is query for the port based on it's enclosed name and then try get/set the value within that port, if it matches the local data holder's data type. (called LDA in the later comments).

            /// <summary>
            /// Get the variable info being held in a data-port
            /// </summary>
            /// <param name="port_name">The name of the port to look up.</param>
            /// <param name="expected_type">The type that's expecte6 to be in the output.</param>
            /// <param name="local_data_holder">The variable (as a ref/alias) to set the value of.</param>
            protected void GetDataFromPort(string port_name, System.Type expected_type, out object local_data_holder)
            {
                // Set the value of the LDA to the default value.
                local_data_holder = default;

                // Set the value of the matching port to null. if it's still null after the check, return immediately.
                NodePort matching_port = null;

                // Go through all input ports
                foreach (NodePort port in inputs)
                {
                    if (port.enclosedPortName == port_name)
                    {
                        matching_port = port;
                        break;
                    }
                }

                // If the matching port is null, return - otherwise try and unpack the port to get it's value.
                if (matching_port != null)
                {
                    // return if it's not a dataport.
                    if (matching_port is DataPort port)
                    {
                        if (port.value == null)
                        {
                            //Diag.Violation($"{matching_port.enclosedPortName}'s enclosed data is null.");
                            return;
                        }

                        // set the value if the data type is the correct type.
                        if (port.DataType == expected_type)
                        {
                            local_data_holder = ((DataPort)matching_port).value;
                            return;
                        }
                    }
                    else
                    {
                        Diag.Violation($"The queried data port \"{port_name}\" is not a data port.");
                        return;
                    }
                }
                else
                {
                    return;
                }
            }

            /// <summary>
            /// Set the variable info being held in a data-port.
            /// </summary>
            /// <param name="port_name">The name of the port to look up.</param>
            /// <param name="expected_type">The type that's expected to be assigned to the data type.</param>
            /// <param name="local_data_holder">The variable (as a read-only ref/alias) to get the value from.</param>
            /// <returns></returns>
            protected bool SetDataInPort(string port_name, System.Type expected_type, in object local_data_holder)
            {
                // Set the value of the matching port to null. if it's still null after the check, return immediately.
                NodePort matching_port = null;

                // Go through all output ports
                foreach (NodePort port in outputs)
                {
                    if (port.enclosedPortName == port_name)
                    {
                        matching_port = port;
                        break;
                    }
                }

                // If the matching port is null, return false - otherwise try and unpack the port to set it's value.
                if (matching_port != null)
                {
                    // return if it's not a dataport.
                    if (matching_port is DataPort port)
                    {
                        if (port.DataType == expected_type)
                        {
                            // If all conditions are met, we can assume the value is correct and set it to the read-only LDA.
                            port.value = local_data_holder;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        Diag.Violation($"The queried data port \"{port_name}\" is not a data port.");
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            #endregion  

            // This was made possible thanks to one of Unity's official staff members making a comment about how to back in 2020:
            //      - https://forum.unity.com/threads/how-to-get-the-actual-width-and-height-of-an-uielement.820266/
            //      - https://docs.unity3d.com/ScriptReference/UIElements.GeometryChangedEvent.html
            /// <summary>
            /// The behaviour that triggers when OnGeometryChanged is called.
            /// </summary>
            /// <param name="geomEvent"></param>
            protected virtual void OnGeometryChanged(GeometryChangedEvent geomEvent)
            {
                m_rectInfo = geomEvent.newRect;

                if (onGeometryChangedEvent != null)
                {
                    onGeometryChangedEvent.Invoke(this, geomEvent, geomEvent.eventTypeId);
                }
            }

            /// <summary>
            /// A delegate type for delegate variables that are called when a change event happens to the node.
            /// </summary>
            /// <param name="node">The Graph Node that triggered this event.</param>
            /// <param name="evt">The event itself. Cast as an EventBase, though can take other types.</param>
            /// <param name="eventType">The event's Type ID.</param>
            public delegate void OnChangedEvent(GraphNode node, EventBase evt, long eventType);

            #region Styles

            /// <summary>
            /// Add the core style sheets that are required to the node.
            /// </summary>
            public virtual void AddSheets()
            {
                styleSheets.Add(AssetLoader.GetStyleSheet("Core/UIToolkit/GraphWindow/StyleSheets/CappuccinoNodePortsStyle"));
                styleSheets.Add(AssetLoader.GetStyleSheet("Core/UIToolkit/GraphWindow/StyleSheets/InteractiveElementSheets/CappuccinoNodeExtensionContainerTextField"));
            }

            // These Style Sheets use the USS Object Model (comes included with Cappuccino Framework).

            //[ExportSheet(FrameworkUtilities.dirInAssets + "Core/UIToolkit/GraphWindow/StyleSheets", true)]
            public static Sheet NodeStyle() => new Sheet("CappuccinoNodeStyle",

                // Main Container - used for modifying color and transparency.
                SimpleSelector.Class("cappuccino-node__main-container",
                    Rules.BackgroundColor(main_container_color),
                    Rules.MinWidth(new Len(192))
                    ),

                // Border Selection - used for modifying the regular behaviour of the selection border.
                ComplexSelector.Child(new SimpleSelector[] {
                    SimpleSelector.Class("node"),
                    SimpleSelector.Name("selection-border")
                    },
                    Rules.BorderBottomColor(transparent_color),
                    Rules.BorderTopColor(transparent_color),
                    Rules.BorderLeftColor(transparent_color),
                    Rules.BorderRightColor(transparent_color),
                    Rules.BorderTopWidth(new Len(1)),
                    Rules.BorderBottomWidth(new Len(1)),
                    Rules.BorderLeftWidth(new Len(1)),
                    Rules.BorderRightWidth(new Len(1))
                    ),

                // Border Selection - used for modifying the selection and hover behaviour of the node's border.
                ComplexSelector.Child(new SimpleSelector[] {
                    SimpleSelector.Class("node", new Pseudoclass[] { Pseudoclass.Hover()}),
                    SimpleSelector.Name("selection-border")
                    },
                    Rules.BorderColor(selection_translucent_highlight_color),
                    Rules.BorderTopWidth(new Len(1)),
                    Rules.BorderBottomWidth(new Len(1)),
                    Rules.BorderLeftWidth(new Len(1)),
                    Rules.BorderRightWidth(new Len(1))
                    ),

                // Border Selection - used for modifying the selection behaviour of the node's border.
                ComplexSelector.Child(new SimpleSelector[] {
                    SimpleSelector.Class("node", new Pseudoclass[] {Pseudoclass.Checked()}),
                    SimpleSelector.Name("selection-border")
                    },
                    Rules.BorderBottomColor(selection_dragging_highlight_color),
                    Rules.BorderTopColor(selection_dragging_highlight_color),
                    Rules.BorderLeftColor(selection_dragging_highlight_color),
                    Rules.BorderRightColor(selection_dragging_highlight_color),
                    Rules.BorderTopWidth(new Len(2)),
                    Rules.BorderBottomWidth(new Len(2)),
                    Rules.BorderLeftWidth(new Len(2)),
                    Rules.BorderRightWidth(new Len(2))
                    ),

                // Border Selection - used for modifying the selection and hover behaviour of the node's border.
                ComplexSelector.Child(new SimpleSelector[] {
                    SimpleSelector.Class("node", new Pseudoclass[] { Pseudoclass.Hover(), Pseudoclass.Checked()}),
                    SimpleSelector.Name("selection-border")
                    },
                    Rules.BorderColor(selection_highlight_color),
                    Rules.BorderTopWidth(new Len(2)),
                    Rules.BorderBottomWidth(new Len(2)),
                    Rules.BorderLeftWidth(new Len(2)),
                    Rules.BorderRightWidth(new Len(2))
                    ),

                // Main Container: Title-Top Divider - used for hiding the divider.
                ComplexSelector.Child(new SimpleSelector[] {
                    SimpleSelector.Class("cappuccino-node__main-container"),
                    SimpleSelector.Name("contents"),
                    SimpleSelector.Name("divider")
                    },

                    Rules.BackgroundColor(transparent_color),
                    Rules.BorderBottomColor(transparent_color),
                    Rules.BorderTopColor(transparent_color),
                    Rules.BorderLeftColor(transparent_color),
                    Rules.BorderRightColor(transparent_color)
                    ),

                // Title Invisible Divider - used for modifying an invisible divider which currenty
                ComplexSelector.Child(new SimpleSelector[] {
                    SimpleSelector.Class("node"),
                    SimpleSelector.Name("node-border"),
                    SimpleSelector.Name("title"),
                    SimpleSelector.Name("title-label")
                    },
                    Rules.Height(new Len(5)),
                    Rules.MaxHeight(new Len(5))
                    ),

                // Title Button Container - used for forcing the size of the title buttons to be smaller.
                SimpleSelector.Class("cappuccino-node__title-button-container",
                    Rules.BackgroundColor(transparent_color),
                    Rules.Height(new Len(20))
                    ),

                // Title Container - used for forcing the size and height of the title contaienr to be smaller.
                ComplexSelector.Child(new SimpleSelector[] {
                    SimpleSelector.Class("node"),
                    SimpleSelector.Name("node-border"),
                    SimpleSelector.Name("title")
                    },
                    Rules.BackgroundColor(transparent_color),
                    Rules.PaddingLeft(new Len(3)),
                    Rules.Height(new Len(20)),
                    Rules.MarginLeft(new Len(0)),
                    Rules.MarginTop(new Len(0)),
                    Rules.MarginBottom(new Len(0))
                    ),

                // Title Container: Label - used for modifying the visual aspects of the title.
                SimpleSelector.Class("cappuccino-node__title-label",
                    Rules.UnityFontStyle(Rules.FontStyleValue.bold),
                    Rules.TextAlign(Rules.TextAlignValue.middleLeft),
                    Rules.PaddingLeft(new Len(6)),
                    Rules.Height(new Len(20))
                    ),

                // Graph Node Ports
                SimpleSelector.Class("cappuccino-node__top-container",
                    Rules.BackgroundColor(body_background_color)
                    ),

                // Graph Node Extension Background Color
                SimpleSelector.Class("cappuccino-node__extension-container",
                    Rules.BackgroundColor(body_background_color)
                    ),

                // Extension Container Divider - used for hiding the divider between the top and extension containers.
                ComplexSelector.Child(new SimpleSelector[] {
                    SimpleSelector.Class("node"),
                    SimpleSelector.Name("node-border"),
                    SimpleSelector.Name("contents"),
                    SimpleSelector.Name("collapsible-area"),
                    SimpleSelector.Name("divider")
                    },
                    Rules.BorderTopWidth(new Len(0)),
                    Rules.BorderBottomWidth(new Len(0)),
                    Rules.BorderLeftWidth(new Len(0)),
                    Rules.BorderRightWidth(new Len(0)),
                    Rules.Height(new Len(0))
                    )
                );

            // Controls the Intricate Details of the node's Top Container for the ports to look and align without a divider.
            // Also controls the design style of the node ports, if they're an execute port.
            //[ExportSheet(FrameworkUtilities.dirInAssets + "Core/UIToolkit/GraphWindow/StyleSheets", true)]
            public static Sheet PortsStyle() => new Sheet("CappuccinoNodePortsStyle",

                // Force the background color for the ports to be transparent.
                new SelectorList(new Selector[]{
                    ComplexSelector.Child(new SimpleSelector[] { SimpleSelector.Name("node-border"), SimpleSelector.Name("contents"), SimpleSelector.Name("top"), SimpleSelector.Name("output") }),
                    ComplexSelector.Child(new SimpleSelector[] { SimpleSelector.Name("node-border"), SimpleSelector.Name("contents"), SimpleSelector.Name("top"), SimpleSelector.Name("input") })
                    },
                    Rules.BackgroundColor(transparent_color)
                 ),

                // Hide the divider in the top.
                ComplexSelector.Child(new SimpleSelector[] {
                    SimpleSelector.Name("node-border"),
                    SimpleSelector.Name("contents"),
                    SimpleSelector.Name("top"),
                    SimpleSelector.Name("divider")
                },
                    Rules.BorderBottomColor(transparent_color),
                    Rules.BorderTopColor(transparent_color),
                    Rules.BorderLeftColor(transparent_color),
                    Rules.BorderRightColor(transparent_color),
                    Rules.BorderTopWidth(new Len(0)),
                    Rules.BorderBottomWidth(new Len(0)),
                    Rules.BorderLeftWidth(new Len(0)),
                    Rules.BorderRightWidth(new Len(0))
                 ),

                // Port Conenctor Body - Change the Port Design.
                new SelectorList(new Selector[]{
                    ComplexSelector.Child(new SimpleSelector[] {
                        SimpleSelector.Name("node-border"),
                        SimpleSelector.Name("contents"),
                        SimpleSelector.Name("top"),
                        SimpleSelector.Name("input"),
                        SimpleSelector.Class("cappuccino_execute_port"),
                        SimpleSelector.Name("connector") 
                    }),

                    ComplexSelector.Child(new SimpleSelector[] {
                        SimpleSelector.Name("node-border"),
                        SimpleSelector.Name("contents"),
                        SimpleSelector.Name("top"),
                        SimpleSelector.Name("output"),
                        SimpleSelector.Class("cappuccino_execute_port"),
                        SimpleSelector.Name("connector")
                        })
                    },
                    Rules.BorderBottomColor(node_connector_color),
                    Rules.BorderTopColor(node_connector_color),
                    Rules.BorderLeftColor(node_connector_color),
                    Rules.BorderRightColor(node_connector_color),
                    Rules.BorderTopWidth(new Len(1)),
                    Rules.BorderBottomWidth(new Len(1)),
                    Rules.BorderLeftWidth(new Len(1)),
                    Rules.BorderRightWidth(new Len(1)),
                    Rules.Width(new Len(12)),
                    Rules.Height(new Len(12)),
                    Rules.BorderTopRightRadius(new Len(10)),
                    Rules.BorderTopLeftRadius(new Len(0)),
                    Rules.BorderBottomRightRadius(new Len(10)),
                    Rules.BorderBottomLeftRadius(new Len(0))
                 ),

                // Port Conenctor Cap - Change the Port Cap Design.
                new SelectorList(new Selector[]{
                    ComplexSelector.Child(new SimpleSelector[] {
                        SimpleSelector.Name("node-border"),
                        SimpleSelector.Name("contents"),
                        SimpleSelector.Name("top"),
                        SimpleSelector.Name("input"),
                        SimpleSelector.Class("cappuccino_execute_port"),
                        SimpleSelector.Name("connector"),
                        SimpleSelector.Name("cap")
                    }),

                    ComplexSelector.Child(new SimpleSelector[] {
                        SimpleSelector.Name("node-border"),
                        SimpleSelector.Name("contents"),
                        SimpleSelector.Name("top"),
                        SimpleSelector.Name("output"),
                        SimpleSelector.Class("cappuccino_execute_port"),
                        SimpleSelector.Name("connector"),
                        SimpleSelector.Name("cap")
                        })
                    },
                    Rules.BorderBottomColor(node_connector_color),
                    Rules.BorderTopColor(node_connector_color),
                    Rules.BorderLeftColor(node_connector_color),
                    Rules.BorderRightColor(node_connector_color),
                    Rules.Width(new Len(8)),
                    Rules.Height(new Len(8)),
                    Rules.BorderTopRightRadius(new Len(4)),
                    Rules.BorderTopLeftRadius(new Len(0)),
                    Rules.BorderBottomRightRadius(new Len(4)),
                    Rules.BorderBottomLeftRadius(new Len(0))
                 )
                );
            #endregion
        }
    }
}