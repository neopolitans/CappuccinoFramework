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
        /// <summary>
        /// <see langword="Cappuccino:"/> This static class is the User Interface Toolkit. It contains common UI drawing methods for Editors. <br></br>
        /// </summary>
        public static partial class UI
        {
            /// <summary>
            /// Get a texture from UnityEditor's internal EditorUtilities. <br></br><br></br>
            /// <see langword="Cappuccino:"/> For commonly used Textures that are often sought out for Editor Windows. <br></br>
            /// <see langword="Unity:"/> All textures are owned by and fall under the copyright of Unity Technologies.
            /// </summary>
            /// <param name="assetName">Asset name to query.</param>
            /// <returns></returns>
            public static Texture UnityAsset(UnityAsset asset)
            {
                switch (asset)
                {
                    case Core.UnityAsset.LOGO:
                        return EditorGUIUtility.FindTexture("UnityLogo");

                    case Core.UnityAsset.PLUS:
                        return EditorGUIUtility.FindTexture("Toolbar Plus");

                    case Core.UnityAsset.MINUS:
                        return EditorGUIUtility.FindTexture("Toolbar Minus");

                    default:
                        return new Texture2D(1,1);
                }
            }
        }
    }
}

