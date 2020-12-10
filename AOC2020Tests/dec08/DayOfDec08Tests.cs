
using AOC2020.dec08;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace AOC2020Tests.dec08
{
    [TestClass()]
    public class DayOfDec08Tests
    {
        private const string PersonalInput = @"./dec08/test08.txt";
        private const string ExampleInput = @"./dec08/example08.txt";

        [TestMethod()]
        public void TestPart1_ExampleInput()
        {
            IEnumerable<string> lines = File.ReadLines(ExampleInput);

            var res = DayOfDec08.Part1(lines);

            Assert.AreEqual(5, res);
        }

        [TestMethod()]
        public void TestPart1()
        {
            IEnumerable<string> lines = File.ReadLines(PersonalInput);

            var res = DayOfDec08.Part1(lines);

            Assert.AreEqual(1675, res);
        }
        
        [TestMethod()]
        public void TestPart2_ExampleInput()
        {
            IEnumerable<string> lines = File.ReadLines(ExampleInput);

            var res = DayOfDec08.Part2(lines);

            Assert.AreEqual(8, res);
        }

        [TestMethod()]
        public void TestPart2()
        {
            IEnumerable<string> lines = File.ReadLines(PersonalInput);

            var res = DayOfDec08.Part2(lines);

            Assert.AreEqual(1532, res);
        }
    }
}
    