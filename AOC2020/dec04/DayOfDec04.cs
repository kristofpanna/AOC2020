using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

        public static bool Valid(IDictionary<string, string> passport)
        {
            return ContainsAllRequiredFields(passport) &&
                   IsNumberBetween(passport["byr"], 1920, 2002) &&
                   IsNumberBetween(passport["iyr"], 2010, 2020) &&
                   IsNumberBetween(passport["eyr"], 2020, 2030) &&
                   IsHeightValid(passport["hgt"]) &&
                   IsRegexMatch(passport["hcl"], @"^#[\da-f]{6}$") &&
                   new[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"}.Contains(passport["ecl"]) &&
                   IsRegexMatch(passport["pid"], @"^\d{9}$");
        }

        private static bool IsRegexMatch(string field, string regex)
        {
            var r = new Regex(regex);
            return r.IsMatch(field);
        }

        private static bool IsHeightValid(string hgt)
        {
            var quantity = hgt[..^2];
            var unit = hgt[^2..];

            return unit == "cm" ? 
                IsNumberBetween(quantity, 150, 193) : 
                IsNumberBetween(quantity, 59, 76);
        }

        private static bool IsNumberBetween(string numAsString, int min, int max)
        {
            if (!int.TryParse(numAsString, out var num))
                return false;

            return num <= max && num >= min;
        }

        private static bool ContainsAllRequiredFields(IDictionary<string, string> passport)
        {
            var requiredFields = new[] {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"}; // ("cid" is optional)
            return !requiredFields.Except(passport.Keys).Any();
        }

        private static IEnumerable<IDictionary<string, string>> GetPassports(IEnumerable<string> lines)
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
                else
                {
                    AddFields(passport, line);
                }
            }

            return passports;
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
