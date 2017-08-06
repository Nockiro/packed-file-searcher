using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipFileSearcher.Searchers
{
    public class ZipFileSearcher : ISearcher
    {
        public string ExtensionText => "Zip files (*.zip) | *.zip";

        public string Path { get; protected set; }

        public ZipFileSearcher()
        {
        }

        public ZipFileSearcher WithPath(string path)
        {
            Path = path;
            return this;
        }

        public List<SearchResultInstance> Search(string pattern)
        {
            List<SearchResultInstance> MatchingEntries = new List<SearchResultInstance>();

                using (ZipArchive zip = ZipFile.Open(Path, ZipArchiveMode.Read))
                    foreach (ZipArchiveEntry entry in zip.Entries)
                        if (entry.Name == "myfile")
                            MatchingEntries.Add(new SearchResultInstance(Path, entry.FullName));

            return MatchingEntries;
        }

        public bool extractFile(SearchResultInstance s)
        {
            //entry.ExtractToFile("myfile");
            throw new NotImplementedException();
        }

    }
}
