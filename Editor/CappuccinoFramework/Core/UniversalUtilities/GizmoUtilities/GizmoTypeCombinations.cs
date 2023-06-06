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
        /// It should not be removed unless you are stripping out all Gizmo-based methods, including the Visualiser toolkit.
        /// </summary>
        public static partial class GT
        {
            /// <summary>
            /// <see langword="Cappuccino:"/> All of the GizmoTypes at once.<br></br>Useful for generic painting in any case.
            /// </summary>
            public const GizmoType All = GizmoType.Pickable | GizmoType.NotInSelectionHierarchy | GizmoType.Selected | GizmoType.Active | GizmoType.InSelectionHierarchy | GizmoType.NonSelected;

            /// <summary>
            /// <see langword="Cappuccino:"/> GizmoTypes Selected and InSelectionHierarchy.<br></br>Useful for generic painting if the object is selected.
            /// </summary>
            public const GizmoType SelectedGeneric = GizmoType.Selected | GizmoType.InSelectionHierarchy;

            /// <summary>
            /// <see langword="Cappuccino:"/> GizmoTypes NonSelected and NotInSelectionHierarchy.<br></br>Useful for generic painting if the object is not selected.
            /// </summary>
            public const GizmoType NotSelectedGeneric = GizmoType.NotInSelectionHierarchy | GizmoType.NonSelected;

        }
    }
}
