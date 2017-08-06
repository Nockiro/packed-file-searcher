
namespace ZipFileSearcher.Enums
{
    // Attention! All types listet here _have_ to exist!
    public enum SearcherType 
    {
        None,
        ZipFile,
    }

    public static class SearcherTypeHelper
    {
        public static SearcherType ExtensionToSearcherType(string ext)
        {
            switch (ext)
            {
                case ".zip":
                    return SearcherType.ZipFile;
                default:
                    return SearcherType.None;
            }
        }
    }
}
