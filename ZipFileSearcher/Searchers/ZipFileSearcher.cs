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

        public ISearcher WithPath(string path)
        {
            Path = path;
            return this;
        }

        public List<SearchResultInstance> Search(string pattern)
        {
            List<SearchResultInstance> MatchingEntries = new List<SearchResultInstance>();

            try
            {
                using (ZipArchive zip = ZipFile.Open(Path, ZipArchiveMode.Read))

                    foreach (ZipArchiveEntry entry in zip.GetRawEntries())
                    {

                        if (Regex.IsMatch(entry.Name, Utils.WildCardToRegular(pattern)))
                            MatchingEntries.Add(new SearchResultInstance(Path, entry.FullName, entry.Name));
                    }

            }
            catch (Exception)
            {
                Error = true;
                return MatchingEntries;
            }
            return MatchingEntries;
        }

        public bool extractFile(SearchResultInstance s)
        {
            //entry.ExtractToFile("myfile");
            throw new NotImplementedException();
        }

    }
}
