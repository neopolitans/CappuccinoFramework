using Cappuccino.Core;
using UnityEngine;

namespace Cappuccino
{
    namespace Interpreters
    {
        namespace Languages
        {
            namespace USS
            {
                /// <summary>
                /// This class defines any and every supported style rule constructor currently known.
                /// </summary>
                public static partial class Rules
                {
                    /// <summary>
                    /// Create a Background-Color Style Rule with a Hexadecimal (#RRGGBB) value.
                    /// </summary>
                    /// <param name="hexColor"> The hexadecimal color to use as a string.</param>
                    public static StyleRule BackgroundColor(ColorHex hexColor)
                    {
                        return new StyleRule(RuleType.backgroundColor, hexColor.value);
                    }

                    /// <summary>
                    /// Create a Background-Color Style Rule with an rgb(r, g, b) USS function value.
                    /// </summary>
                    /// <param name="rgbColor"> The RGB Color to use as a string.</param>
                    public static StyleRule BackgroundColor(ColorRGB rgbColor)
                    {
                        return new StyleRule(RuleType.backgroundColor, rgbColor.value);
                    }

                    /// <summary>
                    /// Create a Background-Color Style Rule with an rgba(r, g, b, a) USS function value.
                    /// </summary>
                    /// <param name="rgbaColor"> The RGBA Color to use as a string.</param>
                    public static StyleRule BackgroundColor(ColorRGBA rgbaColor)
                    {
                        return new StyleRule(RuleType.backgroundColor, rgbaColor.value);
                    }

                    /// <summary>
                    /// Create a Background-Color Style Rule with a &lt;color&gt; Keyword value.
                    /// </summary>
                    /// <param name="keyword"> The color keyword to use as a string.</param>
                    public static StyleRule BackgroundColor(USSColorKeyword keyword)
                    {
                        return new StyleRule(RuleType.backgroundColor, new ColorKeyword(keyword).value);
                    }

                    /// <summary>
                    /// Create a Background-Image-Tint-Color Style Rule with a UnityEngine Color value.
                    /// </summary>
                    /// <param name="color">The UnityEnigne color to convert to a USS-compatible rgba() function.</param>
                    /// <returns></returns>
                    public static StyleRule BackgroundColor(Color color)
                    {
                        return new StyleRule(RuleType.backgroundColor, new ColorRGBA(
                            ((byte)((int)Mathf.Clamp(color.r * 255, 0f, 255f))),
                            ((byte)((int)Mathf.Clamp(color.g * 255, 0f, 255f))),
                            ((byte)((int)Mathf.Clamp(color.b * 255, 0f, 255f))),
                            color.a).value);
                    }
                }
            }
        }
    }
}