using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

using System;
using System.Reflection;

// This script adds the [MethodNeedsRefining] Attribute.
// It adds an alert to the method, indicating that the method needs refining.

namespace Cappuccino
{
    namespace Attributes
    {
        [AttributeUsage(AttributeTargets.Method)]
        public class MethodNeedsRefiningAttribute : CappuccinoAttribute
        {
            public override void Execute(MethodInfo method)
            {
                Debug.LogWarning($"Method Needs Refining: {method.DeclaringType}.{method.Name}()");
            }

            public MethodNeedsRefiningAttribute()
            {
                needsCILCallerInsight = false;
                insightLevel = InsightRequirement.Method;
            }
        }
    }
}   