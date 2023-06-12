using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// CAssetLoader is a basic asset loader for your plugin. Provide an optional asset path if you have a custom file structure.
// CAssetLoaders are not mandatory and you can bypass this entriely with your own custom implementation.

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// An Instantiable Asset Loader specific to your plugin. <br></br><br></br>
        /// <see langword="Cappuccino:"/> This is an optional simplified library of methods for loading assets. <br></br>
        /// To create an asset loader for your editor, it is recommended to use <see cref="CEditor.CreateAssetLoader()"/> unless multiple are needed.
        /// </summary>
        public partial class CAssetLoader
        {
            string assetPath;
            TextureFileType primaryfiletype = TextureFileType.PNG;

            /// <summary>
            /// Create an Asset Loader for your plugin. <br></br>
            /// Specify the directory within your project's Assets folder for your Editor's assets. <br></br><br></br>
            /// E.G. Assets/Editor/MyPlugin/PluginAssets
            /// </summary>
            /// <param name="assetPath"> The path where the editor assets are stored.<br></br> Use the path suffixed after (and including) "Assets/".</param>
            public CAssetLoader(string assetPath)
            {
                this.assetPath = assetPath;
            }

            /// <summary>
            /// Create an Asset Loader for your plugin. <br></br>
            /// Specify the directory within your project's Assets folder for your Editor's assets. <br></br><br></br>
            /// E.G. Assets/Editor/MyPlugin/PluginAssets
            /// </summary>
            /// <param name="assetPath"> The path where the editor assets are stored.<br></br> Use the path suffixed after (and including) "Assets/".</param>
            /// <param name="primaryfiletype"> The primary file-type that will be used if only an asset name is provided. <br></br> <see langword="Cappuccino:"/> </param>
            public CAssetLoader(string assetPath, TextureFileType primaryfiletype)
            {
                this.assetPath = assetPath;
                this.primaryfiletype = primaryfiletype;
            }

            /// <summary>
            /// Get a Texture with the corresponding name from your Editor's assets folder.
            /// </summary>
            /// <param name="assetName">Asset name to query.</param>
            /// <returns></returns>
            public Texture GetTexture(string assetName)
            {
                return (Texture)AssetDatabase.LoadAssetAtPath(assetPath + assetName + FrameworkUtilities.GetTextureFileTypeSuffix(primaryfiletype), typeof(Texture));
            }

            /// <summary>
            /// Get a Texture2D with the corresponding name from your Editor's assets folder.
            /// </summary>
            /// <param name="assetName">Asset name to query.</param>
            /// <returns></returns>
            public Texture2D GetTexture2D(string assetName)
            {
                return (Texture2D)AssetDatabase.LoadAssetAtPath(assetPath + assetName + FrameworkUtilities.GetTextureFileTypeSuffix(primaryfiletype), typeof(Texture2D));
            }

            /// <summary>
            /// Get a Texture with the corresponding name from your Editor's assets folder.
            /// </summary>
            /// <param name="assetName">Asset name to query.</param>
            /// <param name="fileType">The file-type to append to the asset name.</param>
            /// <returns></returns>
            public Texture GetTexture(string assetName, TextureFileType fileType)
            {
                return (Texture)AssetDatabase.LoadAssetAtPath(assetPath + assetName + FrameworkUtilities.GetTextureFileTypeSuffix(fileType), typeof(Texture));
            }

            /// <summary>
            /// Get a Texture2D with the corresponding name from your Editor's assets folder.
            /// </summary>
            /// <param name="assetName">Asset name to query.</param>
            /// <param name="fileType">The file-type to append to the asset name.</param>
            /// <returns></returns>
            public Texture2D GetTexture2D(string assetName, TextureFileType fileType)
            {
                return (Texture2D)AssetDatabase.LoadAssetAtPath(assetPath + assetName + FrameworkUtilities.GetTextureFileTypeSuffix(fileType), typeof(Texture2D));
            }
        }
    }
}