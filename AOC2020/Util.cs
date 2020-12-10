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

        /// <summary>
        /// If string represents an integer and is in the given closed interval.
        /// </summary>
        public static bool IsNumberBetween(string numAsString, int min, int max)
        {
            if (!Int32.TryParse(numAsString, out var num))
                return false;

            return num <= max && num >= min;
        }

        /// <summary>
        /// Read <see cref="T"/> type objects (groups) separated by empty line in the input.
        /// </summary>
        /// <typeparam name="T">type to read</typeparam>
        /// <param name="lines">input lines</param>
        /// <param name="init">funtion to init group</param>
        /// <param name="updateGroup">funtion to update group</param>
        /// <returns>groups</returns>
        public static IEnumerable<T> GetGroups<T>(IEnumerable<string> lines, Func<T> init, Action<T, string> updateGroup) where T : class
        {
            var groups = new List<T>();
            var group = init();
            foreach (var line in lines)
            {
                if (line == "")
                {
                    groups.Add(@group);
                    @group = init();
                }
                else
                {
                    updateGroup(@group, line);
                }
            }

            return groups;
        }

        /// <summary>
        /// Find two distinct numbers in <see cref="sortedNumbers"/> which sum to <see cref="targetSum"/>.
        /// </summary>
        /// <param name="sortedNumbers">not null, not empty, SORTED</param>
        /// <param name="targetSum"></param>
        /// <param name="a">smaller number found</param>
        /// <param name="b">bigger number found</param>
        /// <returns>if there are two such numbers</returns>
        public static bool TryFindTwoWithSum(IList<int> sortedNumbers, int targetSum, out int a, out int b)
        {
            int small = 0;
            int big = sortedNumbers.Count - 1;
            while (small < big)
            {
                var sum = sortedNumbers[small] + sortedNumbers[big];
                if (sum == targetSum)
                {
                    a = sortedNumbers[small];
                    b = sortedNumbers[big];
                    return true;
                }
                if (sum > targetSum)
                {
                    big--;
                }
                else
                {
                    small++;
                }
            }

            a = 0;
            b = 0;
            return false;
        }

        /// <summary>
        /// Find two distinct numbers in <see cref="sortedNumbers"/> which sum to <see cref="targetSum"/>.
        /// </summary>
        /// <param name="sortedNumbers">not null, not empty, SORTED</param>
        /// <param name="targetSum"></param>
        /// <param name="a">smaller number found</param>
        /// <param name="b">bigger number found</param>
        /// <returns>if there are two such numbers</returns>
        public static bool TryFindTwoWithSum(IList<long> sortedNumbers, long targetSum, out long a, out long b) // todo for SortedSet? Reverse?
        {
            int small = 0;
            int big = sortedNumbers.Count - 1;
            while (small < big)
            {
                var sum = sortedNumbers[small] + sortedNumbers[big];
                if (sum == targetSum)
                {
                    a = sortedNumbers[small];
                    b = sortedNumbers[big];
                    return true;
                }
                if (sum > targetSum)
                {
                    big--;
                }
                else
                {
                    small++;
                }
            }

            a = 0;
            b = 0;
            return false;
        }
    }
}
