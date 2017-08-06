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

    public static (Boolean errorOccured, List<string> results) SearchDirectory(string sDir, Boolean errorOccured = false)
    {
        Boolean ErrorOccured = errorOccured;
        List<string> files = new List<string>();

        try
        {
            foreach (string f in Directory.GetFiles(sDir))
                files.Add(f);

            foreach (string d in Directory.GetDirectories(sDir))
            {
                (Boolean errorOccured, List<string> results) search = SearchDirectory(d, ErrorOccured);
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
}