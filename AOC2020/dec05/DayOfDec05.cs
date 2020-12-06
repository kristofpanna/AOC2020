using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.dec05
{
    public class DayOfDec05 : DayOfDec
    {
        public void Run(IEnumerable<string> lines)
        {
            var orderedIds = lines
                .Select(l => new BoardingPass(l))
                .Select(b => b.Id)
                //.Max();
                .OrderBy(x => x)
                .ToList();

            var res = orderedIds
                .Skip(1)
                .Zip(orderedIds, (id, prev) => id - prev > 1 ? id - 1 : -1)
                .First(x => x > 0);

            Console.WriteLine(res);
            Console.ReadKey();
        }

        public class BoardingPass
        {
            public int Row { get; set; }
            public int Col { get; set; }

            public int Id => Row * 8 + Col; // 0-1023

            public BoardingPass(string bp) 
                : this(ParseWeirdBinary(bp[..^3], 'F', 'B'), ParseWeirdBinary(bp[^3..], 'L', 'R'))
            { }

            private BoardingPass(int row, int col)
            {
                Row = row;
                Col = col;
            }
        }

        public static int ParseWeirdBinary(string letters, char char0, char char1)
        {
            var binary = letters
                .Replace(char0, '0')
                .Replace(char1, '1');

            return Convert.ToInt32(binary, 2);
        }

    }
}
