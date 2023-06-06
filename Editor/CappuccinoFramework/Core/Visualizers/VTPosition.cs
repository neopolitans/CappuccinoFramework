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
            /// <see langword="Cappuccino:"/> Draw a Position gizmo for the provided component to view the direction of all axes.
            /// </summary>
            /// <param name="component">The component to draw a position gizmo for.</param>
            public static void Position(Component component)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(component.transform.position, component.transform.position + component.transform.forward);

                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(component.transform.position, component.transform.position + component.transform.up);

                Gizmos.color = Color.red;
                Gizmos.DrawLine(component.transform.position, component.transform.position + component.transform.right);
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a Position gizmo for the provided component to view the direction of all axes.
            /// </summary>
            /// <param name="component">The component to draw a position gizmo for.</param>
            /// <param name="magnitude">The size of the lines to draw. <br></br> <b>1.0</b> being a normal line.</param>
            public static void Position(Component component, float magnitude)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(component.transform.position, component.transform.position + (component.transform.forward * magnitude));

                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(component.transform.position, component.transform.position + (component.transform.up * magnitude));

                Gizmos.color = Color.red;
                Gizmos.DrawLine(component.transform.position, component.transform.position + (component.transform.right * magnitude));
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a Position gizmo for the provided component to view the direction of all axes.
            /// </summary>
            /// <param name="component">The component to draw a position gizmo for.</param>
            /// <param name="magnitude">The size of the lines to draw. <br></br> <b>1.0</b> being a normal line.</param>
            /// <param name="forward"> The color to draw the forward axis with.</param>
            /// <param name="up"> The color to draw the up axis with.</param>
            /// <param name="right"> The color to draw the right axis with.</param>
            public static void Position(Component component, float magnitude, Color forward, Color up, Color right)
            {
                Handles.color = forward;
                Handles.DrawLine(component.transform.position, component.transform.position + (component.transform.forward * magnitude));

                Handles.color = up;
                Handles.DrawLine(component.transform.position, component.transform.position + (component.transform.up * magnitude));

                Handles.color = right;
                Handles.DrawLine(component.transform.position, component.transform.position + (component.transform.right * magnitude));
            }
        }
    }
}