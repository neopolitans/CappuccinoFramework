using System;
using System.Reflection;

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
                /// An attribute that allows you to export a Unity Style Sheet using a static method. <br></br>
                /// <see langword="Cappuccino:"/> This attribute gets called InitializeOnLoad via Cappuccino's AttributeExecutor.
                /// </summary>
                /// 
                [AttributeUsage(AttributeTargets.Method)]
                public class ExportSheet : CappuccinoAttribute
                {
                    string fileSavePath;
                    bool overwriteExisitngFile;

                    public override void Execute(MethodInfo method)
                    {
                        // If the method is static and returns a style sheet, execute the method.
                        if (method.IsStatic)
                        {
                            if (method.ReturnType == typeof(USS.Sheet))
                            {
                                USS.Sheet sheet = (USS.Sheet)method.Invoke(null, new object[] { });
                                sheet.Export(fileSavePath, overwriteExisitngFile);
                            }
                            else
                            {
                                Diag.Violation("The method this attribute is attached to does not return a StyleSheet. The USS Object Model cannot execute the exporter.");
                            }
                        }
                        else
                        {
                            Diag.Violation("The method this attribute is attached to is not static. The USS Object Model cannot execute the exporter.");
                        }
                    }

                    /// <summary>
                    /// Exprot a Unity Style Sheet to the designated filepath. <br></br><br></br>
                    /// <i><b><see langword="Notice:"/></b> If you want to ovewrite a style sheet file, add 'true' after the file path.</i>
                    /// </summary>
                    /// <param name="fileSavePath">The path, starting from the directory after 'Assets/' to save the file to.</param>
                    public ExportSheet(string fileSavePath)
                    {
                        this.fileSavePath = fileSavePath;
                        overwriteExisitngFile = false;

                        insightLevel = InsightRequirement.Method;
                    }

                    /// <summary>
                    /// Exprot a Unity Style Sheet to the designated filepath. <br></br><br></br>
                    /// <i><b><see langword="Notice:"/> This will overwrite an existing .uss file, if one exists.</b></i>
                    /// </summary>
                    /// <param name="fileSavePath">The path, starting from the directory after 'Assets/' to save the file to.</param>
                    /// <param name="overwriteExisitngFile">Whether or not to overwrite the existing file.</param>
                    public ExportSheet(string fileSavePath, bool overwriteExisitngFile)
                    {
                        this.fileSavePath = fileSavePath;
                        this.overwriteExisitngFile = overwriteExisitngFile;

                        insightLevel = InsightRequirement.Method;
                    }
                }
            }
        }
    }
}