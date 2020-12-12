
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
            var counter = new SolutionsCounter(sorted);
            return counter.Count(); 
        }

        public class SolutionsCounter
        {
            private readonly IList<int> _sorted; // -> CountDistinctSolutions cannot be called with a completely different list
            private readonly Dictionary<int, long> _cache = new Dictionary<int, long>();

            public SolutionsCounter(IList<int> sorted)
            {
                _sorted = sorted;
            }

            public long Count()
            {
                return CountDistinctSolutions(0, _sorted); // charging outlet: 0; last fix: max (= my own - 3)
            }

            /// <summary>
            /// Count possible adapter choices, if the last of <see cref="sorted"/> is chosen.
            /// </summary>
            /// <param name="start">starting value before the first adapter</param>
            /// <param name="sorted">adapter joltages, SORTED</param>
            /// <returns>number of distinct ways from <see cref="start"/> to the last of <see cref="sorted"/></returns>
            private long CountDistinctSolutions(int start, IList<int> sorted)
            {
                if (_cache.ContainsKey(start))
                    return _cache[start];

                var first = sorted[0];
                var rest = sorted.Skip(1).ToList();

                if (first > start + 3) // not even the first is approachable
                    return 0;

                if (rest.Count == 0) // first is the last
                    return 1;

                var count = CountDistinctSolutions(first, rest) + CountDistinctSolutions(start, rest); // first is either in the solution or not
                _cache[start] = count;

                return count;
            }
        }
    }
}
