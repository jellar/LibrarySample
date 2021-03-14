using System;
using System.Text.RegularExpressions;

namespace Library.Core.Helpers
{
    public static class StringHelper
    {
        public static string StringCapitalize(this string str)
        {
            if (str.Length == 0) return string.Empty;
            else if (str.Length == 1)
            {
                return char.ToUpper(str[0]).ToString();
            }
            return string.Format(char.ToUpper(str[0]) + str.Substring(1));
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
