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
        public class testWindow : CGraph
        {
            protected static CGraph window;

            [MenuItem("Cappuccino/Base Graph Window")]
            public static void OpenGraphView()
            {
                window = Open<testWindow>();
                window.Rename("Base Graph Window");
                window.minSize = new Vector2(768f, 512f);
            }
        }

        public class PluginBlueprintDesigner : CGraph
        {
            // Variables
            protected static PluginBlueprintDesigner window;

            public System.Action func_OnEnable;
            public System.Action func_OnGui;

            // Methods
            // - Open Window Method
            [MenuItem("Cappuccino/Blueprint Designer")]
            public static void OpenGraphView()
            {
                window = Open<PluginBlueprintDesigner>();
                window.Rename("Plugin Blueprint Designer");
                window.minSize = new Vector2(768f, 512f);
            }

            // - Protected Methods
            /// <summary>
            /// Add a GraphViewInstance to the Blueprint Designer's Window.
            /// </summary>
            protected override void AddGraphInstance()
            {
                graph = new CGraphInstance(this, false);
                graph.blueprintName = "blueprint";
                SetWatermark(graph.blueprintName);
                AddCustomNodeSearcher();

                graph.StretchToParentSize();

                rootVisualElement.Insert(0, graph);
            }

            // Because there's a default, generic node searcher this won't work normally.
            /// <summary>
            /// Add the custom visual-scripting node searcher.
            /// </summary>
            protected void AddCustomNodeSearcher()
            {
                graph.nodeSearcher = CreateInstance<VisualScriptingNodeSearcher>();
                graph.nodeSearcher.Initialize(graph);
                graph.AddSearchWindows();
            }

            // - Public Methods
            /// <summary>
            /// Add the graph and nodes to the core window.
            /// </summary>
            public override void OnEnable()
            {
                if (window == null) { OpenGraphView(); }
                AddGraphInstance();    // Because we do some custom behaviour
                AddToolbar();

                FunctionNode node_OnEnable = (FunctionNode)AddNode(FunctionNode.New("On Enable", new Vector2(0f, 0f), graph));
                func_OnEnable = node_OnEnable.Execute;

                FunctionNode node_OnGui = (FunctionNode)AddNode(FunctionNode.New("On GUI", new Vector2(0f, 192f), graph));

                func_OnGui = node_OnGui.Execute;
            }

            /// <summary>
            /// Add the Visual Scripting Toolbar to the scripting window.
            /// </summary>
            public override void AddToolbar()
            {
                base.AddToolbar(new VisualScriptingToolbar(graph));
            }
        }
    }
}