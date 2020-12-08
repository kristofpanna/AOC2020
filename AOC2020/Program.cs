using AOC2020.dec07;
using System.Collections.Generic;
using System.IO;

namespace AOC2020
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = args[0]; // @"./dec01/test01.txt"
            IEnumerable<string> lines = File.ReadLines(path);

            DayOfDec dayOfDec = new DayOfDec07();
            dayOfDec.Run(lines);
        }
    }
}
