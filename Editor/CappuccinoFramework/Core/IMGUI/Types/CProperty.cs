using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// NOTE: Not everything about CProperty is stored here.
// For some specific methods, there are incusions found in: CappuccinoFramework > Core > Utilities > CPropertyExtensions
// This class is large and only the absolute core elements exist here. Anything in CPropertyExtensions can be absent if need be.

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> This class abstracts some of the minutia and nomenclature issues that Unity has in the <seealso cref="UnityEditor.SerializedProperty"/> object class.
        /// </summary>
        public partial class CProperty
        {
            // Internal Variables
            /// <summary>
            /// The SerializedProperty that this CProperty object represents.
            /// </summary>
            SerializedProperty property;

            /// <summary>
            /// Get or Set the Valid state of the CProperty.
            /// </summary>
            bool valid;

            // External Properties

            /// <summary>
            /// Get the SerializedProperty represented by this object.
            /// </summary>
            public SerializedProperty underlyingProperty
            {
                get { return property; }
            }

            /// <summary>
            /// Get or Set the SerializedProperty represented by this object. <br></br><br></br>
            /// <see langword="Cappuccino:"/> This property has been marked as <b><see langword="unsafe"/></b> as it can be overridden and break the connection with the obejct. <br></br>
            /// </summary>
            public SerializedProperty underlyingPropertyUnsafe
            {
                get { return property; }
                set
                {
                    valid = value != null;
                    property = value;
                }
            }

            /// <summary>
            /// Get the underlying SerializedProperty's display name.
            /// </summary>
            public string name
            {
                get { return property.displayName; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> How many parents the property has, including it's owning SerializedObject. <br></br>
            /// <see langword="Unity:"/> This fetches the underlying SerializedProperty.depth.
            /// </summary>
            public int depth
            {
                get { return property.depth; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> The path of the property, starting from it's owning object. <br></br>
            /// <see langword="Unity:"/> This fetches the underlying SerializedProperty.propertyPath. <br></br><br></br>
            /// <b>Example:</b> <i>owningSerializedObject.parentSerializedProperty.thisPropertyName</i>
            /// </summary>
            public string path
            {
                get { return property != null ? property.propertyPath : "{This Property was Invalidated and dereferneced.}"; }
            }

            /// <summary>
            /// Get whether or not the CProperty is valid. <br></br> 
            /// <i>True if there is an underlying SerializedProperty, otherwise false.</i>
            /// </summary>
            public bool Valid
            {
                get { return valid; }
            }

            // Methods

            #region Constructors
            /// <summary>
            /// Create a CProperty object by finding the named property within the parent SerialziedObject. <br></br><br></br>
            /// <see langword="CProperty.parent:"/> This constructor variant does not create parent information for this property. <br></br><br></br>
            /// <see langword="CProperty.owner:"/> This constructor variant creates a CObject to fill <b><i><see cref="owner"/></i></b>. <br></br>
            /// If you already have created a CObject to represent the SerializedObject, pass that throughinstead of the raw SerializedObject for better memory usage.
            /// </summary>
            /// <param name="owner">Parent SerializedObject to find the named property in.</param>
            /// <param name="name">The name of the property to query.</param>
            public CProperty(SerializedObject owner, string name)
            {
                this.owner = new CObject(owner);
                property = owner.FindProperty(name);
                valid = property != null;
            }

            /// <summary>
            /// Create a CProperty object from an already provided SerializedProperty <br></br><br></br>
            /// <see langword="CProperty.parent:"/> This constructor variant does not create parent information for this property. <br></br><br></br>
            /// <see langword="CProperty.owner [READ-ONLY]:"/> This constructor variant creates a CObject to fill <b><i><see cref="owner"/></i></b> from the SerializedProperty.serializedObject property, which is a read-only value. <br></br>
            /// If you already have created a CObject for this SerializedObject, use that instead for better memory usage and to edit values within the owner through the CProperty.
            /// </summary>
            /// <param name="property">The SerializedProperty to create the CProperty for.</param>
            public CProperty(SerializedProperty property)
            {
                owner = new CObject(property.serializedObject);
                this.property = property;
                valid = property != null;
            }

            /// <summary>
            /// Create a CProperty object by finding the named property within the parent SerializedProperty.<br></br><br></br>
            /// <see langword="CProperty.parent:"/> This constructor variant uses a SerializedProperty to fill the <b><i><see cref="parent"/></i></b> value with a new CProperty. <br></br>
            /// If you have already created a CProperty for the parent SerializedProperty, pass that through instead for better memory usage.<br></br><br></br>
            /// <see langword="CProperty.owner [READ-ONLY]:"/> This constructor variant creates a CObject to fill <b><i><see cref="owner"/></i></b> from the SerializedProperty.serializedObject property, which is a read-only value. <br></br>
            /// If you already have created a CObject for this SerializedObject, use that instead for better memory usage and to edit values within the owner through the CProperty.
            /// </summary>
            /// <param name="parent">Parent SerializedProperty to find the named property in.</param>
            /// <param name="name">The name of the property to query.</param>
            public CProperty(SerializedProperty parent, string name)
            {
                owner = new CObject(parent.serializedObject);
                this.parent = new CProperty(parent);
                property = this.parent.FindRaw(name);
                valid = property != null;
            }

            /// <summary>
            /// Create a CProperty object by finding the named property within the parent CProperty.<br></br><br></br>
            /// <see langword="CProperty.owner [READ-ONLY]:"/> This constructor variant creates a CObject to fill <b><i><see cref="owner"/></i></b> from the SerializedProperty.serializedObject property, which is a read-only value. <br></br>
            /// If you already have created a CObject for this SerializedObject, use that instead for better memory usage and to edit values within the owner through the CProperty.
            /// </summary>
            /// <param name="parent">Parent CProperty to find the named property in.</param>
            /// <param name="name">The name of the property to query.</param>
            public CProperty(CProperty parent, string name)
            {
                owner = new CObject(parent.Owner);
                this.parent = parent;
                property = parent.FindRaw(name);
                valid = property != null;
            }

            /// <summary>
            /// Create a CProperty object by finding the named property within the parent CProperty.<br></br><br></br>
            /// <see langword="CProperty.parent:"/> This constructor variant does not create parent information for this property. <br></br><br></br>
            /// </summary>
            /// <param name="owner">Parent CObject to find the child in.</param>
            /// <param name="name">The name of the property to query.</param>
            public CProperty(CObject owner, string name)
            {
                this.owner = owner;
                property = owner.FindRaw(name);
                valid = property != null;
            }

            /// <summary>
            /// Create a CProperty object by finding the named property within the parent CProperty.<br></br><br></br>
            /// <see langword="CProperty.parent:"/> This constructor variant does not create parent information for this property. <br></br><br></br>
            /// </summary>
            /// <param name="owner">Parent CObject to find the child in.</param>
            /// <param name="property">The property to be converted into a CProperty.</param>
            public CProperty(CObject owner, SerializedProperty property)
            {
                this.owner = owner;
                this.property = property;
                valid = property != null;
            }

            /// <summary>
            /// Create a CProperty object by finding the named property within the parent CProperty.<br></br><br></br>
            /// <see langword="Cappuccino:"/> This constructor variant creates parent and owner information for this property.
            /// </summary>
            /// <param name="owner">Owning CObject class for both the this CProperty and the parent CProperty.</param>
            /// <param name="parent">Parent CProperty to find the named property in.</param>
            /// <param name="name">The name of the property to query.</param>
            public CProperty(CObject owner, CProperty parent, string name)
            {
                this.owner = owner;
                this.parent = parent;
                property = parent.FindRaw(name);
                valid = property != null;
            }
            #endregion

            // Methods.

            /// <summary>
            /// Find a SerializedProperty within this CProperty.
            /// </summary>
            /// <param name="name">Serialized Property to find.</param>
            /// <returns></returns>
            public SerializedProperty FindRaw(string name)
            {
                return property.FindPropertyRelative(name);
            }

            /// <summary>
            /// Find a SerializedProperty within this CProperty, create and return a CProperty automatically.
            /// </summary>
            /// <param name="name">Serialized Property to find and create a CProperty for.</param>
            /// <returns></returns>
            public CProperty Find(string name)
            {
                return new CProperty(this, name);
            }

            #region Value-Related Methods

            /// <summary>
            /// Get or Set the value of the SerializedProperty without having to prefix the type (e.g. boolValue).  <br></br>
            /// If the CProperty is not valid, this will return <i><see langword="default(object)"/></i> or will not attempt to set the value.
            /// <br></br><br></br>
            /// <see langword="Cappuccino:"/> This requires that you have an <i><b>absolute</b></i> certainty of what the value's type is. <br></br>
            /// <i><see langword="If you are trying to change the value, you must use the exact type. This does not convert mismatched types. e.g. bool -> string"/></i> <br></br><br></br>
            /// If you want to get the value (as a string), use <see cref="valueString"/>. <br></br>
            /// If you want to get the value with error handling, use <i><b>CProperty.GetValue()</b></i>.<br></br>
            /// If you want to set the value with error handling, use <i><b>CProperty.SetValue()</b></i>.
            /// </summary>
            /// <returns></returns>
            public object Value
            {
                get
                {
                    if (!valid) { return default;  }
                    return property.propertyType switch
                    {
                        SerializedPropertyType.Boolean => property.boolValue,
                        SerializedPropertyType.Integer => property.intValue,
                        SerializedPropertyType.Float => property.floatValue,
                        SerializedPropertyType.String => property.stringValue,
                        SerializedPropertyType.Color => property.colorValue,
                        SerializedPropertyType.Vector2 => property.vector2Value,
                        SerializedPropertyType.Vector3 => property.vector3Value,
                        SerializedPropertyType.Vector4 => property.vector4Value,
                        SerializedPropertyType.Vector2Int => property.vector2IntValue,
                        SerializedPropertyType.Vector3Int => property.vector3IntValue,
                        SerializedPropertyType.Rect => property.rectValue,
                        SerializedPropertyType.RectInt => property.rectIntValue,
                        SerializedPropertyType.Bounds => property.boundsValue,
                        SerializedPropertyType.BoundsInt => property.boundsIntValue,
                        SerializedPropertyType.AnimationCurve => property.animationCurveValue,
                        SerializedPropertyType.Quaternion => property.quaternionValue,
                        SerializedPropertyType.Hash128 => property.hash128Value,
                        SerializedPropertyType.ManagedReference => property.managedReferenceValue,
                        SerializedPropertyType.ExposedReference => property.exposedReferenceValue,
                        SerializedPropertyType.ObjectReference => property.objectReferenceValue,
                        SerializedPropertyType.FixedBufferSize => property.fixedBufferSize,

                        // These could be accurate
                        SerializedPropertyType.Enum => property.intValue, // Issue with Enum is it could be int or uint. 
                        SerializedPropertyType.ArraySize => property.arraySize,
                        SerializedPropertyType.LayerMask => property.intValue,
                        SerializedPropertyType.Character => property.stringValue,

                        // These remaining properties are unhandleable right now as it's extremely hard to understand *what* accessible member they're actually pointing to.
                        SerializedPropertyType.Generic => default,
                        SerializedPropertyType.Gradient => default,
                        _ => throw new System.NotImplementedException()
                    };

                }
                set
                {
                    if (!valid) { return; }
                    switch (property.propertyType)
                    {
                        case SerializedPropertyType.Boolean:
                            property.boolValue = (bool)value;
                            break;

                        case SerializedPropertyType.Integer:
                            property.intValue = (int)value;
                            break;

                        case SerializedPropertyType.Float:
                            if (value.GetType() == typeof(float))
                            {
                                property.floatValue = (float)value;
                            }

                            if (value.GetType() == typeof(double))
                            {
                                property.doubleValue = (double)value;
                            }
                            break;

                        case SerializedPropertyType.String:
                            property.stringValue = (string)value;
                            break;

                        case SerializedPropertyType.Color:
                            property.colorValue = (Color)value;
                            break;

                        case SerializedPropertyType.Vector2:
                            property.vector2Value = (Vector2)value;
                            break;

                        case SerializedPropertyType.Vector3:
                            property.vector3Value = (Vector3)value;
                            break;

                        case SerializedPropertyType.Vector4:
                            property.vector4Value = (Vector4)value;
                            break;

                        case SerializedPropertyType.Vector2Int:
                            property.vector2IntValue = (Vector2Int)value;
                            break;

                        case SerializedPropertyType.Vector3Int:
                            property.vector3IntValue = (Vector3Int)value;
                            break;

                        case SerializedPropertyType.Rect:
                            property.rectValue = (Rect)value;
                            break;

                        case SerializedPropertyType.RectInt:
                            property.rectIntValue = (RectInt)value;
                            break;

                        case SerializedPropertyType.Bounds:
                            property.boundsValue = (Bounds)value;
                            break;

                        case SerializedPropertyType.BoundsInt:
                            property.boundsIntValue = (BoundsInt)value;
                            break;

                        case SerializedPropertyType.AnimationCurve:
                            property.animationCurveValue = (AnimationCurve)value;
                            break;

                        case SerializedPropertyType.Quaternion:
                            property.quaternionValue = (Quaternion)value;
                            break;

                        case SerializedPropertyType.Hash128:
                            property.hash128Value = (Hash128)value;
                            break;

                        case SerializedPropertyType.ManagedReference:
                            property.managedReferenceValue = value;
                            break;

                        case SerializedPropertyType.ExposedReference:
                            property.exposedReferenceValue = (UnityEngine.Object)value;
                            break;

                        case SerializedPropertyType.ObjectReference:
                            property.objectReferenceValue = (UnityEngine.Object)value;
                            break;

                        // Unity's documentation for this property says that if the enumerator is a uint-type enum, use .longValue to access it - otherwise use .intValue.
                        // going from 2021.3 -> 2023.1 documentation made it less clearer due to new property types added. If this doesn't work, my bad.
                        case SerializedPropertyType.Enum:
                            if (value.GetType() == typeof(uint))
                            {
                                property.longValue = (uint)value;
                            }
                            else
                            {
                                property.intValue = (int)value;
                            }
                            break;

                        case SerializedPropertyType.LayerMask:
                            property.intValue = (int)value;
                            break;

                        case SerializedPropertyType.Character:
                            property.stringValue = (string)value;
                            break;
                    }
                }
            }

            /// <summary>
            /// Try set the value of the SerializedProperty.<br></br>
            /// <see langword="Cappuccino:"/> This is an alternative to <b><i><see cref="Value"/></i></b>, though still an <b><see langword="unsafe"/></b> means of setting the Value of the SerializedProperty. <br></br>
            /// <i><see langword="If you are trying to change the value, you must use the exact type. This does not convert mismatched types. e.g. bool -> string"/></i> <br></br><br></br>
            /// If you do not want to use unsafe methods and you know the type, all SerializedProperty value types are provided with shorthand <see langword="get-set"/> variations. <br></br>
            /// - e.g. (<see cref="SerializedProperty.boolValue"/> > <see cref="Bool"/>)
            /// </summary>
            /// <param name="value">The value to try set the SerializedProperty underlying value to. </param>
            public void SetValueUnsafe(object value)
            {
                if (!valid)
                {
                    Debug.Log("[Cappuccino Notify] - The current CProperty you have tried to draw has been marked as invalid. \nProperty:" + path);
                    return;
                }

                switch (property.propertyType)
                {
                    case SerializedPropertyType.Boolean:
                        property.boolValue = (bool)value;
                        break;

                    case SerializedPropertyType.Integer:
                        property.intValue = (int)value;
                        break;

                    case SerializedPropertyType.Float:
                        if (value.GetType() == typeof(float))
                        {
                            property.floatValue = (float)value;
                        }

                        if (value.GetType() == typeof(double))
                        {
                            property.doubleValue = (double)value;
                        }
                        break;

                    case SerializedPropertyType.String:
                        property.stringValue = (string)value;
                        break;

                    case SerializedPropertyType.Color:
                        property.colorValue = (Color)value;
                        break;

                    case SerializedPropertyType.Vector2:
                        property.vector2Value = (Vector2)value;
                        break;

                    case SerializedPropertyType.Vector3:
                        property.vector3Value = (Vector3)value;
                        break;

                    case SerializedPropertyType.Vector4:
                        property.vector4Value = (Vector4)value;
                        break;

                    case SerializedPropertyType.Vector2Int:
                        property.vector2IntValue = (Vector2Int)value;
                        break;

                    case SerializedPropertyType.Vector3Int:
                        property.vector3IntValue = (Vector3Int)value;
                        break;

                    case SerializedPropertyType.Rect:
                        property.rectValue = (Rect)value;
                        break;

                    case SerializedPropertyType.RectInt:
                        property.rectIntValue = (RectInt)value;
                        break;

                    case SerializedPropertyType.Bounds:
                        property.boundsValue = (Bounds)value;
                        break;

                    case SerializedPropertyType.BoundsInt:
                        property.boundsIntValue = (BoundsInt)value;
                        break;

                    case SerializedPropertyType.AnimationCurve:
                        property.animationCurveValue = (AnimationCurve)value;
                        break;

                    case SerializedPropertyType.Quaternion:
                        property.quaternionValue = (Quaternion)value;
                        break;

                    case SerializedPropertyType.Hash128:
                        property.hash128Value = (Hash128)value;
                        break;

                    case SerializedPropertyType.ManagedReference:
                        property.managedReferenceValue = value;
                        break;

                    case SerializedPropertyType.ExposedReference:
                        property.exposedReferenceValue = (UnityEngine.Object)value;
                        break;

                    case SerializedPropertyType.ObjectReference:
                        property.objectReferenceValue = (UnityEngine.Object)value;
                        break;

                    // Unity's documentation for this property says that if the enumerator is a uint-type enum, use .longValue to access it - otherwise use .intValue.
                    // going from 2021.3 -> 2023.1 documentation made it less clearer due to new property types added. If this doesn't work, my bad.
                    case SerializedPropertyType.Enum:
                        if (value.GetType() == typeof(uint))
                        {
                            property.longValue = (uint)value;
                        }
                        else
                        {
                            property.intValue = (int)value;
                        }
                        break;

                    case SerializedPropertyType.LayerMask:
                        property.intValue = (int)value;
                        break;

                    case SerializedPropertyType.Character:
                        property.stringValue = (string)value;
                        break;
                }
            }

            /// <summary>
            /// Return a string conversion for the SerializedProperty's value. <br></br><br></br> 
            /// <see langword="Cappuccino:"/> This property does not use the runtime-resolving keyword dynamic nor does it use <seealso cref="value"/>.
            /// </summary>
            public string valueString
            {
                get
                {
                    return property.propertyType switch
                    {
                        SerializedPropertyType.Boolean => property.boolValue.ToString(),
                        SerializedPropertyType.Integer => property.intValue.ToString(),
                        SerializedPropertyType.Float => property.floatValue.ToString(),
                        SerializedPropertyType.String => property.stringValue,
                        SerializedPropertyType.Color => property.colorValue.ToString(),
                        SerializedPropertyType.Vector2 => property.vector2Value.ToString(),
                        SerializedPropertyType.Vector3 => property.vector3Value.ToString(),
                        SerializedPropertyType.Vector4 => property.vector4Value.ToString(),
                        SerializedPropertyType.Vector2Int => property.vector2IntValue.ToString(),
                        SerializedPropertyType.Vector3Int => property.vector3IntValue.ToString(),
                        SerializedPropertyType.Rect => property.rectValue.ToString(),
                        SerializedPropertyType.RectInt => property.rectIntValue.ToString(),
                        SerializedPropertyType.Bounds => property.boundsValue.ToString(),
                        SerializedPropertyType.BoundsInt => property.boundsIntValue.ToString(),
                        SerializedPropertyType.AnimationCurve => property.animationCurveValue.ToString(),
                        SerializedPropertyType.Quaternion => property.quaternionValue.ToString(),
                        SerializedPropertyType.Hash128 => property.hash128Value.ToString(),
                        SerializedPropertyType.ManagedReference => property.managedReferenceValue.ToString(),
                        SerializedPropertyType.ExposedReference => property.exposedReferenceValue.ToString(),
                        SerializedPropertyType.ObjectReference => property.objectReferenceValue.ToString(),
                        SerializedPropertyType.Enum => property.enumDisplayNames[property.enumValueIndex],
                        SerializedPropertyType.ArraySize => property.arraySize.ToString(),
                        SerializedPropertyType.LayerMask => property.intValue.ToString(),
                        SerializedPropertyType.Character => property.stringValue,
                        SerializedPropertyType.Generic => "Generic Type.",
                        SerializedPropertyType.Gradient => "Gradient currently not supported.",
                        SerializedPropertyType.FixedBufferSize => "FixedBufferSize currently not supported.",
                        _ => "Incompatible Type."
                    };
                }
            }

            #endregion

            #region CProperty Validation
            /// <summary>
            /// Mark the CProperty as invalid. <br></br><br></br>
            /// <see langword="Cappuccino:"/>This will prevent get-set methods for this CProperty's underlying value from working, until one is assigned. <br></br>
            /// <see langword="Notice:"/> Setting the underlying property using underlyingPropertyUnsafe sets the CProperty back to valid.
            /// </summary>
            public void Invalidate()
            {
                valid = false;
            }


            /// <summary>
            /// Mark the CProperty as valid. <br></br><br></br>
            /// <see langword="Cappuccino:"/>This will re-enable get-set methods for this CProperty's underlying value if the CProperty was invalid. <br></br>
            /// <b><i><see langword="Notice: If you use this on a CProperty that is invalid and not assigned a new underlying SerializedProperty, get-set calls will fail and error."/></i></b>
            /// </summary>
            public void Validate()
            {
                valid = true;
            }

            #endregion
        }
    }
}