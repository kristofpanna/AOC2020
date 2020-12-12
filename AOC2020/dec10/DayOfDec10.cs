
using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.dec10
{
    public class DayOfDec10 : DayOfDec
    {
        public void Run(IEnumerable<string> lines)
        {
            var res = Part1(lines);

            Console.WriteLine(res);
            Console.ReadKey();
        }

        public static int Part1(IEnumerable<string> lines)
        {
            var sorted = GetSortedJoltages(lines).Prepend(0); // the charging outlet: 0

            var counts = sorted
            .Zip(sorted.Skip(1), (a, b) => b - a)
            .GroupBy(x => x)
            .Where(g => g.Key == 1 || g.Key == 3)
            .OrderBy(g => g.Key)
            .Select(g => g.Count())
            .ToArray();

            return counts[0] * (counts[1] + 1); // +1 to 3s for (my own - the biggest)
        }

        private static List<int> GetSortedJoltages(IEnumerable<string> lines)
        {
            var sorted = lines
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToList();

            return sorted;
        }

        public static long Part2(IEnumerable<string> lines)
        {
            var sorted = GetSortedJoltages(lines);

            return CountDistinctSolutions(0, sorted); // charging outlet: 0; last fix: max (= my own - 3)
        }

        /// <summary>
        /// Count possible adapter choices, if the last of <see cref="sorted"/> is chosen.
        /// </summary>
        /// <param name="start">starting value before the first adapter</param>
        /// <param name="sorted">adapter joltages, SORTED</param>
        /// <returns>number of distinct ways from <see cref="start"/> to the last of <see cref="sorted"/></returns>
        private static long CountDistinctSolutions(int start, IEnumerable<int> sorted)
        {
            if (!sorted.Any())
                return 0;

            var first = sorted.First();
            var rest = sorted.Skip(1);

            if (first > start + 3) // not even the first is approachable
                return 0;

            if (!rest.Any())
                return 1;
            
            return CountDistinctSolutions(first, rest) + CountDistinctSolutions(start, rest); // first is either in the solution or not
        }
    }
}
