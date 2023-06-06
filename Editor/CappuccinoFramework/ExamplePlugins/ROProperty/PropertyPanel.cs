using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using Cappuccino.Core;

namespace ROProperty
{
    /*
        This Editor Panel uses MANUAL DRAWING and AUTOMATIC DRAWING methods for it's contents.
        Some of the values contained within are the ones that best worked with the editor window, achieving the desired look.
        
        Manually-Drawn methods pass through a Rect alongside the other values. Unity separates these into two separate variations,
        Cappuccino combines them for quicker editing.
    */

    public class Body
    {
        // The size of the editor window we can use.
        // This is set in Draw() to help with determining how much space
        // we have to work with due to the ScrollArea Scrollbars.
        static Vector2 size;

        // currentPosition is used to track where to draw the next UI Element.
        // This is used for Manually Drawn elements in tandem with the auto-layout methods.
        static Vector2 currentPosition;

        // scrollPosition is used for the ScrollArea
        static Vector2 scrollPosition;

        // CObject is used in place of SerializedObject though acts nearly identically.
        static CObject selected;

        // The components of the (unserializedObject)
        static Component[] objectComponents;

        // The iterator CObject (for components) and CProperty (component properties) panels to use.
        static CObject component_iterator;
        static CProperty property_iterator;

        // The bool array is dynamically changed and used for the various foldouts representing eahc component..
        static bool[] componentFoldoutBools = new bool[1]; 

        /// <summary>
        /// Draw this Editor Panel.
        /// </summary>
        public static void Draw()
        {
            // If there isn't any object selected to serialize and draw, draw an Alert instead.
            // Otherwise, serialize the object and continue.
            if (Selection.activeGameObject == null)
            {
                RoPropertyManager.wnd.Alert("No Game Object is selected.");
                return;
            }
            else
            {
                selected = new CObject(Selection.activeGameObject);
            }

            // Update the representation of the CObject.
            selected.Update();

            // Get the current size of the window, accounting for the 16px wide scrollbar on the side + 1px overhead for content drawing.
            size = RoPropertyManager.wnd.position.size - new Vector2(17f, 0);

            // Set the currentPosition to zero so that manually-drawn contents aren't drawn out of bounds.
            currentPosition = Vector2.zero;

            // Draw the provided ScrollContents method with the scrollPosition and ScrollBar settings.
            scrollPosition = UI.ScrollArea(ScrollContents, scrollPosition, UI.ScrollBarDraw.None);

            // Apply any changes made to the contents.
            selected.Apply();
        }

        /// <summary>
        /// Use these contents for the UI.ScrollArea call.
        /// </summary>
        static void ScrollContents()
        {
            // Draw the header for the panel in a Vertical auto-layout Area, displaying what GameObject is currently being selected.
            UI.Vertical(PropertiesHeader, UI.GetStyle(StudioColor.LightOutline));

            // Draw the Properties for this object in a Vertical auto-layout Area.
            UI.Vertical(PropertyPanelLayout, UI.GetStyle(StudioColor.Base), GUILayout.Height(size.y));
        }

        /// <summary>
        /// Draw a Header in a similar style to ROBLOX Studio's header.
        /// </summary>
        static void PropertiesHeader()
        {
            // Force the Vertical Area to draw filler content.
            UI.Space(1); 
            UI.Label("");

            // Create a rect for  the properties panel to use to display the selected object type followed by the object name.
            Rect HeaderRect = new Rect(1f, 0.5f, size.x + 2.5f, 21f);

            // Split the component name to get the display name of the game object being selected.
            string[] split = selected.obj.targetObject.GetType().ToString().Split(".");

            // Draw the properties header with the provided Rect, display name and style.
            // Then account for the size of the header.
            UI.Label(HeaderRect, "Properties - " + split[split.Length - 1] + " \"" + selected.obj.targetObject.name + "\"", UI.GetStyle(StudioStyle.HeaderGreyLabel));
            currentPosition += new Vector2(0f, 22f);
        }

