using UnityEngine;
using UnityEngine.UIElements;

namespace Cappuccino
{
    namespace Graphing
    {
        /// <summary>
        /// A class containing various extensions for callback events related to visual elements. <br></br><br></br>
        /// <see langword="Notice:"/> Any method without the suffix "Constant" only happens once and gets automatically unbound. <br></br>
        /// Any method with the suffix "Constant" will not be unbindable normally.
        /// </summary>
        public static partial class VisualElementExtensions
        {
            /// <summary>
            /// A delegate for a method that takes a MouseDownEvent object. <br></br>
            /// Gets called when a Visual Element recieves a mouse down input event.
            /// </summary>
            /// <param name="evt">The mouse down event created as a result of the interaction.</param>
            public delegate void MouseDown(MouseDownEvent evt);

            /// <summary>
            /// Create a single-call binding when the Geometry is changed that triggers once and self-unbinds afterwards.
            /// </summary>
            /// <param name="element">The element to add the GeometryChangedEvent RegisterCallback to.</param>
            /// <param name="onMouseDownEvent">The action to perform when the mouse has been pressed.</param>
            public static void OnMouseDown(this VisualElement element, MouseDown onMouseDownEvent)
            {
                // _sc suffix stands for "single-call".
                void evt_callback_mousedown_sc(MouseDownEvent evt)
                {
                    onMouseDownEvent(evt);
                    element.UnregisterCallback((EventCallback<MouseDownEvent>)evt_callback_mousedown_sc);
                }

                element.RegisterCallback<MouseDownEvent>(evt_callback_mousedown_sc);
            }

            /// <summary>
            /// Create a single-call binding when the Geometry is changed that triggers multiple times.
            /// </summary>
            /// <param name="element">The element to add the GeometryChangedEvent RegisterCallback to.</param>
            /// <param name="onMouseDownEvent">The action to perform when the mouse has been pressed.</param>
            public static void OnMouseDownConstant(this VisualElement element, MouseDown onMouseDownEvent)
            {
                // _mc suffix stands for "multi-call".
                void evt_callback_mousedown_mc(MouseDownEvent evt)
                {
                    onMouseDownEvent(evt);
                }

                element.RegisterCallback<MouseDownEvent>(evt_callback_mousedown_mc);
            }
        }
    }
}