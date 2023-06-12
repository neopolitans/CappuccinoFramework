using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This Extension Script adds Ownership Data that can be amended or applied to the CProperty.
// Supercedes COwner for better memory usage.

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> This class abstracts some of the minutia and nomenclature issues that Unity has in the <seealso cref="UnityEditor.SerializedProperty"/> object class.
        /// </summary>
        public partial class CProperty
        {
            CObject owner;
            CProperty parent;

            /// <summary>
            /// Get the parent SerializedProperty if one is available.
            /// </summary>
            public SerializedProperty Parent
            {
                get { return parent.underlyingProperty; }
            }

            /// <summary>
            /// Get or set the parent SerializedProperty if one is available.<br></br><br></br>
            /// <see langword="Cappuccino:"/> This provides unsafe get-set access to modifying the value of the parent property's underlying SerializedProperty.
            /// </summary>
            public SerializedProperty ParentUnsafe
            {
                get { return parent.underlyingPropertyUnsafe; }
                set { parent.underlyingPropertyUnsafe = value; }
            }

            /// <summary>
            /// Get the parent SerializedProperty if one is available.
            /// </summary>
            public SerializedObject Owner
            {
                get { return owner.obj; }
            }

            /// <summary>
            /// Get or set the parent SerializedProperty if one is available. <br></br><br></br>
            /// <see langword="Cappuccino:"/> This provides unsafe get-set access to modifying the value of the owner property's underlying SerializedObject.
            /// </summary>
            public SerializedObject OwnerUnsafe
            {
                get { return owner.objUnsafe; }
                set { owner.objUnsafe = value; }
            }

            /// <summary>
            /// Get the parent CProperty if one is available.
            /// </summary>
            public CProperty CParent
            {
                get { return parent; }
            }

            /// <summary>
            /// Get or set the parent CProperty if one is available.
            /// <see langword="Cappuccino:"/> This provides unsafe get-set access to modifying the value of the parent property.
            /// </summary>
            public CProperty CParentUnsafe
            {
                get { return parent; }
                set { parent = value; }
            }

            /// <summary>
            /// Get the parent CObject if one is available.
            /// </summary>
            public CObject COwner
            {
                get { return owner; }
            }

            /// <summary>
            /// Get or set the parent CObject if one is available.
            /// <see langword="Cappuccino:"/> This provides unsafe get-set access to modifying the value of the owner property.
            /// </summary>
            public CObject COwnerUnsafe
            {
                get { return owner; }
                set { owner = value; }
            }

            /// <summary>
            /// Get the owning SerializedObject if one is available. 
            /// </summary>
            /// <returns>
            /// <see langword="bool"/> result <br></br>
            /// <see langword="out"/> <see cref="SerializedObject"/> DesiredObject
            /// </returns>
            public bool GetOwner(out SerializedObject serializedObjectRef)
            {
                if (owner == null)
                {
                    serializedObjectRef = null;
                    return false;
                }
                else
                {
                    serializedObjectRef = owner.objUnsafe;
                    return true;
                }
            }

            /// <summary>
            /// Get the owning CObeject reperesentation of SerializedObject if one is available.
            /// </summary>
            /// <returns>
            /// <see langword="bool"/> result <br></br>
            /// <see langword="out"/> <see cref="CObject"/> DesiredObject
            /// </returns>
            public bool GetOwner(out CObject cobjectRef)
            {
                if (owner == null)
                {
                    cobjectRef = null;
                    return false;
                }
                else
                {
                    cobjectRef = owner;
                    return true;
                }
            }

            /// <summary>
            /// Get the hierarchical parent SerializedProperty if one is available. 
            /// </summary>
            /// <returns>
            /// <see langword="bool"/> result <br></br>
            /// <see langword="out"/> <see cref="SerializedProperty"/> DesiredObject
            /// </returns>
            public bool GetParent(out SerializedProperty serializedPropertyRef)
            {
                if (parent == null)
                {
                    serializedPropertyRef = null;
                    return false;
                }
                else
                {
                    serializedPropertyRef = parent.underlyingPropertyUnsafe;
                    return true;
                }
            }


            /// <summary>
            /// Get the owning CObeject reperesentation of SerializedObject if one is available.
            /// </summary>
            /// <returns>
            /// <see langword="bool"/> result <br></br>
            /// <see langword="out"/> <see cref="CProperty"/> DesiredObject
            /// </returns>
            public bool GetParent(out CProperty cpropertyRef)
            {
                if (parent == null)
                {
                    cpropertyRef = null;
                    return false;
                }
                else
                {
                    cpropertyRef = parent;
                    return true;
                }
            }
        }
    }
}