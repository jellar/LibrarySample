﻿namespace Library.Core.Helpers
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
    }
}
