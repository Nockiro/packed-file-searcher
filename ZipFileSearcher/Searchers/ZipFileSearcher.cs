using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;

namespace ZipFileSearcher.Searchers
{
    public class ZipFileSearcher : ISearcher
    {
        /// <summary>
        /// Text to be shown in the OpenFileDialog
        /// </summary>
        public string ExtensionText => "Zip files (*.zip) | *.zip";

        /// <summary>
        /// Path of this certain package
        /// </summary>
        public string Path { get; protected set; }

        /// <summary>
        /// If the package is damaged, this is to be set to true
        /// </summary>
        public Boolean Error { get; private set; } = false;

        public ZipFileSearcher()
        {
        }

        /// <summary>
        /// Set the given path for this searcher instance
        /// </summary>
        /// <param name="path">Path to archive</param>
        /// <returns>this</returns>
        public ISearcher WithPath(string path)
        {
            Path = path;
            return this;
        }

        /// <summary>
        /// Search in the given file for the given pattern
        /// </summary>
        /// <param name="pattern">String to be searched for</param>
        /// <returns>List with search results of entries</returns>
        public List<SearchResultInstance> Search(string pattern)
        {
            List<SearchResultInstance> MatchingEntries = new List<SearchResultInstance>();

            try
            {
                using (ZipArchive zip = ZipFile.Open(Path, ZipArchiveMode.Read))

                    foreach (ZipArchiveEntry entry in zip.GetRawEntries())
                    {

                        if (Regex.IsMatch(entry.Name, Utils.WildCardToRegular(pattern)))
                            MatchingEntries.Add(new SearchResultInstance(this, Path, entry.FullName, entry.Name, entry.Length));
                    }

            }
            catch (Exception)
            {
                Error = true;
                return MatchingEntries;
            }
            return MatchingEntries;
        }

        /// <summary>
        /// Extract a found entry
        /// </summary>
        /// <param name="s">Instance of the search result</param>
        /// <param name="savePath">Path to be saved to</param>
        /// <returns>True if successful</returns>
        public bool extract(SearchResultInstance s, string savePath)
        {
            try
            {
                using (ZipArchive zip = ZipFile.Open(Path, ZipArchiveMode.Read))
                    zip.GetRawEntries().Where(entry => entry.FullName == s.FolderPath).FirstOrDefault()?.ExtractToFile(savePath);

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
