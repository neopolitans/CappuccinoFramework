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
            /// Get an Icon from Cappuccino Framework's provided Iconography. <br></br><br></br>
            /// <see langword="Cappuccino:"/> For commonly used Textures that are often sought out for Editor Windows though aren't available through Unity's methods for one reason or another. <br></br>
            /// </summary>
            /// <param name="asset">The enumerator representing the asset to retrieve.</param>
            /// <returns></returns>
            public static Texture Icon(Iconography asset)
            {
                switch (asset)
                {
                    case Core.Iconography.MOREV:
                        return AssetLoader.GetIcon("MoreVertical");

                    case Core.Iconography.MOREH:
                        return AssetLoader.GetIcon("MoreHorizontal");

                    default:
                        return new Texture2D(1, 1);
                }
            }
        }
    }
}

