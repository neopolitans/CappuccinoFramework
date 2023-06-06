using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

using UnityEditor.Experimental.GraphView;

using Cappuccino.Core;
using Cappuccino.Interpreters.Languages.USS;

using System;

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
            protected IManipulator CreateNodeMenuItem(string actionTitle, NodeFactory constructor)
            {
                ContextualMenuManipulator contextualMenu = new ContextualMenuManipulator(
                    menuEvent => menuEvent.menu.AppendAction(actionTitle, actionEvent => AddElement(constructor("Base Node", contentViewContainer.WorldToLocal(actionEvent.eventInfo.localMousePosition), this)))
                    );

                return contextualMenu;
            }

            protected IManipulator CreateGroupMenuItem(string actionTitle, GroupFactory constructor)
            {
                ContextualMenuManipulator contextualMenu = new ContextualMenuManipulator(
                    menuEvent => menuEvent.menu.AppendAction(actionTitle, actionEvent => AddElement(constructor("Comment", contentViewContainer.WorldToLocal(actionEvent.eventInfo.localMousePosition), this)))
                    );

                return contextualMenu;
            }

            /// <summary>
            /// The node element creation method to use.
            /// </summary>
            /// <param name="name">The name to display in the node's title.</param>
            /// <param name="position">The position to place the group at within the grid.</param>
            /// <returns><see cref="GraphNode"/> or inheritor.</returns>
            public delegate GraphNode NodeFactory(string name, Vector2 position, CGraphInstance graphInstance);

            /// <summary>
            /// The group element creation method to use.
            /// </summary>
            /// <param name="name">The name to display in the group's title</param>
            /// <param name="position">The position to place the group at within the grid.</param>
            /// <param name="graphInstance">The Graph that the resulting group is attached to.</param>
            /// <returns><see cref="Group"/> or inheritor.</returns>
            public delegate Group GroupFactory(string name, Vector2 position, CGraphInstance graphInstance);
        }
    }
}