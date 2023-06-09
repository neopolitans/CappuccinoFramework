using Cappuccino.Core;

namespace Cappuccino
{
    namespace Interpreters
    {
        namespace Languages
        {
            namespace USS
            {
                /// <summary>
                /// This class defines any and every supported style rule constructor currently known.
                /// </summary>
                public static partial class Rules
                {
                    /// <summary>
                    /// Create a Unity Paragraph Spacing Style Rule with a length value.
                    /// </summary>
                    public static StyleRule ParagraphSpacing(Len length)
                    {
                        if (length.isAuto)
                        {
                            Diag.Violation("-unity-paragraph-spacing rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.unityParagraphSpacing, length.ToString(), false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.unityParagraphSpacing, length.ToString());
                        }
                    }
                }
            }
        }
    }
}