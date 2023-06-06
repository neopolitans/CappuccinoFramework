using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using UnityEditor; 
using Cappuccino.Core;

// ROProperty is the first plugin developed with Cappuccino Editor Framework. Some errors may be present.

namespace ROProperty
{
    /// <summary>
    /// A CEditor that ports over the ROBLOX Studio Property Panel.
    /// </summary>
    public class RoProperty : CEditor
    {
        // MenuItemAttribute is the only necessary part of UnityEditor that we have to use to open an EditorWindow.
        // Due to the way UnityEngine handles this, we cannot inherit or overload this method for our own variation.
        [MenuItem("Plugins/StudioToUnity/Properties %#T")]
        public static void OpenEditor()
        {
            // Open the properties panel.
            RoPropertyManager.wnd = Open<RoProperty>("Properties");

            // Set the minimum size to a lower value for safety.
            RoPropertyManager.wnd.minSize = new Vector2(256, 512);

            // As the Properties Panel displays information for the currently selected object (or none if null),
            // Add a delegate for invocation to selection changed. *Note: This may bind multiple times.
            Selection.selectionChanged += RoPropertyManager.wnd.Repaint;
        }

        // Because we don't need multiple panels to display a single property object,
        // The only use for the Editor Window script is to check if the editor has nulled
        // and refresh the reference in RoPropertyManager if it has.

        // The null-coalescing operator will always result in Body.Draw (default window
        // for this editor) being called.
        public override void Draw()
        {
            if (RoPropertyManager.wnd == null) { OpenEditor(); }

            currentPanel ??= Body.Draw;
            currentPanel();
        }
    }
}