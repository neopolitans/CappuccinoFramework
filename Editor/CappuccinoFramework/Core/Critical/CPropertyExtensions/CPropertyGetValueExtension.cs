using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This Extension Script adds an optional counterpart to SetValue called GetValue.
// GetValue always returns bool and uses <out type typeName> to.

// Note: This isn't genercized with <T> due to needing comparisons between SerializedPropertyTypes and specifically defined outputs.
//       Feel free to take a crack at a Genericized variant yourself!

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
            /// Get the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Outputs a boolean to the reference variable. Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="boolValue">The reference to the variable to output the value into.</param>
            /// <returns></returns>
            public bool GetValue(out bool boolValue)
            {
                if (property.propertyType == SerializedPropertyType.Boolean)
                {
                    boolValue = property.boolValue;
                    return true;
                }
                else
                {
                    boolValue = default(bool);
                    return false;
                }
            }

            /// <summary>
            /// Get the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Outputs an int to the reference variable. Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="intValue">The reference to the variable to output the value into.</param>
            /// <returns></returns>
            public bool GetValue(out int intValue)
            {
                if (property.propertyType == SerializedPropertyType.Integer || property.propertyType == SerializedPropertyType.Enum || property.propertyType == SerializedPropertyType.LayerMask)
                {
                    intValue = property.intValue;
                    return true;
                }
                else
                {
                    intValue = default(int);
                    return false;
                }
            }

            /// <summary>
            /// Get the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Outputs a float to the reference variable. Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="floatValue">The reference to the variable to output the value into.</param>
            /// <returns></returns>
            public bool GetValue(out float floatValue)
            {
                if (property.propertyType == SerializedPropertyType.Float)
                {
                    floatValue = property.floatValue;
                    return true;
                }
                else
                {
                    floatValue = default(float);
                    return false;
                }
            }

            /// <summary>
            /// Get the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Outputs a double to the reference variable. Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="doubleValue">The reference to the variable to output the value into.</param>
            /// <returns></returns>
            public bool GetValue(out double doubleValue)
            {
                if (property.propertyType == SerializedPropertyType.Float)
                {
                    doubleValue = property.doubleValue;
                    return true;
                }
                else
                {
                    doubleValue = default(double);
                    return false;
                }
            }

            /// <summary>
            /// Get the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Outputs a long int to the reference variable. Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="longValue">The reference to the variable to output the value into.</param>
            /// <returns></returns>
            public bool GetValue(out long longValue)
            {
                if (property.propertyType == SerializedPropertyType.Integer)
                {
                    longValue = property.longValue;
                    return true;
                }
                else
                {
                    longValue = default(long);
                    return false;
                }
            }

            /// <summary>
            /// Get the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Outputs a string to the reference variable. Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="stringValue">The reference to the variable to output the value into.</param>
            /// <returns></returns>
            public bool GetValue(out string stringValue)
            {
                if (property.propertyType == SerializedPropertyType.String)
                {
                    stringValue = property.stringValue;
                    return true;
                }
                else
                {
                    stringValue = default(string);
                    return false;
                }
            }

            /// <summary>
            /// Get the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Outputs a Vector2 to the reference variable. Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="vector2Value">The reference to the variable to output the value into.</param>
            /// <returns></returns>
            public bool GetValue(out Vector2 vector2Value)
            {
                if (property.propertyType == SerializedPropertyType.Vector2)
                {
                    vector2Value = property.vector2Value;
                    return true;
                }
                else
                {
                    vector2Value = default(Vector2);
                    return false;
                }
            }

            /// <summary>
            /// Get the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Outputs a Vector2Int to the reference variable. Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="vector2IntValue">The reference to the variable to output the value into.</param>
            /// <returns></returns>
            public bool GetValue(out Vector2Int vector2IntValue)
            {
                if (property.propertyType == SerializedPropertyType.Vector2Int)
                {
                    vector2IntValue = property.vector2IntValue;
                    return true;
                }
                else
                {
                    vector2IntValue = default(Vector2Int);
                    return false;
                }
            }

            /// <summary>
            /// Get the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Outputs a Vector3 to the reference variable. Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="vector3Value">The reference to the variable to output the value into.</param>
            /// <returns></returns>
            public bool GetValue(out Vector3 vector3Value)
            {
                if (property.propertyType == SerializedPropertyType.Vector3)
                {
                    vector3Value = property.vector3Value;
                    return true;
                }
                else
                {
                    vector3Value = default(Vector3);
                    return false;
                }
            }

            /// <summary>
            /// Get the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Outputs a Vector3Int to the reference variable. Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="vector3IntValue">The reference to the variable to output the value into.</param>
            /// <returns></returns>
            public bool GetValue(out Vector3Int vector3IntValue)
            {
                if (property.propertyType == SerializedPropertyType.Vector3Int)
                {
                    vector3IntValue = property.vector3IntValue;
                    return true;
                }
                else
                {
                    vector3IntValue = default(Vector3Int);
                    return false;
                }
            }

            /// <summary>
            /// Get the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Outputs a Vector4 to the reference variable. Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="vector4Value">The reference to the variable to output the value into.</param>
            /// <returns></returns>
            public bool GetValue(out Vector4 vector4Value)
            {
                if (property.propertyType == SerializedPropertyType.Vector3)
                {
                    vector4Value = property.vector4Value;
                    return true;
                }
                else
                {
                    vector4Value = default(Vector4);
                    return false;
                }
            }

            /// <summary>
            /// Get the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Outputs a Rect to the reference variable. Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="rectValue">The reference to the variable to output the value into.</param>
            /// <returns></returns>
            public bool GetValue(out Rect rectValue)
            {
                if (property.propertyType == SerializedPropertyType.Rect)
                {
                    rectValue = property.rectValue;
                    return true;
                }
                else
                {
                    rectValue = default(Rect);
                    return false;
                }
            }

            /// <summary>
            /// Get the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Outputs a RectInt to the reference variable. Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="rectIntValue">The reference to the variable to output the value into.</param>
            /// <returns></returns>
            public bool GetValue(out RectInt rectIntValue)
            {
                if (property.propertyType == SerializedPropertyType.RectInt)
                {
                    rectIntValue = property.rectIntValue;
                    return true;
                }
                else
                {
                    rectIntValue = default(RectInt);
                    return false;
                }
            }

            /// <summary>
            /// Get the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Outputs a Bounds to the reference variable. Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="boundsValue">The reference to the variable to output the value into.</param>
            /// <returns></returns>
            public bool GetValue(out Bounds boundsValue)
            {
                if (property.propertyType == SerializedPropertyType.Bounds)
                {
                    boundsValue = property.boundsValue;
                    return true;
                }
                else
                {
                    boundsValue = default(Bounds);
                    return false;
                }
            }

            /// <summary>
            /// Get the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Outputs a BoundsInt to the reference variable. Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="boundsIntValue">The reference to the variable to output the value into.</param>
            /// <returns></returns>
            public bool GetValue(out BoundsInt boundsIntValue)
            {
                if (property.propertyType == SerializedPropertyType.BoundsInt)
                {
                    boundsIntValue = property.boundsIntValue;
                    return true;
                }
                else
                {
                    boundsIntValue = default(BoundsInt);
                    return false;
                }
            }

            /// <summary>
            /// Get the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Outputs a Quaternion to the reference variable. Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="quaternionValue">The reference to the variable to output the value into.</param>
            /// <returns></returns>
            public bool GetValue(out Quaternion quaternionValue)
            {
                if (property.propertyType == SerializedPropertyType.Quaternion)
                {
                    quaternionValue = property.quaternionValue;
                    return true;
                }
                else
                {
                    quaternionValue = default(Quaternion);
                    return false;
                }
            }

            /// <summary>
            /// Get the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Outputs an AnimationCurve to the reference variable. Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="animationCurveValue">The reference to the variable to output the value into.</param>
            /// <returns></returns>
            public bool GetValue(out AnimationCurve animationCurveValue)
            {
                if (property.propertyType == SerializedPropertyType.AnimationCurve)
                {
                    animationCurveValue = property.animationCurveValue;
                    return true;
                }
                else
                {
                    animationCurveValue = default(AnimationCurve);
                    return false;
                }
            }

            /// <summary>
            /// Get the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Outputs a Hash128 to the reference variable. Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="hash128Value">The reference to the variable to output the value into.</param>
            /// <returns></returns>
            public bool GetValue(out Hash128 hash128Value)
            {
                if (property.propertyType == SerializedPropertyType.Hash128)
                {
                    hash128Value = property.hash128Value;
                    return true;
                }
                else
                {
                    hash128Value = default(Hash128);
                    return false;
                }
            }

            /// <summary>
            /// Get the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Outputs a Color to the reference variable. Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="colorValue">The reference to the variable to output the value into.</param>
            /// <returns></returns>
            public bool GetValue(out Color colorValue)
            {
                if (property.propertyType == SerializedPropertyType.Color)
                {
                    colorValue = property.colorValue;
                    return true;
                }
                else
                {
                    colorValue = default(Color);
                    return false;
                }
            }

            /// <summary>
            /// Get the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Outputs an Object representing the Object Reference Value to the reference variable. Returns true if the property is the matching type or false otherwise.<br></br><br></br>
            /// For ExposedReferenceValue, add <b><see langword="true"/></b> after the output reference variable.
            /// </summary>
            /// <param name="objectValue">The reference to the variable to output the value into.</param>
            /// <returns></returns>
            public bool GetValue(out UnityEngine.Object objectValue)
            {
                if (property.propertyType == SerializedPropertyType.ObjectReference)
                {
                    objectValue = property.objectReferenceValue;
                    return true;
                }
                else
                {
                    objectValue = default(Object);
                    return false;
                }
            }

            /// <summary>
            /// Get the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Outputs an Object representing the Object Reference Value (or Exposed Reference Value) to the reference variable. Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="objectValue">The reference to the variable to output the value into.</param>
            /// <param name="getExposed">Return the ExposedReferenceValue instead of the ObjectReferenceValue</param>
            /// <returns></returns>
            public bool GetValue(out UnityEngine.Object objectValue, bool getExposed)
            {
                if (property.propertyType == SerializedPropertyType.ObjectReference)
                {
                    objectValue = getExposed ? property.exposedReferenceValue : property.objectReferenceValue;
                    return true;
                }
                else
                {
                    objectValue = default(Object);
                    return false;
                }
            }

        }
    }
}