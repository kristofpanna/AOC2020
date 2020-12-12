
using AOC2020.dec10;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace AOC2020Tests.dec10
{
    [TestClass()]
    public class DayOfDec10Tests
    {
        private const string PersonalInput = @"./dec10/test10.txt";
        private const string ExampleInput = @"./dec10/example10.txt";

        [TestMethod()]
        public void TestPart1_ExampleInput()
        {
            IEnumerable<string> lines = File.ReadLines(ExampleInput);

            var res = DayOfDec10.Part1(lines);

            Assert.AreEqual(22 * 10, res);
        }

        [TestMethod()]
        public void TestPart1()
        {
            IEnumerable<string> lines = File.ReadLines(PersonalInput);

            var res = DayOfDec10.Part1(lines);

            Assert.AreEqual(2738, res);
        }

        [TestMethod()]
        public void TestPart2_ExampleInput()
        {
            IEnumerable<string> lines = File.ReadLines(ExampleInput);

            var res = DayOfDec10.Part2(lines);

            Assert.AreEqual(-1, res);
        }

        [TestMethod()]
        public void TestPart2()
        {
            IEnumerable<string> lines = File.ReadLines(PersonalInput);

            var res = DayOfDec10.Part2(lines);

            Assert.AreEqual(-1, res);
        }
    }
}
