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
                /// An attribute that allows you to export a USS Selector as a style sheet using a static method. <br></br>
                /// <see langword="Cappuccino:"/> This attribute gets called InitializeOnLoad via Cappuccino's AttributeExecutor.
                /// </summary>
                /// 
                [AttributeUsage(AttributeTargets.Method)]
                public class ExportSelector : CappuccinoAttribute
                {
                    string fileName;
                    string fileSavePath;
                    bool overwriteExisitngFile;

                    public override void Execute(MethodInfo method)
                    {
                        // If the method is static and returns a style sheet, execute the method.
                        if (method.IsStatic)
                        {
                            if (method.ReturnType == typeof(USS.Selector) || (method.ReturnType.IsSubclassOf(typeof(USS.Selector)) && method.ReturnType != typeof(Pseudoclass)))
                            {
                                USS.Selector selector = (USS.Selector)method.Invoke(null, new object[] { });
                                selector.Export(fileName, fileSavePath, overwriteExisitngFile);
                            }
                            else
                            {
                                Diag.Violation("The method this attribute is attached to does not return an exportable selector (invalid type or a Pseudoclass). The USS Object Model cannot execute the exporter.");
                            }
                        }
                        else
                        {
                            Diag.Violation("The method this attribute is attached to is not static. The USS Object Model cannot execute the exporter.");
                        }
                    }

                    /// <summary>
                    /// Exprot a USS Selector as a style sheet to the designated filepath. <br></br><br></br>
                    /// <i><b><see langword="Notice:"/></b> If you want to ovewrite a style sheet file, add 'true' after the file path.</i>
                    /// </summary>
                    /// <param name="fileName">The name of the file that the USS Selector will be saved to as a style sheet.</param>
                    /// <param name="fileSavePath">The path, starting from the directory after 'Assets/' to save the file to.</param>
                    public ExportSelector(string fileName, string fileSavePath)
                    {
                        this.fileName = fileName;
                        this.fileSavePath = fileSavePath;
                        overwriteExisitngFile = false;

                        insightLevel = InsightRequirement.Method;
                    }

                    /// <summary>
                    /// Exprot a USS Selector as a style sheet to the designated filepath. <br></br><br></br>
                    /// <i><b><see langword="Notice:"/> This will overwrite an existing .uss file, if one exists.</b></i>
                    /// </summary>
                    /// <param name="fileName">The name of the file that the USS Selector will be saved to as a style sheet.</param>
                    /// <param name="fileSavePath">The path, starting from the directory after 'Assets/' to save the file to.</param>
                    /// <param name="overwriteExisitngFile">Whether or not to overwrite the existing file.</param>
                    public ExportSelector(string fileName, string fileSavePath, bool overwriteExisitngFile)
                    {
                        this.fileName = fileName;
                        this.fileSavePath = fileSavePath;
                        this.overwriteExisitngFile = overwriteExisitngFile;

                        insightLevel = InsightRequirement.Method;
                    }
                }
            }
        }
    }
}