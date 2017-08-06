
namespace ZipFileSearcher.Enums
{
    // Attention! All types listet here _have_ to exist!
    public enum SearcherType 
    {
        ZipFile,
        SevenZip,
        Rar
    }

    public static class SearcherTypeHelper
    {
        public static SearcherType ExtensionToSearcherType(string ext)
        {
            switch (ext)
            {
                case ".7z":
                    return SearcherType.SevenZip;
                case ".rar":
                    return
                        SearcherType.Rar;
                case ".zip":
                    return SearcherType.ZipFile;
                default:
                    throw new System.NotImplementedException();
            }
        }
    }
}
