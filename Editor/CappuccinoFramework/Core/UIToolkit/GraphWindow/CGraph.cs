using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

using UnityEditor.Experimental.GraphView;

using Cappuccino.Core;

// If your version of Unity doesn't have the following then you will be unable to use this feature:<br></br>
// Version Dependency: Experimental  - Found within UnityEngine 2019.1 or later.
// Version Dependency: UIElements    - Found within UnityEngine 2019.1 or later.
// Version Dependency: VisualElement - Found within UnityEngine 2019.1 or later.

namespace Cappuccino
{
    // Graphing is an extension namespace which adds.
    namespace Graphing
    {
        /// <summary>
        /// A deriveable class that creates a CGraph window containing a Graph Instance. This class derives core functionality from the <i>IMGUI-focused</i> CEditor. <br></br>
        /// <i>This extension is only compatible with <b>[UnityEngine 2019.1 or later]</b>.</i> <br></br><br></br>
        /// 
        /// <see langword="Notice:"/> Not to be confused with CGraphInstance, which is the graph itself rather than the window.
        /// </summary>
        public class CGraph : CEditor
        {
            /// <summary>
            /// The GraphView Instance that is being accessed through the <b>CGraph</b> class.
            /// </summary>
            protected static CGraphInstance graph;

            // Private Methods

            /// <summary>
            /// <b>OnEnable</b> adds the Graph Instance to the CGraph Window. <br></br>
            /// It is advised not to override this unless you remember to call AddGraphInstance() later.
            /// </summary>
            public virtual void OnEnable()
            {
                AddGraphInstance();
            }

            /// <summary>
            /// Add a GraphViewInstance to the CGraph Window.
            /// </summary>
            protected virtual void AddGraphInstance()
            {
                graph = new CGraphInstance(this);

                graph.StretchToParentSize();

                rootVisualElement.Insert(0, graph);
            }

            /// <summary>
            /// Add a new default toolbar to the Graph Instance.
            /// </summary>
            public virtual void AddToolbar()
            {
                graph.SetToolbar();
            }

            /// <summary>
            /// Add a new custom toolbar to the Graph Instance.
            /// </summary>
            /// <param name="newToolbar"></param>
            public virtual void AddToolbar(GraphToolbar newToolbar)
            {
                graph.SetToolbar(newToolbar);
            }

            /// <summary>
            /// Add a Comment to the Graph.
            /// </summary>
            /// <param name="node">The graph node to be added to the graph.</param>
            /// <returns><see cref="Node"/> - For further manipulation after being added.</returns>
            public GraphNode AddNode(GraphNode node)
            {
                if (graph == null) { return null; }

                graph.AddElement(node);

                return node;
            }

            /// <summary>
            /// Add a Comment to the Graph.
            /// </summary>
            /// <param name="comment">The comment to be added to the graph.</param>
            /// <returns><see cref="Comment"/> - For further manipulation after being added.</returns>
            public Comment AddComment(Comment comment)
            {
                if (graph == null) { return null; }

                graph.AddElement(comment);

                return comment;
            }

            /// <summary>
            /// Add a custom node search window to the graph.
            /// </summary>
            /// <param name="searcher">The custom node-searcher to add to the graph view.</param>
            public virtual void AddCustomNodeSearcher(NodeSearchWindow searcher)
            {
                graph.nodeSearcher = searcher;
                graph.nodeCreationRequest = context => SearchWindow.Open(new SearchWindowContext(context.screenMousePosition), graph.nodeSearcher);
            }

            /// <summary>
            /// Set the View Transform of the Graph inside the GraphView element using a Vector2.
            /// </summary>
            /// <param name="viewPosition">The Vector2 view position used for the X and Y values.</param>
            public void SetView(Vector2 viewPosition)
            {
                graph.viewTransform.position = new Vector3(viewPosition.x, viewPosition.y, 0f);
            }

            /// <summary>
            /// Set the View Transform of the Graph inside the GraphView element using a Vector3.
            /// </summary>
            /// <param name="viewPosition">The Vector2 view position used for the X, Y and Z values.</param>
            public void SetView(Vector3 viewPosition)
            {
                graph.viewTransform.position = new Vector3(viewPosition.x, viewPosition.y, viewPosition.z);
            }

            // - Prevent IMGUI from being loaded in the background.
            public override void OnGUI() { }
                
            // Public Methods

            /// <summary>
            /// <see langword="Cappuccino:"/> Set the watermark text of the graph window. <br></br><br></br>
            /// Provided for those looking for an Unreal-like experience.
            /// </summary>
            /// <param name="watermarkText">The text to set the watermark to.</param>
            public virtual void SetWatermark(string watermarkText)
            {
                // Return if there's no graph instance.
                if (graph == null) { return; }

                graph.SetWatermarkText(watermarkText);
            }
        }
    }
}