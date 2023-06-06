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
        /// <see langword="Cappuccino:"/> This static class contains gizmo-drawing methods and additional utiltiies. <br></br><br></br>
        /// <b><see langword="Notice: This toolkit is used by other methods in Cappuccino Framework to make extra features."/></b><br></br>
        /// It should not be removed unless you are stripping out all Gizmo-based methods, including the Visualiser to  olkit.
        /// </summary>
        public static partial class GT
        {
            // Forward-ported from Introduction to AI Module submission and further refined.
            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a 3D Arrow with Gizmo Lines.
            /// </summary>
            /// <param name="start">The start position of the arrow.</param>
            /// <param name="end">The end position of the arrow.</param>
            /// <param name="arrowheadAngle">The angle that the arrowhead arms are drawn with.</param>
            /// <param name="arrowheadDistance">The distance from the start that the end point is multiplied by.</param>
            /// <param name="arrowheadLength">The length of the arrowhead arms.</param>
            public static void DrawArrow3D(Vector3 start, Vector3 end, float arrowheadAngle, float arrowheadDistance, float arrowheadLength)
            {
                // Get the start and end positions of the arrow.
                Vector3 dir = end - start;
                Vector3 arrowPos = start + (dir * arrowheadDistance);

                // Get all arrow ends.
                Vector3 up = Quaternion.LookRotation(dir) * new Vector3(0f, MathToolkit.Deg2Sin(arrowheadAngle), -1f) * arrowheadLength;
                Vector3 down = Quaternion.LookRotation(dir) * new Vector3(0f, -MathToolkit.Deg2Sin(arrowheadAngle), -1f) * arrowheadLength;
                Vector3 left = Quaternion.LookRotation(dir) * new Vector3(MathToolkit.Deg2Sin(arrowheadAngle), 0, -1f) * arrowheadLength;
                Vector3 right = Quaternion.LookRotation(dir) * new Vector3(-MathToolkit.Deg2Sin(arrowheadAngle), 0f, -1f) * arrowheadLength;

                // Get the length of the section of the arrowhead to subtract from the final drawn arrow line.
                Vector3 len = Quaternion.LookRotation(dir) * new Vector3(0f, 0f, -1f) * arrowheadLength;

                // Draw all the arrow lines from the end to each direction.
                Gizmos.DrawLine(arrowPos, arrowPos + up);
                Gizmos.DrawLine(arrowPos, arrowPos + down);
                Gizmos.DrawLine(arrowPos, arrowPos + left);
                Gizmos.DrawLine(arrowPos, arrowPos + right);

                // Draw the interconnecting lines between external points.
                Gizmos.DrawLine(arrowPos + left, arrowPos + up);
                Gizmos.DrawLine(arrowPos + up, arrowPos + right);
                Gizmos.DrawLine(arrowPos + right, arrowPos + down);
                Gizmos.DrawLine(arrowPos + down, arrowPos + left);

                // Draw the interconnecting lines between each pair of ends.
                Gizmos.DrawLine(arrowPos + left, arrowPos + right);
                Gizmos.DrawLine(arrowPos + up, arrowPos + down);

                // Draw the line between the arrowhead and the start position.
                Gizmos.DrawLine(start, start + ((dir * arrowheadDistance) + len));

            }
        }
    }
}