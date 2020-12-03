using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.dec03
{
    public class DayOfDec03 : DayOfDec
    {
        public void Run(IEnumerable<string> lines)
        {
            // var count = CountTreesEveryLine(lines, 3);
            // Console.WriteLine($"number of trees on line: {count}");

            long ret = new[]
                {
                    (Right: 1, Down: 1),
                    (Right: 3, Down: 1),
                    (Right: 5, Down: 1),
                    (Right: 7, Down: 1),
                    (Right: 1, Down: 2)
                }
                .Select(p => (long)CountTreesOnSlope(lines, p.Right, p.Down))
                .Aggregate((a, b) => a * b);

            Console.WriteLine($"multiplied: {ret}");
            Console.WriteLine("Hello Advent Of Code!");
            Console.ReadKey();
        }

        private int CountTreesOnSlope(IEnumerable<string> lines, int rightSlope, int downSlope)
        {
            var linesToProcess = lines.Where((line, i) => i % downSlope == 0);
            return CountTreesEveryLine(linesToProcess, rightSlope);
        }

        private int CountTreesEveryLine(IEnumerable<string> lines, int slope)
        {
            return lines
                .Select((line, i) => line[i * slope % line.Length])
                .Count(IsTree);
        }

        private bool IsTree(char field)
        {
            return field == '#';
        }
    }
}
