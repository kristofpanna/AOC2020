using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static AOC2020.dec04.DayOfDec04;

namespace AOC2020.dec04.Tests
{
    [TestClass()]
    public class DayOfDec04Tests
    {
        [DataTestMethod()]
        //[DataRow(new Dictionary<string, string>() { })] -> így nem megy, mert csak const lehet
        //[DynamicData(nameof(Valid_passports))]
        [DataRow("iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719")]
        public void ValidTest_Valid(string line)
        {
            var passport = new Dictionary<string, string>();
            AddFields(passport, line);

            Assert.IsTrue(Valid(passport));
        }

        [DataTestMethod()]
        [DataRow("eyr:1972 cid:100 hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926")]
        [DataRow("iyr:2019 hcl:#602927 eyr:1967 hgt:170cm ecl:grn pid:012533040 byr:1946")]
        public void ValidTest_Invalid(string line)
        {
            var passport = new Dictionary<string, string>();
            AddFields(passport, line);

            Assert.IsFalse(Valid(passport));
        }

        /*
        public static IEnumerable<IDictionary<string, string>> Valid_passports
        {
            get
            {
                yield return new Dictionary<string, string>() { "iyr":"2010", "hgt":"158cm",  hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719 }; // macerás
                yield return new Dictionary<string, string>() { };
            }
        }
        */
    }
}