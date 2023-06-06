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
        /// Find the amount of occurances of a character within a string.
        /// </summary>
        /// <param name="queryTarget">The string to query for any occurances.</param>
        /// <param name="character">The character to find the amount of occurances of in the string.</param>
        /// <returns></returns>
        public static int Occurances(this string queryTarget, char character)
        {
            int occurances = 0;

            char[] chars = queryTarget.ToCharArray();

            foreach (char c in chars)
            {
                if (c == character) { occurances++; }
            }

            return occurances;
        }
    }
}