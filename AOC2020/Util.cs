// <copyright file="Util.cs" company="PrefixBox Ltd">
//     Copyright (c) PrefixBox Ltd. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
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
            if (!int.TryParse(numAsString, out var num))
                return false;

            return num <= max && num >= min;
        }

        public static IEnumerable<T> GetGroups<T>(IEnumerable<string> lines, Func<T> init, Action<T, string> updateGroup) where T : class
        {
            var groups = new List<T>();
            var group = init();
            foreach (var line in lines)
            {
                if (line == "")
                {
                    groups.Add(group);
                    group = init();
                }
                else
                {
                    updateGroup(group, line);
                }
            }

            return groups;
        }
    }
}
