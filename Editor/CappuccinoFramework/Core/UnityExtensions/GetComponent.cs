using UnityEngine;

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> This namespace contains mostly methods found within Unity namespaces (and packages) that are extremely useful. <br></br><br></br>
        /// <b><see langword="Notice:"/></b> Any methods provided through this namespace are often not explicitly created by the author(s) of Cappuccino, instead being authored (or originating from) Unity. <br></br>
        /// They are provided for future backwards-compatibility with older versions of Unity Engine. <br></br><br></br>
        /// <b>The original source is cited within XML documentation for each module included.</b> <br></br>
        /// <i>It is not advised, for various reasons, to extract these methods yourself.</i>
        /// </summary>
        public static partial class Unity
        {
            /// <summary>
            /// Try get a component from an Object. If the object is not a GameObject or Component object, this will fail. <br></br><br></br>
            /// <b><see langword="Source:"/> <see href="https://docs.unity3d.com/Packages/com.unity.visualscripting@1.5/api/Unity.VisualScripting.ComponentHolderProtocol.html">Unity.VisualScripting.ComponentHolderProtocol</see></b> (Unity Engine 2021.1 or newer)
            /// </summary>
            /// <param name="obj">The object to try find the specified component within.</param>
            /// <param name="type">The component type to try find.</param>
            /// <returns></returns>
            public static Component GetComponent(this Object obj, System.Type type)
            {
                if (obj is GameObject)
                {
                    return ((GameObject)obj).GetComponent(type);
                }
                else if (obj is Component)
                {
                    return ((Component)obj).GetComponent(type);
                }
                else
                {
                    Diag.Violation("The Object you have provided to be serialized is not a compatible type.", 3);
                    return null;
                }
            }
        }
    }
}