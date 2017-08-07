
namespace PackedFileSearcher.Enums
{
    // Attention! All types listet here _have_ to exist!
    public enum SearcherType 
    {
        None,
        ZipFile,
        SevenZip
    }

    public static class SearcherTypeHelper
    {
        public static SearcherType ExtensionToSearcherType(string ext)
        {
            switch (ext)
            {
                case ".zip":
                    return SearcherType.ZipFile;
                case ".7z":
                    return SearcherType.SevenZip;
                default:
                    return SearcherType.None;
            }
        }
    }
}
