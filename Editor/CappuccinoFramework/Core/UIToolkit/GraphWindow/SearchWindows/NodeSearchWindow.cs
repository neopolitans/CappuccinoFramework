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
        /// A base class search window for which every context-senstive search window afterwards dervies from.
        /// </summary>
        public class NodeSearchWindow : ScriptableObject, ISearchWindowProvider
        {
            protected CGraphInstance graph;

            /// <summary>
            /// Initialise the node search window, providing a 
            /// </summary>
            /// <param name="graphView"></param>
            public void Initialize(CGraphInstance graphView)
            {
                graph = graphView;
            }

            /// <summary>
            /// Populate the menu with all the types of nodes that can be created.
            /// </summary>
            /// <param name="context"></param>
            /// <returns></returns>
            public virtual List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
            {
                List<SearchTreeEntry> searchTreeEntries = new List<SearchTreeEntry>()
                {
                    new SearchTreeGroupEntry(new GUIContent("Nodes")),
                    new SearchTreeGroupEntry(new GUIContent("Basic Nodes"), 1),
                    new SearchTreeEntry(new GUIContent("Base Node")) {level = 2, userData = typeof(GraphNode)}
                };

                return searchTreeEntries;
            }

            /// <summary>
            /// When an entry in the search tree is selected, this triggers based on which search tree entry, using the user data to determine what node is to be created.
            /// </summary>
            /// <param name="SearchTreeEntry"></param>
            /// <param name="context"></param>
            /// <returns></returns>
            public virtual bool OnSelectEntry(SearchTreeEntry SearchTreeEntry, SearchWindowContext context)
            {
                if ((Type)SearchTreeEntry.userData == typeof(GraphNode))
                {
                    GraphNode node = GraphNode.New("Base Node", graph.graphMousePosition, graph);
                    graph.AddElement(node);

                    node.onGeometryChangedEvent += RepositionAfterCreation;
                    return true;
                }

                return false;
            }

            // This allows nodes to properly be positioned at the center of where the mouse cursor was when the developer opened the search window.
            
            /// <summary>
            /// Repositions the node provided as the first parameter after the OnGeometryChanged event has occured within said node. <br></br>
            /// </summary>
            /// <param name="node">The node that had a Geometry Changed Event happen within.</param>
            /// <param name="evt">The Geometry Changed Event, as an EventBase.</param>
            /// <param name="eventType">The Event Type ID.</param>
            public virtual void RepositionAfterCreation(GraphNode node, EventBase evt, long eventType)
            {
                if (eventType == GeometryChangedEvent.TypeId())
                {
                    Rect nodeRect = ((GeometryChangedEvent)evt).newRect;
                    node.SetPosition(new Rect(new Vector2(nodeRect.x - (nodeRect.size.x / 2f), nodeRect.y), nodeRect.size));
                }

                node.onGeometryChangedEvent -= RepositionAfterCreation; // Unbind no matter what - *could* cause issues though.
            }

        }
    }
}