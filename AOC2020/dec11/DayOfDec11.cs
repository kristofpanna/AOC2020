
using System;
using System.Collections.Generic;

namespace AOC2020.dec11
{
    public class DayOfDec11 : DayOfDec
    {
        public void Run(IEnumerable<string> lines)
        {
            var res = Part1(lines);

            Console.WriteLine(res);
            Console.ReadKey();
        }

        public static int Part1(IEnumerable<string> lines)
        {
            var state = new SeatLayout(lines);
            Console.WriteLine($"start: \n\n{state}\n\n");

            while (state.GetNextState(out state))
            {
                Console.WriteLine($"{state}\n\n");
            }

            Console.WriteLine($"end: \n\n{state}");
            return state.CountAllOccupied();
        }

        public static int Part2(IEnumerable<string> lines)
        {
            return 0;
        }
    }
}
    