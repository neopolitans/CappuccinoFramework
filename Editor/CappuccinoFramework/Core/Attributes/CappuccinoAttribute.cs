using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

using System;
using System.Reflection;


// This script has the base attribute class for all Cappuccino Attributes.
// This is a simple attribute meant to act as a filter between System.Attribute and any attribute inheriting from this.
// It also includes a virtual EXECUTE void for InitializeOnLoad to work.

// I decided to add these after months of trying to do so on other projects.
// I really disliked how undescriptive [Obsolete()] is for the situations where I needed to mark specific, special information.

namespace Cappuccino
{
    namespace Attributes 
    {
        /// <summary>
        /// <see langword="Cappuccino:"/> The base attribute which all attributes in Cappuccino Editor Framework uses to attach metadata to and execute on Unity Engine loading or after script compilation. <br></br><br></br>
        /// <see langword="Notice:"/> Any inheriting attribute of this attribute stored in it's own script is denoted with "CA" prefixed to the main name, standing for "Cappuccino Attribute". <br></br>
        /// When adding your own attributes to the core, it is advised to follow this nomencalture.
        /// </summary>
        public class CappuccinoAttribute : Attribute 
        {
            /// <summary>
            /// Whether or not to call this method on InitializeOnLoad.
            /// </summary>
            public bool doNotCallOnLoad = false;

            /// <summary>
            /// Does this attribute need to know if any methods call it in order to function? <br></br><br></br>
            /// <i><b><see langword="Notice:"/> If set to true, any attribute requiring this behaviour is called during the last stage in the order of execution.</b></i> <br></br>
            /// Due to the requirement that all methods in the project assembly are disassembled and analysed to find any calls to the method attached, this is executed last.<br></br><br></br>
            /// <see langword="Cappuccino:"/> This is set on attribute construction as it determines whether or not the Attribute Executor must call the Execute(MemberInfo) or Execute(MethodInfo) <br></br>
            /// methods attached with either the MethodInfo object of the attached method or the MethodInfo object of the method(s) that call the method.
            /// </summary>
            public bool needsCILCallerInsight = false;

            /// <summary>
            /// What type of information ("insight") this attirbute needs when it is executed. <br></br><br></br>
            /// <see langword="Cappuccino:"/> If a member needs no insight, <b>Execute()</b> will be called.<br></br>
            /// If it needs generic member insight, <b>Execute(<see cref="MemberInfo"/>)</b> will be called. <br></br>
            /// If it needs method member insight, <b>Execute(<see cref="MethodInfo"/>)</b> will be called.
            /// </summary>
            public InsightRequirement insightLevel = InsightRequirement.None;

            /// <summary>
            /// Execute any code related to the attribute. 
            /// </summary>
            public virtual void Execute() { }

            /// <summary>
            /// Execute any code related to the attribute, passing in the calling member or the member attached to this attribute instance.
            /// </summary>
            /// <param name="attachedMember">The member in the project assembly with this attribute attached.</param>
            public virtual void Execute(MemberInfo attachedMember) { }

            /// <summary>
            /// Execute any code related to the attribute, passing in the calling method or the method attached to this attribute instance.
            /// </summary>
            /// <param name="attachedMethod">The calling method or the method attached to the attribute instance.</param>
            public virtual void Execute(MethodInfo attachedMethod) { }

            /// <summary>
            /// Execute any code related to the attribute, passing in the member attached to this attribute and the member calling the attached member.
            /// </summary>
            /// <param name="self">The member attached to this attribute instance.</param>
            /// <param name="caller">The member that called the attached member.</param>
            public virtual void Execute(MemberInfo self, MemberInfo caller) { }

            /// <summary>
            /// Execute any code related to the attribute, passing in the method attached to this attribute and the method calling the attached method.
            /// </summary>
            /// <param name="self">The method attached to this attribute instance.</param>
            /// <param name="caller">The method that called the attached method.</param>
            public virtual void Execute (MethodInfo self, MethodInfo caller) { }
        };
    }
}