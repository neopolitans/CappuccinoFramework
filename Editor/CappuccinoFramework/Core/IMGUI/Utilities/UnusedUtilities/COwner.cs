using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;
using System;

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> A Class sued to provide simpler hierarchical navigation ability for a property.
        /// </summary>
        [Obsolete("This method has been superceded by [CappuccinoFramework > Core > Utilities > CPropertyExtensions > CPropertyOwnership] \nReason: Memory Management Concerns; unecessary extra objects stored and referenced for a single Object Type.", true)]
        public class COwner
        {
            // Raw Values
            SerializedObject ownerRaw;
            SerializedProperty p_ownerRaw;

            #region Constructors
            /// <summary>
            /// Create a COwner object from a SerializedObject. <br></br><br></br>
            /// <see langword="Cappuccino:"/> This variant of the constructor will assume no property parent exists and assuming the attached SerializedObject is the only owner.
            /// </summary>
            /// <param name="obj">The SerializedObject to store as the owner.</param>
            public COwner(SerializedObject obj)
            {
                ownerRaw = obj;
            }

            /// <summary>
            /// Create a COwner object from a SerializedObject and SerializedProperty.
            /// </summary>
            /// <param name="obj">The SerializedObject to store as the owner.</param>
            public COwner(SerializedObject obj, SerializedProperty property)
            {
                ownerRaw = obj;

                p_ownerRaw = property;
            }
            #endregion


            /// <summary>
            /// The SerializedObject owner of this object.
            /// </summary>
            public SerializedObject ObjectParentRaw
            {
                get { return ownerRaw; }
            }

            /// <summary>
            /// The SerializedProperty parent of this object. (Read-only) as a quick-accessor.
            /// </summary>
            public SerializedProperty PropertyParentRaw
            {
                get { return p_ownerRaw; }
            }

            /// <summary>
            /// The SerializedObject owner of this object.
            /// </summary>
            public SerializedObject Owner
            {
                get { return ownerRaw; }
            }

            /// <summary>
            /// The SerializedProperty parent of this object.
            /// </summary>
            public SerializedProperty Parent
            {
                get { return p_ownerRaw; }
            }

            /// <summary>
            /// The SerializedObject owner of this object. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Unsafe. Only use this if you're experienced with using CObject, CProperty and COwner. <br></br>
            /// Provides raw, modifiable access to the property.
            /// </summary>
            public SerializedObject OwnerUnsafe
            {
                get { return ownerRaw; }
                set { ownerRaw = value; }
            }

            /// <summary>
            /// The SerializedProperty parent of this object. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Unsafe. Only use this if you're experienced with using CObject, CProperty and COwner. <br></br>
            /// Provides raw, modifiable access to the property.
            /// </summary>
            public SerializedProperty ParentUnsafe
            {
                get { return p_ownerRaw; }
                set { p_ownerRaw = value; }
            }

        }
    }
}