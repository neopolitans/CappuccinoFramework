// This script has the InsightRequirement enumerator.

namespace Cappuccino
{
    namespace Attributes
    {
        /// <summary>
        /// What information needs to be passed into the attribute for it to execute as intended? <br></br><br></br>
        /// <see langword="Cappuccino:"/> If <b>needsCILCallerInsight</b> is true, this affects what the attribute recieves from <see cref="AttributeExecutor"/> about the method's caller. <br></br>
        /// Otherwise, this affects what information the attribute recieves from <see cref="AttributeExecutor"/> about the method it is attached to.
        /// </summary>
        public enum InsightRequirement
        {
            /// <summary>
            /// This attribute needs no insight.
            /// </summary>
            None,

            /// <summary>
            /// This attribute requires knowledge of only the member it's attached to or it's calling member.
            /// </summary>
            Member,

            /// <summary>
            /// This attribute requires knowledge of only the method it's attached to or it's calling member.
            /// </summary>
            Method,

            /// <summary>
            /// This attribute requires knowledge of the attached member and the calling members(s). <br></br>
            /// Only for methods that need CIL Caller insight but not strictly method info.
            /// </summary>
            SelfAndCallerMembers,

            /// <summary>
            /// This attribute requires knowledge of the attached method and the calling method(s). <br></br>
            /// Only for methods that need CIL Caller insight.
            /// </summary>
            SelfAndCallerMethods
        }
    }
}