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
            /// Get a CStyle of the provided BaseStyle type. <br></br><br></br>
            /// <b><see langword="Cappuccino:"/> CStyle is currently not in active use. It exists in preparation for future utilities.</b>
            /// </summary>
            /// <param name="baseStyle">The desired BaseStyle type.</param>
            /// <returns>CStyle</returns>
            public static CStyle GetCStyle(BaseStyle baseStyle)
            {
                CStyle style = new CStyle();

                switch (baseStyle)
                {
                    case BaseStyle.SelectionActive:
                        style.normal.background = GetStyleTexture(baseStyle);
                        style.normal.textColor = Color.white;
                        style.hover.background = style.normal.background;
                        style.hover.textColor = Color.white;
                        style.active.background = style.normal.background;
                        style.active.textColor = Color.white;

                        style.alignment = TextAnchor.MiddleLeft;
                        style.fontStyle = FontStyle.Bold;
                        break;

                    case BaseStyle.SelectionHover:
                        style.normal.background = GetStyleTexture(BaseStyle.SelectionNormal);
                        style.normal.textColor = C255.Color(155, 155, 155);
                        style.hover.background = GetStyleTexture(BaseStyle.SelectionHover);
                        style.hover.textColor = C255.Color(155, 155, 155);
                        style.active.textColor = C255.Color(155, 155, 155);

                        style.alignment = TextAnchor.MiddleLeft;
                        break;

                    case BaseStyle.InteractionButtonHierarchy:
                        style.normal.background = GetStyleTexture(BaseStyle.SelectionNormal);
                        style.normal.textColor = Color.white;
                        style.hover.background = GetStyleTexture(BaseStyle.SelectionHover);
                        style.hover.textColor = Color.white;
                        style.active.background = GetStyleTexture(UnityStyle.SceneHeaderGrey);
                        style.active.textColor = Color.white;
                        break;

                    case BaseStyle.HeaderButtonDark:
                        style.normal.background = GetStyleTexture(BaseStyle.EveningGrey);
                        style.normal.textColor = Color.white;
                        style.hover.background = GetStyleTexture(BaseStyle.GreyBlack);
                        style.hover.textColor = Color.white;
                        style.active.background = GetStyleTexture(BaseStyle.DarkStormGrey);
                        style.active.textColor = Color.white;
                        break;

                    default:
                        // Most styles use this basic config. This is why it's the default.
                        style.normal.background = GetStyleTexture(baseStyle);
                        style.normal.textColor = Color.white;
                        break;
                }

                return style;
            }

            /// <summary>
            /// Get a CStyle of the provided UnityStyle type. <br></br><br></br>
            /// <b><see langword="Cappuccino:"/> CStyle is currently not in active use. It exists in preparation for future utilities.</b>
            /// </summary>
            /// <param name="unityStyle">The desired UnityStyle type.</param>
            /// <returns>CStyle</returns>
            public static CStyle GetCStyle(UnityStyle unityStyle)
            {
                CStyle style = new CStyle();

                switch (unityStyle)
                {
                    default:
                        // Most styles use this basic config. This is why it's the default.
                        style.normal.background = GetStyleTexture(unityStyle);
                        style.normal.textColor = Color.white;
                        break;
                }

                return style;
            }

            /// <summary>
            /// Get a GUIStyle of the provided BaseStyle type.
            /// </summary>
            /// <param name="baseStyle">The desired BaseStyle type.</param>
            /// <returns>GUIStyle</returns>
            public static GUIStyle GetStyle(BaseStyle baseStyle)
            {
                GUIStyle style = new GUIStyle();

                switch (baseStyle)
                {
                    case BaseStyle.SelectionActive:
                        style.normal.background = GetStyleTexture(baseStyle);
                        style.normal.textColor = Color.white;
                        style.hover.background = style.normal.background;
                        style.hover.textColor = Color.white;
                        style.active.background = style.normal.background;
                        style.active.textColor = Color.white;

                        style.alignment = TextAnchor.MiddleLeft;
                        style.fontStyle = FontStyle.Bold;
                        break;

                    case BaseStyle.SelectionHover:
                        style.normal.background = GetStyleTexture(BaseStyle.SelectionNormal);
                        style.normal.textColor = C255.Color(155, 155, 155);
                        style.hover.background = GetStyleTexture(BaseStyle.SelectionHover);
                        style.hover.textColor = C255.Color(155, 155, 155);
                        style.active.textColor = C255.Color(155, 155, 155);

                        style.alignment = TextAnchor.MiddleLeft;
                        break;

                    case BaseStyle.InteractionButtonHierarchy:
                        style.normal.background = GetStyleTexture(BaseStyle.SelectionNormal);
                        style.normal.textColor = Color.white;
                        style.hover.background = GetStyleTexture(BaseStyle.SelectionHover);
                        style.hover.textColor = Color.white;
                        style.active.background = GetStyleTexture(UnityStyle.SceneHeaderGrey);
                        style.active.textColor = Color.white;
                        break;

                    case BaseStyle.HeaderButtonDark:
                        style.normal.background = GetStyleTexture(BaseStyle.EveningGrey);
                        style.normal.textColor = Color.white;
                        style.hover.background = GetStyleTexture(BaseStyle.GreyBlack);
                        style.hover.textColor = Color.white;
                        style.active.background = GetStyleTexture(BaseStyle.DarkStormGrey);
                        style.active.textColor = Color.white;
                        break;

                    case BaseStyle.HandlesNormal:
                        style.normal.background = GetStyleTexture(BaseStyle.HandlesNormal);
                        style.normal.textColor = C255.Color(204, 204, 204);
                        break;

                    default:
                        // Most styles use this basic config. This is why it's the default.
                        style.normal.background = GetStyleTexture(baseStyle);
                        style.normal.textColor = Color.white;
                        break;
                }

                return style;
            }

            /// <summary>
            /// Get a GUIStyle of the provided UnityStyle type.
            /// </summary>
            /// <param name="unityStyle">The desired UnityStyle type.</param>
            /// <returns>GUIStyle</returns>
            public static GUIStyle GetStyle(UnityStyle unityStyle)
            {
                GUIStyle style = new GUIStyle();

                switch (unityStyle)
                {
                    default:
                        // Most styles use this basic config. This is why it's the default.
                        style.normal.background = GetStyleTexture(unityStyle);
                        style.normal.textColor = Color.white;
                        break;

                    case UnityStyle.GreyLabel:
                        style.normal.textColor = C255.Color(128, 128, 128);
                        style.alignment = TextAnchor.MiddleLeft;
                        break;
                }

                return style;
            }

            /// <summary>
            /// Get a GUIStyle of the provided InteractiveStyle type.
            /// </summary>
            /// <param name="interactiveStyle">The desired InteractiveStyle type.</param>
            /// <returns>GUIStyle</returns>
            public static GUIStyle GetStyle(InteractiveStyle interactiveStyle)
            {
                GUIStyle style = new GUIStyle();

                switch (interactiveStyle)
                {
                    default:
                        // Most styles use this basic config. This is why it's the default.
                        style.normal.background = GetStyleTexture(BaseStyle.DarkStormGrey);
                        style.normal.textColor = Color.white;
                        break;

                    case InteractiveStyle.WindowTopbarButton:
                        style.normal.background = GetStyleTexture(BaseStyle.DarkStormGrey);
                        style.normal.textColor = Color.white;

                        style.hover.background = GetStyleTexture(BaseStyle.SelectionHover);
                        style.hover.textColor = Color.white;

                        style.active.background = GetStyleTexture(BaseStyle.SelectionHover);
                        style.active.textColor = Color.white;

                        style.onNormal.background = GetStyleTexture(BaseStyle.DarkStormGrey);
                        style.onNormal.textColor = Color.white;

                        style.onHover.background = GetStyleTexture(BaseStyle.SelectionHover);
                        style.onHover.textColor = Color.white;

                        style.onActive.background = GetStyleTexture(BaseStyle.SelectionHover);
                        style.onActive.textColor = Color.white;

                        style.font = GetFont(CFonts.SourceSansPro, CFontStyle.SemiBold);
                        style.fontSize = 11;

                        style.alignment = TextAnchor.MiddleCenter;

                        break;

                    case InteractiveStyle.ArrayListButton:
                        style.normal.background = GetStyleTexture(BaseStyle.DarkStormGrey);
                        style.normal.textColor = Color.white;

                        style.hover.background = GetStyleTexture(BaseStyle.SelectionHover);
                        style.hover.textColor = Color.white;

                        style.active.background = GetStyleTexture(BaseStyle.SelectionHover);
                        style.active.textColor = Color.white;

                        style.font = GetFont(CFonts.FiraMono, CFontStyle.Regular);
                        style.fontSize = 12;

                        style.alignment = TextAnchor.MiddleLeft;

                        break;

                    case InteractiveStyle.ArrayListSelectedButton:
                        style.normal.background = GetStyleTexture(BaseStyle.SelectionActive);
                        style.normal.textColor = Color.white;

                        style.hover.background = GetStyleTexture(BaseStyle.SelectionActiveSelected);
                        style.hover.textColor = Color.white;

                        style.active.background = GetStyleTexture(BaseStyle.SelectionActiveSelected);
                        style.active.textColor = Color.white;

                        style.font = GetFont(CFonts.FiraMono, CFontStyle.Bold);
                        style.fontSize = 12;

                        style.alignment = TextAnchor.MiddleLeft;

                        break;

                    case InteractiveStyle.ArrayModifyButton:
                        style.normal.background = GetStyleTexture(UnityStyle.UnityGrey);
                        style.normal.textColor = Color.white;

                        style.hover.background = GetStyleTexture(BaseStyle.GreyBlack);
                        style.hover.textColor = Color.white;

                        style.active.background = GetStyleTexture(BaseStyle.DarkStormGrey);
                        style.active.textColor = Color.white;

                        break;

                    case InteractiveStyle.HandlesButton:
                        style.normal.background = GetStyleTexture(BaseStyle.HandlesNormal);
                        style.normal.textColor = Color.white;

                        style.hover.background = GetStyleTexture(BaseStyle.HandlesHover);
                        style.hover.textColor = Color.white;

                        style.active.background = GetStyleTexture(BaseStyle.HandlesActive);
                        style.active.textColor = Color.white;

                        style.onNormal.background = GetStyleTexture(BaseStyle.HandlesNormal);
                        style.onNormal.textColor = Color.white;

                        style.onHover.background = GetStyleTexture(BaseStyle.HandlesHover);
                        style.onHover.textColor = Color.white;

                        style.onActive.background = GetStyleTexture(BaseStyle.HandlesActive);
                        style.onActive.textColor = Color.white;

                        style.font = GetFont(CFonts.SourceSansPro, CFontStyle.SemiBold);
                        style.fontSize = 11;

                        style.alignment = TextAnchor.MiddleCenter;
                        break;
                }

                return style;
            }

            /// <summary>
            /// Make a GUIStyle from the provided byte color.
            /// </summary>
            /// <param name="r">The byte representing the amount of Red in the color.</param>
            /// <param name="g">The byte representing the amount of Green in the color.</param>
            /// <param name="b">The byte representing the amount of Blue in the color.</param>
            /// <returns>GUIStyle</returns>
            public static GUIStyle MakeStyle(byte r, byte g, byte b)
            {
                GUIStyle style = new GUIStyle();

                style.normal.background = MakeStyleTexture(r, g, b);
                style.normal.textColor = Color.white;

                return style;
            }

            /// <summary>
            /// Make a GUIStyle from the provided byte color.
            /// </summary>
            /// <param name="r">The byte representing the amount of Red in the color.</param>
            /// <param name="g">The byte representing the amount of Green in the color.</param>
            /// <param name="b">The byte representing the amount of Blue in the color.</param>
            /// <param name="a">The byte representing the color Alpha Transparency.</param>
            /// <returns>GUIStyle</returns>
            public static GUIStyle MakeStyle(byte r, byte g, byte b, byte a)
            {
                GUIStyle style = new GUIStyle();

                style.normal.background = MakeStyleTexture(r, g, b, a);
                style.normal.textColor = Color.white;

                return style;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Get the style texture based on the BaseStyle param.<br></br><br></br>
            /// <see langword="default:"/> BaseStyle.DarkStormGrey
            /// </summary>
            /// <param name="style">The BaseStyle Texture you wish to retrieve.</param>
            /// <returns><seealso cref="Texture2D"/></returns>
            public static Texture2D GetStyleTexture(BaseStyle style)
            {
                Texture2D tex = new Texture2D(1, 1);

                switch (style)
                {
                    case BaseStyle.DarkStormGrey:
                        tex.SetPixel(0, 0, C255.Color(51, 51, 51));
                        break;

                    case BaseStyle.EveningGrey:
                        tex.SetPixel(0, 0, C255.Color(41, 41, 41));
                        break;

                    case BaseStyle.GreyBlack:
                        tex.SetPixel(0, 0, C255.Color(44, 44, 44));
                        break;

                    case BaseStyle.SelectionNormal:
                        tex.SetPixel(0, 0, C255.Color(56, 56, 56));
                        break;

                    case BaseStyle.SelectionActive:
                        tex.SetPixel(0, 0, new Color(0.17f, 0.36f, 0.53f, 1f));
                        break;

                    case BaseStyle.SelectionHover:
                        tex.SetPixel(0, 0, new Color(0.32f, 0.32f, 0.32f, 0.5f));
                        break;

                    case BaseStyle.SelectionActiveSelected:
                        tex.SetPixel(0, 0, C255.Color(49, 105, 154));
                        break;

                    case BaseStyle.HandlesNormal:
                        tex.SetPixel(0, 0, C255.Color(27, 42, 53, 128));
                        break;

                    case BaseStyle.HandlesHover:
                        tex.SetPixel(0, 0, C255.Color(82, 82, 82, 128));
                        break;

                    case BaseStyle.HandlesActive:
                        tex.SetPixel(0, 0, C255.Color(43, 92, 135, 192));
                        break;

                    default:
                        tex.SetPixel(0, 0, C255.Color(51, 51, 51));
                        break;
                }

                tex.Apply();

                return tex;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Get the style texture based on the UnityStyle param. <br></br><br></br>
            /// <see langword="default:"/> UnityStyle.UnityGrey
            /// </summary>
            /// <param name="unityStyle">The UnityStyle Texture you wish to retrieve.</param>
            /// <returns><seealso cref="Texture2D"/></returns>
            public static Texture2D GetStyleTexture(UnityStyle unityStyle)
            {
                Texture2D tex = new Texture2D(1, 1);

                switch (unityStyle)
                {
                    case UnityStyle.SceneHeaderGrey:
                        tex.SetPixel(0, 0, C255.Color(80, 80, 80));
                        break;

                    case UnityStyle.HierarchyDark:
                        tex.SetPixel(0, 0, C255.Color(35, 35, 35));
                        break;

                    case UnityStyle.WindowSelectionRibbon:
                        tex.SetPixel(0, 0, C255.Color(44, 93, 135));
                        break;

                    default:
                        tex.SetPixel(0, 0, C255.Color(56, 56, 56));
                        break;
                }

                tex.Apply();
                return tex;
            }

            /// <summary>
            /// Make a Texture2D from the provided byte color.
            /// </summary>
            /// <param name="r">The byte representing the amount of Red in the color.</param>
            /// <param name="g">The byte representing the amount of Green in the color.</param>
            /// <param name="b">The byte representing the amount of Blue in the color.</param>
            /// <returns><see cref="Texture2D"/></returns>
            public static Texture2D MakeStyleTexture(byte r, byte g, byte b)
            {
                Texture2D tex = new Texture2D(1, 1);
                tex.SetPixel(0, 0, C255.Color(r, g, b));
                tex.Apply();
                return tex;
            }

            /// <summary>
            /// Make a Texture2D from the provided byte color.
            /// </summary>
            /// <param name="r">The byte representing the amount of Red in the color.</param>
            /// <param name="g">The byte representing the amount of Green in the color.</param>
            /// <param name="b">The byte representing the amount of Blue in the color.</param>
            /// <param name="a">The byte representing the color Alpha Transparency.</param>
            /// <returns><see cref="Texture2D"/></returns>
            public static Texture2D MakeStyleTexture(byte r, byte g, byte b, byte a)
            {
                Texture2D tex = new Texture2D(1, 1);
                tex.SetPixel(0, 0, C255.Color(r, g, b, a));
                tex.Apply();
                return tex;
            }
        }
    }
}