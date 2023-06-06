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
        /// <see langword="Cappuccino:"/> A Wrapper for <seealso cref="UnityEditor.SerializedObject"/>. <br></br>
        /// Used to help provide simplified methods and easier hierarchical navigation of properties and their children.
        /// </summary>
        public class CObject
        {
            SerializedObject serializedObject;

            string name = string.Empty;

            /// <summary>
            /// Get or Set the Valid state of the CObject.
            /// </summary>
            bool valid;

            /// <summary>
            /// Get whether or not the CObject is valid. <br></br> 
            /// <i>True if there is an underlying SerializedObject, otherwise false.</i>
            /// </summary>
            public bool Valid
            {
                get { return valid; }
            }

            #region Constructors
            /// <summary>
            /// Create a CObject from an Object.
            /// </summary>
            /// <param name="obj">The UnityEngine.Object to create a SerializedObject and CObject for.</param>
            public CObject(Object obj)
            {
                serializedObject = new(obj);
                name = obj.name;
            }

            /// <summary>
            /// Create a CObject from an underlying component of a UnityEngine.Object. <br></br><br></br>
            /// <see langword="Notice:"/> This requires that the object you're trying to find has the underlying component and requires error handling. <br></br>
            /// </summary>
            /// <param name="obj">The UnityEngine.Object to get the .</param>
            /// <param name="type">The System.Type of the component to try fetch.</param>
            public CObject(Object obj, System.Type type)
            {
                serializedObject = new SerializedObject(obj.GetComponent(type));
                valid = serializedObject != null;
            }

            /// <summary>
            /// Create a CObject from a SerializedObject.
            /// </summary>
            /// <param name="serializedObject">The SerializedObject to create a CObject for.</param>
            public CObject(SerializedObject serializedObject)
            {
                this.serializedObject = serializedObject;
                name = serializedObject.targetObject.name;
            }
            #endregion
        
            /// <summary>
            /// A Read-Only accessor for the SerializedObject stored inside the CObject.
            /// </summary>
            public SerializedObject obj 
            {
                get { return serializedObject; } 
            }

            /// <summary>
            /// An accessor for the SerializedObject stored inside the CObject.
            /// </summary>
            public SerializedObject objUnsafe
            {
                get { return serializedObject; }
                set
                {
                    valid = value != null;
                    serializedObject = value; 
                }
            }

            /// <summary>
            /// Find the SerializedProperty child of this CObject and return it as a CProperty. <br></br><br></br>
            /// <see langword="Notice:"/> This property may return null, either from it's value or otherwise. Check if this property is null or not.
            /// </summary>
            /// <param name="name">The name of the property to try find.</param>
            /// <returns></returns>
            public CProperty Find(string name)
            {
                return new CProperty(this, serializedObject.FindProperty(name));
            }

            /// <summary>
            /// Find the SerializedProperty child of this CObject.
            /// </summary>
            /// <param name="name">The name of the property to try find.</param>
            /// <returns></returns>
            public SerializedProperty FindRaw(string name)
            {
                return serializedObject.FindProperty(name);
            }

            /// <summary>
            /// Find and draw a property within this SerializedObject. <br></br>
            /// Does not find properties within objects that are the child of this property.
            /// </summary>
            /// <param name="propertyName">The name of the property to try find.</param>
            public void DrawProperty(string propertyName)
            {
                CProperty p = Find(propertyName);

                if (p != null)
                {
                    p.Draw();
                }
            }

            /// <summary>
            /// Find and draw a property within this SerializedObject. <br></br>
            /// Does not find properties within objects that are the child of this property.
            /// </summary>
            /// <param name="propertyName">The name of the property to try find.</param>
            /// <param name="label">The text label to display as the property field name.</param>
            public void DrawProperty(string propertyName, string label)
            {
                CProperty p = Find(propertyName);

                if (p != null)
                {
                    p.Draw(label);
                }
            }

            /// <summary>
            /// Find and draw a property within this SerializedObject. <br></br>
            /// Does not find properties within objects that are the child of this property.
            /// </summary>
            /// <param name="propertyName">The name of the property to try find.</param>
            /// <param name="readOnly">Whether or not the property field should be read-only.</param>
            public void DrawProperty(string propertyName, bool readOnly)
            {
                CProperty p = Find(propertyName);

                if (p != null)
                {
                    p.Draw(readOnly);
                }
            }

            /// <summary>
            /// Find and draw a property within this SerializedObject. <br></br>
            /// Does not find properties within objects that are the child of this property.
            /// </summary>
            /// <param name="propertyName">The name of the property to try find.</param>
            /// <param name="label">The text label to display as the property field name.</param>
            /// <param name="readOnly">Whether or not the property field should be read-only.</param>
            public void DrawProperty(string propertyName, string label, bool readOnly)
            {
                CProperty p = Find(propertyName);

                if (p != null)
                {
                    p.Draw(label, readOnly);
                }
            }

            #region Object Inspection State Methods
            /// <summary>
            /// Update the information of the SerializedObject. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Necessary to see the changes just made to the underlying SerializedObject on the next GUI Draw.
            /// </summary>
            public void Update()
            {
                serializedObject.Update();
            }

            /// <summary>
            /// Apply the changes made to the underlying SerializedObject and it's children. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Necessary to save the changes just made to the underlying SerializedObject before the next GUI Draw. <br></br>
            /// If there are no modified properties, ApplyModifiedProperties() isn't called.
            /// </summary>
            public void Apply()
            {
                if (serializedObject.hasModifiedProperties)
                {
                    serializedObject.ApplyModifiedProperties();
                }
            }

            /// <summary>
            /// Apply the changes made to the underlying SerializedObject and it's children. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Necessary to save the changes just made to the underlying SerializedObject before the next GUI Draw. <br></br>
            /// If there are no modified properties, ApplyModifiedProperties() isn't called. <br></br><br></br>
            /// <b><see langword="Notice:"/> This method does not allow you to undo any actions taken on an object. Use with extreme caution. </b> 
            /// </summary>
            public void ApplyWithoutUndo()
            {
                if (serializedObject.hasModifiedProperties)
                {
                    serializedObject.ApplyModifiedPropertiesWithoutUndo();
                }
            }
            #endregion

            #region Iteration Methods
            /// <summary>
            /// Get the first SerializedProperty as an iterator to use for iterating over all the objects. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Redirect for the underlying SerializedObject's GetIterator() method. <br></br>
            /// </summary>
            public SerializedProperty GetIterator()
            {
                return serializedObject.GetIterator();
            }

            /// <summary>
            /// Get the first SerializedProperty (in a CProperty) as an iterator to use for iterating over all the objects. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Creates a CProperty from the underlying SerializedObject's GetIterator() method. <br></br>
            /// </summary>
            public CProperty First()
            {
                return new CProperty(serializedObject.GetIterator());
            }
            #endregion

            #region Object Validation Methods

            /// <summary>
            /// Mark the CObject as invalid. <br></br><br></br>
            /// <see langword="Notice:"/> Setting the underlying object using objUnsafe sets the CProperty back to valid.
            /// </summary>
            public void Invalidate()
            {
                valid = false;
            }


            /// <summary>
            /// Mark the CObject as valid. <br></br><br></br>
            /// <b><i><see langword="Notice: If you use this on a CObject that is invalid and not assigned a new underlying SerializedObject, get-set calls will fail and error."/></i></b>
            /// </summary>
            public void Validate()
            {
                valid = true;
            }

            // I considered adding a Diag.Violation to Validate but potential use cases will 

            #endregion
        }
    }
}