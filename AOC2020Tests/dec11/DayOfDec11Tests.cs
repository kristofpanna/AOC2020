
using AOC2020.dec11;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace AOC2020Tests.dec11
{
    [TestClass()]
    public class DayOfDec11Tests
    {
        private const string PersonalInput = @"./dec11/test11.txt";
        private const string ExampleInput = @"./dec11/example11.txt";

        [TestMethod()]
        public void TestPart1_ExampleInput()
        {
            IEnumerable<string> lines = File.ReadLines(ExampleInput);

            var res = DayOfDec11.Part1(lines);

            Assert.AreEqual(37, res);
        }

        [TestMethod()]
        public void TestPart1()
        {
            IEnumerable<string> lines = File.ReadLines(PersonalInput);

            var res = DayOfDec11.Part1(lines);

            Assert.AreEqual(2152, res);
        }
        
        [TestMethod()]
        public void TestPart2_ExampleInput()
        {
            IEnumerable<string> lines = File.ReadLines(ExampleInput);

            var res = DayOfDec11.Part2(lines);

            Assert.AreEqual(26, res);
        }

        [TestMethod()]
        public void TestPart2()
        {
            IEnumerable<string> lines = File.ReadLines(PersonalInput);

            var res = DayOfDec11.Part2(lines);

            Assert.AreEqual(1937, res);
        }
    }
}
    