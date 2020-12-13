
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
            return SimulateFrom(state);
        }

        public static int Part2(IEnumerable<string> lines)
        {
            var state = new SeatLayout(lines, 5, SeatLayout.NeighborMode.FirstToSee);
            return SimulateFrom(state);
        }

        private static int SimulateFrom(SeatLayout startState)
        {
            Console.WriteLine($"start: \n\n{startState}\n\n");

            while (startState.GetNextState(out startState))
            {
                Console.WriteLine($"{startState}\n\n");
            }

            Console.WriteLine($"end: \n\n{startState}");
            return startState.CountAllOccupied();
        }
    }
}
    