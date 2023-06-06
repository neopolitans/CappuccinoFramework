using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

using Cappuccino.Core;
using Cappuccino.Attributes;

namespace Cappuccino
{
    namespace Interpreters
    {
        namespace Languages
        {
            namespace USS
            { 
                /// <summary>
                /// <see langword="Cappuccino:"/> An Enumerator denoting the specification compliancy of any member in the USS Class. <br></br>
                /// Some compliancy levels are reserved for future use.
                /// </summary>
                public enum CSSLevel
                {
                    /// <summary>
                    /// Not compliant to any specification. Default value. <br></br>
                    /// </summary>
                    NC = 0x0,

                    /// <summary>
                    /// Represents USS, the CSS Level 3 superset developed by Unity Technologies. <br></br>
                    /// This is the base compliacny of all USS modules in Iroquois.
                    /// </summary>
                    USS = 0x1,

                    /// <summary>
                    /// Represents CSS Level 3 and any modules marked Level 3. <br></br>
                    /// A compliancy of CSS3 means it may feature CSS3 specific functions and compatibility is unknown. <br></br>
                    /// ExCSS (Unity's used importer/exporter) and Iroquois are known to support up to CSS3 but anything after is ambiguous.
                    /// </summary>
                    CSS3 = 0x2,

                    /// <summary>
                    /// Represents CSS Level 4 and any modules marked Level 4. <br></br>
                    /// Reserved for future use.
                    /// </summary>
                    CSS4 = 0x4,

                    /// <summary>
                    /// Represents CSS Level 5 and any modules marked Level 5. <br></br>
                    /// Reserved for future use.
                    /// </summary>
                    CSS5 = 0x8,

                    /// <summary>
                    /// Represents CSS Level 6 and any modules marked Level 6. <br></br>
                    /// Reserved for future use. W3C currently contains only <i>one</i> module specification in drafting stage for Level 6.
                    /// </summary>
                    CSS6 = 0x16
                }

                /// <summary>
                /// An attribute representing the compliancy level of an object contained within the USS namespace. <br></br>
                /// <see langword="Cappuccino:"/> This attribute does not get called on InitializeOnLoad via the AttributeExecutor.
                /// </summary>
                /// 
                [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
                public class CSSCompliancy : CappuccinoAttribute
                {
                    public CSSLevel level;

                    public CSSCompliancy(CSSLevel level)
                    {
                        this.level = level;

                        doNotCallOnLoad = true;
                        needsCILCallerInsight = false;
                    }
                }
            }
        }
    }
}