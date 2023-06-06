using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This Extension Script adds the Shorthands for drawing CProperty values.

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> This class abstracts some of the minutia and nomenclature issues that Unity has in the <seealso cref="UnityEditor.SerializedProperty"/> object class.
        /// </summary>
        public partial class CProperty
        {
            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for EditorGUILayout.PropertyField.
            /// </summary>
            public bool Draw()
            {
                if (valid)
                {
                    return EditorGUILayout.PropertyField(property);
                }
                else
                {
                    Debug.Log("[Cappuccino Notify] - The current CProperty you have tried to draw has been marked as invalid. \nProperty:" + path);
                    return false;
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for EditorGUILayout.PropertyField.
            /// </summary>
            /// <param name="text">The text to display as the header of the Property Field.</param>
            public bool Draw(string text)
            {
                if (valid)
                {
                    return EditorGUILayout.PropertyField(property, new GUIContent(text));
                }
                else
                {
                    Debug.Log("[Cappuccino Notify] - The current CProperty you have tried to draw has been marked as invalid. \nProperty:" + path);
                    return false;
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for EditorGUILayout.PropertyField.
            /// </summary>
            /// <param name="readOnly"> Should this property be displayed as Read-Only?</param>
            public bool Draw(bool readOnly)
            {
                bool result = false;

                if (readOnly) { GUI.enabled = false;  }

                if (valid)
                {
                    result = EditorGUILayout.PropertyField(property);
                }
                else
                {
                    Debug.Log("[Cappuccino Notify] - The current CProperty you have tried to draw has been marked as invalid. \nProperty:" + path);
                }

                if (readOnly) { GUI.enabled = true; }

                return result;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for EditorGUILayout.PropertyField.
            /// </summary>
            /// <param name="text">The text to display as the header of the Property Field.</param>
            /// <param name="readOnly"> Should this property be displayed as Read-Only?</param>
            public bool Draw(string text, bool readOnly)
            {
                bool result = false;

                if (readOnly) { GUI.enabled = false; }

                if (valid)
                {
                    return EditorGUILayout.PropertyField(property, new GUIContent(text));
                }
                else
                {
                    Debug.Log("[Cappuccino Notify] - The current CProperty you have tried to draw has been marked as invalid. \nProperty:" + path);
                }

                if (readOnly) { GUI.enabled = true; }

                return result;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for EditorGUILayout.PropertyField.
            /// </summary>
            /// <param name="options">The auto-layout options to apply.</param>
            public bool Draw(params GUILayoutOption[] options)
            {
                if (valid)
                {
                    return EditorGUILayout.PropertyField(property, options);
                }
                else
                {
                    Debug.Log("[Cappuccino Notify] - The current CProperty you have tried to draw has been marked as invalid. \nProperty:" + path);
                    return false;
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for EditorGUILayout.PropertyField.
            /// </summary>
            /// <param name="text">The text to display as the header of the Property Field.</param>
            /// <param name="options">The auto-layout options to apply.</param>
            public bool Draw(string text, params GUILayoutOption[] options)
            {
                if (valid)
                {
                    return EditorGUILayout.PropertyField(property, new GUIContent(text), options);
                }
                else
                {
                    Debug.Log("[Cappuccino Notify] - The current CProperty you have tried to draw has been marked as invalid. \nProperty:" + path);
                    return false;
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for EditorGUILayout.PropertyField.
            /// </summary>
            /// <param name="readOnly"> Should this property be displayed as Read-Only?</param>
            /// <param name="options">The auto-layout options to apply.</param>
            public bool Draw(bool readOnly, params GUILayoutOption[] options)
            {
                bool result = false;

                if (readOnly) { GUI.enabled = false; }

                if (valid)
                {
                    result = EditorGUILayout.PropertyField(property, options);
                }
                else
                {
                    Debug.Log("[Cappuccino Notify] - The current CProperty you have tried to draw has been marked as invalid. \nProperty:" + path);
                }

                if (readOnly) { GUI.enabled = true; }

                return result;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for EditorGUILayout.PropertyField.
            /// </summary>
            /// <param name="text">The text to display as the header of the Property Field.</param>
            /// <param name="readOnly"> Should this property be displayed as Read-Only?</param>
            /// <param name="options">The auto-layout options to apply.</param>
            public bool Draw(string text, bool readOnly, params GUILayoutOption[] options)
            {
                bool result = false;

                if (readOnly) { GUI.enabled = false; }

                if (valid)
                {
                    return EditorGUILayout.PropertyField(property, new GUIContent(text), options);
                }
                else
                {
                    Debug.Log("[Cappuccino Notify] - The current CProperty you have tried to draw has been marked as invalid. \nProperty:" + path);
                }

                if (readOnly) { GUI.enabled = true; }

                return result;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for EditorGUILayout.PropertyField.
            /// </summary>
            /// <param name="position"> The Position and Size (as Rect) to draw the UI Element with.</param>
            public bool Draw(Rect position)
            {
                if (valid)
                {
                    return EditorGUI.PropertyField(position, property);
                }
                else
                {
                    Debug.Log("[Cappuccino Notify] - The current CProperty you have tried to draw has been marked as invalid. \nProperty:" + path);
                    return false;
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for EditorGUILayout.PropertyField.
            /// </summary>
            /// <param name="position"> The Position and Size (as Rect) to draw the UI Element with.</param>
            /// <param name="readOnly"> Should this property be displayed as Read-Only?</param>
            public bool Draw(Rect position, bool readOnly)
            {
                bool result = false;

                if (readOnly) { GUI.enabled = false; }

                if (valid)
                {
                    result = EditorGUI.PropertyField(position, property);
                }
                else
                {
                    Debug.Log("[Cappuccino Notify] - The current CProperty you have tried to draw has been marked as invalid. \nProperty:" + path);
                }

                if (readOnly) { GUI.enabled = true; }

                return result;
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for EditorGUILayout.PropertyField.
            /// </summary>
            /// <param name="position"> The Position and Size (as Rect) to draw the UI Element with.</param>
            public bool Draw(Rect position, string text)
            {
                if (valid)
                {
                    return EditorGUI.PropertyField(position, property, new GUIContent(text));
                }
                else
                {
                    Debug.Log("[Cappuccino Notify] - The current CProperty you have tried to draw has been marked as invalid. \nProperty:" + path);
                    return false;
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Shorthand for EditorGUILayout.PropertyField.
            /// </summary>
            /// <param name="position"> The Position and Size (as Rect) to draw the UI Element with.</param>
            /// <param name="readOnly"> Should this property be displayed as Read-Only?</param>
            public bool Draw(Rect position, string text, bool readOnly)
            {
                bool result = false;

                if (readOnly) { GUI.enabled = false; }

                if (valid)
                {
                    result = EditorGUI.PropertyField(position, property, new GUIContent(text));
                }
                else
                {
                    Debug.Log("[Cappuccino Notify] - The current CProperty you have tried to draw has been marked as invalid. \nProperty:" + path);
                }

                if (readOnly) { GUI.enabled = true; }

                return result;
            }
        }
    }
}