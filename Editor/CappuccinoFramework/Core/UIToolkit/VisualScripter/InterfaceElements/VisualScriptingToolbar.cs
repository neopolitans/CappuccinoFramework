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
        public class VisualScriptingToolbar : GraphToolbar
        {
            // Variables
            private Label zoom;
            private Rect zoomRect;

            private Button fileButton;
            private Button editButton;
            private Button graphButton;
            private Button helpButton;

            // Constructors
            public VisualScriptingToolbar(CGraphInstance graph) : base(graph) { }

            // Methods
            protected override void Contents()
            {

                fileButton = AddButton("File", delegate {
                    if (currentDropdown == null)
                    {
                        AddDropdown(fileButton, VisualScripting_File_Dropdown.New);
                    }
                    else
                    {
                        RemoveDropdown();
                        if (dropdownInvoker != fileButton)
                        {
                            AddDropdown(fileButton, VisualScripting_File_Dropdown.New);
                        }
                    }
                });

                editButton = AddButton("Edit", delegate {
                    if (currentDropdown == null)
                    {
                        AddDropdown(editButton, VisualScripting_Edit_Dropdown.New);
                    }
                    else
                    {
                        RemoveDropdown();
                        if (dropdownInvoker != editButton)
                        {
                            AddDropdown(editButton, VisualScripting_Edit_Dropdown.New);
                        }
                    }
                });

                graphButton = AddButton("Graph", delegate {
                    if (currentDropdown == null)
                    {
                        AddDropdown(graphButton, VisualScripting_Graph_Dropdown.New);
                    }
                    else
                    {
                        RemoveDropdown();
                        if (dropdownInvoker != editButton)
                        {
                            AddDropdown(graphButton, VisualScripting_Graph_Dropdown.New);
                        }
                    }
                });
                AddDivider();
                helpButton = AddButton("Help", delegate { });

                CreateZoomAtEnd();
            }

            protected void CreateZoomAtEnd()
            {
                zoom = CreateZoomLabel();

                zoom.OnGeometryChanged(delegate (Rect newRect)
                {
                    zoomRect = newRect; // Cache the changes of the first zoom rect calculation.
                    zoom.style.marginLeft = new StyleLength(worldBound.size.x - newRect.x - newRect.width - 4f);
                });

                RegisterCallback(delegate (GeometryChangedEvent evt)
                {
                    zoom.style.marginLeft = new StyleLength(worldBound.size.x - zoomRect.x - zoomRect.width - 4f);
                });

                Insert(childCount, zoom);
            }

            protected override void AddDropdown(Button button)
            {
                base.AddDropdown(button);
            }
        }
    }
}