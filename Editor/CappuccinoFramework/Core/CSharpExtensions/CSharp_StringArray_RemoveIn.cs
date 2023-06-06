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
        /// Remove a collection of Characters from within a string array.
        /// </summary>
        /// <param name="array">The string array to parse.</param>
        /// <param name="chars">The characters to filter from the array.</param>
        /// <returns></returns>
        public static string[] RemoveIn(this string[] array, params char[] chars)
        {
            List<string> result = new List<string>();

            // For all the strings in the array, if any character (as a string) is equal to the string being iterated over, remove it.
            foreach (string s in array)
            {
                bool matchedChar = false;
                foreach (char c in chars)
                {
                    matchedChar = c.ToString() == s;
                    if (matchedChar) { break; }
                }

                if (matchedChar)
                {
                    continue;
                }
                else
                {
                    result.Add(s);
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// Remove a collection of Strings from within a string array.
        /// </summary>
        /// <param name="array">The string array to parse.</param>
        /// <param name="strings">The strings to filter from the array.</param>
        /// <returns></returns>
        public static string[] RemoveIn(this string[] array, params string[] strings)
        {
            List<string> result = new List<string>();

            // For all the strings in the array, if any character (as a string) is equal to the string being iterated over, remove it.
            foreach (string s in array)
            {
                bool matchedOtherString = false;
                foreach (string s2 in strings)
                {
                    matchedOtherString = s2 == s;
                    if (matchedOtherString) { break; }
                }

                if (matchedOtherString)
                {
                    continue;
                }
                else
                {
                    result.Add(s);
                }
            }

            return result.ToArray();
        }
    }
}

