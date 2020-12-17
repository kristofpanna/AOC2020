
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

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

        public static BigInteger Part2(IEnumerable<string> lines)
        {
            // get linear congruence system
            // all numbers are prime in the inputs -> mods are primes
            List<(BigInteger rem, BigInteger mod)> congruences = GetCongruences(lines.Skip(1).First());

            // https://en.wikipedia.org/wiki/Chinese_remainder_theorem constructive proof
            var (solution, mod) = congruences.Aggregate<(BigInteger rem, BigInteger mod)>(
                (acc, next) => (SolveTogether(acc, next), acc.mod * next.mod)
            );
            
            return solution;

        }

        private static List<(BigInteger rem, BigInteger mod)> GetCongruences(string line)
        {
            return line.Split(',')
                .Select((x, i) => (x, i)) // add index
                .Where(t => t.x != "x") // only numbers
                .Select(t => (x: BigInteger.Parse(t.x), i: new BigInteger(t.i))) // parse/convert to
                .Select(t => (rem: (t.x - t.i) % t.x, mod: t.x))
                .OrderByDescending(t => t.mod)
                .ToList();
        }

        /// <summary>
        /// Get solution for the linear system of 2 congruences.
        /// </summary>
        private static BigInteger SolveTogether((BigInteger rem, BigInteger mod) cong1, (BigInteger rem, BigInteger mod) cong2)
        {
            // want to solve: 
            //   x = r1 (m1)
            //   x = r2 (m2)
            // Bézout:
            // exists x1, x2:  x1*m1 + x2*m2 = 1  <-- get with Extended Eucl. alg. (primes -> gcd=1)
            // -> a solution: x1*m1*r2 + r1*x2*m2
            var (x1, x2) = Euclidean(cong1.mod, cong2.mod);
            return x1 * cong1.mod * cong2.rem + x2 * cong2.mod * cong1.rem;
        }

        // x,y: a*x + b*y = gcd(a,b)
        private static (BigInteger, BigInteger) Euclidean(BigInteger a, BigInteger b)
        {
            var (oldR, r) = (a, b);
            var (oldS, s) = (new BigInteger(1), new BigInteger(0));
            var (oldT, t) = (new BigInteger(0), new BigInteger(1));

            while (r != 0)
            {
                var quotient = oldR / r;
                (oldR, r) = (r, oldR - quotient * r);
                (oldS, s) = (s, oldS - quotient * s);
                (oldT, t) = (t, oldT - quotient * t);
            }

            return (oldS + oldT, oldT);
        }
    }
}
