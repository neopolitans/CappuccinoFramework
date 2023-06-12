using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This Extension Script adds Safe alternatives to the generic-oriented SetValue contained in the main CProperty script.

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
            /// Set the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="boolValue">The value to set the SerialziedProperty's value to.</param>
            /// <returns></returns>
            public bool SetValue(bool boolValue)
            {
                if (valid && property.propertyType == SerializedPropertyType.Boolean)
                {
                    property.boolValue = boolValue;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Set the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="intValue">The value to set the SerialziedProperty's value to.</param>
            /// <returns></returns>
            public bool SetValue(int intValue)
            {
                if (valid && property.propertyType == SerializedPropertyType.Integer)
                {
                    property.intValue = intValue;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Set the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="floatValue">The value to set the SerialziedProperty's value to.</param>
            /// <returns></returns>
            public bool SetValue(float floatValue)
            {
                if (valid && property.propertyType == SerializedPropertyType.Float)
                {
                    property.floatValue = floatValue;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Set the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="doubleValue">The value to set the SerialziedProperty's value to.</param>
            /// <returns></returns>
            public bool SetValue(double doubleValue)
            {
                if (valid && property.propertyType == SerializedPropertyType.Float)
                {
                    property.doubleValue = doubleValue;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Set the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="longValue">The value to set the SerialziedProperty's value to.</param>
            /// <returns></returns>
            public bool SetValue(long longValue)
            {
                if (valid && property.propertyType == SerializedPropertyType.Integer)
                {
                    property.longValue = longValue;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Set the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="stringValue">The value to set the SerialziedProperty's value to.</param>
            /// <returns></returns>
            public bool SetValue(string stringValue)
            {
                if (valid && property.propertyType == SerializedPropertyType.String)
                {
                    property.stringValue = stringValue;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Set the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="vector2Value">The value to set the SerialziedProperty's value to.</param>
            /// <returns></returns>
            public bool SetValue(Vector2 vector2Value)
            {
                if (valid && property.propertyType == SerializedPropertyType.Vector2)
                {
                    property.vector2Value = vector2Value;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Set the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="vector2IntValue">The value to set the SerialziedProperty's value to.</param>
            /// <returns></returns>
            public bool SetValue(Vector2Int vector2IntValue)
            {
                if (valid && property.propertyType == SerializedPropertyType.Vector2Int)
                {
                    property.vector2IntValue = vector2IntValue;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Set the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="vector3Value">The value to set the SerialziedProperty's value to.</param>
            /// <returns></returns>
            public bool SetValue(Vector3 vector3Value)
            {
                if (valid && property.propertyType == SerializedPropertyType.Vector3)
                {
                    property.vector3Value = vector3Value;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Set the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="vector3IntValue">The value to set the SerialziedProperty's value to.</param>
            /// <returns></returns>
            public bool SetValue(Vector3Int vector3IntValue)
            {
                if (valid && property.propertyType == SerializedPropertyType.Vector3Int)
                {
                    property.vector3IntValue = vector3IntValue;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Set the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="vector4Value">The value to set the SerialziedProperty's value to.</param>
            /// <returns></returns>
            public bool SetValue(Vector4 vector4Value)
            {
                if (valid && property.propertyType == SerializedPropertyType.Vector3)
                {
                    property.vector4Value = vector4Value;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Set the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="rectValue">The value to set the SerialziedProperty's value to.</param>
            /// <returns></returns>
            public bool SetValue(Rect rectValue)
            {
                if (valid && property.propertyType == SerializedPropertyType.Rect)
                {
                    property.rectValue = rectValue;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Set the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="rectIntValue">The value to set the SerialziedProperty's value to.</param>
            /// <returns></returns>
            public bool SetValue(RectInt rectIntValue)
            {
                if (valid && property.propertyType == SerializedPropertyType.RectInt)
                {
                    property.rectIntValue = rectIntValue;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Set the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="boundsValue">The value to set the SerialziedProperty's value to.</param>
            /// <returns></returns>
            public bool SetValue(Bounds boundsValue)
            {
                if (valid && property.propertyType == SerializedPropertyType.Bounds)
                {
                    property.boundsValue = boundsValue;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Set the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="boundsIntValue">The value to set the SerialziedProperty's value to.</param>
            /// <returns></returns>
            public bool SetValue(BoundsInt boundsIntValue)
            {
                if (valid && property.propertyType == SerializedPropertyType.BoundsInt)
                {
                    property.boundsIntValue = boundsIntValue;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Set the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="quaternionValue">The value to set the SerialziedProperty's value to.</param>
            /// <returns></returns>
            public bool SetValue(Quaternion quaternionValue)
            {
                if (valid && property.propertyType == SerializedPropertyType.Quaternion)
                {
                    property.quaternionValue = quaternionValue;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Set the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="animationCurveValue">The value to set the SerialziedProperty's value to.</param>
            /// <returns></returns>
            public bool SetValue(AnimationCurve animationCurveValue)
            {
                if (valid && property.propertyType == SerializedPropertyType.AnimationCurve)
                {
                    property.animationCurveValue = animationCurveValue;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Set the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="hash128Value">The value to set the SerialziedProperty's value to.</param>
            /// <returns></returns>
            public bool SetValue(Hash128 hash128Value)
            {
                if (valid && property.propertyType == SerializedPropertyType.Hash128)
                {
                    property.hash128Value = hash128Value;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Set the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="colorValue">The value to set the SerialziedProperty's value to.</param>
            /// <returns></returns>
            public bool SetValue(Color colorValue)
            {
                if (valid && property.propertyType == SerializedPropertyType.Color)
                {
                    property.colorValue = colorValue;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Set the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="objectValue">The value to set the SerialziedProperty's value to.</param>
            /// <returns></returns>
            public bool SetValue(UnityEngine.Object objectValue)
            {
                if (valid && property.propertyType == SerializedPropertyType.ObjectReference)
                {
                    property.objectReferenceValue = objectValue;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Set the underlying value of the SerializedProperty. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Returns true if the property is the matching type or false otherwise.
            /// </summary>
            /// <param name="objectValue">The value to set the SerialziedProperty's value to.</param>
            /// <param name="getExposed">Set the ExposedReferenceValue instead of the ObjectReferenceValue</param>
            /// <returns></returns>
            public bool SetValue(UnityEngine.Object objectValue, bool getExposed)
            {
                if (valid && property.propertyType == SerializedPropertyType.ObjectReference)
                {
                    if (getExposed)
                    {
                        property.exposedReferenceValue = objectValue;
                    }
                    else
                    {
                        property.objectReferenceValue = objectValue;
                    }
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