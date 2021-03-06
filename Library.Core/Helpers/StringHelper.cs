using System;
using System.Text.RegularExpressions;

namespace Library.Core.Helpers
{
    public static class StringHelper
    {
        public static string StringCapitalize(this string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;
            return str.Length == 1
                ? char.ToUpper(str[0]).ToString()
                : string.Format(char.ToUpper(str[0]) + str.Substring(1));
        }

        public static string RemovePunctuations(this string str)
        {
            return Regex.Replace(str,  @"[\W_-[\s]]+", "");
        }

        public static string[] SplitWords(this string str)
        {
            var delimiters = new[] { ' ', '\r', '\n' };
            return str.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
