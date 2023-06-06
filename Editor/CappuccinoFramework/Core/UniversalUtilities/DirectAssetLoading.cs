using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// IntenralAssetLoader is a basic asset loader for Cappuccino Editor Framework to default to in order to load assets
// stored within the "Core / Icons" folder. Deleting this script may cause unexpected errors.

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> AssetLoader is an internal class for Cappuccino Framework to use in order to load it's own assets. <br></br>
        /// It defaults to the default directory above all else. This can be modified to be a public, inheritable class though it's not recommended. <br></br><br></br>
        /// Tags: <i><b><see langword="[internal], [coreclass], [modifiable]"/> </b></i><br></br>
        /// </summary>
        static class AssetLoader
        {
            /// <summary>
            /// Get a Texture with the corresponding name from Cappuccino's internal icons folder. <br></br>
            /// <b>This does not need the file extension to be provided. Only the Icon name.</b>
            /// </summary>
            /// <param name="assetName">Asset name to query.</param>
            /// <returns></returns>
            public static Texture GetIcon(string assetName)
            {
                return (Texture)AssetDatabase.LoadAssetAtPath(Core.FrameworkUtilities.Icons + assetName + FrameworkUtilities.defaultIconFiletypeSuffix, typeof(Texture));
            }

            /// <summary>
            /// Get a Texture2D with the corresponding name from your Editor's assets folder. <br></br>
            /// <b>This does not need the file extension to be provided. Only the Icon name.</b>
            /// </summary>
            /// <param name="assetName">Asset name to query.</param>
            /// <returns></returns>
            public static Texture2D GetIcon2D(string assetName)
            {
                return (Texture2D)AssetDatabase.LoadAssetAtPath(Core.FrameworkUtilities.Icons + assetName + FrameworkUtilities.defaultIconFiletypeSuffix, typeof(Texture2D));
            }

            /// <summary>
            /// Get a Unity Style Sheet with the corresponding name from the path within Cappuccino Framework. <br></br>
            /// <b>This does not need the file extension to be provided, only the sheet name. </b> <br></br><br></br>
            /// <see langword="Cappuccino:"/> This method is provided as a Style Sheet may not have a fixed place in the framework.
            /// </summary>
            /// <param name="assetpath">The path of the asset, including the asset name.</param>
            /// <returns></returns>
            public static StyleSheet GetStyleSheet(string assetpath)
            {
                return (StyleSheet)AssetDatabase.LoadAssetAtPath(FrameworkUtilities.defaultDirectory + assetpath + ".uss", typeof(StyleSheet));
            }
        }
    }
}