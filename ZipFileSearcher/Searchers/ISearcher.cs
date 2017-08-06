using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipFileSearcher.Searchers
{
    public interface ISearcher
    {
        /// <summary>
        /// Returns a list of all results we've got
        /// </summary>
        /// <param name="paths">Search path</param>
        /// <param name="pattern">Search string</param>
        /// <returns>List of all SearchResults</returns>
        List<SearchResultInstance> Search(string pattern);

        /// <summary>
        /// Extracts a found file
        /// </summary>
        /// <param name="s">Instance of the search result</param>
        /// <returns></returns>
        bool extractFile(SearchResultInstance s);

        /// <summary>
        /// Text to be shown on "file choose.." dialog
        /// </summary>
        string ExtensionText { get; }

        /// <summary>
        /// Path to file
        /// </summary>
        string Path { get; }
    }
}
