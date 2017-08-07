
using System.Collections.Generic;

namespace PackedFileSearcher.Searchers
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
        /// Extracts a found entry
        /// </summary>
        /// <param name="s">Instance of the search result</param>
        /// <param name="savePath">Path to be saved to</param>
        /// <returns>true if successful</returns>
        bool extract(SearchResultInstance s, string savePath);

        /// <summary>
        /// Used for setting the path if needed
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <returns>This</returns>
        ISearcher WithPath(string path);

        /// <summary>
        /// Text to be shown on "file choose.." dialog
        /// </summary>
        string ExtensionText { get; }

        /// <summary>
        /// Path to file
        /// </summary>
        string Path { get; }

        /// <summary>
        /// If the package is damaged, this is to be set to true
        /// </summary>
        bool Error { get; }
    }
}
