using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

using Cappuccino.Graphing;
using UnityEditor.Experimental.GraphView;

namespace Cappuccino
{
    namespace VisualScripting
    {
        public class VisualScriptingNodeSearcher : NodeSearchWindow
        { 
            public override List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
            {
                List<SearchTreeEntry> searchTreeEntries = new List<SearchTreeEntry>()
                {
                    new SearchTreeGroupEntry(new GUIContent("Visual Scripting Nodes")),
                        new SearchTreeGroupEntry(new GUIContent("Core Nodes"), 1),
                            new SearchTreeEntry(new GUIContent("Branch")) {level = 2, userData = typeof(BranchNode)},
                        new SearchTreeGroupEntry(new GUIContent("IMGUI Nodes"), 1),
                            new SearchTreeEntry(new GUIContent("UI Toggle")) {level = 2, userData = typeof(ToggleNode)}
                };

                return searchTreeEntries;
            }

            /// <summary>
            /// When an entry in the search tree is selected, this triggers based on which search tree entry, using the user data to determine what node is to be created.
            /// </summary>
            /// <param name="SearchTreeEntry"></param>
            /// <param name="context"></param>
            /// <returns></returns>
            public override bool OnSelectEntry(SearchTreeEntry SearchTreeEntry, SearchWindowContext context)
            {
                switch ((Type)SearchTreeEntry.userData)
                {
                    case Type branch when branch == typeof(BranchNode):
                        BranchNode branch_node = BranchNode.New("Branch", graph.graphMousePosition, graph);
                        graph.AddElement(branch_node);

                        branch_node.onGeometryChangedEvent += RepositionAfterCreation;
                        return true;

                    case Type toggle when toggle == typeof(ToggleNode):
                        ToggleNode toggle_node = ToggleNode.New("GUI Toggle", graph.graphMousePosition, graph);
                        graph.AddElement(toggle_node);

                        toggle_node.onGeometryChangedEvent += RepositionAfterCreation;
                        return true;
                }

                return false;
            }
        }
    }
}   