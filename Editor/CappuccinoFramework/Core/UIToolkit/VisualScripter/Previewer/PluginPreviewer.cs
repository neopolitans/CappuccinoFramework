using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using Cappuccino.Graphing;
using Cappuccino.Interpreters.Languages.USS;
using Cappuccino.Core;

namespace Cappuccino
{
    namespace VisualScripting
    {
        /// <summary>
        /// The previewer editor window that executes the code stored in the Visual Scripter. <br></br>
        /// <see langword="Cappuccino:"/> This requires the Visual Scripter to work.
        /// </summary>
        public class PluginPreviewer : CEditor
        {
            // Variables
            /// <summary>
            /// The attached plugin blueprint designer.
            /// </summary>
            protected PluginBlueprintDesigner attachedDesigner;

            public static PluginPreviewer CreatePreviewer(string blueprintName, PluginBlueprintDesigner designer)
            {
                PluginPreviewer previewer = Open<PluginPreviewer>($"Previewer: {blueprintName.ToUpper()}");
                previewer.attachedDesigner = designer;
                previewer.OnEnableCustom();

                return previewer;   
            }

            public void OnEnableCustom()
            {
                if (attachedDesigner == null) { Close(); } // There's been an error or the designer has closed unexpectedly.
                else { attachedDesigner.func_OnEnable(); }
            }

            public override void OnGUI()
            {
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();

                if (attachedDesigner == null) { Close(); } // There's been an error or the designer has closed unexpectedly.
                else { attachedDesigner.func_OnGui(); }

                sw.Stop();
                Debug.Log("Visual Scripting IMGUI:" + sw.ElapsedTicks);
            }
        }

        public class RawIMGUITest : CEditor
        {
            [MenuItem("Cappuccino/RawIMGUITest")]
            public static void OpenWnd()
            {
                Open<RawIMGUITest>();
            }

            bool ta, tb, tc, td;

            public override void Draw()
            {
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();

                ta = UI.Toggle("First Option", ta);

                if (ta)
                {
                    tb = UI.Toggle("Sub Option A", tb);

                    tc = UI.Toggle("Sub Option B", tc);

                }

                td = UI.Toggle("Second Option", td);

                sw.Stop();
                Debug.Log("Raw IMGUI:" + sw.ElapsedTicks);
            }
        }
    }
}