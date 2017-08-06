
using System.IO;
using System.Linq;

namespace ZipFileSearcher
{
    public static class Extensions
    {
        public static string removeInvalidPathChars(this string str)
        {
            string sanitizedFileNameChars = Path.GetInvalidFileNameChars().Aggregate(str, (current, c) => current.Replace(c.ToString(), string.Empty));
            return Path.GetInvalidPathChars().Aggregate(str, (current, c) => current.Replace(c.ToString(), string.Empty));
        }
    }
}
