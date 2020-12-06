using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.dec04
{
    public class DayOfDec04 : DayOfDec
    {
        public void Run(IEnumerable<string> lines)
        {
            var passports = GetPassports(lines);
            var result = passports.Count(Valid); // 158

            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static bool Valid(IDictionary<string, string> passport)
        {
            return ContainsAllRequiredFields(passport) 
                   && Util.IsNumberBetween(passport["byr"], 1920, 2002) 
                   && Util.IsNumberBetween(passport["iyr"], 2010, 2020) 
                   && Util.IsNumberBetween(passport["eyr"], 2020, 2030) 
                   && IsHeightValid(passport["hgt"]) 
                   && Util.IsRegexMatch(passport["hcl"], @"^#[\da-f]{6}$") 
                   && new[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"}.Contains(passport["ecl"]) 
                   && Util.IsRegexMatch(passport["pid"], @"^\d{9}$");
        }

        private static bool IsHeightValid(string hgt)
        {
            var quantity = hgt[..^2];
            var unit = hgt[^2..];

            return unit == "cm" ? Util.IsNumberBetween(quantity, 150, 193) : Util.IsNumberBetween(quantity, 59, 76);
        }

        private static bool ContainsAllRequiredFields(IDictionary<string, string> passport)
        {
            var requiredFields = new[] {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"}; // ("cid" is optional)
            return !requiredFields.Except(passport.Keys).Any();
        }

        private static IEnumerable<IDictionary<string, string>> GetPassports(IEnumerable<string> lines)
        {
            return Util.GetGroups(lines, () => new Dictionary<string, string>(), AddFields);
        }

        public static void AddFields(IDictionary<string, string> passport, string line)
        {
            var fields = line.Split(' ');
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
