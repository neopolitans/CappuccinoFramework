using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// Because this style is legally the property of ROBLOX Corporation, it is separated as a custom style type, though it uses documentation styles akin to Cappuccino.
// It's also a perfect opportunity to establish ground rules (and an example thereof) of a custom style for developers to take notes from.

namespace Cappuccino
{
    namespace Core
    {
        public enum StudioStyle
        {
            HeaderGreyLabel,
            PropertyLabel,
            PropertyField,
            ReadOnlyPropertyLabel,
            FoldoutHeaderClosed,
            FoldoutHeaderOpen

        }


        /// <summary>
        /// <see langword="Cappuccino:"/> Options which return styles akin to ROBLOX Studio's. <br></br>
        /// <b><see langword="Notice:"/></b> Color Accuracy may vary.
        /// </summary>
        public enum StudioColor
        {
            Base,                   //RGB  46,  46,  46
            Header,                 //RGB  53,  53,  53
            Hover,                  //RGB  66,  66,  66
            Selected,               //RGB  11,  91, 175
            LightOutline,           //RGB  34,  34,  34
            DarkOutline,            //RGB  26,  26,  26
            PopupOutline,           //RGB  91,  91,  91
            SearchBackground        //RGB  37,  37,  37
        }

        public enum StudioTextColor
        {
            Base,                   //RGB 204, 204, 204
            HeaderGrey,             //RGB 170, 170, 170
            ReadOnly               //RGB  85,  85,  85
        }
    }
}