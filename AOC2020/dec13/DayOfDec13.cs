
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

        public static long Part2(IEnumerable<string> lines) // TODO BigInt?
        {
            // get linear congruence system
            // all numbers are prime in the inputs -> mods are primes
            List<(long rem, long mod)> congruences = GetCongruences(lines.Skip(1).First());

            long solution = 0;
            long mod = 1;
            foreach (var congruence in congruences)
            {
                solution = SolveNext(solution, mod, congruence);
                mod *= congruence.mod;
            }

            return solution;
        }

        private static long SolveNext(long solution, long mod, (long rem, long mod) congruence)
        {
            return ArithmeticProgression(solution, mod)
                .First(x => IsSolutionForCongruence(x, congruence));
        }

        private static IEnumerable<long> ArithmeticProgression(long start, long difference) // infinite
        {
            while (true)
            {
                yield return start;
                start += difference;
            }
        }

        private static bool IsSolutionForCongruence(long solution, (long rem, long mod) congruence)
        {
            return solution % congruence.mod == congruence.rem;
        }

        private static List<(long rem, long mod)> GetCongruences(string line)
        {
            return line.Split(',')
                .Select((x, i) => (x, i))
                .Where(t => t.x != "x")
                .Select(t => (rem: (long.Parse(t.x) - (long)t.i) % long.Parse(t.x), mod: long.Parse(t.x)))
                .OrderByDescending(t => t.mod)
                .ToList();
        }
    }
}
    