        /// <summary>
        /// Draw the following contents for the layout of the propreties panel.
        /// </summary>
        static void PropertyPanelLayout()
        {
            // Draw the initial space between the Properties header and the  panel layout
            UI.Horizontal(delegate { UI.Space(1); }, UI.GetStyle(StudioColor.LightOutline), GUILayout.Width(size.x + 4f), GUILayout.Height(1f));

            // Refresh the current objectComponents array.
            objectComponents = Selection.activeGameObject.GetComponents(typeof(Component));

            // Prevent the component foldouts being reset if the objectComponent count hasn't changed. Rudimentary and not the best solution.
            componentFoldoutBools = componentFoldoutBools.Length == objectComponents.Length ? componentFoldoutBools : new bool[objectComponents.Length];

            // Draw each foldout.
            for (int i = 0; i < objectComponents.Length; i++)
            {
                // create a CObject of the current objectComponent
                component_iterator = new CObject(objectComponents[i]);

                // Update the current object component.
                component_iterator.Update();

                // Get the first property of the object component.
                property_iterator = component_iterator.First();

                // Draw the autolayout placeholder for the current foldout and account for the foldout size in currentPosition.
                UI.Horizontal(delegate { UI.Space(1); }, componentFoldoutBools[i] ? UI.GetStyle(StudioStyle.FoldoutHeaderOpen) : UI.GetStyle(StudioStyle.FoldoutHeaderClosed), GUILayout.Width(size.x + 4f), GUILayout.Height(18f));
                currentPosition += new Vector2(0f, 18f);

                // Split the name of the component type (as a string) to only return the name of the component without the namespace(s) it belongs to prefixed.
                string[] split = objectComponents[i].GetType().ToString().Split(".");

                // Draw the Data foldout with manual positioning.
                componentFoldoutBools[i] = UI.Foldout(new Rect(currentPosition.x + 2f, currentPosition.y - 18f, size.x, 18f),
                    delegate
                    {
                        // If the next element can be found in the iterator list, return it.
                        // Note: the first property before this is a foldout called "Base." Foldouts aren't supported.
                        if (property_iterator.NextVisible(true))
                        {
                            PropertyElement(property_iterator);
                        }

                        if (property_iterator.NextVisible(false))
                        {
                            do
                            {
                                PropertyElement(property_iterator);
                            }
                            while (property_iterator.NextVisible(false));
                            BlankElement();
                        }
                    }
                    ,
                    new GUIContent("    " + split[split.Length - 1], componentFoldoutBools[i] ? RoPropertyManager.assetHandler.GetTexture("FoldoutOpen.png") : RoPropertyManager.assetHandler.GetTexture("FoldoutClosed.png")),
                    componentFoldoutBools[i],
                    true,
                    componentFoldoutBools[i] ? UI.GetStyle(StudioStyle.FoldoutHeaderOpen) : UI.GetStyle(StudioStyle.FoldoutHeaderClosed)
                    );

                // Apply any changes made to the component.
                component_iterator.Apply();
            }

            // Add an End Cap - Will not always work.
        }
            
        #region Property Drawing Methods

        /// <summary>
        /// Draw a Property Element
        /// </summary>
        /// <param name="p">The property to draw to screen.</param>
        static void PropertyElement(CProperty p)
        {
            // Create the automatically laid out Horizontal space for the property.
            // This method of constructing a UIContent delegate in the paramater call is also valid for all Cappuccino Methods.
            UI.Horizontal(delegate { UI.Space(1); }, UI.GetStyle(StudioColor.LightOutline), GUILayout.Width(size.x + 4f), GUILayout.Height(20f));

            // Create the Property Name
            Rect LabelPosition = new Rect(1f, currentPosition.y + 0.4f, (size.x / 2) - 0.5f, 19f);
            UI.Label(LabelPosition, "   " + GetLabelIndent(p.depth) + p.name, UI.GetStyle(StudioStyle.PropertyLabel));

            // Create a background for the Field Value
            Rect backgroundPosition = new Rect((size.x / 2) + 1, currentPosition.y + 0.4f, (size.x / 2) + 2f, 19f);
            UI.Label(backgroundPosition, "", UI.GetStyle(StudioStyle.PropertyLabel));

            // Create the Editable Field
            Rect FieldPosition = new Rect((size.x / 2) + 4, currentPosition.y + 1f, (size.x / 2) - 4f, 16f);
            p.Draw(FieldPosition, "");

            currentPosition += new Vector2(0f, 20f);
        }

        /// <summary>
        /// Draw a blank element. <br></br>
        /// This is the only way to get end-caps on each property list.
        /// </summary>
        static void BlankElement()
        {
            // Create the automatically laid out Horizontal space for the property.
            // This method of constructing a UIContent delegate in the paramater call is also valid for all Cappuccino Methods.
            UI.Horizontal(delegate { UI.Space(1); }, UI.GetStyle(StudioColor.LightOutline), GUILayout.Width(size.x + 4f), GUILayout.Height(20f));

            // Create the blank label
            Rect LabelPosition = new Rect(0f, currentPosition.y + 0.4f, size.x + 4f, 19f);
            UI.Label(LabelPosition, "", UI.GetStyle(StudioStyle.PropertyLabel));

            // Account for the new blank label.
            currentPosition += new Vector2(0f, 20f);
        }
        
        static string GetLabelIndent(int indentDepth)
        {
            string ind = "";
            
            for (int i = 0; i < indentDepth; i++)
            {
                ind = ind + "  ";
            }

            return ind;
        }

        #endregion

    }
}
