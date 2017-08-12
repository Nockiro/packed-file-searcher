using PackedFileSearcher.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;

namespace PackedFileSearcher.Searchers
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
        /// <param name="depth">Current recursion depth</param>
        /// <returns>List with search results of entries</returns>
        public List<SearchResultInstance> Search(string pattern, int depth = 0)
        {
            List<SearchResultInstance> MatchingEntries = new List<SearchResultInstance>();

            try
            {
                using (ZipArchive zip = ZipFile.Open(Path, ZipArchiveMode.Read))

                    foreach (ZipArchiveEntry entry in zip.GetRawEntries())
                    {
                        Boolean isDir = false;

                        if (entry.FullName.EndsWith("/") && entry.Name == "")
                            isDir = true;

                        // if either the file name matches the pattern or, if SearchInDirs is enabled, the path includes the pattern somewhere 
                        if (Regex.IsMatch(entry.Name, Utils.WildCardToRegular(pattern)) || (isDir && Properties.Settings.Default.SearchInDirs && Regex.IsMatch(entry.FullName, Utils.WildCardToRegular(pattern))))
                            MatchingEntries.Add(new SearchResultInstance(this, Path, entry.FullName, entry.Name, (ulong)entry.Length, entry.LastWriteTime, isDir));

                        // if the current entry is an archive, check if we have a searcher for it and search through it to the depth given in the settings
                        if (Properties.Settings.Default.RecursiveArchiveDepth > 0 && SearcherTypeHelper.ExtensionToSearcherType(System.IO.Path.GetExtension(entry.Name)) != SearcherType.None)
                        {
                            string tempFileName = System.IO.Path.Combine(Program.tempPath, System.IO.Path.GetFileNameWithoutExtension(Utils.NextAvailableFilename(Path, true)), entry.Name);
                            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(tempFileName));

                            entry.ExtractToFile(tempFileName, true);
                            ISearcher tempSearcher = Searcher.GetSearcher(SearcherTypeHelper.ExtensionToSearcherType(System.IO.Path.GetExtension(entry.Name)));

                            foreach (SearchResultInstance si in tempSearcher.WithPath(tempFileName).Search(pattern, depth + 1))
                                MatchingEntries.Add(si);
                        }
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
                {
                    if (!s.IsDir)
                        foreach (ZipArchiveEntry entry in zip.GetRawEntries().Where(entry => entry.FullName == s.FolderPath))
                            entry.ExtractToFile(savePath);
                    else
                    {
                        var result = from currEntry in zip.GetRawEntries()
                                     where System.IO.Path.GetDirectoryName(currEntry.FullName) == System.IO.Path.GetDirectoryName(s.FolderPath)
                                     where !String.IsNullOrEmpty(currEntry.Name)
                                     select currEntry;


                        foreach (ZipArchiveEntry entry in result)
                        {
                            string endPath = System.IO.Path.Combine(savePath, entry.FullName);
                            if (!Directory.Exists(System.IO.Path.GetDirectoryName(endPath)))
                                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(endPath));
                            entry.ExtractToFile(endPath);
                        }
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
