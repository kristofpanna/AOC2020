using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.dec02
{
    public class DayOfDec02 : DayOfDec
    {
        public void Run(IEnumerable<string> lines)
        {
            var ret = lines.Count(Valid);

            Console.WriteLine($"number of valid pws: {ret}");
            Console.WriteLine("Hello Advent Of Code!");
            Console.ReadKey();
        }

        private bool Valid(string line)
        {
            (int min, int max, char letter, string password) = ParseLine(line);
            int count = password.Count(c => c == letter);
            return min <= count && count <= max;
        }

        private (int, int, char, string) ParseLine(string line)
        {
            var things = line.Split(new []{'-', ':', ' '}, StringSplitOptions.RemoveEmptyEntries);
            return (int.Parse(things[0]), int.Parse(things[1]), char.Parse(things[2]), things[3]);
        }
    }
}
