using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.dec01
{
    public class DayOfDec01 : DayOfDec
    {
        public void Run(IEnumerable<string> lines)
        {
            var numbers = lines.Select(int.Parse);
            (int a, int b) = FindWithSum(numbers, 2020);
            Console.WriteLine($"numbers: {a} {b}");
            Console.WriteLine($"multiplied: {a * b}");

            Console.WriteLine("Hello Advent Of Code!");
            Console.ReadKey();
        }

        private (int, int) FindWithSum(IEnumerable<int> numbers, int targetSum)
        {
            // assume: numbers: not null, not empty
            var sortedNumbers = numbers.OrderBy(x => x).ToList();

            int small = 0;
            int big = sortedNumbers.Count - 1;
            while (small < big)
            {
                var sum = sortedNumbers[small] + sortedNumbers[big];
                if (sum == targetSum)
                {
                    return (sortedNumbers[small], sortedNumbers[big]);
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

            throw new ArgumentException("No such pair, silly!");
        }
    }
}
