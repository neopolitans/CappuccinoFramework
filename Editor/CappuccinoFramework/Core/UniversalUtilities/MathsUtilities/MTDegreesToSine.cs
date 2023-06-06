using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> This static class is the Maths Toolkit. It contains additional mathematics methods. <br></br>
        /// <b><see langword="Notice:"/></b> This toolkit is used by other methods in Cappuccino Framework to make extra features.
        /// </summary>
        public static partial class MathToolkit
        {
            // Forward-ported from Introduction to AI Module submission.
            /// <summary>
            /// Degrees -> Sine result
            /// </summary>
            /// <param name="degrees"></param>
            /// <returns>Arc Sine result</returns>
            public static float Deg2Sin(float degrees)
            {
                return Mathf.Sin(degrees * Mathf.Deg2Rad);
            }
        }
    }
}