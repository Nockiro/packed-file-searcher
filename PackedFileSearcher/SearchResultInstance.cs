
using System;
using PackedFileSearcher.Searchers;

namespace PackedFileSearcher
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
        /// Size of the unpacked entry in the archive
        /// </summary>
        public ulong EntryLength { get; }

        /// <summary>
        /// Searcher Instance
        /// </summary>
        public ISearcher SearcherInstance { get; }

        /// <summary>
        /// Last time the file was written
        /// </summary>
        public DateTimeOffset LastWrite { get; }

        /// <summary>
        /// Represents a search result
        /// </summary>
        /// <param name="path">Path to the original archive, eg. C:\test\test.zip</param>
        /// <param name="insidePath">Path inside the zip, eg. Backup\99AirBaloons.txt</param>
        /// <param name="filename">File name</param>
        /// <param name="entryLength">Size of the unpacked entry in the archive</param>
        public SearchResultInstance(ISearcher si, string path, string insidePath, string filename, ulong entryLength, DateTimeOffset lastWrite)
        {
            SearcherInstance = si;
            PackagePath = path;
            FolderPath = insidePath;
            FileName = filename;
            EntryLength = entryLength;
            LastWrite = lastWrite;
        }

    }
}
