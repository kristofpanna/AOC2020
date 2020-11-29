using System;
using System.Collections.Generic;

namespace AOC2020.dec01
{
    public class DayOfDec01 : DayOfDec
    {
        public void Run(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                Console.WriteLine(line);
                Console.WriteLine("---");
            }
            Console.WriteLine("Hello Advent Of Code!");
        }
    }
}
