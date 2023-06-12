using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This Extension Script adds the Shorthands for accessing a specific value type in the CProperty's attached SerializedProperty.
// This Extension is used internally by Cappuccino.CProperty.

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> This class abstracts some of the minutia and nomenclature issues that Unity has in the <seealso cref="UnityEditor.SerializedProperty"/> object class.
        /// </summary>
        public partial class CProperty
        {
            #region Value Properties
            // These are simplified abstractions from just "<type>Value"

            // - Basic Values
            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.boolValue;
            /// </summary>
            public bool Bool
            {
                get { return property.boolValue; }
                set { property.boolValue = value; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.intValue;
            /// </summary>
            public int Int
            {
                get { return property.intValue; }
                set { property.intValue = value; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.floatValue;
            /// </summary>
            public float Float
            {
                get { return property.floatValue; }
                set { property.floatValue = value; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.doubleValue;
            /// </summary>
            public double Double
            {
                get { return property.doubleValue; }
                set { property.doubleValue = value; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.longValue;
            /// </summary>
            public long Long
            {
                get { return property.longValue; }
                set { property.longValue = value; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.longValue;
            /// </summary>
            public string String
            {
                get { return property.stringValue; }
                set { property.stringValue = value; }
            }

            // - Vector Values

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.vector2Value;
            /// </summary>
            public Vector2 Vec2
            {
                get { return property.vector2Value; }
                set { property.vector2Value = value; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.vector2IntValue;
            /// </summary>
            public Vector2Int Vec2I
            {
                get { return property.vector2IntValue; }
                set { property.vector2IntValue = value; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.vector3Value;
            /// </summary>
            public Vector3 Vec3
            {
                get { return property.vector3Value; }
                set { property.vector3Value = value; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.vector3IntValue;
            /// </summary>
            public Vector3Int Vec3I
            {
                get { return property.vector3IntValue; }
                set { property.vector3IntValue = value; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.vector4Value;
            /// </summary>
            public Vector4 Vec4
            {
                get { return property.vector4Value; }
                set { property.vector4Value = value; }
            }

            // - Rect Values
            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.rectValue;
            /// </summary>
            public Rect Rect
            {
                get { return property.rectValue; }
                set { property.rectValue = value; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.rectIntValue;
            /// </summary>
            public RectInt RectI
            {
                get { return property.rectIntValue; }
                set { property.rectIntValue = value; }
            }

            // - Bounds Values
            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.boundsValue;
            /// </summary>
            public Bounds Bounds
            {
                get { return property.boundsValue; }
                set { property.boundsValue = value; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.boundsIntValue;
            /// </summary>
            public BoundsInt BoundsI
            {
                get { return property.boundsIntValue; }
                set { property.boundsIntValue = value; }
            }

            // - Enum Value Types

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.enumValueFlag;
            /// </summary>
            public int EnumFlag
            {
                get { return property.enumValueFlag; }
                set { property.enumValueFlag = value; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.enumValueIndex;
            /// </summary>
            public int EnumIndex
            {
                get { return property.enumValueIndex; }
                set { property.enumValueIndex = value; }
            }

            // - Quaternion Value Types
            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.quaternionValue;
            /// </summary>
            public Quaternion Quaternion
            {
                get { return property.quaternionValue; }
                set { property.quaternionValue = value; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Alternative Shorthand for SerializedProperty.quaternionValue;
            /// </summary>
            public Quaternion Qt
            {
                get { return property.quaternionValue; }
                set { property.quaternionValue = value; }
            }

            // - Other Value Types

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.animationCurveValue;
            /// </summary>
            public AnimationCurve AnimCurve
            {
                get { return property.animationCurveValue; }
                set { property.animationCurveValue = value; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.hash128Value;
            /// </summary>
            public Hash128 Hash
            {
                get { return property.hash128Value; }
                set { property.hash128Value = value; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.colorValue;
            /// </summary>
            public Color Color
            {
                get { return property.colorValue; }
                set { property.colorValue = value; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.objectReferenceValue;
            /// </summary>
            public UnityEngine.Object ObjectRef
            {
                get { return property.objectReferenceValue; }
                set { property.objectReferenceValue = value; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.exposedReferenceValue;
            /// </summary>
            public UnityEngine.Object ExposedRef
            {
                get { return property.exposedReferenceValue; }
                set { property.exposedReferenceValue = value; }
            }

            // - Managed Ref

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.managedReferenceValue;
            /// </summary>
            public object ManagedRef
            {
                get { return property.managedReferenceValue; }
                set { property.managedReferenceValue = value; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.managedReferenceId;
            /// </summary>
            public long ManagedId
            {
                get { return property.managedReferenceId; }
                set { property.managedReferenceId = value; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.managedReferenceFieldTypename;
            /// </summary>
            public string ManagedFieldName
            {
                get { return property.managedReferenceFieldTypename; }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for SerializedProperty.managedReferenceFullTypename;
            /// </summary>
            public string ManagedFullName
            {
                get { return property.managedReferenceFullTypename; }
            }
            #endregion
        }
    }
}