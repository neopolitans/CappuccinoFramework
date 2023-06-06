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
        /// Break a string into an array of strings using a set of characters provided as breakpoints to test for.
        /// </summary>
        /// <param name="str">The string to break apart.</param>
        /// <param name="breakpointCharacters">The set of characters to use as breakpoints.</param>
        /// <returns></returns>
        public static string[] BreakAny(this string str, params char[] breakpointCharacters)
        {
            char[] chars = str.ToCharArray();
            List<string> result = new List<string>();
            string current = "";

            foreach (char c in chars)
            {
                // if the character is any of the breakpoint characters, resize the result array,
                // add the current substring to the array then set the current substring to the current character.
                if (c.IsAny(breakpointCharacters))
                {
                    result.Add(current);

                    current = c.ToString();
                }
                // otherwise, add to the current substring.
                else
                {
                    current += c;
                }
            }

            result.Add(current); // A string will still be present, we add it to the array afterwards to prevent an additional check.

            return result.ToArray();
        }
    }
}