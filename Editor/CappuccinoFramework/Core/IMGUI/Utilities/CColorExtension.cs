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
        /// <see langword="Cappuccino:"/> Color-255 Extension for Color object. <br></br>
        /// Allows for use of int values when creating colors.
        /// </summary>
        public static class C255
        {
            public const float n = 1.0f / 255.0f;

            public static Color Color(byte r, byte g, byte b)
            {
                return new Color(n * r, n * g, n * b);
            }
            public static Color Color(byte r, byte g, byte b, byte a)
            {
                return new Color(n * r, n * g, n * b, n * a);
            }
        }
    }
}