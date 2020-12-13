
using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.dec13
{
    public class DayOfDec13 : DayOfDec
    {
        public void Run(IEnumerable<string> lines)
        {
            var res = Part1(lines);

            Console.WriteLine(res);
            Console.ReadKey();
        }

        public static long Part1(IEnumerable<string> lines)
        {
            long earliest = GetEarliest(lines);
            List<long> busIds = GetNumericBusIds(lines);

            var (wait, minWaitId) = MinWait(earliest, busIds);
            
            return minWaitId * wait;
        }

        private static long GetEarliest(IEnumerable<string> lines)
        {
            return long.Parse(lines.First());
        }

        private static List<long> GetNumericBusIds(IEnumerable<string> lines)
        {
            string line = lines.Skip(1).First();

            return line.Split(',')
                .Where(x => x != "x")
                .Select(long.Parse)
                .ToList();
        }

        private static (long wait, long id) MinWait(long earliest, List<long> busIds)
        {
            return busIds
                .Select(b => (WaitDepart(earliest, b), b))
                .Min();
        }

        private static long WaitDepart(long earliest, long busId)
        {
            return busId - (earliest % busId);
        }

        public static int Part2(IEnumerable<string> lines)
        {
            return 0;
        }
    }
}
    