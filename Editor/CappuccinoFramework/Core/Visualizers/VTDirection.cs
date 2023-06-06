using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This script adds the ability to draw a 2D Arrow protruding from a circle (representing the component's origin) to the Visualizer Toolkit.

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
            /// Draw a Visualizer that displays the direction the provided component's GameObject is facing.
            /// </summary>
            /// <param name="component">The component to draw the visualizer for.</param>
            public static void Direction(Component component)
            {
                Transform tr = component.transform;

                Gizmos.color = Color.blue;
                GT.DrawArrow2D(tr.position, tr.position + tr.forward, 45f, 1f, 1f);
                Gizmos.DrawWireSphere(tr.position, 1f);
            }

            /// <summary>
            /// Draw a Visualizer that displays the direction the provided component's GameObject is facing.
            /// </summary>
            /// <param name="component">The component to draw the visualizer for.</param>
            /// <param name="gizmoColor">The color to draw the underlying gizmos with.</param>
            public static void Direction(Component component, Color gizmoColor)
            {
                Transform tr = component.transform;

                Gizmos.color = gizmoColor;
                GT.DrawArrow2D(tr.position, tr.position + tr.forward, 45f, 1f, 1f);
                Gizmos.DrawWireSphere(tr.position, 1f);
            }

            /// <summary>
            /// Draw a Visualizer that displays the direction the provided component's GameObject is facing.
            /// </summary>
            /// <param name="component">The component to draw the visualizer for.</param>
            /// <param name="gizmoColor">The color to draw the underlying gizmos with.</param>
            /// <param name="sphereSize">The size of the sphere.</param>
            public static void Direction(Component component, Color gizmoColor, float sphereSize)
            {
                Transform tr = component.transform;

                Gizmos.color = gizmoColor;
                GT.DrawArrow2D(tr.position + (tr.forward * sphereSize), tr.position + tr.forward, 45f, 1f, 1f);
                Gizmos.DrawWireSphere(tr.position, sphereSize);
            }

            /// <summary>
            /// Draw a Visualizer that displays the direction the provided component's GameObject is facing.
            /// </summary>
            /// <param name="component">The component to draw the visualizer for.</param>
            /// <param name="gizmoColor">The color to draw the underlying gizmos with.</param>
            /// <param name="sphereSize">The size of the sphere.</param>
            /// <param name="arrowheadAngle">The angle of the arrowhead to draw.</param>
            public static void Direction(Component component, Color gizmoColor, float sphereSize, float arrowheadAngle)
            {
                Transform tr = component.transform;

                Gizmos.color = gizmoColor;
                GT.DrawArrow2D(tr.position + (tr.forward * sphereSize), tr.position + tr.forward, arrowheadAngle, 1f, 1f);
                Gizmos.DrawWireSphere(tr.position, sphereSize);
            }

            /// <summary>
            /// Draw a Visualizer that displays the direction the provided component's GameObject is facing.
            /// </summary>
            /// <param name="component">The component to draw the visualizer for.</param>
            /// <param name="gizmoColor">The color to draw the underlying gizmos with.</param>
            /// <param name="sphereSize">The size of the sphere.</param>
            /// <param name="arrowheadAngle">The angle of the arrowhead to draw.</param>
            /// <param name="arrowDistance">The distance multiplier that the end arrow's direction should be modified.</param>
            public static void Direction(Component component, Color gizmoColor, float sphereSize, float arrowheadAngle, float arrowDistance)
            {
                Transform tr = component.transform;

                Gizmos.color = gizmoColor;
                GT.DrawArrow2D(tr.position + (tr.forward * sphereSize), tr.position + tr.forward, arrowheadAngle, arrowDistance, 1f);
                Gizmos.DrawWireSphere(tr.position, sphereSize);
            }

            /// <summary>
            /// Draw a Visualizer that displays the direction the provided component's GameObject is facing.
            /// </summary>
            /// <param name="component">The component to draw the visualizer for.</param>
            /// <param name="gizmoColor">The color to draw the underlying gizmos with.</param>
            /// <param name="sphereSize">The size of the sphere.</param>
            /// <param name="arrowheadAngle">The angle of the arrowhead to draw.</param>
            /// <param name="arrowDistance">The distance multiplier that the end arrow's direction should be modified.</param>
            /// <param name="arrowheadLength">The length of the arrowhead arms from the end point.</param>
            public static void Direction(Component component, Color gizmoColor, float sphereSize, float arrowheadAngle, float arrowDistance, float arrowheadLength)
            {
                Transform tr = component.transform;

                Gizmos.color = gizmoColor;
                GT.DrawArrow2D(tr.position + (tr.forward * sphereSize), tr.position + tr.forward, arrowheadAngle, arrowDistance, arrowheadLength);
                Gizmos.DrawWireSphere(tr.position, sphereSize);
            }
            
            /// <summary>
            /// Draw a Visualizer that displays the direction the provided component's GameObject is facing.
            /// </summary>
            /// <param name="start">The position to draw the visualiser at.</param>
            /// <param name="direction">The direction for the visualiser to face</param>
            public static void Direction(Vector3 start, Vector3 direction)
            {
                Gizmos.color = Color.blue;
                GT.DrawArrow2D(start, direction, 45f, 1f, 1f);
                Gizmos.DrawWireSphere(start, 1f);
            }

            /// <summary>
            /// Draw a Visualizer that displays the direction the provided component's GameObject is facing.
            /// </summary>
            /// <param name="start">The position to draw the visualiser at.</param>
            /// <param name="direction">The direction for the visualiser to face</param>
            /// <param name="gizmoColor">The color to draw the underlying gizmos with.</param>
            public static void Direction(Vector3 start, Vector3 direction, Color gizmoColor)
            {
                Gizmos.color = gizmoColor;
                GT.DrawArrow2D(start, direction, 45f, 1f, 1f);
                Gizmos.DrawWireSphere(start, 1f);
            }

            /// <summary>
            /// Draw a Visualizer that displays the direction the provided component's GameObject is facing.
            /// </summary>
            /// <param name="start">The position to draw the visualiser at.</param>
            /// <param name="direction">The direction for the visualiser to face</param>
            /// <param name="gizmoColor">The color to draw the underlying gizmos with.</param>
            /// <param name="sphereSize">The size of the sphere.</param>
            public static void Direction(Vector3 start, Vector3 direction, Color gizmoColor, float sphereSize)
            {
                Gizmos.color = gizmoColor;
                GT.DrawArrow2D(start + (direction * sphereSize), start + direction, 45f, 1f, 1f);
                Gizmos.DrawWireSphere(start, sphereSize);
            }

            /// <summary>
            /// Draw a Visualizer that displays the direction the provided component's GameObject is facing.
            /// </summary>
            /// <param name="start">The position to draw the visualiser at.</param>
            /// <param name="direction">The direction for the visualiser to face</param>
            /// <param name="gizmoColor">The color to draw the underlying gizmos with.</param>
            /// <param name="sphereSize">The size of the sphere.</param>
            /// <param name="arrowheadAngle">The angle of the arrowhead to draw.</param>
            public static void Direction(Vector3 start, Vector3 direction, Color gizmoColor, float sphereSize, float arrowheadAngle)
            {
                Gizmos.color = gizmoColor;
                GT.DrawArrow2D(start + (direction * sphereSize), start + direction, arrowheadAngle, 1f, 1f);
                Gizmos.DrawWireSphere(start, sphereSize);
            }

            /// <summary>
            /// Draw a Visualizer that displays the direction the provided component's GameObject is facing.
            /// </summary>
            /// <param name="start">The position to draw the visualiser at.</param>
            /// <param name="direction">The direction for the visualiser to face</param>
            /// <param name="gizmoColor">The color to draw the underlying gizmos with.</param>
            /// <param name="sphereSize">The size of the sphere.</param>
            /// <param name="arrowheadAngle">The angle of the arrowhead to draw.</param>
            /// <param name="arrowDistance">The distance multiplier that the end arrow's direction should be modified.</param>
            public static void Direction(Vector3 start, Vector3 direction, Color gizmoColor, float sphereSize, float arrowheadAngle, float arrowDistance)
            {
                Gizmos.color = gizmoColor;
                GT.DrawArrow2D(start + (direction * sphereSize), start + direction, arrowheadAngle, arrowDistance, 1f);
                Gizmos.DrawWireSphere(start, sphereSize);
            }

            /// <summary>
            /// Draw a Visualizer that displays the direction the provided component's GameObject is facing.
            /// </summary>
            /// <param name="start">The position to draw the visualiser at.</param>
            /// <param name="direction">The direction for the visualiser to face</param>
            /// <param name="gizmoColor">The color to draw the underlying gizmos with.</param>
            /// <param name="sphereSize">The size of the sphere.</param>
            /// <param name="arrowheadAngle">The angle of the arrowhead to draw.</param>
            /// <param name="arrowDistance">The distance multiplier that the end arrow's direction should be modified.</param>
            /// <param name="arrowheadLength">The length of the arrowhead arms from the end point.</param>
            public static void Direction(Vector3 start, Vector3 direction, Color gizmoColor, float sphereSize, float arrowheadAngle, float arrowDistance, float arrowheadLength)
            {
                Gizmos.color = gizmoColor;
                GT.DrawArrow2D(start + (direction * sphereSize), start + direction, arrowheadAngle, arrowDistance, arrowheadLength);
                Gizmos.DrawWireSphere(start, sphereSize);
            }
        }
    }
}