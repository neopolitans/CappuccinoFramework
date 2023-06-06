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
            /// Get a GUIStyle of the provided StudioStyle type.
            /// </summary>
            /// <param name="studioStyle">The desired StudioStyle type.</param>
            /// <returns>GUIStyle</returns>
            public static GUIStyle GetStyle(StudioStyle studioStyle)
            {
                GUIStyle style = new GUIStyle();

                switch (studioStyle)
                {
                    default:
                        // Most styles use this basic config. This is why it's the default.
                        style.normal.textColor = GetStudioTextColor(StudioTextColor.Base);

                        style.font = GetFont(CFonts.SourceSansPro, CFontStyle.Light);
                        style.fontSize = 12;
                        break;

                    case StudioStyle.HeaderGreyLabel:
                        style.normal.background = GetStyleTexture(StudioColor.Header);
                        style.border = new RectOffset(0, 0, 0, 0);
                        style.normal.textColor = GetStudioTextColor(StudioTextColor.HeaderGrey);
                        style.font = GetFont(CFonts.SourceSansPro, CFontStyle.Regular);
                        style.fontSize = 12;

                        style.alignment = TextAnchor.MiddleCenter;
                        break;

                    case StudioStyle.PropertyLabel:
                        style.normal.background = GetStyleTexture(StudioColor.Base);
                        style.border = new RectOffset(0, 0, 0, 0);
                        style.normal.textColor = GetStudioTextColor(StudioTextColor.Base);
                        style.font = GetFont(CFonts.SourceSansPro, CFontStyle.Medium);
                        style.fontSize = 10;

                        style.alignment = TextAnchor.MiddleLeft;

                        break;

                    case StudioStyle.FoldoutHeaderClosed:
                        style.normal.background = GetStyleTexture(StudioColor.Header);
                        style.normal.textColor = GetStudioTextColor(StudioTextColor.Base);

                        style.hover.background = GetStyleTexture(StudioColor.Header);
                        style.hover.textColor = GetStudioTextColor(StudioTextColor.Base);

                        style.active.background = GetStyleTexture(StudioColor.Header);
                        style.active.textColor = GetStudioTextColor(StudioTextColor.Base);

                        style.font = GetFont(CFonts.SourceSansPro, CFontStyle.Bold);
                        style.fontSize = 11;
                        style.alignment = TextAnchor.MiddleLeft;

                        style.border = new RectOffset(0, 0, 0, 0);
                        break;

                    case StudioStyle.FoldoutHeaderOpen:
                        style.normal.background = GetStyleTexture(StudioColor.Hover);
                        style.normal.textColor = GetStudioTextColor(StudioTextColor.Base);

                        style.hover.background = GetStyleTexture(StudioColor.Hover);
                        style.hover.textColor = GetStudioTextColor(StudioTextColor.Base);

                        style.active.background = GetStyleTexture(StudioColor.Hover);
                        style.active.textColor = GetStudioTextColor(StudioTextColor.Base);

                        style.font = GetFont(CFonts.SourceSansPro, CFontStyle.Bold);
                        style.fontSize = 11;
                        style.alignment = TextAnchor.MiddleLeft;

                        style.border = new RectOffset(0, 0, 0, 0);
                        break;
                }

                return style;
            }

            /// <summary>
            /// Get a GUIStyle of the provided StudioColor type. <br></br><br></br>
            /// <see langword="Cappuccino:"/> This variation is used for basic color blocking.
            /// </summary>
            /// <param name="studioColor">The desired StudioColor type.</param>
            /// <returns>GUIStyle</returns>
            public static GUIStyle GetStyle(StudioColor studioColor)
            {
                GUIStyle style = new GUIStyle();

                switch (studioColor)
                {
                    default:
                        // Most styles use this basic config. This is why it's the default.
                        style.normal.background = GetStyleTexture(studioColor);
                        style.normal.textColor = GetStudioTextColor(StudioTextColor.Base);

                        style.font = GetFont(CFonts.SourceSansPro, CFontStyle.Light);
                        style.fontSize = 12;
                        break;
                }

                return style;
            }

            /// <summary>
            /// Get a GUIStyle of the provided StudioColor type. <br></br><br></br>
            /// <see langword="Cappuccino:"/> This variation is used to test StudioColor enumerators and StudioTextColor enumerators.
            /// </summary>
            /// <param name="studioColor">The desired StudioColor type.</param>
            /// <param name="textColor">The desired Text Color to use for all used elements.</param>
            /// <returns>GUIStyle</returns>
            public static GUIStyle GetStyle(StudioColor studioColor, StudioTextColor textColor)
            {
                GUIStyle style = new GUIStyle();

                switch (studioColor)
                {
                    default:
                        // Most styles use this basic config. This is why it's the default.
                        style.normal.background = GetStyleTexture(studioColor);
                        style.normal.textColor = GetStudioTextColor(textColor);

                        style.font = GetFont(CFonts.SourceSansPro, CFontStyle.Light);
                        style.fontSize = 12;
                        break;
                }

                return style;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Get the style texture based on the StudioStyle param.<br></br><br></br>
            /// <see langword="default:"/> StudioStyle.Base
            /// </summary>
            /// <param name="style">The StudioStyle Texture you wish to retrieve.</param>
            /// <returns><seealso cref="Texture2D"/></returns>
            public static Texture2D GetStyleTexture(StudioColor style)
            {
                Texture2D tex = new Texture2D(1, 1);

                switch (style)
                {
                    default:
                        tex.SetPixel(0, 0, C255.Color(46, 46, 46));
                        break;

                    case StudioColor.Header:
                        tex.SetPixel(0, 0, C255.Color(53, 53, 53));
                        break;

                    case StudioColor.Hover:
                        tex.SetPixel(0, 0, C255.Color(66, 66, 66));
                        break;

                    case StudioColor.Selected:
                        tex.SetPixel(0, 0, C255.Color(11, 90, 175));
                        break;

                    case StudioColor.LightOutline:
                        tex.SetPixel(0, 0, C255.Color(34, 34, 34));
                        break;

                    case StudioColor.DarkOutline:
                        tex.SetPixel(0, 0, C255.Color(26, 26, 26));
                        break;

                    case StudioColor.PopupOutline:
                        tex.SetPixel(0, 0, C255.Color(91, 91, 91));
                        break;

                    case StudioColor.SearchBackground:
                        tex.SetPixel(0, 0, C255.Color(37, 37, 37));
                        break;
                }

                tex.Apply();

                return tex;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Get the text color based on the StudioTextColor param.<br></br><br></br>
            /// <see langword="default:"/> StudioTextColor.Base
            /// </summary>
            /// <param name="studioColor">The specific StudioTextColor to get.</param>
            /// <returns></returns>
            public static Color GetStudioTextColor(StudioTextColor studioColor)
            {
                switch (studioColor)
                {
                    default:
                        return C255.Color(204, 204, 204);

                    case StudioTextColor.HeaderGrey:
                        return C255.Color(170, 170, 170);

                    case StudioTextColor.ReadOnly:
                        return C255.Color(85, 85, 85);
                }
            }
        }
    }
}