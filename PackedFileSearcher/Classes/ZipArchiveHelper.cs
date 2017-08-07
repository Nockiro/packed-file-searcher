using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PackedFileSearcher
{
    //
    // Workaround Entries Collection in ZipArchive
    // (C)2015 Ramon Ordiales
    // see: https://www.codeproject.com/Tips/1007398/Avoid-Illegal-Characters-in-Path-error-in-ZipArchi
    //

    public static class ZipArchiveHelper
    {
        private static FieldInfo _Entries;
        private static MethodInfo _EnsureDirRead;

        static ZipArchiveHelper()
        {
            _Entries = typeof(ZipArchive).GetField("_entries", BindingFlags.NonPublic | BindingFlags.Instance);
            _EnsureDirRead = typeof(ZipArchive).GetMethod("EnsureCentralDirectoryRead", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public static List<ZipArchiveEntry> GetRawEntries(this ZipArchive archive)
        {
            try { _EnsureDirRead.Invoke(archive, null); } catch { }
            return (List<ZipArchiveEntry>)_Entries.GetValue(archive);
        }
    }
}
