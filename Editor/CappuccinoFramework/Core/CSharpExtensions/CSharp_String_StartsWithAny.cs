using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Cappuccino.Attributes;

namespace Cappuccino
{
    /// <summary>
    /// <see langword="Cappuccino:"/> A class containing various extension methods for C# types internally. <br></br>
    /// <b><see langword="Notice:"/> <i>Not for runtime use.</i></b> 
    /// </summary>
    public static partial class CSharp
    {
        /// <summary>
        /// Find if a string starts with any of a set of charcaters.
        /// </summary>
        /// <param name="queryTarget">The string to query.</param>
        /// <param name="characters">The set of characters that are used to check the starting character of the string.</param>
        /// <returns></returns>
        public static bool StartsWithAny(this string queryTarget, params char[] characters)
        {
            foreach (char c in characters)
            {
                if (queryTarget.StartsWith(c))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Find if a string starts with any of a set of charcaters.
        /// </summary>
        /// <param name="queryTarget">The string to query.</param>
        /// <param name="strings">The set of strings that are used to check the starting character of the string.</param>
        /// <returns></returns>
        public static bool StartsWithAny(this string queryTarget, params string[] strings)
        {
            foreach (string s in strings)
            {
                if (queryTarget.StartsWith(s))
                {
                    return true;
                }
            }

            return false;
        }


        // These extensions are a macro to help with checking a bulk of characters.
    }
}
