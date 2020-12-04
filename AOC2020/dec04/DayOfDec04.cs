using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.dec04
{
    public class DayOfDec04 : DayOfDec
    {
        public void Run(IEnumerable<string> lines)
        {
            //Console.WriteLine(lines.Count());
            var passports = GetPassports(lines);
            var result = passports.Count(Valid);

            Console.WriteLine(result);
            Console.ReadKey();
        }

        private bool Valid(IDictionary<string, string> passport)
        {
            var requiredFields = new[] {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"}; // ("cid" is optional)
            return !requiredFields.Except(passport.Keys).Any();
        }

        private IEnumerable<IDictionary<string, string>> GetPassports(IEnumerable<string> lines)
        {
            var passports = new List<IDictionary<string, string>>();
            var passport = new Dictionary<string, string>();
            foreach (var line in lines)
            {
                if (line == "")
                {
                    passports.Add(passport);
                    passport = new Dictionary<string, string>();
                }
                AddFields(passport, line);
            }

            return passports;
        }

        private static void AddFields(IDictionary<string, string> passport, string line)
        {
            var fields = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var field in fields)
            {
                AddField(passport, field);
            }
        }

        private static void AddField(IDictionary<string, string> passport, string field)
        {
            var parts = field.Split(':');
            var key = parts[0];
            var value = parts[1];

            passport[key] = value;
        }
    }
}
