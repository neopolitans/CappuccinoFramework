using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Cappuccino
{
    // Note: As Substring is from start index to length, I find it more restrictive to plan around. 
    //       so instead, I've added this so that I can directly use a character array to get the string betwene the indices.

    /// <summary>
    /// <see langword="Cappuccino:"/> A class containing various extension methods for C# types internally. <br></br>
    /// <b><see langword="Notice:"/> <i>Not for runtime use.</i></b> 
    /// </summary>
    public static partial class CSharp
    { 

        /// <summary>
        /// Get the substring between the start and end integers. <br></br><br></br>
        /// <see langword="Notice:"/> This returns the substring, starting at the start integer and the end integer. <br></br>
        /// This may cause undesireable returns if you aren't wanting the start or end point characters included.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string Between(this string str, int start, int end)
        {
            // If start or end are either lower than 0 or higher than string length, throw an IndexOutOfRangeException.
            if (start > str.Length - 1 || start < 0 || end > str.Length - 1)
            {
                throw new System.IndexOutOfRangeException();
            }

            char[] chars = str.ToCharArray();
            string result = "";

            for (int i = 0; i < chars.Length; i++)
            {
                if (i >= start && i <= end)
                {
                    result += chars[i];
                }
            }

            return result;
        }
    }
}