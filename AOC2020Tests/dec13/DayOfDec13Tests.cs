
using AOC2020.dec13;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace AOC2020Tests.dec13
{
    [TestClass()]
    public class DayOfDec13Tests
    {
        private const string PersonalInput = @"./dec13/test13.txt";
        private const string ExampleInput = @"./dec13/example13.txt";

        [TestMethod()]
        public void TestPart1_ExampleInput()
        {
            IEnumerable<string> lines = File.ReadLines(ExampleInput);

            var res = DayOfDec13.Part1(lines);

            Assert.AreEqual(59 * (944 - 939), res); // 295
        }

        [TestMethod()]
        public void TestPart1()
        {
            IEnumerable<string> lines = File.ReadLines(PersonalInput);

            var res = DayOfDec13.Part1(lines);

            Assert.AreEqual(3246, res);
        }
        
        [TestMethod()]
        public void TestPart2_ExampleInput()
        {
            IEnumerable<string> lines = File.ReadLines(ExampleInput);

            var res = DayOfDec13.Part2(lines);

            Assert.AreEqual(1068781, res);
        }

        [TestMethod()]
        public void TestPart2()
        {
            IEnumerable<string> lines = File.ReadLines(PersonalInput);

            var res = DayOfDec13.Part2(lines);

            Assert.AreEqual(-1, res);
        }
    }
}
    