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
            /// <see langword="Cappuccino:"/> Return the desired Font. <br></br>
            /// The default custom font is FiraMono.<br></br><br></br>
            /// <b><see langword="Notice:"/></b> Only returns Regular style fonts (where applicable).
            /// </summary>
            /// <param name="font">The included Font to return.</param>
            /// <returns><see cref="Font"/></returns>
            public static Font GetFont(CFonts font)
            {
                switch (font)
                {
                    default:
                        return (Font)AssetDatabase.LoadAssetAtPath(FrameworkUtilities.Fonts + "FiraMono/FiraMono-Regular.ttf", typeof(Font));

                    case CFonts.SourceSansPro:
                        return (Font)AssetDatabase.LoadAssetAtPath(FrameworkUtilities.Fonts + "SourceSansPro/SourceSansPro-Regular.ttf", typeof(Font));
                }
            }


            /// <summary>
            /// <see langword="Cappuccino:"/> Return the desired Font. <br></br>
            /// The default custom font is FiraMono.<br></br><br></br>
            /// <b><see langword="Notice:"/></b> If a font doesn't have a specific style a default is provided, usually Regular style.
            /// </summary>
            /// <param name="font">The included Font to return.</param>
            /// <param name="style">The Font Style to return.</param>
            /// <returns><see cref="Font"/></returns>
            public static Font GetFont(CFonts font, CFontStyle style)
            {
                switch (font)
                {
                    default:
                        switch (style)
                        {
                            default:
                                return (Font)AssetDatabase.LoadAssetAtPath(FrameworkUtilities.Fonts + "FiraMono/FiraMono-Regular.ttf", typeof(Font));

                            case CFontStyle.Medium:
                                return (Font)AssetDatabase.LoadAssetAtPath(FrameworkUtilities.Fonts + "FiraMono/FiraMono-Medium.ttf", typeof(Font));

                            case CFontStyle.Bold:
                                return (Font)AssetDatabase.LoadAssetAtPath(FrameworkUtilities.Fonts + "FiraMono/FiraMono-Bold.ttf", typeof(Font));
                        }

                    case CFonts.SourceSansPro:
                        switch (style)
                        {
                            default:
                                return (Font)AssetDatabase.LoadAssetAtPath(FrameworkUtilities.Fonts + "SourceSansPro/SourceSansPro-Regular.ttf", typeof(Font));

                            case CFontStyle.Italic:
                                return (Font)AssetDatabase.LoadAssetAtPath(FrameworkUtilities.Fonts + "SourceSansPro/SourceSansPro-Italic.ttf", typeof(Font));

                            case CFontStyle.Bold:
                                return (Font)AssetDatabase.LoadAssetAtPath(FrameworkUtilities.Fonts + "SourceSansPro/SourceSansPro-Bold.ttf", typeof(Font));

                            case CFontStyle.BoldItalic:
                                return (Font)AssetDatabase.LoadAssetAtPath(FrameworkUtilities.Fonts + "SourceSansPro/SourceSansPro-BoldItalic.ttf", typeof(Font));

                            case CFontStyle.Light:
                                return (Font)AssetDatabase.LoadAssetAtPath(FrameworkUtilities.Fonts + "SourceSansPro/SourceSansPro-Light.ttf", typeof(Font));

                            case CFontStyle.LightItalic:
                                return (Font)AssetDatabase.LoadAssetAtPath(FrameworkUtilities.Fonts + "SourceSansPro/SourceSansPro-LightItalic.ttf", typeof(Font));

                            case CFontStyle.ExtraLight:
                                return (Font)AssetDatabase.LoadAssetAtPath(FrameworkUtilities.Fonts + "SourceSansPro/SourceSansPro-ExtraLight.ttf", typeof(Font));

                            case CFontStyle.ExtraLightItalic:
                                return (Font)AssetDatabase.LoadAssetAtPath(FrameworkUtilities.Fonts + "SourceSansPro/SourceSansPro-ExtraLightItalic.ttf", typeof(Font));

                            case CFontStyle.SemiBold:
                                return (Font)AssetDatabase.LoadAssetAtPath(FrameworkUtilities.Fonts + "SourceSansPro/SourceSansPro-SemiBold.ttf", typeof(Font));

                            case CFontStyle.SemiBoldItalic:
                                return (Font)AssetDatabase.LoadAssetAtPath(FrameworkUtilities.Fonts + "SourceSansPro/SourceSansPro-SemiBoldItalic.ttf", typeof(Font));

                            case CFontStyle.Black:
                                return (Font)AssetDatabase.LoadAssetAtPath(FrameworkUtilities.Fonts + "SourceSansPro/SourceSansPro-Black.ttf", typeof(Font));

                            case CFontStyle.BlackItalic:
                                return (Font)AssetDatabase.LoadAssetAtPath(FrameworkUtilities.Fonts + "SourceSansPro/SourceSansPro-BlackItalic.ttf", typeof(Font));
                        }

                }
            }
        }
    }
}