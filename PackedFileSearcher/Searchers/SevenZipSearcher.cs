﻿using PackedFileSearcher.Enums;
using SevenZip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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
        /// <param name="depth">Current depth of archive extraction</param>
        /// <returns>List with search results of entries</returns>
        public List<SearchResultInstance> Search(string pattern, int depth = 0)
        {
            List<SearchResultInstance> MatchingEntries = new List<SearchResultInstance>();

            try
            {
                SevenZipExtractor extr = new SevenZipExtractor(Path);

                foreach (ArchiveFileInfo entry in extr.ArchiveFileData)
                {

                    // if either the file name matches the pattern or, if SearchInDirs is enabled, the path includes the pattern somewhere 
                    if (Regex.IsMatch(System.IO.Path.GetFileName(entry.FileName), Utils.WildCardToRegular(pattern)) &&
                        (!entry.IsDirectory || (entry.IsDirectory && Properties.Settings.Default.SearchInDirs && Regex.IsMatch(entry.FileName, Utils.WildCardToRegular(pattern)))))
                        MatchingEntries.Add(new SearchResultInstance(this, Path, entry.FileName, System.IO.Path.GetFileName(entry.FileName), entry.Size, entry.LastWriteTime, entry.IsDirectory));

                    // if the current entry is an archive, check if we have a searcher for it and search through it to the depth given in the settings
                    if (Properties.Settings.Default.RecursiveArchiveDepth > 0 && SearcherTypeHelper.GetSearcherFromPath(entry.FileName) != SearcherType.None)
                    {
                        string tempFileName = System.IO.Path.Combine(Program.tempPath, System.IO.Path.GetFileNameWithoutExtension(Utils.NextAvailableFilename(Path, true)), entry.FileName);

                        using (FileStream archiveStream = File.Create(tempFileName))
                        {
                            extr.ExtractFile(tempFileName, archiveStream);
                            ISearcher tempSearcher = Searcher.GetSearcher(SearcherTypeHelper.GetSearcherFromPath(entry.FileName));

                            foreach (SearchResultInstance si in tempSearcher.WithPath(tempFileName).Search(pattern, depth + 1))
                                MatchingEntries.Add(si);
                        }

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
                using (SevenZipExtractor extr = new SevenZipExtractor(Path))
                    if (s.IsDir)
                    {
                        extr.ExtractFiles(savePath, extr.ArchiveFileData.Where(archiveFileInfo => archiveFileInfo.FileName.StartsWith(s.FolderPath)).Select(t => t.Index).ToArray());

                    }
                    else
                    {
                        using (FileStream fs = new FileStream(savePath, FileMode.Create))  //replace empty string with desired destination
                        {
                            extr.ExtractFile(s.FolderPath, fs);
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
