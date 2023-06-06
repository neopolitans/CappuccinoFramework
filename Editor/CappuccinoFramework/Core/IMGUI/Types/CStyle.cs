using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// CStyle is a wrapper for the sealed GUIStyle class.
// It offers no benefits over GUIStyle at time of writing. (8 Feb 2023)

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> A Class Wrapper for GUIStyle. <br></br><br></br>
        /// This is optional in editors and can be skipped in favor of custom GUIStyles and GUISkins. <br></br>
        /// A wrapper for future expansion.
        /// </summary>
        public class CStyle
        {
            public GUIStyle style; // Target GUIStyle instance.

            public CSState normal, active, focused, hover, onNormal, onActive, onFocused, onHover;

            public CStyle() 
            {
                style = new GUIStyle();

                normal = new(style.normal);
                active = new(style.active);
                focused = new(style.focused);
                hover = new(style.hover);
                onNormal = new(style.onNormal);
                onActive = new(style.onActive);
                onFocused = new(style.onFocused);
                onHover = new(style.onHover);
            }

            /// <summary>
            /// Shortcut for an empty style. <br></br>
            /// <see langword="Cappuccino:"/> Similar to GUIStyle.none.
            /// </summary>
            public static CStyle none
            {
                get { return new CStyle(); }
            }


            public TextAnchor alignment
            {
                get { return style.alignment; }
                set { style.alignment = value; }
            }

            public RectOffset border
            {
                get { return style.border; }
                set { style.border = value; }
            }

            public TextClipping clipping
            {
                get { return style.clipping; }
                set { style.clipping = value; }
            }

            public Vector2 contentOffset
            {
                get { return style.contentOffset; }
                set { style.contentOffset = value; }
            }

            public float fixedHeight
            {
                get { return style.fixedHeight; }
                set { style.fixedHeight = value; }
            }

            public float fixedWidth
            {
                get { return style.fixedWidth; }
                set { style.fixedWidth = value; }
            }

            public Font font
            {
                get { return style.font; }
                set { style.font = value; }
            }

            public int fontSize
            {
                get { return style.fontSize; }
                set { style.fontSize = value; }
            }

            public FontStyle fontStyle
            {
                get { return style.fontStyle; }
                set { style.fontStyle = value; }
            }

            public ImagePosition imagePosition
            {
                get { return style.imagePosition; }
                set { style.imagePosition = value; }
            }

            public float lineHeight
            {
                get { return style.lineHeight; }
            }

            public RectOffset margin
            {
                get { return style.margin; }
                set { style.margin = value; }
            }

            public string name
            {
                get { return style.name; }
                set { style.name = value; }
            }

            public RectOffset overflow
            {
                get { return style.overflow; }
                set { style.overflow = value; }   
            }

            public RectOffset padding
            {
                get { return style.padding; }
                set { style.padding = value; }   
            }

            public bool richText
            {
                get { return style.richText; }
                set { style.richText = value; }   
            }

            public bool stretchHeight
            {
                get { return style.stretchHeight; }
                set { style.stretchHeight = value; }   
            }

            public bool stretchWidth
            {
                get { return style.stretchWidth; }
                set { style.stretchWidth = value; }
            }
            public bool wordWrap
            {
                get { return style.wordWrap; }
                set { style.wordWrap = value; }
            }
        }
    }
}