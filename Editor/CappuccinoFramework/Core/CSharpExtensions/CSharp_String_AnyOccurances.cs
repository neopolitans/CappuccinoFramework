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
        /// Find the amount of occurances of a set of characters within a string.
        /// </summary>
        /// <param name="queryTarget">The string to query for any occurances.</param>
        /// <param name="characters">The characters to find in the array.</param>
        /// <returns></returns>
        public static int AnyOccurances(this string queryTarget, params char[] characters)
        {
            int occurances = 0;

            char[] chars = queryTarget.ToCharArray();

            foreach (char a in chars)
            {
                foreach (char b in characters)
                {
                    if (a == b)
                    {
                        occurances++;
                        break;
                    }
                }
            }

            return occurances;
        }

        // Note: I'm aware nested loops aren't efficient for this use case but I believe this is fine, at least on recompilation.
    }
}

