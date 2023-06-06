using UnityEngine;
using UnityEngine.UIElements;

namespace Cappuccino
{
    namespace Graphing
    { 
        public static partial class VisualElementExtensions
        {
            /// <summary>
            /// A delegate for a method that takes a Rect. <br></br>
            /// Gets called when a Visual Element's geometry changes.
            /// </summary>
            /// <param name="newRect">The new rect defined for the visual element when the geometry changed.</param>
            public delegate void GeometryChanged(Rect newRect);

            /// <summary>
            /// Create a single-call binding when the Geometry is changed that triggers once and self-unbinds afterwards.
            /// </summary>
            /// <param name="element">The element to add the GeometryChangedEvent RegisterCallback to.</param>
            /// <param name="onGeometryChangedEvent">The action to perform when the geometry has been changed.</param>
            public static void OnGeometryChanged(this VisualElement element, GeometryChanged onGeometryChangedEvent)
            {
                // _sc suffix stands for "single-call".
                void evt_callback_geomchanged_sc(GeometryChangedEvent evt)
                {
                    onGeometryChangedEvent(evt.newRect);
                    element.UnregisterCallback((EventCallback<GeometryChangedEvent>)evt_callback_geomchanged_sc);
                }

                element.RegisterCallback<GeometryChangedEvent>(evt_callback_geomchanged_sc);
            }

            /// <summary>
            /// Create a single-call binding when the Geometry is changed that triggers multiple times.
            /// </summary>
            /// <param name="element">The element to add the GeometryChangedEvent RegisterCallback to.</param>
            /// <param name="onGeometryChangedEvent">The action to perform when the geometry has been changed.</param>
            public static void OnGeometryChangedConstant(this VisualElement element, GeometryChanged onGeometryChangedEvent)
            {
                // _mc suffix stands for "multi-call".
                void evt_callback_geomchanged_mc(GeometryChangedEvent evt)
                {
                    onGeometryChangedEvent(evt.newRect);
                }

                element.RegisterCallback<GeometryChangedEvent>(evt_callback_geomchanged_mc);
            }
        }
    }
}