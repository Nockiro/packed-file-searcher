using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public static class Utils
{
    public static IEnumerable<T> GetValues<T>()
    {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }

    // If you want to implement both "*" and "?"
    public static String WildCardToRegular(String value)
    {
        return "^" + Regex.Escape(value).Replace("\\?", ".").Replace("\\*", ".*") + "$";
    }

    // If a thread or background worker requests a cancellation, it's important for the user experience to softly cancel it..
    // Yes, it's no clean programming, but it does the work
    public static Boolean CancellationOfSearchPending = false;
    public static (Boolean errorOccured, List<string> results) SearchDirectory(string sDir, Boolean errorOccured = false, Boolean ListenToCancelRequest = true)
    {
        Boolean ErrorOccured = errorOccured;
        List<string> files = new List<string>();

        try
        {
            foreach (string f in Directory.GetFiles(sDir))
                files.Add(f);

            foreach (string d in Directory.GetDirectories(sDir))
            {
                if (ListenToCancelRequest && CancellationOfSearchPending)
                {
                    CancellationOfSearchPending = false;
                    return (true, files);
                }

                (Boolean errorOccured, List<string> results) search = SearchDirectory(d, ErrorOccured, ListenToCancelRequest);

                ErrorOccured = search.errorOccured || ErrorOccured;
                files.AddRange(search.results);
            }
        }
        catch (Exception excpt)
        {
            Console.WriteLine(excpt.Message);
            return (true, files);
        }

        return (ErrorOccured, files);
    }

    private static string numberPattern = " ({0})";

    public static string NextAvailableFilename(string path)
    {
        // Short-cut if already available
        if (!File.Exists(path))
            return path;

        // If path has extension then insert the number pattern just before the extension and return next filename
        if (Path.HasExtension(path))
            return GetNextFilename(path.Insert(path.LastIndexOf(Path.GetExtension(path)), numberPattern));

        // Otherwise just append the pattern to the path and return next filename
        return GetNextFilename(path + numberPattern);
    }

    private static string GetNextFilename(string pattern)
    {
        string tmp = string.Format(pattern, 1);
        if (tmp == pattern)
            throw new ArgumentException("The pattern must include an index place-holder", "pattern");

        if (!File.Exists(tmp))
            return tmp; // short-circuit if no matches

        int min = 1, max = 2; // min is inclusive, max is exclusive/untested

        while (File.Exists(string.Format(pattern, max)))
        {
            min = max;
            max *= 2;
        }

        while (max != min + 1)
        {
            int pivot = (max + min) / 2;
            if (File.Exists(string.Format(pattern, pivot)))
                min = pivot;
            else
                max = pivot;
        }

        return string.Format(pattern, max);
    }
}