using AOC2020.dec06;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace AOC2020Tests.dec06_
{
    [TestClass()]
    public class DayOfDec06Tests
    {
        private const string PersonalInput = @"./dec06/test06.txt";

        [TestMethod()]
        public void TestPart1()
        {
            IEnumerable<string> lines = File.ReadLines(PersonalInput);

            var res = DayOfDec06.Part1(lines);

            Assert.AreEqual(6542, res);
        }

        [TestMethod()]
        public void TestPart2()
        {
            IEnumerable<string> lines = File.ReadLines(PersonalInput);

            var res = DayOfDec06.Part2(lines);

            Assert.AreEqual(3299, res);
        }
    }
}