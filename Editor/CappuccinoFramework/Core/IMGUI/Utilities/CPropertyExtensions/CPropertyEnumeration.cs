using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This Extension Script adds interoperability with SerializedProperty's enumeration methods, however it does not modify some of them.

/* This Extension Script utilizes "=>" (Lambda Expression) to condense some methods from:

   ------------------------------------------------------------------------------------------------
   access-modifier <returnType> CappuccinoMethodName(...)
   {
        return unityObjectReference.UnityMethodName(...)
   }
   ------------------------------------------------------------------------------------------------

    : to :

   ------------------------------------------------------------------------------------------------
    access-modifier <returnType> CappuccinoMethodName(...) => unityObjectReference.UnityMethodName(...);
   ------------------------------------------------------------------------------------------------

    Why was this done? For any methods using a lambda expression, there's no need to improve upon reliable work that Unity's Internal Design team has already done.
    I cannot change or improve the functionality in a way that is more familiar in naming. At most, all that can be done is making the documentation more experssive.

    Lambdas are not used normally in Cappuccino as I want to be able to make it quick to extend or change something and provide the same to anyone looking to modify Cappuccino.
    This was a consideration here on the express grounds that there is no improvement to be made. All in all, Good Game Unity Technologies!

    If you can find anything to improve here and don't know Lambda expressions, you can consider this a quick introduction to them.
    (P.S. If you find something to extend about Unity's SerializedProperty method that I couldn't, hats off to you.)
*/

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
            /// Return an Iterator for the current property that iterates over all visible Child SerializedProperties. <br></br><br></br>
            /// <see langword="Cappuccino:"/> This is a method-redirect for SerializedProperty.GetEnumerator().
            /// </summary>
            /// <returns><see cref="IEnumerator"/> for child properties in a SerializedProperty</returns>
            public IEnumerator GetEnumerator() => property.GetEnumerator();

            /// <summary>
            /// If there are other properties in the parent object of this SerializedProperty, it will update the property reference to the next one in order of Serialization and <b><i>return <see langword="true"/></i></b>.<br></br>
            /// If no other property can be found, this method will <b><i>return <see langword="false"/></i></b>, the underlying property for this CProperty will be invalid and this CProperty will no longer be valid.<br></br><br></br>
            /// <see langword="Cappuccino:"/> This is a method-redirect for SerializedProperty.Next(). <br></br>
            /// <b><see langword="Notice:"/></b> Calling this method will mark the CProperty as invalid if property.Next() returns false.
            /// </summary>
            /// <returns><see langword="boolean"/> If there is another SerializedProperty to move to</returns>
            public bool Next()
            {
                bool result = property.Next(true);
                valid = result;

                return valid;
            }

            /// <summary>
            /// If there are other properties in the parent object of this SerializedProperty, it will update the property reference to the next one visible in order of Serialization and <b><i>return <see langword="true"/></i></b>.<br></br>
            /// If no other property can be found, this method will <b><i>return <see langword="false"/></i></b>, the underlying property for this CProperty will be invalid and this CProperty will no longer be valid.<br></br><br></br>
            /// <see langword="Cappuccino:"/> This is a method-redirect for SerializedProperty.Next(). <br></br>
            /// <b><see langword="Notice:"/></b> Calling this method will mark the CProperty as invalid if property.Next() returns false.
            /// </summary>
            /// <returns><see langword="boolean"/> If there is another SerializedProperty to move to</returns>
            public bool NextVisible()
            {
                bool result = property.NextVisible(true);
                valid = result;

                return valid;
            }

            /// <summary>
            /// If there are other properties in the parent object of this SerializedProperty, it will update the property reference to the next one in order of Serialization and <b><i>return <see langword="true"/></i></b>.<br></br>
            /// If no other property can be found, this method will <b><i>return <see langword="false"/></i></b>, the underlying property for this CProperty will be invalid and this CProperty will no longer be valid.<br></br><br></br>
            /// <see langword="Cappuccino:"/> This is a method-redirect for SerializedProperty.Next(). <br></br>
            /// <b><see langword="Notice:"/></b> Calling this method will mark the CProperty as invalid if property.Next() returns false.
            /// </summary>
            /// <param name="accessChildProperties"> Should the underlying SerializedProperty try to move to the child properties linked to the current property? </param>
            /// <returns><see langword="boolean"/> True if a property was found after the current one, false if none were. Additionally invalidates the CProperty. </returns>
            public bool Next(bool accessChildProperties)
            {
                bool result = property.Next(accessChildProperties);
                valid = result;

                return valid;
            }

            /// <summary>
            /// If there are other properties in the parent object of this SerializedProperty, it will update the property reference to the next one visible in order of Serialization and <b><i>return <see langword="true"/></i></b>.<br></br>
            /// If no other property can be found, this method will <b><i>return <see langword="false"/></i></b>, the underlying property for this CProperty will be invalid and this CProperty will no longer be valid.<br></br><br></br>
            /// <see langword="Cappuccino:"/> This is a method-redirect for SerializedProperty.Next(). <br></br>
            /// <b><see langword="Notice:"/></b> Calling this method will mark the CProperty as invalid if property.Next() returns false.
            /// </summary>
            /// <param name="accessChildProperties"> Should the underlying SerializedProperty try to move to the child properties linked to the current property? </param>
            /// <returns><see langword="boolean"/> True if a property was found after the current one, false if none were. Additionally invalidates the CProperty. </returns>
            public bool NextVisible(bool accessChildProperties)
            {
                bool result = property.NextVisible(accessChildProperties);
                valid = result;

                return valid;
            }

            /// <summary>
            /// Reset the SerializedProperty reference to the first SerializedProperty in it's owning SerializedObject.
            /// </summary>
            public void Reset()
            {
                property.Reset();
                valid = true;
            }
        }
    }
}