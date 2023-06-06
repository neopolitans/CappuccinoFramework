// This script contains the CompilerLoggingStates enumerator.

namespace Cappuccino
{
    namespace Attributes
    {
        /// <summary>
        /// Which way to display the message attached to the attribute instance.
        /// </summary>
        public enum CompilerLoggingStates
        {
            /// <summary>
            /// Do not display the message.
            /// </summary>
            None,

            /// <summary>
            /// Display the contained message as a log message.
            /// </summary>
            Log,

            /// <summary>
            /// Display the contained message as a log warning.
            /// </summary>
            Warn,

            /// <summary>
            /// Display the contained message as a log error.
            /// </summary>
            Error
        }
    }
}