
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
                case ".bz":
                case ".bz2":
                case ".gz":
                case ".xz":
                case ".tar":
                case ".wim":
                case ".rar":
                case ".sfx":
                case ".lzh":
                case ".iso":
                    return SearcherType.SevenZip;
                default:
                    return SearcherType.None;
            }
        }
    }
}
