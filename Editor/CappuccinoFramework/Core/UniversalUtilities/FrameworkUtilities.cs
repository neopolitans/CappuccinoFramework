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
        /// <see langword="Cappuccino:"/> Default Settings and Expected Behaviours for Cappuccino Editor Framework. <br></br>
        /// <b>If you change your directory outside of where it's expected to be, modify defaultDirectory.</b>
        /// </summary>
        public static partial class FrameworkUtilities
        {
            /// <summary>
            /// The default, expected install directory of Cappuccino Framework.
            /// </summary>
            public const string defaultDirectory = "Assets/Editor/CappuccinoFramework/";

            /// <summary>
            /// The default, expected install directory of Cappuccino Framework, without the "Assets/" prefix for some modules in Cappuccino.
            /// </summary>
            public const string dirInAssets = "Editor/CappuccinoFramework/";

            /// <summary>
            /// The Fonts subdirectory from within the default install directory.
            /// </summary>
            public const string Fonts = defaultDirectory + "Core/Fonts/";

            /// <summary>
            /// The Icons subdirectory from within the default install directory.
            /// </summary>
            public const string Icons = defaultDirectory + "Core/Icons/";

            /// <summary>
            /// Any and all icons included are saved in this format.
            /// </summary>
            public const TextureFileType defaultIconFiletype = TextureFileType.PNG;

            public static string defaultIconFiletypeSuffix
            {
                get { return GetTextureFileTypeSuffix(defaultIconFiletype); }
            }
        }
    }
}