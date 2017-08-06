using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZipFileSearcher.Enums;

namespace ZipFileSearcher.Searchers
{
    public class Searcher
    {

        public static String ExtensionText
        {
            get
            {
                return Utils.GetValues<SearcherType>().Select(t => GetSearcher(t).ExtensionText).Aggregate((i, j) => i + "|" + j);
            }
        }

        public static ISearcher GetSearcher(SearcherType type)
        {
            switch (type)
            {
                case SearcherType.ZipFile:
                default:
                    return new ZipFileSearcher();
            }
        }
    }
}
