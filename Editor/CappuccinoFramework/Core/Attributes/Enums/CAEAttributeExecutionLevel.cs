// This script contains the AttributeExecutionLevel enumerator.

namespace Cappuccino
{
    namespace Attributes
    { 
        public enum AttributeExecutionLevel
        {
            /// <summary>
            /// Do not execute any attributes.
            /// </summary>
            None = 0,

            /// <summary>
            /// Execute simple attributes only. <br></br>
            /// They require either no or self insight during execution.
            /// </summary>
            Simple = 1,

            /// <summary>
            /// Execute all attributes. <br></br>
            /// These require anything from no insight to direct insight into how other methods are calling them.
            /// </summary>
            Full = 2
        }
    }
}
