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
        /// Remove null, empty or whitespace strings from within a string array.
        /// </summary>
        /// <param name="array">The string array to parse.</param>
        /// <param name="chars">The characters to filter from the array.</param>
        /// <returns></returns>
        public static string[] RemoveBlanks(this string[] array)
        {
            List<string> result = new List<string>();

            // For the array, filter out any string that is null, empty or a whitespace.
            foreach (string s in array)
            {
                if (!string.IsNullOrEmpty(s) && !string.IsNullOrWhiteSpace(s))
                {
                    result.Add(s);
                }
            }

            return result.ToArray();
        }
    }
}

