using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

using UnityEditor.Experimental.GraphView;

using Cappuccino.Core;
using Cappuccino.Interpreters.Languages.USS;

namespace Cappuccino
{
    namespace Graphing
    {
        /// <summary>
        /// A class deriving from the <see cref="NodePort"/> type for nodes. <br></br> 
        /// Used for defining a node connection to pass data through <br></br><br></br>
        /// This port sub-class exists for GetCompatiblePorts and port filtering.
        /// </summary>
        public partial class DataPort : NodePort
        {
            // Thanks to user743382, I found out a means of using a type in a switch statement:
            // I'm aware it's not particularly as readable sometimes but it's extremely helpful.
            // Additionally, it's helpful to know that `when` exists as a case guard.

            // Sources: (Accessed: 15 April 2023)
            //      https://stackoverflow.com/a/43080709
            //      https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/when
            //      https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression#case-guards

            public void AddEntryFieldSheets()
            {
                // Unused - Unity provides custom images that contain their own highlights which can't be overridden.
                //styleSheets.Add(AssetLoader.GetStyleSheet("Core/UIToolkit/GraphWindow/StyleSheets/GenericFields/CappuccinoBooleanField"));


            }

            /// <summary>
            /// Create a data entry field for the data port.
            /// </summary>
            public virtual void CreateField()
            {
                if (connected) { return; } // Cannot be created if a prior connection exists.

                switch (DataType)
                {
                    case Type boolean when boolean == typeof(bool):
                        m_EntryField = new Toggle();

                        ((Toggle)m_EntryField).RegisterValueChangedCallback(delegate (ChangeEvent<bool> evt)
                        {
                            value = evt.newValue;
                            lastFieldValue = value;
                        });

                        m_EntryField.AddToClassList("cappuccino-field__toggle-field");

                        Add(m_EntryField);
                        break;

                    case Type str when str == typeof(string):
                        m_EntryField = new TextField();

                        ((TextField)m_EntryField).RegisterValueChangedCallback(delegate (ChangeEvent<string> evt)
                        {
                            value = evt.newValue;
                            lastFieldValue = value;
                        });

                        m_EntryField.AddToClassList("cappuccino-field__text-field");

                        Add(m_EntryField);
                        break;

                }
            }
        }
    }
}