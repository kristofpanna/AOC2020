
using System;
using System.Collections.Generic;

namespace AOC2020.dec08
{
    public class DayOfDec08 : DayOfDec
    {
        public void Run(IEnumerable<string> lines)
        {
            var res = Part1(lines);

            Console.WriteLine(res);
            Console.ReadKey();
        }

        public static int Part1(IEnumerable<string> lines)
        {
            var machine = new Machine(lines);
            return machine.Execute();
        }

        public static int Part2(IEnumerable<string> lines)
        {
            return 0;
        }


    }
}
    