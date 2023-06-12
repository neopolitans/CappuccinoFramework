using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// CSState is a wrapper for the sealed GUIStyleState class.
// Meant for internal use. It offers no benefits over GUIStyleState at time of writing. (8 Feb 2023)

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> A Class Wrapper for GUIStyleState.
        /// </summary>
        public class CSState
        {
            public GUIStyleState state;

            public CSState()
            {
                state = new GUIStyleState();
            }

            public CSState(GUIStyleState state)
            {
                this.state = state;
            }

            public Texture2D background
            {
                get { return state.background; }
                set { state.background = value; }
            }

            public Texture2D[] scaledBackgrounds
            {
                get { return state.scaledBackgrounds; }
                set { state.scaledBackgrounds = value; }
            }

            public Color textColor
            {
                get { return state.textColor; }
                set { state.textColor = value;}
            }
        }
    }
}