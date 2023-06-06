using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// A note about this - CComparatives was created originally for CProperty - to make extracting a value easier.
// however, due to how <T> methods work and some tricky issues with it, this became obsolete. This stays in InternalUtilities in the event it's ever needed.

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// A bunch of quick comaparators used to quickly compare what a value is - meant in place of typeof(a) == typeof(b). <br></br><br></br>
        /// <see langword="Cappuccino:"/> Unused. Can be used and modified in [CappuccinoFramework > Core > InternalUtilities].
        /// </summary>
        /// 
        // This script is dedicated for the partial-class containing comparatives for only system values.
        public partial class CComparatives
        {
            // Core
            public static bool Bool<T>(T a)
            {
                return a.GetType() == typeof(bool);
            }

            public static bool Int<T>(T a)
            {
                return a.GetType() == typeof(int);
            }

            public static bool Float<T>(T a)
            {
                return a.GetType() == typeof(float);
            }

            public static bool Double<T>(T a)
            {
                return a.GetType() == typeof(double);
            }

            public static bool Byte<T>(T a)
            {
                return a.GetType() == typeof(byte);
            }

            public static bool SByte<T>(T a)
            {
                return a.GetType() == typeof(sbyte);
            }

            public static bool Char<T>(T a)
            {
                return a.GetType() == typeof(char);
            }

            public static bool Decimal<T>(T a)
            {
                return a.GetType() == typeof(decimal);
            }

            public static bool Uint<T>(T a)
            {
                return a.GetType() == typeof(uint);
            }

            public static bool Nint<T>(T a)
            {
                return a.GetType() == typeof(nint);
            }

            public static bool Nuint<T>(T a)
            {
                return a.GetType() == typeof(nuint);
            }

            public static bool Long<T>(T a)
            {
                return a.GetType() == typeof(long);
            }

            public static bool Ulong<T>(T a)
            {
                return a.GetType() == typeof(ulong);
            }

            public static bool Short<T>(T a)
            {
                return a.GetType() == typeof(short);
            }

            public static bool Ushort<T>(T a)
            {
                return a.GetType() == typeof(ushort);
            }


            // Special
            public static bool Array<T>(T a)
            {
                return a.GetType().IsArray;
            }

            public static bool Struct<T>(T a) where T : struct
            {
                return a.GetType().IsValueType && !a.GetType().IsEnum;
            }
        }
    }
}