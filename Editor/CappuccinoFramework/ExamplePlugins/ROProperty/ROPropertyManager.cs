using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using UnityEditor;
using Cappuccino.Core;

namespace ROProperty
{
    /// <summary>
    /// A Manager that tracks elements of the RoProperty window.
    /// </summary>
    public static class RoPropertyManager
    {
        public static RoProperty wnd;
        public static CAssetLoader assetHandler = new CAssetLoader(FrameworkUtilities.defaultDirectory + "Assets/");
    }
}