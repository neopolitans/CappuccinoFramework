using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This script adds the ability to draw a solo 3D Arrow to the Visualizer Toolkit.
// Shorthand for GizmoUtilities > DrawArrow3D.cs

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> This static class is the Visualizer Toolkit. It contains common Gizmo Drawing methods for Editors. <br></br>
        /// For use with the Unity Attribute <i><b>DrawGizmo</b></i>. <br></br><br></br>
        /// <b><see langword="Notice:"/></b> Any methods trying to use [DrawGizmo(GizmoType)] must be a static method and must include two parameters. One of the targeted component type and one of GizmoType.<br></br>
        /// See: <see href="https://docs.unity3d.com/ScriptReference/DrawGizmo.html"/>
        /// </summary>
        public static partial class VT
        {
            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a 3D Arrow.
            /// </summary>
            /// <param name="start">The start position of the arrow.</param>
            /// <param name="end">The end position of the arrow.</param>
            public static void Arrow3D(Vector3 start, Vector3 end)
            {
                GT.DrawArrow3D(start, end, 30f, 3f, 0.5f);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a 3D Arrow.
            /// </summary>
            /// <param name="start">The start position of the arrow.</param>
            /// <param name="end">The end position of the arrow.</param>
            /// <param name="arrowheadAngle">The angle that the arrowhead arms are drawn with.</param>
            public static void Arrow3D(Vector3 start, Vector3 end, float arrowheadAngle)
            {
                GT.DrawArrow3D(start, end, arrowheadAngle, 3f, 0.5f);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a 3D Arrow.
            /// </summary>
            /// <param name="start">The start position of the arrow.</param>
            /// <param name="end">The end position of the arrow.</param>
            /// <param name="arrowheadAngle">The angle that the arrowhead arms are drawn with.</param>
            /// <param name="arrowheadDistance">The distance from the start that the end point is multiplied by.</param>
            public static void Arrow3D(Vector3 start, Vector3 end, float arrowheadAngle, float arrowheadDistance)
            {
                GT.DrawArrow3D(start, end, arrowheadAngle, arrowheadDistance, 0.5f);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a 3D Arrow.
            /// </summary>
            /// <param name="start">The start position of the arrow.</param>
            /// <param name="end">The end position of the arrow.</param>
            /// <param name="arrowheadAngle">The angle that the arrowhead arms are drawn with.</param>
            /// <param name="arrowheadDistance">The distance from the start that the end point is multiplied by.</param>
            /// <param name="arrowheadLength">The length of the arrowhead arms.</param>
            public static void Arrow3D(Vector3 start, Vector3 end, float arrowheadAngle, float arrowheadDistance, float arrowheadLength)
            {
                GT.DrawArrow3D(start, end, arrowheadAngle, arrowheadDistance, arrowheadLength);
            }
        }
    }
}
