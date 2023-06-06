using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This script adds the ability to draw outlines when provided a list of vertices to the Visualizer Toolkit.

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
            /// Draw the outline with the provided vertices.
            /// </summary>
            /// <param name="vertices">The vertices to draw.</param>
            /// <param name="drawColor">The color to draw with.</param>
            public static void DrawOutline(Vector3[] vertices, Color drawColor)
            {
                if (vertices == null || vertices.Length <= 0) { return; } 

                for (int j = 0; j < vertices.Length; j++)
                {
                    Vector3 pa, pb;

                    pa = vertices[j];

                    if (j < vertices.Length - 1)
                    {
                        pb = vertices[j + 1];
                    }
                    else
                    {
                        pb = vertices[0];
                    }

                    Gizmos.color = drawColor;
                    Gizmos.DrawLine(pa, pb);
                }
            }

            /// <summary>
            /// Draw the outline with the provided vertices.
            /// </summary>
            /// <param name="vertices">The vertices to draw.</param>
            /// <param name="drawColor">The color to draw with.</param>
            /// <param name="alpha">The transparency alpha value to apply to the color.</param>
            public static void DrawOutline(Vector3[] vertices, Color drawColor, float alpha)
            {
                if (vertices == null || vertices.Length <= 0) { return; }

                for (int j = 0; j < vertices.Length; j++)
                {
                    Vector3 pa, pb;

                    pa = vertices[j];

                    if (j < vertices.Length - 1)
                    {
                        pb = vertices[j + 1];
                    }
                    else
                    {
                        pb = vertices[0];
                    }

                    Gizmos.color = new Color(drawColor.r, drawColor.g, drawColor.b, alpha);
                    Gizmos.DrawLine(pa, pb);
                }
            }

            /// <summary>
            /// Draw the outline with the provided vertices.
            /// </summary>
            /// <param name="vertices">The vertices to draw.</param>
            /// <param name="drawColor">The color to draw with.</param>
            /// <param name="alpha">The transparency alpha value to apply to the color.</param>
            public static void DrawOutline(Vector3[] vertices, Color drawColor, int alpha)
            {
                if (vertices == null || vertices.Length <= 0) { return; }

                for (int j = 0; j < vertices.Length; j++)
                {
                    Vector3 pa, pb;

                    pa = vertices[j];

                    if (j < vertices.Length - 1)
                    {
                        pb = vertices[j + 1];
                    }
                    else
                    {
                        pb = vertices[0];
                    }

                    Gizmos.color = new Color(drawColor.r, drawColor.g, drawColor.b, (1/255) * alpha);
                    Gizmos.DrawLine(pa, pb);
                }
            }
        }
    }
}