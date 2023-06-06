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
        /// Tampering with this class is not advised unless you know how to use GraphView, Nodes, Ports, Unity Style Sheets, UI Toolkit and various other elements. <br></br>
        /// For all other use cases, <see cref="CGraph"/> exposes the most helpful elements, including the direct CGraphInstance object for further modification.
        /// </summary>
        public partial class CGraphInstance : GraphView
        {
            // Variables
            // - Instance Variables [public or private]
            /// <summary>
            /// The CEditor Window (CGraph Subclass) that contains this graph view.
            /// </summary>
            public CGraph window;

            /// <summary>
            /// The grid background used in the graph view.
            /// </summary>
            GridBackground background;

            /// <summary>
            /// The watermark label to use.
            /// </summary>
            Label watermark;

            /// <summary>
            /// The container with all the toolbar contents.
            /// </summary>
            public GraphToolbar toolbar;

            /// <summary>
            /// The node search window that will appear if spacebar is pressed a node's port connection is dragged off.
            /// </summary>
            public NodeSearchWindow nodeSearcher;

            // - Private Variables
            private Vector2 m_localMousePos;
            private Vector2 m_mousePos;
            private Vector2 m_graphPos;

            // - Public Variables
            public string blueprintName = "";
            public bool mouseInWindow;
            public bool hasFocus;

            /// <summary>
            /// Get the mouse's position in the local coordinates of the content container.
            /// </summary>
            public Vector2 localMousePosition { get { return m_localMousePos; } protected set { m_localMousePos = value; } }

            /// <summary>
            /// Get the mouse's position in the panel's coordinates system.
            /// </summary>
            public Vector2 mousePosition { get { return m_mousePos; } protected set { m_mousePos = value; } }

            /// <summary>
            /// Get the mouse's position in the graph's coordinates system. <br></br>
            /// <b><see langword="Notice:"/></b> Refers to the draggable grid's mouse position.
            /// </summary>
            public Vector2 graphMousePosition { get { return m_graphPos; } protected set { m_graphPos = value; } }

            // Methods
            // - Constructors
            /// <summary>
            /// Create a Graph Instance using the default search windows.
            /// </summary>
            public CGraphInstance(CGraph window)
            {
                this.window = window;

                AddManipulators();
                AddGridBackground();
                AddGraphCallbacks();

                AddSearchWindows();

                AddDefaultGraphStyles();

                viewTransform.position += (new Vector3(window.size.x, window.size.y, 0f) / 2f) / EditorGUIUtility.pixelsPerPoint;
            }

            /// <summary>
            /// Create a Graph Instance, specifying whether or not to use the default search windows.
            /// </summary>
            public CGraphInstance(CGraph window, bool useDefaultSearchWindows)
            {
                this.window = window;

                AddManipulators();
                AddGridBackground();
                AddGraphCallbacks();

                if (useDefaultSearchWindows)
                {
                    AddSearchWindows();
                }

                AddDefaultGraphStyles();

                viewTransform.position += (new Vector3(window.size.x, window.size.y, 0f) / 2f) / EditorGUIUtility.pixelsPerPoint;
            }

            // - Protected Methods

            /// <summary>
            /// Register any callbacks that the GraphView must react to before it's child Visual Elements do.
            /// </summary>
            protected void AddGraphCallbacks()
            {
                // Used for tracking the mouse position accurately.
                contentContainer.RegisterCallback<MouseMoveEvent>(MouseMoved, TrickleDown.TrickleDown);

                // Used for tracking when the graph is in focus or not.
                RegisterCallback(delegate (FocusEvent f_evt) { hasFocus = true; });
                RegisterCallback(delegate (BlurEvent b_evt) { hasFocus = false; });

                // If the graph has focus then pressing C will add 
                RegisterCallback(delegate (KeyDownEvent evt)
                {
                    // Create a comment if the graph has focus and the keycode C is pressed.
                    if (evt.keyCode == KeyCode.C && hasFocus)
                    {
                        // If the toolbar or dropdown has focus, return.
                        if (UIElementsHaveFocus()) { return; } 
                        AddElement(Comment.New("Comment", graphMousePosition, this));
                    }
                });
            }

            protected virtual void OnKeyDown(KeyDownEvent kde)
            {
                switch (kde.keyCode)
                {
                    default: break; // Do nothing.

                    case KeyCode.M: // Minimap key.
                        if (UIElementsHaveFocus()) { break; }

                        break;
                }
            }

            /// <summary>
            /// Get the mouse positions based on the current location within the window.
            /// </summary>
            /// <param name="moveEvt">The Mouse Movement event.</param>
            protected virtual void MouseMoved(MouseMoveEvent moveEvt)
            {
                localMousePosition = moveEvt.localMousePosition;
                mousePosition = moveEvt.mousePosition;

                graphMousePosition = -(contentViewContainer.worldBound.position - localMousePosition) / scale;

                //Debug.Log($"MousePos : {mousePosition} | Graph: {graphMousePosition}"); 
                // - Uncomment this if you want to see the debugging that helped form the explanation.
                // - 'MousePos' is relative to the top left corner of the window,' Graph' is relative to the origin point in the grid.
            }
            /* Just some developer notes here about getting the mouse position:
             * I need the MousePosition within the window and within the graph because node creation from the search menu is otherwise massively inaccurate when creating nodes. (press space or drag a port connection into an empty space to see it)
             * 
             * By taking the world bounds position minused by the local mouse position, we get the position of the mouse relative to the graph view. However, that won't work for the position Vector2 required when calling GraphNode.New() 
             * (or any variation thereof). To fix this we wrap brackets around the subtraction and negate the result to get the 'Visual' graph position. This will give us a position within the bounds of (0 -> window size x, 0 -> window size y) that we
             * can use to place a node.
             * 
             * Trying to use that alone will only place the node within a fixed range from the graph's origin point (0,0), but backwards. Another limitation of just using the value on it's own is that it can only be placed at an X,Y coordinate that's 
             * within the size of the editor window instead of the size of the graph. By dividing the negated result by the graph's zoom ('scale'), the node will be positioned correctly relative to how far away the location is from the center of the graph 
             * and relative to the graph's zoom level, using the mouse position within the editor window as a basis for the transform.
             * 
             * The other reason we don't the unmodified result is because using the result would place the node along the (-x, +y) direction. The negation gives us the (+x, -y) direction, which is the correct 'visual' direction.
             * 
             * Another note: Our Graph View's axis is a bit messed up. The graph seemingly percieves it's world bounds position based on the position of the editor window's top left corner within itself, so the "visual" (-x, +y) basis vectors act like 
             * the logical (+x, +y) basis vectors for the graph.
             *               
             *  By providing a mouse position, local mouse position and graph mouse position to developers, it makes extending and creating graph view behaviours which require the exact position of the mouse much easier provided there's a reference to the
             *  CGraphInstance stored in the object on creation. 
             *  
             *  Resources used:
             *  - https://docs.unity3d.com/Manual/UIE-Events-Handling.html#:~:text=Listen%20to%20value%20changes - For creating event handlers and intercepting the mouse's position from the CGraphInstance's content container visual element.
             *  - https://answers.unity.com/questions/1825041/how-to-get-the-correct-contextual-menu-mouse-posit.html (ended up going entirely unused, but influecned the problem-solving process and introudced some extra members in the GraphView class)
             *
             *Another note: The GraphView's axis is a bit deceptive. Dragging the graph view in the following directions results in the following x, y World Bounds directions: (This is based on the top left corner of the graph view, not the center of the view)
             *  Dragging 'Visual Axis' (-x, +y) -> World Bounds 'Logical Axis' (+x, +y)
             *  Dragging 'Visual Axis' (+x, +y) -> World Bounds 'Logical Axis' (-x, +y)
             *  Dragging 'Visual Axis' (-x, -y) -> World Bounds 'Logical Axis' (+x, -y)
             *  Dragging 'Visual Axis' (+x, -y) -> World Bounds 'Logical Axis' (-x, -y)
             * 
             *  To see this: right click on the name of the plugin in the tab bar, open up UIToolkit Debugger and open up foldouts until you see "ContentViewContainer #contentViewContainer". 
             *               Observe the WorldBounds value in the right-hand panel as you drag.
             *  
             *  The visual axis is the one we use and want to "negate" for placing nodes, the logical axis is the one that Unity tracks for the GraphView.
             */

            /// <summary>
            /// Handle any generated Action Events from the Graph.
            /// </summary>
            /// <param name="evt">The Event object.</param>
            protected override void ExecuteDefaultActionAtTarget(EventBase evt)
            {
                base.ExecuteDefaultActionAtTarget(evt);

                if (evt.eventTypeId == MouseEnterEvent.TypeId())
                {
                    mouseInWindow = true;
                }

                if (evt.eventTypeId == MouseLeaveEvent.TypeId())
                {
                    mouseInWindow = false;
                }
            }

            /// <summary>
            /// Do UI Elements (Toolbar and/or dropdowns attached to them) have focus? <br></br>
            /// </summary>
            /// <returns></returns>
            protected virtual bool UIElementsHaveFocus()
            {
                bool a = toolbar != null && toolbar.hasFocus;
                bool b = toolbar != null && toolbar.currentDropdown != null && toolbar.currentDropdown.hasFocus;
                return a || b;
            }

            // - Public Methods

            /// <summary>
            /// Add the graph manipulators, which control how we can view or modify the contents of the Graph Window.
            /// </summary>
            public void AddManipulators()
            {
                SetupZoom(ContentZoomer.DefaultMinScale / 1.25f, ContentZoomer.DefaultMaxScale * 1.25f); // Allow us to zoom in and out of our graph.
                this.AddManipulator(new ContentDragger());  // Allow us to use our mouse (Middle Mouse) to move around the graph.

                this.AddManipulator(new SelectionDragger()); // Allow us to drag one or more selected nodes. Must go before Rectangle Selector.
                this.AddManipulator(new RectangleSelector()); // Allow us to select multiple nodes at once.

                this.AddManipulator(CreateNodeMenuItem("Add Node", GraphNode.New));
                this.AddManipulator(CreateGroupMenuItem("Add Comment", Comment.New));
            }

            /// <summary>
            /// Add the relavent search windows for logic and data nodes.
            /// </summary>
            public void AddSearchWindows()
            {
                if (nodeSearcher == null)
                {
                    nodeSearcher = ScriptableObject.CreateInstance<NodeSearchWindow>();
                    nodeSearcher.Initialize(this);
                }

                nodeCreationRequest = context => SearchWindow.Open(new SearchWindowContext(context.screenMousePosition), nodeSearcher);
            }

            /// <summary>
            /// Open the Node Search Window.
            /// </summary>
            public void OpenNodeSearch()
            {
                if (nodeSearcher != null)
                {
                    SearchWindow.Open(new SearchWindowContext(window.position.position + Event.current.mousePosition), nodeSearcher);
                }
            }

            /// <summary>
            /// Set the Toolbar for the Graph Window. <br></br>
            /// <see langword="Cappuccino:"/> This variation creates a new GraphToolbar instance.
            /// </summary>
            public void SetToolbar()
            {
                toolbar ??= new GraphToolbar(this); // Use the toolbar container if one exists, otherwise create and assign a new visual element the variable.
                
                Insert(3, toolbar);
            }

            /// <summary>
            /// Set the Toolbar for the Graph Window. <br></br>
            /// <see langword="Cappuccino:"/> This variation requires you create and provide a new toolbar.
            /// </summary>
            public void SetToolbar(GraphToolbar newToolbar)
            {
                if (toolbar != null && Contains(toolbar)) { Remove(toolbar); } // Remove toolbar as a precaution, just in case it wasn't properly removed already.
                toolbar = newToolbar; // Use the toolbar container if one exists, otherwise create and assign a new visual element the variable.

                Insert(3, toolbar);
            }

            /// <summary>
            /// Set the watermark text of the graphi instance.
            /// </summary>
            /// <param name="text">The text to set the watermark to.</param>
            public void SetWatermarkText(string text)
            {
                watermark ??= new Label(); // Use watermark if it exists, otherwise create and assign a new label the variable.

                watermark.text = text.ToUpper();
                watermark.focusable = false;

                watermark.StretchToParentSize();
                watermark.AddToClassList("cappuccino-graph__watermark-label");

                Insert(1, watermark);
            }

            // Contains all the style sheet creation, loading and addition for the graph instance.
            #region Background & USS Setup

            /// <summary>
            /// Add the Grid Background to the Graph View.
            /// </summary>
            protected void AddGridBackground()
            {
                background = new GridBackground();
                background.StretchToParentSize();

                Insert(0, background);
            }

            /// <summary>
            /// Add all required Unity Style Sheets to the Graph View.
            /// </summary>
            protected void AddDefaultGraphStyles()
            {
                AddStyle("Core/UIToolkit/GraphWindow/StyleSheets/GridBackground");
                AddStyle("Core/UIToolkit/GraphWindow/StyleSheets/CappuccinoGraphToolbarStyle");
                AddStyle("Core/UIToolkit/GraphWindow/StyleSheets/CappuccinoGraphToolbarDropdownStyle");
                AddStyle("Core/UIToolkit/GraphWindow/StyleSheets/CappuccinoNodeStyle");
                AddStyle("Core/UIToolkit/GraphWindow/StyleSheets/CappuccinoGraphGroupStyle");
                AddStyle("Core/UIToolkit/GraphWindow/StyleSheets/CappuccinoGraphGroupResizerStyle");
            }

            /// <summary>
            /// Get a Unity Style Sheet with the corresponding name from the path within Cappuccino Framework and add it to the graph instance.<br></br>
            /// <b>This does not need the file extension to be provided, only the sheet name. </b> <br></br><br></br>
            /// <see langword="Cappuccino:"/> This method is provided as a Style Sheet may not have a fixed place in the framework.
            /// </summary>
            /// <param name="sheetPath">The path of the sheet, including the sheet name.</param>
            /// <returns></returns>
            protected void AddStyle(string sheetPath)
            {
                StyleSheet style = AssetLoader.GetStyleSheet(sheetPath);

                styleSheets.Add(style);
            }

            /// <summary>
            /// Export a GridBackground Unity Style Sheet. <br></br>
            /// This will trigger any time the script is saved.
            /// </summary>
            /// <returns></returns>
            //[ExportSheet(FrameworkUtilities.dirInAssets + "Core/UIToolkit/GraphWindow/StyleSheets", true)]
            public static Sheet GridBackground() => new Sheet("GridBackground",
                SimpleSelector.Type("GridBackground",
                        Rules.Variable("grid-background-color", new ColorRGBA(38, 38, 38, 1.0f)),
                        Rules.Variable("line-color", new ColorRGBA(46, 46, 46, 1.0f)),
                        Rules.Variable("thick-line-color", new ColorRGBA(24, 24, 24, 1.0f)),
                        Rules.Variable("spacing", 15)
                    ),

                SimpleSelector.Class("cappuccino-graph__watermark-label",
                    Rules.Color(new Color(1f, 1f, 1f, 0.15f)),
                    Rules.TextAlign(Rules.TextAlignValue.lowerRight),
                    Rules.FontSize(new Len(48)),
                    Rules.UnityFontStyle(Rules.FontStyleValue.bold),
                    Rules.PaddingRight(new Len(12)),
                    Rules.PaddingBottom(new Len(3))
                    )
                );

            #endregion

        }
    }
}