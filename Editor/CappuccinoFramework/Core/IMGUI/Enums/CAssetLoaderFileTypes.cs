using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This script adds an enum to denote the filetype of a texture and enum-conversion for the FrameworkUtilities Class.

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> The list of Texture/Texture2D File types that Unity natively supports. <br></br>
        /// <b><see langword="Notice:"/> If you need a unique file type, you may need to create your own conversion tool for the format to a Unity-supported type.</b> <br></br><br></br>
        /// 
        /// <see langword="Unity:"/> <i>Not to be confused with UnityEngine.TextureFormat, which denotes the formatting of a texture such as it's RGB color space.</i>
        /// </summary>
        /// 
        public enum TextureFileType
        {
            BMP,
            EXR,
            GIF,
            HDR,
            IFF,
            JPG,
            PICT,
            PNG,
            PSD,
            TGA,
            TIFF
        }

        public partial class FrameworkUtilities
        {
            // Learnt how to do this special variation of switch-expressions directly from Microsoft's resources.

            /// <summary>
            /// <see langword="Cappuccino:"/> Converts the provided TextureFileType to a string. <br></br>
            /// <b><see langword="Notice:"/> If the provided filetype you've added isn't supported by Unity, you may need to implement your own file-converter.</b>
            /// </summary>
            /// <param name="type"></param>
            /// <returns>The Suffix of the desired filetype, if it's supported. <br></br> Otherwise, a NotImplementedException is thrown.</returns>
            /// <exception cref="System.NotImplementedException"></exception>
            public static string GetTextureFileTypeSuffix(TextureFileType type) => type switch
            {
                TextureFileType.BMP => ".bmp",
                TextureFileType.EXR => ".exr",
                TextureFileType.GIF => ".gif",
                TextureFileType.HDR => ".hdr",
                TextureFileType.IFF => ".iff",
                TextureFileType.JPG => ".jpg",
                TextureFileType.PICT => ".pict",
                TextureFileType.PNG => ".png",
                TextureFileType.PSD => ".psd",
                TextureFileType.TGA => ".tga",
                TextureFileType.TIFF => ".tiff",
                _ => throw new System.NotImplementedException("The file type you have tried to specify is either not supported by Unity or is not supported by Cappuccino.")
            };
        }
    }
}
