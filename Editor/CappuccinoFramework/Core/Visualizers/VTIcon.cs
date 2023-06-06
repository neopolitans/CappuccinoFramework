using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This script adds the ability to draw Icons in SceneView to the Visualizer Toolkit.

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> This static class is the Visualizer Toolkit. It contains common Gizmo Drawing methods for Editors. <br></br>
        /// For use with the Unity Attribute <i><b>DrawGizmo</b></i>. <br></br><br></br>
        /// <b><see langword="Notice:"/></b> Any methods trying to use [DrawGizmo(GizmoType)] must be a static method and must include two parameters. One of the targeted component type and one of GizmoType.<br></br>
        /// See: <see href="https://docs.unity3d.com/ScriptReference/DrawGizmo.html">DrawGizmo</see>
        /// </summary>
        public static partial class VT
        {
            /// <summary>
            /// Draw an icon with the provided gizo icon path. <br></br>
            /// <see langword="Cappuccino:"/> Assumes the file-type of the icon is the default file type "PNG";
            /// <br></br><br></br>
            /// <b><see langword="Notice:"/></b> This requires the icon to be placed within [Assets/Gizmos]. If this folder doesn't exist, it must be created. <br></br>
            /// See: <see href="https://docs.unity3d.com/ScriptReference/Gizmos.DrawIcon.html">Gizmos.DrawIcon</see>
            /// </summary>
            /// <param name="position">The position to draw the icon at.</param>
            /// <param name="gizmoIconPath">The file path of the icon to draw.</param>
            public static void Icon(Vector3 position, string gizmoIconPath)
            {
                Gizmos.DrawIcon(position, gizmoIconPath + FrameworkUtilities.defaultIconFiletypeSuffix);
            }

            /// <summary>
            /// Draw an icon with the provided gizo icon path. <br></br>
            /// <see langword="Cappuccino:"/> Assumes the file-type of the icon is the default file type "PNG";
            /// <br></br><br></br>
            /// <b><see langword="Notice:"/></b> This requires the icon to be placed within [Assets/Gizmos]. If this folder doesn't exist, it must be created. <br></br>
            /// See: <see href="https://docs.unity3d.com/ScriptReference/Gizmos.DrawIcon.html">Gizmos.DrawIcon</see>
            /// </summary>
            /// <param name="position">The position to draw the icon at.</param>
            /// <param name="gizmoIconPath">The file path of the icon to draw.</param>
            /// <param name="tint">The tint color of the icon.</param>
            public static void Icon(Vector3 position, string gizmoIconPath, Color tint)
            {
                Gizmos.DrawIcon(position, gizmoIconPath + FrameworkUtilities.defaultIconFiletypeSuffix, true, tint);
            }

            /// <summary>
            /// Draw an icon with the provided gizo icon path. <br></br>
            /// <see langword="Cappuccino:"/> Assumes the file-type of the icon is the default file type "PNG";
            /// <br></br><br></br>
            /// <b><see langword="Notice:"/></b> This requires the icon to be placed within [Assets/Gizmos]. If this folder doesn't exist, it must be created. <br></br>
            /// See: <see href="https://docs.unity3d.com/ScriptReference/Gizmos.DrawIcon.html">Gizmos.DrawIcon</see>
            /// </summary>
            /// <param name="position">The position to draw the icon at.</param>
            /// <param name="gizmoIconPath">The file path of the icon to draw.</param>
            /// <param name="allowScaling">Allow Icon Scaling.</param>
            public static void Icon(Vector3 position, string gizmoIconPath, bool allowScaling)
            {
                Gizmos.DrawIcon(position, gizmoIconPath + FrameworkUtilities.defaultIconFiletypeSuffix, allowScaling);
            }

            /// <summary>
            /// Draw an icon with the provided gizo icon path. <br></br>
            /// <see langword="Cappuccino:"/> Assumes the file-type of the icon is the default file type "PNG";
            /// <br></br><br></br>
            /// <b><see langword="Notice:"/></b> This requires the icon to be placed within [Assets/Gizmos]. If this folder doesn't exist, it must be created. <br></br>
            /// See: <see href="https://docs.unity3d.com/ScriptReference/Gizmos.DrawIcon.html">Gizmos.DrawIcon</see>
            /// </summary>
            /// <param name="position">The position to draw the icon at.</param>
            /// <param name="gizmoIconPath">The file path of the icon to draw.</param>
            /// <param name="allowScaling">Allow Icon Scaling.</param>
            /// <param name="tint">The tint color of the icon.</param>
            public static void Icon(Vector3 position, string gizmoIconPath, bool allowScaling, Color tint)
            {
                Gizmos.DrawIcon(position, gizmoIconPath + FrameworkUtilities.defaultIconFiletypeSuffix, allowScaling, tint);
            }

            /// <summary>
            /// Draw an icon with the provided gizo icon path. <br></br>
            /// <b><see langword="Notice:"/></b> This requires the icon to be placed within [Assets/Gizmos]. If this folder doesn't exist, it must be created. <br></br>
            /// See: <see href="https://docs.unity3d.com/ScriptReference/Gizmos.DrawIcon.html">Gizmos.DrawIcon</see>
            /// </summary>
            /// <param name="position">The position to draw the icon at.</param>
            /// <param name="gizmoIconPath">The file path of the icon to draw.</param>
            /// <param name="fileType">The file-type to append to the asset name.</param>
            public static void Icon(Vector3 position, string gizmoIconPath, TextureFileType fileType)
            {
                Gizmos.DrawIcon(position,gizmoIconPath + FrameworkUtilities.GetTextureFileTypeSuffix(fileType));
            }

            /// <summary>
            /// Draw an icon with the provided gizo icon path. <br></br>
            /// <b><see langword="Notice:"/></b> This requires the icon to be placed within [Assets/Gizmos]. If this folder doesn't exist, it must be created. <br></br>
            /// See: <see href="https://docs.unity3d.com/ScriptReference/Gizmos.DrawIcon.html">Gizmos.DrawIcon</see>
            /// </summary>
            /// <param name="position">The position to draw the icon at.</param>
            /// <param name="gizmoIconPath">The file path of the icon to draw.</param>
            /// <param name="fileType">The file-type to append to the asset name.</param>
            /// <param name="tint">The tint color of the icon.</param>
            public static void Icon(Vector3 position, string gizmoIconPath, TextureFileType fileType, Color tint)
            {
                Gizmos.DrawIcon(position, gizmoIconPath + FrameworkUtilities.GetTextureFileTypeSuffix(fileType), true, tint);
            }

            /// <summary>
            /// Draw an icon with the provided gizo icon path. <br></br>
            /// <b><see langword="Notice:"/></b> This requires the icon to be placed within [Assets/Gizmos]. If this folder doesn't exist, it must be created. <br></br>
            /// See: <see href="https://docs.unity3d.com/ScriptReference/Gizmos.DrawIcon.html">Gizmos.DrawIcon</see>
            /// </summary>
            /// <param name="position">The position to draw the icon at.</param>
            /// <param name="gizmoIconPath">The file path of the icon to draw.</param>
            /// <param name="fileType">The file-type to append to the asset name.</param>
            /// <param name="allowScaling">Allow Icon Scaling.</param>
            public static void Icon(Vector3 position, string gizmoIconPath, TextureFileType fileType, bool allowScaling)
            {
                Gizmos.DrawIcon(position, gizmoIconPath + FrameworkUtilities.GetTextureFileTypeSuffix(fileType), allowScaling);
            }

            /// <summary>
            /// Draw an icon with the provided gizo icon path. <br></br>
            /// <b><see langword="Notice:"/></b> This requires the icon to be placed within [Assets/Gizmos]. If this folder doesn't exist, it must be created. <br></br>
            /// See: <see href="https://docs.unity3d.com/ScriptReference/Gizmos.DrawIcon.html">Gizmos.DrawIcon</see>
            /// </summary>
            /// <param name="position">The position to draw the icon at.</param>
            /// <param name="gizmoIconPath">The file path of the icon to draw.</param>
            /// <param name="fileType">The file-type to append to the asset name.</param>
            /// <param name="allowScaling">Allow Icon Scaling.</param>
            /// <param name="tint">The tint color of the icon.</param>
            public static void Icon(Vector3 position, string gizmoIconPath, TextureFileType fileType, bool allowScaling, Color tint)
            {
                Gizmos.DrawIcon(position, gizmoIconPath + FrameworkUtilities.GetTextureFileTypeSuffix(fileType), allowScaling, tint);
            }
        }
    }
}