// <copyright file="Util.cs" company="PrefixBox Ltd">
//     Copyright (c) PrefixBox Ltd. All rights reserved.
// </copyright>

using System;
using System.Text.RegularExpressions;

namespace AOC2020
{
    public class Util
    {
        public static bool IsRegexMatch(string field, string regex)
        {
            var r = new Regex(regex);
            return r.IsMatch(field);
        }

        public static bool IsNumberBetween(string numAsString, int min, int max)
        {
            if (!Int32.TryParse(numAsString, out var num))
                return false;

            return num <= max && num >= min;
        }
    }
}
