
using AOC2020.dec09;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace AOC2020Tests.dec09
{
    [TestClass()]
    public class DayOfDec09Tests
    {
        private const string PersonalInput = @"./dec09/test09.txt";
        private const string ExampleInput = @"./dec09/example09.txt";

        [TestMethod()]
        public void TestPart1_ExampleInput()
        {
            IEnumerable<string> lines = File.ReadLines(ExampleInput);
            var day = new DayOfDec09();
            day.PreambleLength = 5;

            var res = day.Part1(lines);

            Assert.AreEqual(127, res);
        }

        [TestMethod()]
        public void TestPart1()
        {
            IEnumerable<string> lines = File.ReadLines(PersonalInput);
            var day = new DayOfDec09();
            
            var res = day.Part1(lines);

            Assert.AreEqual(1492208709, res);
        }
        
        [TestMethod()]
        public void TestPart2_ExampleInput()
        {
            IEnumerable<string> lines = File.ReadLines(ExampleInput);
            var day = new DayOfDec09();
            day.PreambleLength = 5;

            var res = day.Part2(lines);

            Assert.AreEqual(62, res);
        }

        [TestMethod()]
        public void TestPart2()
        {
            IEnumerable<string> lines = File.ReadLines(PersonalInput);
            var day = new DayOfDec09();

            var res = day.Part2(lines);

            Assert.AreEqual(238243506, res);
        }
    }
}
    