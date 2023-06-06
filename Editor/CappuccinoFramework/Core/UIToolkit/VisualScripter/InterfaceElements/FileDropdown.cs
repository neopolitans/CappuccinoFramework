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
        /// <summary>
        /// The dropdown for the "File" button on the Visual Scripting toolbar.
        /// </summary>
        public class VisualScripting_File_Dropdown : GraphDropdown
        {
            public VisualScripting_File_Dropdown(CGraphInstance graph) : base(graph) { }

            /// <summary>
            /// A method-as-constructor for creating a new file dropdown.
            /// </summary>
            /// <param name="graph">The graph to attach the dropdown to.</param>
            /// <returns></returns>
            public static VisualScripting_File_Dropdown New(CGraphInstance graph) => new VisualScripting_File_Dropdown(graph);

            protected override void Content()
            {
                AddButton("Open", delegate { });
                AddDivider();
                AddButton("Save", delegate { });
                AddButton("Save as...", delegate { });
                AddDivider();
                AddButton("Export To...", delegate { });
            }
        }
    }
}