using System;
using System.Linq;
using PackedFileSearcher.Enums;

namespace PackedFileSearcher.Searchers
{
    public class Searcher
    {

        public static String ExtensionText
            => Utils.GetValues<SearcherType>().Select(t => GetSearcher(t).ExtensionText).Aggregate((i, j) => i + "|" + j);

        public static ISearcher GetSearcher(SearcherType type)
        {
            switch (type)
            {
                case SearcherType.ZipFile:
                    return new ZipFileSearcher();
                case SearcherType.SevenZip:
                default: // if there hasn't been a decision of which searcher to use, try sevenzip anyway
                    return new SevenZipSearcher();
            }
        }
    }
}
