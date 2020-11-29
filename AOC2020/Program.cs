using AOC2020.dec01;
using System;
using System.Collections.Generic;
using System.IO;

namespace AOC2020
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try // StreamReader
            {
                string path = args[0]; // @"./dec01/test01.txt"
                IEnumerable<string> lines = File.ReadLines(path);

                DayOfDec dayOfDec = new DayOfDec01();
                dayOfDec.Run(lines);
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
