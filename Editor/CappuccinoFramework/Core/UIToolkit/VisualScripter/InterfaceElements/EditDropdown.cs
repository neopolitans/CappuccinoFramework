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
        /// The dropdown for the "Edit" button on the Visual Scripting toolbar.
        /// </summary>
        public class VisualScripting_Edit_Dropdown : GraphDropdown
        {
            public VisualScripting_Edit_Dropdown(CGraphInstance graph) : base(graph) { }

            /// <summary>
            /// A method-as-constructor for creating a new edit dropdown.
            /// </summary>
            /// <param name="graph">The graph to attach the dropdown to.</param>
            /// <returns></returns>
            public static VisualScripting_Edit_Dropdown New(CGraphInstance graph) => new VisualScripting_Edit_Dropdown(graph);

            protected override void Content()
            {
                AddButton("Rename Blueprint", delegate { });
            }

        }
    }
}