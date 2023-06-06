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
        /// <see langword="Cappuccino:"/> Fonts included with Cappuccino Editor Framework.
        /// </summary>
        public enum CFonts
        {
            FiraMono,
            SourceSansPro
        }

        /// <summary>
        /// <see langword="Cappuccino:"/> The style of the font to return. <br></br><br></br>
        /// <b><see langword="Notice:"/></b> Not all fonts may have the style. <br></br> 
        /// If you don't know what styles are available, open up the Fonts folder in: <br></br>
        /// <b>- /.../CappuccinoFramework/Core/Fonts </b>
        /// </summary>
        public enum CFontStyle
        {
            Regular,
            Italic,
            Bold,
            Medium,
            Light,

            Black,
            BlackItalic,
            BoldItalic,
            ExtraLight,
            ExtraLightItalic,
            LightItalic,
            SemiBold,
            SemiBoldItalic,

        }

    }
}