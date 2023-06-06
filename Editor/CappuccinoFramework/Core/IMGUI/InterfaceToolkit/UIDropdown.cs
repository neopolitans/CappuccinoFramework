using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This script builds "UI.Label" into Cappuccino.Core.UI.
// EditorGUI and EditorGUILayout methods are combined here for ease of use and quicker changes.

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> This static class is the User Interface Toolkit. It contains common UI drawing methods for Editors. <br></br>
        /// </summary>
        public static partial class UI
        {
            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a Dropdown Menu button (and it's following Menu Items) automatically. <br></br><br></br>
            /// <b><i><see langword="Notice:"/> This uses integer-based item selection. You will have to convert the result provided through onClicked by-hand to the intended value, be it through array looping or such.</i></b> <br></br><br></br>
            /// Tags: <b><i><see langword="[Advanced-Feature], [Technical]"/> </i></b>
            /// </summary>
            /// <param name="tooltip">The tooltip to show when hovering over the button.</param>
            /// <param name="menuItems">The objects and their names to add to the menu.</param>
            /// <param name="comparator">The boolean comparator (that compares the selected integer</param>
            /// <param name="onClicked">The delegate to use when an option is clicked <br></br> <b><see langword="Notice:"/></b> The only permitted parameter of this method is a System.Object value.</param>
            /// <param name="options">The layout options to use when drawing the editor window.</param>
            public static void Dropdown(string tooltip, (string[] itemNames, object[] returnObjects) menuItems, BoolComparator comparator, GenericMenu.MenuFunction2 onClicked, params GUILayoutOption[] options)
            {
                // Prevent inconsistent or mismatched item lists.
                // Provide Warnings for each.
                if (menuItems == (null, null))
                {
                    Diag.Violation("Dropdown has no menu items.");
                    return;
                }
                if (menuItems.returnObjects == null || menuItems.returnObjects.Length < 1)
                {
                    Diag.Violation("Dropdown menu items has no return object(s) for it's menu item(s).");
                    return;
                }
                if (menuItems.itemNames == null || menuItems.itemNames.Length < 1)
                {
                    Diag.Violation("Dropdown menu items has no item name(s) for it's menu item(s).");
                    return;
                }
                if (menuItems.returnObjects.Length < menuItems.itemNames.Length || menuItems.returnObjects.Length > menuItems.itemNames.Length)
                {
                    Diag.Violation("The length of the arrays for each return object and each menu item name are mismatched.");
                    return;
                }

                if (EditorGUILayout.DropdownButton(new GUIContent(Icon(Iconography.MOREV), tooltip), FocusType.Passive, options))
                {
                    GenericMenu menu = new GenericMenu();

                    for (int i = 0; i < menuItems.itemNames.Length; i++)
                    {
                        menu.AddItem(new GUIContent(menuItems.itemNames[i]), comparator(i), onClicked, menuItems.returnObjects[i]);
                    }

                    menu.ShowAsContext();
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a Dropdown Menu button (and it's following Menu Items) automatically. <br></br><br></br>
            /// <b><i><see langword="Notice:"/> This uses integer-based item selection. You will have to convert the result provided through onClicked by-hand to the intended value, be it through array looping or such.</i></b> <br></br><br></br>
            /// Tags: <b><i><see langword="[Advanced-Feature], [Technical]"/> </i></b>
            /// </summary>
            /// <param name="label">The GUIContent to show for the button.</param>
            /// <param name="menuItems">The objects and their names to add to the menu.</param>
            /// <param name="comparator">The boolean comparator (that compares the selected integer</param>
            /// <param name="onClicked">The delegate to use when an option is clicked <br></br> <b><see langword="Notice:"/></b> The only permitted parameter of this method is a System.Object value.</param>
            /// <param name="options">The layout options to use when drawing the editor window.</param>
            public static void Dropdown(GUIContent label, (string[] itemNames, object[] returnObjects) menuItems, BoolComparator comparator, GenericMenu.MenuFunction2 onClicked, params GUILayoutOption[] options)
            {
                // Prevent inconsistent or mismatched item lists.
                // Provide Warnings for each.
                if (menuItems == (null, null))
                {
                    Diag.Violation("Dropdown has no menu items.");
                    return;
                }
                if (menuItems.returnObjects == null || menuItems.returnObjects.Length < 1)
                {
                    Diag.Violation("Dropdown menu items has no return object(s) for it's menu item(s).");
                    return;
                }
                if (menuItems.itemNames == null || menuItems.itemNames.Length < 1)
                {
                    Diag.Violation("Dropdown menu items has no item name(s) for it's menu item(s).");
                    return;
                }
                if (menuItems.returnObjects.Length < menuItems.itemNames.Length || menuItems.returnObjects.Length > menuItems.itemNames.Length)
                {
                    Diag.Violation("The length of the arrays for each return object and each menu item name are mismatched.");
                    return;
                }

                if (EditorGUILayout.DropdownButton(label, FocusType.Passive, options))
                {
                    GenericMenu menu = new GenericMenu();

                    for (int i = 0; i < menuItems.itemNames.Length; i++)
                    {
                        menu.AddItem(new GUIContent(menuItems.itemNames[i]), comparator(i), onClicked, menuItems.returnObjects[i]);
                    }

                    menu.ShowAsContext();
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a Dropdown Menu button (and it's following Menu Items) automatically. <br></br><br></br>
            /// <b><i><see langword="Notice:"/> This uses integer-based item selection. You will have to convert the result provided through onClicked by-hand to the intended value, be it through array looping or such.</i></b> <br></br><br></br>
            /// Tags: <b><i><see langword="[Advanced-Feature], [Technical]"/> </i></b>
            /// </summary>
            /// <param name="tooltip">The tooltip to show when hovering over the button.</param>
            /// <param name="style">The GUIStyle to draw with.</param>
            /// <param name="menuItems">The objects and their names to add to the menu.</param>
            /// <param name="comparator">The boolean comparator (that compares the selected integer</param>
            /// <param name="onClicked">The delegate to use when an option is clicked <br></br> <b><see langword="Notice:"/></b> The only permitted parameter of this method is a System.Object value.</param>
            /// <param name="options">The layout options to use when drawing the editor window.</param>
            public static void Dropdown(string tooltip, GUIStyle style, (string[] itemNames, object[] returnObjects) menuItems, BoolComparator comparator, GenericMenu.MenuFunction2 onClicked, params GUILayoutOption[] options)
            {
                // Prevent inconsistent or mismatched item lists.
                // Provide Warnings for each.
                if (menuItems == (null, null))
                {
                    Diag.Violation("Dropdown has no menu items.");
                    return;
                }
                if (menuItems.returnObjects == null || menuItems.returnObjects.Length < 1)
                {
                    Diag.Violation("Dropdown menu items has no return object(s) for it's menu item(s).");
                    return;
                }
                if (menuItems.itemNames == null || menuItems.itemNames.Length < 1)
                {
                    Diag.Violation("Dropdown menu items has no item name(s) for it's menu item(s).");
                    return;
                }
                if (menuItems.returnObjects.Length < menuItems.itemNames.Length || menuItems.returnObjects.Length > menuItems.itemNames.Length)
                {
                    Diag.Violation("The length of the arrays for each return object and each menu item name are mismatched.");
                    return;
                }

                if (EditorGUILayout.DropdownButton(new GUIContent(Icon(Iconography.MOREV), tooltip), FocusType.Passive, style, options))
                {
                    GenericMenu menu = new GenericMenu();
                    
                    for (int i = 0; i < menuItems.itemNames.Length; i++)
                    {
                        menu.AddItem(new GUIContent(menuItems.itemNames[i]), comparator(i), onClicked, menuItems.returnObjects[i]);
                    }

                    menu.ShowAsContext();
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a Dropdown Menu button (and it's following Menu Items) automatically. <br></br><br></br>
            /// <b><i><see langword="Notice:"/> This uses integer-based item selection. You will have to convert the result provided through onClicked by-hand to the intended value, be it through array looping or such.</i></b> <br></br><br></br>
            /// Tags: <b><i><see langword="[Advanced-Feature], [Technical]"/> </i></b>
            /// </summary>
            /// <param name="label">The GUIContent to show for the button.</param>
            /// <param name="style">The GUIStyle to draw with.</param>
            /// <param name="menuItems">The objects and their names to add to the menu.</param>
            /// <param name="comparator">The boolean comparator (that compares the selected integer</param>
            /// <param name="onClicked">The delegate to use when an option is clicked <br></br> <b><see langword="Notice:"/></b> The only permitted parameter of this method is a System.Object value.</param>
            /// <param name="options">The layout options to use when drawing the editor window.</param>
            public static void Dropdown(GUIContent label, GUIStyle style, (string[] itemNames, object[] returnObjects) menuItems, BoolComparator comparator, GenericMenu.MenuFunction2 onClicked, params GUILayoutOption[] options)
            {
                // Prevent inconsistent or mismatched item lists.
                // Provide Warnings for each.
                if (menuItems == (null, null))
                {
                    Diag.Violation("Dropdown has no menu items.");
                    return;
                }
                if (menuItems.returnObjects == null || menuItems.returnObjects.Length < 1)
                {
                    Diag.Violation("Dropdown menu items has no return object(s) for it's menu item(s).");
                    return;
                }
                if (menuItems.itemNames == null || menuItems.itemNames.Length < 1)
                {
                    Diag.Violation("Dropdown menu items has no item name(s) for it's menu item(s).");
                    return;
                }
                if (menuItems.returnObjects.Length < menuItems.itemNames.Length || menuItems.returnObjects.Length > menuItems.itemNames.Length)
                {
                    Diag.Violation("The length of the arrays for each return object and each menu item name are mismatched.");
                    return;
                }

                if (EditorGUILayout.DropdownButton(label, FocusType.Passive, style, options))
                {
                    GenericMenu menu = new GenericMenu();

                    for (int i = 0; i < menuItems.itemNames.Length; i++)
                    {
                        menu.AddItem(new GUIContent(menuItems.itemNames[i]), comparator(i), onClicked, menuItems.returnObjects[i]);
                    }

                    menu.ShowAsContext();
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a Dropdown Menu button (and it's following Menu Items) automatically. <br></br><br></br>
            /// <b><i><see langword="Notice:"/> This uses integer-based item selection. You will have to convert the result provided through onClicked by-hand to the intended value, be it through array looping or such.</i></b> <br></br><br></br>
            /// Tags: <b><i><see langword="[Advanced-Feature], [Technical]"/> </i></b>
            /// </summary>
            /// <param name="position">The Rect Position to draw items</param>
            /// <param name="tooltip">The tooltip to show.</param>
            /// <param name="menuItems">The objects and their names to add to the menu.</param>
            /// <param name="comparator">The boolean comparator (that compares the selected integer</param>
            /// <param name="onClicked">The delegate to use when an option is clicked <br></br> <b><see langword="Notice:"/></b> The only permitted parameter of this method is a System.Object value.</param>
            public static void Dropdown(Rect position, string tooltip, (string[] itemNames, object[] returnObjects) menuItems, BoolComparator comparator, GenericMenu.MenuFunction2 onClicked)
            {
                // Prevent inconsistent or mismatched item lists.
                // Provide Warnings for each.
                if (menuItems == (null, null))
                {
                    Diag.Violation("Dropdown has no menu items.");
                    return;
                }
                if (menuItems.returnObjects == null || menuItems.returnObjects.Length < 1)
                {
                    Diag.Violation("Dropdown menu items has no return object(s) for it's menu item(s).");
                    return;
                }
                if (menuItems.itemNames == null || menuItems.itemNames.Length < 1)
                {
                    Diag.Violation("Dropdown menu items has no item name(s) for it's menu item(s).");
                    return;
                }
                if (menuItems.returnObjects.Length < menuItems.itemNames.Length || menuItems.returnObjects.Length > menuItems.itemNames.Length)
                {
                    Diag.Violation("The length of the arrays for each return object and each menu item name are mismatched.");
                    return;
                }

                if (EditorGUI.DropdownButton(position, new GUIContent(Icon(Iconography.MOREV), tooltip), FocusType.Passive))
                {
                    GenericMenu menu = new GenericMenu();

                    for (int i = 0; i < menuItems.itemNames.Length; i++)
                    {
                        menu.AddItem(new GUIContent(menuItems.itemNames[i]), comparator(i), onClicked, menuItems.returnObjects[i]);
                    }

                    menu.ShowAsContext();
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a Dropdown Menu button (and it's following Menu Items) automatically. <br></br><br></br>
            /// <b><i><see langword="Notice:"/> This uses integer-based item selection. You will have to convert the result provided through onClicked by-hand to the intended value, be it through array looping or such.</i></b> <br></br><br></br>
            /// Tags: <b><i><see langword="[Advanced-Feature], [Technical]"/> </i></b>
            /// </summary>
            /// <param name="position">The Rect Position to draw items</param>
            /// <param name="label">The GUIContent to show for the button.</param>
            /// <param name="menuItems">The objects and their names to add to the menu.</param>
            /// <param name="comparator">The boolean comparator (that compares the selected integer</param>
            /// <param name="onClicked">The delegate to use when an option is clicked <br></br> <b><see langword="Notice:"/></b> The only permitted parameter of this method is a System.Object value.</param>
            public static void Dropdown(Rect position, GUIContent label, (string[] itemNames, object[] returnObjects) menuItems, BoolComparator comparator, GenericMenu.MenuFunction2 onClicked)
            {
                // Prevent inconsistent or mismatched item lists.
                // Provide Warnings for each.
                if (menuItems == (null, null))
                {
                    Diag.Violation("Dropdown has no menu items.");
                    return;
                }
                if (menuItems.returnObjects == null || menuItems.returnObjects.Length < 1)
                {
                    Diag.Violation("Dropdown menu items has no return object(s) for it's menu item(s).");
                    return;
                }
                if (menuItems.itemNames == null || menuItems.itemNames.Length < 1)
                {
                    Diag.Violation("Dropdown menu items has no item name(s) for it's menu item(s).");
                    return;
                }
                if (menuItems.returnObjects.Length < menuItems.itemNames.Length || menuItems.returnObjects.Length > menuItems.itemNames.Length)
                {
                    Diag.Violation("The length of the arrays for each return object and each menu item name are mismatched.");
                    return;
                }

                if (EditorGUI.DropdownButton(position, label, FocusType.Passive))
                {
                    GenericMenu menu = new GenericMenu();

                    for (int i = 0; i < menuItems.itemNames.Length; i++)
                    {
                        menu.AddItem(new GUIContent(menuItems.itemNames[i]), comparator(i), onClicked, menuItems.returnObjects[i]);
                    }

                    menu.ShowAsContext();
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a Dropdown Menu button (and it's following Menu Items) automatically. <br></br><br></br>
            /// <b><i><see langword="Notice:"/> This uses integer-based item selection. You will have to convert the result provided through onClicked by-hand to the intended value, be it through array looping or such.</i></b> <br></br><br></br>
            /// Tags: <b><i><see langword="[Advanced-Feature], [Technical]"/> </i></b>
            /// </summary>
            /// <param name="position">The Rect Position to draw items</param>
            /// <param name="tooltip">The tooltip to show.</param>
            /// <param name="style">The GUIStyle to draw with.</param>
            /// <param name="menuItems">The objects and their names to add to the menu.</param>
            /// <param name="comparator">The boolean comparator (that compares the selected integer</param>
            /// <param name="onClicked">The delegate to use when an option is clicked <br></br> <b><see langword="Notice:"/></b> The only permitted parameter of this method is a System.Object value.</param>
            public static void Dropdown(Rect position,string tooltip, GUIStyle style, (string[] itemNames, object[] returnObjects) menuItems, BoolComparator comparator, GenericMenu.MenuFunction2 onClicked)
            {
                // Prevent inconsistent or mismatched item lists.
                // Provide Warnings for each.
                if (menuItems == (null, null))
                {
                    Diag.Violation("Dropdown has no menu items.");
                    return;
                }
                if (menuItems.returnObjects == null || menuItems.returnObjects.Length < 1)
                {
                    Diag.Violation("Dropdown menu items has no return object(s) for it's menu item(s).");
                    return;
                }
                if (menuItems.itemNames == null || menuItems.itemNames.Length < 1)
                {
                    Diag.Violation("Dropdown menu items has no item name(s) for it's menu item(s).");
                    return;
                }
                if (menuItems.returnObjects.Length < menuItems.itemNames.Length || menuItems.returnObjects.Length > menuItems.itemNames.Length)
                {
                    Diag.Violation("The length of the arrays for each return object and each menu item name are mismatched.");
                    return;
                }

                if (EditorGUI.DropdownButton(position, new GUIContent(Icon(Iconography.MOREV), tooltip), FocusType.Passive, style))
                {
                    GenericMenu menu = new GenericMenu();

                    for (int i = 0; i < menuItems.itemNames.Length; i++)
                    {
                        menu.AddItem(new GUIContent(menuItems.itemNames[i]), comparator(i), onClicked, menuItems.returnObjects[i]);
                    }

                    menu.ShowAsContext();
                }
            }

            /// <summary>
            /// <see langword="Cappuccino:"/> Draw a Dropdown Menu button (and it's following Menu Items) automatically. <br></br><br></br>
            /// <b><i><see langword="Notice:"/> This uses integer-based item selection. You will have to convert the result provided through onClicked by-hand to the intended value, be it through array looping or such.</i></b> <br></br><br></br>
            /// Tags: <b><i><see langword="[Advanced-Feature], [Technical]"/> </i></b>
            /// </summary>
            /// <param name="position">The Rect Position to draw items</param>
            /// <param name="label">The GUIContent to show for the button.</param>
            /// <param name="style">The GUIStyle to draw with.</param>
            /// <param name="menuItems">The objects and their names to add to the menu.</param>
            /// <param name="comparator">The boolean comparator (that compares the selected integer</param>
            /// <param name="onClicked">The delegate to use when an option is clicked <br></br> <b><see langword="Notice:"/></b> The only permitted parameter of this method is a System.Object value.</param>
            public static void Dropdown(Rect position, GUIContent label, GUIStyle style, (string[] itemNames, object[] returnObjects) menuItems, BoolComparator comparator, GenericMenu.MenuFunction2 onClicked)
            {
                // Prevent inconsistent or mismatched item lists.
                // Provide Warnings for each.
                if (menuItems == (null, null))
                {
                    Diag.Violation("Dropdown has no menu items.");
                    return;
                }
                if (menuItems.returnObjects == null || menuItems.returnObjects.Length < 1)
                {
                    Diag.Violation("Dropdown menu items has no return object(s) for it's menu item(s).");
                    return;
                }
                if (menuItems.itemNames == null || menuItems.itemNames.Length < 1)
                {
                    Diag.Violation("Dropdown menu items has no item name(s) for it's menu item(s).");
                    return;
                }
                if (menuItems.returnObjects.Length < menuItems.itemNames.Length || menuItems.returnObjects.Length > menuItems.itemNames.Length)
                {
                    Diag.Violation("The length of the arrays for each return object and each menu item name are mismatched.");
                    return;
                }

                if (EditorGUI.DropdownButton(position, label, FocusType.Passive, style))
                {
                    GenericMenu menu = new GenericMenu();

                    for (int i = 0; i < menuItems.itemNames.Length; i++)
                    {
                        menu.AddItem(new GUIContent(menuItems.itemNames[i]), comparator(i), onClicked, menuItems.returnObjects[i]);
                    }

                    menu.ShowAsContext();
                }
            }
        }
    }
}   