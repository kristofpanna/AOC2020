
using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.dec09
{
    public class DayOfDec09 : DayOfDec
    {
        public int PreambleLength { get; set; } = 25;

        public void Run(IEnumerable<string> lines)
        {
            var res = Part1(lines);

            Console.WriteLine(res);
            Console.ReadKey();
        }

        /// <summary>
        /// find the first number in the list (after the preamble) which is not the sum of two of the 25 numbers before it
        /// </summary>
        public long Part1(IEnumerable<string> lines)
        {
            var numbers = lines.Select(long.Parse).ToList();

            var sortedWindow = new SortedSet<long>(numbers.GetRange(0, PreambleLength));
            for (var i = PreambleLength; i < numbers.Count; i++)
            {
                var act = numbers[i];
                if (!Util.TryFindTwoWithSum(sortedWindow.ToList(), act, out _, out _))
                    return act;

                // update sortedWindow for the next iteration
                var firstOfInterval = numbers[i - PreambleLength];
                sortedWindow.Remove(firstOfInterval);
                sortedWindow.Add(act);
            }

            return 0;
        }
        
        public int Part2(IEnumerable<string> lines)
        {
            return 0;
        }
    }
}
