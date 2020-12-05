using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AOC2020.dec05.DayOfDec05;


namespace AOC2020Tests.dec05
{
    [TestClass()]
    public class DayOfDec05Tests
    {
        [DataTestMethod()]
        [DataRow("BFFFBBF", 70)]
        [DataRow("FFFBBBF", 14)]
        [DataRow("BBFFBBF", 102)]
        [DataRow("FFFFFFF", 0)]
        [DataRow("BBBBBBB", 127)]
        public void ParseWeirdBinaryTest_rowExamples(string letters, int expectedValue)
        {
            var value = ParseWeirdBinary(letters, 'F', 'B');
            Assert.AreEqual(expectedValue, value);
        }

        [DataTestMethod()]
        [DataRow("RRR", 7)]
        [DataRow("RLL", 4)]
        public void ParseWeirdBinaryTest_colExamples(string letters, int expectedValue)
        {
            var value = ParseWeirdBinary(letters, 'L', 'R');
            Assert.AreEqual(expectedValue, value);
        }
    }
}