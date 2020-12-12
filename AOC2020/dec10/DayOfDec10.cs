
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
            var sorted = lines.Select(int.Parse).OrderBy(x => x).ToList();

            var counts = sorted
                .Zip(sorted.Skip(1), (a, b) => b - a)
                .GroupBy(x => x)
                .Where(g => g.Key == 1 || g.Key == 3)
                .OrderBy(g => g.Key)
                .Select(g => g.Count())
                .ToArray();

            return (counts[0] + 1) * (counts[1] + 1); // +1 to 3s for (my own - the last), +1 to 1s why???
        }

        public static int Part2(IEnumerable<string> lines)
        {
            return 0;
        }
    }
}
