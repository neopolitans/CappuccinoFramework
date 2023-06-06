using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;
using System;

// This script adds extensions for Array-oriented methods for CProperty.

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> This class abstracts some of the minutia and nomenclature issues that Unity has in the <seealso cref="UnityEditor.SerializedProperty"/> object class.
        /// </summary>
        public partial class CProperty
        {
            /// <summary>
            /// <see langword="Cappuccino:"/> Is the current CProperty an array?
            /// </summary>
            public bool isArray
            {
                get { return property.isArray; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Get the size of the SerializedProperty's array, if the SerializedProperty is storing an array.
            /// </summary>
            public int arraySize
            {
                get
                {
                    if (property.isArray)
                    {
                        return property.arraySize;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Get a CProperty representation of the SerializedProperty at the specified index. 
            /// </summary>
            /// <param name="index">The index to try get the value from.</param>
            /// <returns><see cref="CProperty"/> or <see langword="null"/> if the containing property is not storing an array.</returns>
            public CProperty GetIndex(int index)
            {
                if (property.isArray)
                {
                    return new CProperty(property.GetArrayElementAtIndex(index));
                }
                else
                {
                    return null;
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Get the SerializedProperty at the specified index.
            /// </summary>
            /// <param name="index">The index to try get the value from.</param>
            /// <returns><see cref="SerializedProperty"/> or <see langword="null"/> if the containing property is not storing an array.</returns>
            public SerializedProperty GetIndexRaw(int index)
            {
                if (property.isArray)
                {
                    return property.GetArrayElementAtIndex(index);
                }
                else
                {
                    return null;
                }
            }

            /// <summary>
            /// Add an element in the position of the array.<br></br> 
            /// The element added will be empty and needs to have assigned data.<br></br><br></br>
            /// <see langword="Cappuccino:"/>  If the property isn't storing an array, this method returns false. <br></br>
            /// <see langword="Notice:"/> If the element type of the array is a struct or class, you may need to wrap this call inside a function and set the default data for it.
            /// </summary>
            /// <param name="index">The index to add the element at.</param>
            /// <returns><see langword="boolean"/></returns>
            public bool Add(int index)
            {
                if (isArray)
                {
                    property.InsertArrayElementAtIndex(index);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Add an element to the end of the array.<br></br> 
            /// The element added will be empty and needs to have assigned data.<br></br><br></br>
            /// <see langword="Cappuccino:"/>  If the property isn't storing an array, this method returns false. <br></br>
            /// <see langword="Notice:"/> If the element type of the array is a struct or class, you may need to wrap this call inside a function and set the default data for it.
            /// </summary>
            /// <returns><see langword="boolean"/></returns>
            public bool AddLast()
            {
                if (isArray)
                {
                    property.InsertArrayElementAtIndex(arraySize);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Remove the element at the specified index. <br></br><br></br>
            /// <see langword="Cappuccino:"/> If the property isn't storing an array or the array size isn't greater or equal to the index value, this method returns false.
            /// </summary>
            /// <param name="index">The index of the element to remove</param>
            /// <returns><see langword="boolean"/></returns>
            public bool Remove(int index)
            {
                if (isArray && arraySize - 1 >= index)
                {
                    property.DeleteArrayElementAtIndex(index);
                    return true;
                }
                else
                {
                    return false;
                }
            }


            /// <summary>
            /// Remove the element at the specified index. <br></br><br></br>
            /// <see langword="Cappuccino:"/> If the property isn't storing an array, this method returns false.
            /// </summary>
            /// <param name="index"></param>
            /// <returns><see langword="boolean"/></returns>
            public bool RemoveLast()
            {
                if (isArray && arraySize > 0)
                {
                    property.DeleteArrayElementAtIndex(arraySize - 1);
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
    }
}