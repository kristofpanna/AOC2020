using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.dec01
{
    public class DayOfDec01 : DayOfDec
    {
        public void Run(IEnumerable<string> lines)
        {
            var sortedNumbers = lines.Select(int.Parse).OrderBy(x => x).ToList();

            Util.TryFindTwoWithSum(sortedNumbers, 2020, out var a, out var b);
            Console.WriteLine($"2 numbers: {a} {b}");
            Console.WriteLine($"multiplied: {a * b}");

            TryFindThreeWithSum(sortedNumbers, 2020, out var x, out var y, out var z);
            Console.WriteLine($"3 numbers: {x} {y} {z}");
            Console.WriteLine($"multiplied: {x * y * z}");

            Console.WriteLine("Hello Advent Of Code!");
            Console.ReadKey();
        }

        private bool TryFindThreeWithSum(IList<int> sortedNumbers, int targetSum, out int x, out int y, out int z)
        {
            // assume: numbers: not null, not empty, SORTED
            for (int i = 0; i < sortedNumbers.Count; i++)
            {
                x = sortedNumbers[i];
                bool isFound = Util.TryFindTwoWithSum(sortedNumbers.Skip(i).ToList(), targetSum - x, out y, out z);
                if (isFound)
                {
                    return true;
                }
            }

            x = 0;
            y = 0;
            z = 0;
            return false;
        }

    }
}
