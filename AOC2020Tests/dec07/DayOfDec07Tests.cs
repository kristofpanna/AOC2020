
using AOC2020.dec07;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using static AOC2020.dec07.DayOfDec07;

namespace AOC2020Tests.dec07
{
    [TestClass()]
    public class DayOfDec07Tests
    {
        private const string PersonalInput = @"./dec07/test07.txt";
        private const string ExampleInput = @"./dec07/example07.txt";
        private const string ExampleInput2 = @"./dec07/example07_2.txt";

        [TestMethod()]
        public void TestPart1_ExampleInput()
        {
            IEnumerable<string> lines = File.ReadLines(ExampleInput);

            var res = new DayOfDec07().Part1(lines);

            Assert.AreEqual(4, res);
        }

        [TestMethod()]
        public void TestPart1_PersonalInput()
        {
            IEnumerable<string> lines = File.ReadLines(PersonalInput);

            var res = new DayOfDec07().Part1(lines);

            Assert.AreEqual(265, res);
        }

        [TestMethod()]
        public void TestPart2_ExampleInput()
        {
            IEnumerable<string> lines = File.ReadLines(ExampleInput);

            var res = new DayOfDec07().Part2(lines);

            Assert.AreEqual(32, res);
        }

        [TestMethod()]
        public void TestPart2_ExampleInput2()
        {
            IEnumerable<string> lines = File.ReadLines(ExampleInput2);

            var res = new DayOfDec07().Part2(lines);

            Assert.AreEqual(126, res);
        }

        [TestMethod()]
        public void TestPart2()
        {
            IEnumerable<string> lines = File.ReadLines(PersonalInput);

            var res = new DayOfDec07().Part2(lines);

            Assert.AreEqual(14177, res);
        }

        [DataTestMethod()]
        [DataRow("drab gray bags contain 5 mirrored white bags, 1 light green bag, 5 shiny lavender bags, 5 faded aqua bags.", "drab gray")]
        public void ExtractColorTest(string line, string expectedColor)
        {
            var color = ExtractColor(line);

            Assert.AreEqual(expectedColor, color);
        }


        [TestMethod()]
        public void ExtractContentTest_Empty()
        {
            string line = "dotted black bags contain no other bags.";
            List<(int, string)> expectedList = new List<(int, string)>();

            var contents = ExtractContent(line);

            CollectionAssert.AreEquivalent(expectedList, contents);
        }

        [TestMethod()]
        public void ExtractContentTest_ContentEquals()
        {
            string line = "muted indigo bags contain 4 muted chartreuse bags, 2 dotted teal bags.";
            List<(int, string)> expectedList = new List<(int, string)>()
            {
                (4, "muted chartreuse"),
                (2, "dotted teal")
            };

            var contents = ExtractContent(line);

            CollectionAssert.AreEquivalent(expectedList, contents);
        }

    }
}
