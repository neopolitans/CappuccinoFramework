using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> This namespace contains mostly methods found within Unity namespaces (and packages) that are extremely useful. <br></br><br></br>
        /// <b><see langword="Notice:"/></b> Any methods provided through this namespace are often not explicitly created by the author(s) of Cappuccino, instead being authored (or originating from) Unity. <br></br>
        /// They are provided for future backwards-compatibility with older versions of Unity Engine. <br></br><br></br>
        /// <b>The original source is cited within XML documentation for each module included.</b> <br></br>
        /// <i>It is not advised, for various reasons, to extract these methods yourself.</i>
        /// </summary>
        public static partial class Unity
        {
            /// <summary>
            /// Get the average size of a glyph. <br></br><br></br>
            /// <b><see langword="Source:"/></b> Cappuccino Framework (Custom)
            /// </summary>
            /// <param name="font"></param>
            /// <returns></returns>
            public static Vector2 GetAverageGlyphSize(this Font font)
            {
                int char_amount = font.characterInfo.Length;
                Vector2 glyph_size = new Vector2(0f, 0f);

                foreach (CharacterInfo char_info in font.characterInfo)
                {
                    glyph_size.x += char_info.glyphWidth;
                    glyph_size.y += char_info.glyphHeight;
                }

                glyph_size.x = glyph_size.x / char_amount;
                glyph_size.y = glyph_size.y / char_amount;

                return glyph_size;
            }
        }
    }
}