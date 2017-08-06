using System;
using System.Collections.Generic;
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
}