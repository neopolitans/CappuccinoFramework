using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cappuccino
{
    /// <summary>
    /// <see langword="Cappuccino:"/> A class containing various extension methods for C# types internally. <br></br>
    /// <b><see langword="Notice:"/> <i>Not for runtime use.</i></b> 
    /// </summary>
    public static partial class CSharp
    { 
        /// <summary>
        /// Returns whether a character is any of the provided charcaters.
        /// </summary>
        /// <param name="chr">The character being compared.</param>
        /// <param name="characters">The characters to compare with.</param>
        /// <returns></returns>
        public static bool IsAny(this char chr, params char[] characters)
        {
            foreach (char c in characters)
            {
                if (chr == c)
                {
                    return true;
                }
            }

            return false;
        }
    }
}