using SevenZip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PackedFileSearcher.Searchers
{
    public class SevenZipSearcher : ISearcher
    {
        /// <summary>
        /// Text to be shown in the OpenFileDialog
        /// </summary>
        public string ExtensionText => "7Zip files (*.7z;*.xz;*.gz;*.bz;*.bz2;*.tar;*.sfx;*.rar;*.iza;*.iso) | *.7z;*.xz;*.gz;*.bz;*.bz2;*.tar;*.sfx;*.rar;*.iso";

        /// <summary>
        /// Path of this certain package
        /// </summary>
        public string Path { get; protected set; }

        /// <summary>
        /// If the package is damaged, this is to be set to true
        /// </summary>
        public Boolean Error { get; private set; } = false;

        public SevenZipSearcher()
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
                SevenZipBase.SetLibraryPath("3rdParty" + System.IO.Path.DirectorySeparatorChar + "7z.dll");
                SevenZipExtractor extr = new SevenZipExtractor(Path);

                foreach (ArchiveFileInfo entry in extr.ArchiveFileData)
                {

                    if (Regex.IsMatch(entry.FileName, Utils.WildCardToRegular(pattern)) && (!entry.IsDirectory || Properties.Settings.Default.SearchInDirs))
                        MatchingEntries.Add(new SearchResultInstance(this, Path, entry.FileName, System.IO.Path.GetFileName(entry.FileName), entry.Size, entry.LastWriteTime, entry.IsDirectory));
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
                SevenZipBase.SetLibraryPath("3rdParty" + System.IO.Path.DirectorySeparatorChar + "7z.dll");
                using (SevenZipExtractor extr = new SevenZipExtractor(Path))
                        extr.ExtractFiles(savePath, s.FolderPath);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
