
using AOC2020.dec12;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace AOC2020Tests.dec12
{
    [TestClass()]
    public class DayOfDec12Tests
    {
        private const string PersonalInput = @"./dec12/test12.txt";
        private const string ExampleInput = @"./dec12/example12.txt";

        [TestMethod()]
        public void TestPart1_ExampleInput()
        {
            IEnumerable<string> lines = File.ReadLines(ExampleInput);

            var res = DayOfDec12.Part1(lines);

            Assert.AreEqual(17 + 8, res);
        }

        [TestMethod()]
        public void TestPart1()
        {
            IEnumerable<string> lines = File.ReadLines(PersonalInput);

            var res = DayOfDec12.Part1(lines);

            Assert.AreEqual(1565, res);
        }
        
        [TestMethod()]
        public void TestPart2_ExampleInput()
        {
            IEnumerable<string> lines = File.ReadLines(ExampleInput);

            var res = DayOfDec12.Part2(lines);

            Assert.AreEqual(-1, res);
        }

        [TestMethod()]
        public void TestPart2()
        {
            IEnumerable<string> lines = File.ReadLines(PersonalInput);

            var res = DayOfDec12.Part2(lines);

            Assert.AreEqual(-1, res);
        }
    }
}
    