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
        /// <see langword="Cappuccino:"/> Default Settings for CEditor Editor Windows. <br></br>
        /// </summary>
        public static class WindowUtilities
        {
            /// <summary>
            /// <see langword="Cappuccino:"/> The default minimum size for an Editor Window.
            /// </summary>
            public static readonly Vector2 minSize = new Vector2(384f, 512f);

            /// <summary>
            /// <see langword="Cappuccino:"/> <b>Unused.</b> For a future extension of CEditor which uses an automated error-handling method for Panel Drawing involving Lists.
            /// </summary>
            public const int defaultPanel = 0;

            /// <summary>
            /// <see langword="Cappuccino:"/> The default header size used for some method overloads of CHeader header styles.
            /// </summary>
            public const float defaultHeaderSize = 16f;
        }
    }
}