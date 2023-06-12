using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

namespace Cappuccino
{
    namespace Core
    {
        public partial class CEditor : EditorWindow
        {
            protected CAssetLoader assetLoader;

            /// <summary>
            /// Create an Asset Loader. <br></br>
            /// <see langword="Cappuccino:"/> Directory defaults to: [Assets > Editor > Plugins > windowName > EditorAssets]
            /// </summary>
            public bool CreateAssetLoader()
            {
                if (assetLoader == null)
                {
                    assetLoader = new CAssetLoader("Assets/Editor/Plugins/" + windowName + "/EditorAssets");
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Create an Asset Loader. <br></br>
            /// Uses a custom directory provided by the developer.
            /// </summary>
            public bool CreateAssetLoader(string path)
            {
                if (assetLoader == null)
                {
                    assetLoader = new CAssetLoader(path);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}