using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.dec03
{
    public class DayOfDec03 : DayOfDec
    {
        public void Run(IEnumerable<string> lines)
        {
            int count = CountTreesStraight(lines, 3);

            Console.WriteLine($"number of trees: {count}");
            Console.WriteLine("Hello Advent Of Code!");
            Console.ReadKey();
        }

        private int CountTreesStraight(IEnumerable<string> lines, int slope)
        {
            return lines
                .Select((line, row) => line[row * slope % line.Length])
                .Count(IsTree);
        }

        private bool IsTree(char field)
        {
            return field == '#';
        }
    }
}
