using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipFileSearcher
{
    public class SearchResultInstance
    {
        /// <summary>
        /// Path to the original archive, eg. C:\test\test.zip
        /// </summary>
        public string PackagePath { get; }

        /// <summary>
        /// Path inside the zip, eg. Backup\99AirBaloons.txt
        /// </summary>
        public string FolderPath { get; }

        /// <summary>
        /// Represents a search result
        /// </summary>
        /// <param name="path">Path to the original archive, eg. C:\test\test.zip</param>
        /// <param name="insidePath">Path inside the zip, eg. Backup\99AirBaloons.txt</param>
        public SearchResultInstance(string path, string insidePath)
        {
            PackagePath = path;
            FolderPath = insidePath;
        }

    }
}
