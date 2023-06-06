using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

using Cappuccino.Graphing;
using UnityEditor.Experimental.GraphView;
using System;

namespace Cappuccino
{
    namespace VisualScripting
    {
        /// <summary>
        /// The dropdown for the "Graph" button on the Visual Scripting toolbar. <br></br>
        /// Prefixed with "VisualScripting_" to prevent overlap with "GraphDropdown", the core class which this derives from.
        /// </summary>
        public class VisualScripting_Graph_Dropdown : GraphDropdown
        {
            public VisualScripting_Graph_Dropdown(CGraphInstance graph) : base(graph) { }

            /// <summary>
            /// A method-as-constructor for creating a new graph-button dropdown.
            /// </summary>
            /// <param name="graph">The graph to attach the dropdown to.</param>
            /// <returns></returns>
            public static VisualScripting_Graph_Dropdown New(CGraphInstance graph) => new VisualScripting_Graph_Dropdown(graph);

            protected override void Content()
            {
                AddButton("Preview Plugin", "Opens the Previewer to show the plugin contents.", delegate {
                    PluginPreviewer.CreatePreviewer(graph.blueprintName, (PluginBlueprintDesigner)graph.window);
                });

                AddDivider();

                AddButton("Clear Graph", "Clicking this button will reset the Graph Editor.", delegate {
                    CGraph wnd = graph.window;
                    wnd.rootVisualElement.Remove(graph);
                    wnd.OnEnable();
                });
            }

        }
    }
}