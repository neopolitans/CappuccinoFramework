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
        /// A Derivable class which abstracts elements of creating an Editor Window for <see langword="Unity"/>. <br></br><br></br>
        /// <see langword="Cappuccino:"/> Methods within this class can be dervied, extended and replaced as need be.
        /// </summary>
        public partial class CEditor : EditorWindow
        {
            /// <summary>
            /// <see langword="Cappuccino:"/> The currently opened instance of the CEditor window you're trying to use. <br></br>
            /// This is automatically set whenever you use the Open method to create an editor window. <br></br><br></br>
            /// <see langword="Notice:"/> This will only give you access to the generic CEditor properties tied to your editor window. <br></br>
            /// To edit properties specific to your editor window, you must cast the instance to your class type.
            /// </summary>
            public static CEditor instance;

            /// <summary>
            /// The current drawing function to use. <br></br><br></br>
            /// <see langword="Cappuccino:"/> Used for drawing static panels. Easier to use but less querying and information.<br></br>
            /// Requires consistent management of the editor window state by the developer. <br></br><br></br>
            /// <b><see langword="Notice:"/> Does not support multiple methods being hooked at once.</b>
            /// </summary>
            public DrawFunction currentPanel;

            /// <summary>
            /// <see langword="Cappuccino:"/> The method to call when the CEditor Window has gained focus. <br></br>
            /// Supports multiple methods being hooked at once.
            /// </summary>
            public FocusChangeMethod focused;

            /// <summary>
            /// <see langword="Cappuccino:"/> The method to call when the CEditor Window has lost focus. <br></br>
            /// Supports multiple methods being hooked at once.
            /// </summary>
            public FocusChangeMethod unfocused;

            /// <summary>
            /// The default panel drawing function to return to in the event of currentPanel being null. <br></br>
            /// <see langword="Cappuccino:"/> Recommended for panels 
            /// </summary>
            protected static DrawFunction defaultPanel;

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for CEditor.position.size; 
            /// </summary>
            public Vector2 size
            {
                get { return position.size; }
            }

            /// <summary>
            /// Create an Editor Window. <br></br><br></br>
            /// Use of <seealso cref="WindowUtilities"/> is recommended for optimal visibility and behaviour.
            /// </summary>
            /// <returns>Returns a window <seealso cref="CEditor"/> instance that you can store and modify. </returns>
            // This is based off of how GetWindow<T>() works.
            public static T Open<T>() where T : CEditor
            {
                T wnd = GetWindow<T>();
                wnd.minSize = WindowUtilities.minSize; // This Method only applies the default minimum size of 384x512 for a window.
                instance = wnd;

                return wnd;
            }

            /// <summary>
            /// Create an Editor Window. <br></br><br></br>
            /// Use of <seealso cref="WindowUtilities"/> is recommended for optimal visibility and behaviour.
            /// </summary>
            /// <param name="initialTitle">Initial Window Title to display.</param>
            /// <returns>Returns a window <seealso cref="CEditor"/> instance that you can store and modify. </returns>
            public static T Open<T>(string initialTitle) where T : CEditor
            {
                T wnd = GetWindow<T>();
                wnd.minSize = WindowUtilities.minSize; // This Method only applies the default minimum size of 384x512 for a window.
                wnd.Rename(initialTitle);
                instance = wnd;

                return wnd;
            }

            /// <summary>
            /// Create an Editor Window. <br></br><br></br>
            /// Use of <seealso cref="WindowUtilities"/> is recommended for optimal visibility and behaviour.
            /// </summary>
            /// <param name="initialIcon">Initial Window Icon to display.</param>
            /// <returns>Returns a window <seealso cref="CEditor"/> instance that you can store and modify. </returns>
            public static T Open<T>(Texture initialIcon) where T : CEditor
            {
                T wnd = GetWindow<T>();
                wnd.minSize = WindowUtilities.minSize; // This Method only applies the default minimum size of 384x512 for a window.
                wnd.Icon(initialIcon);
                instance = wnd;

                return wnd;
            }

            /// <summary>
            /// Create an Editor Window. <br></br><br></br>
            /// Use of <seealso cref="WindowUtilities"/> is recommended for optimal visibility and behaviour.
            /// </summary>
            /// <param name="initialTitle">Initial Window Title to display.</param>
            /// <param name="initialIcon">Initial Window Icon to display.</param>
            /// <returns>Returns a window <seealso cref="CEditor"/> instance that you can store and modify. </returns>
            public static T Open<T>(string initialTitle, Texture initialIcon) where T : CEditor
            {
                T wnd = GetWindow<T>();
                wnd.minSize = WindowUtilities.minSize; // This Method only applies the default minimum size of 384x512 for a window.
                wnd.Rename(initialTitle);
                wnd.Icon(initialIcon);
                instance = wnd;

                return wnd;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Only calls Draw for intercompatibility with conversions from EditorWindow to CEditor. <br></br>
            /// Inherited from Unity's <seealso cref="EditorWindow"/> Class. <br></br>
            /// </summary>
            public virtual void OnGUI()
            {
                Draw();
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Only calls focused if focused is not null. <br></br>
            /// Inherited from Unity's <seealso cref="EditorWindow"/> Class. <br></br>
            /// </summary>
            public virtual void OnFocus()
            {
                if (focused != null)
                {
                    focused();
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Only calls unfocused if unfocused is not null. <br></br>
            /// Inherited from Unity's <seealso cref="EditorWindow"/> Class. <br></br>
            /// </summary>
            public virtual void OnLostFocus()
            {
                if (unfocused != null)
                {
                    unfocused();
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw the contents of your editor here.
            /// </summary>
            public virtual void Draw()
            {
                if (currentPanel != null)
                {
                    currentPanel();
                }
                else
                {
                    Alert("There is currently no defined panel to draw to the window.");
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Write your Editor Window's input event handling here.
            /// </summary>
            public virtual void OnInputEvent()
            {

            }

            /// <summary>
            /// Set the current panel. <br></br>
            /// <see langword="Cappuccino:"/> This is an alternative to directly setting the panel within the editor for other windows.
            /// </summary>
            /// <param name="panelDrawer"></param>
            public void SetPanel(DrawFunction panelDrawer)
            {
                currentPanel = panelDrawer;
            }


            /// <summary>
            /// A no-parameter void named specifically to denote it's use for currentPanel in the editor window.
            /// </summary>
            public delegate void DrawFunction();

            /// <summary>
            /// A no-parameter void named specifically to denote it's use for OnFocus and OnLostFocus in the editor window.
            /// </summary>
            public delegate void FocusChangeMethod();
        }
    }
}
