
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
        /// File name
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Represents a search result
        /// </summary>
        /// <param name="path">Path to the original archive, eg. C:\test\test.zip</param>
        /// <param name="insidePath">Path inside the zip, eg. Backup\99AirBaloons.txt</param>
        public SearchResultInstance(string path, string insidePath, string filename)
        {
            PackagePath = path;
            FolderPath = insidePath;
            FileName = filename;
        }

    }
}
