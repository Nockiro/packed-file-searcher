
using System.IO;

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
        public static SearcherType GetSearcherFromPath(string filepath)
        {
            // for standard zip files, use the faster and more lightweight zip file searcher
            if (System.IO.Path.GetExtension(filepath) == ".zip")
                return SearcherType.ZipFile;

            try
            {
                // if this method doesn't throw an exception, the file extension is valid
                SevenZip.Formats.FormatByFileName(filepath, true);
                return SearcherType.SevenZip;
            }
            catch (System.ArgumentException)
            {
                // if we couldn't get a result from the extension, try the file signature
                try
                {
                    new SevenZip.SevenZipExtractor(File.OpenRead(filepath));

                    return SearcherType.SevenZip;
                }
                catch
                {
                    return SearcherType.None;
                }
            }
        }
    }
}
