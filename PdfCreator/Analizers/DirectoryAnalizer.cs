using System.Collections.Generic;
using System.IO;

namespace PdfCreator.Analizers
{
    public class DirectoryAnalizer
    {
        /// <summary>
        /// Directory analizer.
        /// </summary>
        /// <param name="targetDirectory">Target directory path.</param>
        public static IList<string> GetFileNames(string targetDirectory)
        {
            return Directory.GetFiles(targetDirectory);
        }
    }
}
