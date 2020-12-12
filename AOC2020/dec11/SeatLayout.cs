using System.Collections.Generic;
using System.Linq;

namespace AOC2020.dec11
{
    public class SeatLayout
    {
        private const char Floor = '.';
        private const char Empty = 'L';
        private const char Occupied = '#';

        private readonly List<List<char>> _grid;

        public SeatLayout(IEnumerable<string> lines)
        {
            _grid = lines.Select(line => line.ToList()).ToList();
        }

        private SeatLayout()
        {
            _grid = new List<List<char>>();
        }

        /// <summary>
        /// Get next state of the seat layout based on the rules.
        /// </summary>
        /// <param name="nextLayout">out param for next state</param>
        /// <returns>if next state is different from this</returns>
        public bool GetNextState(out SeatLayout nextLayout)
        {
            bool isChanged = false;
            nextLayout = new SeatLayout();
            for (var i = 0; i < _grid.Count; i++)
            {
                var newRow = new List<char>();
                for (var j = 0; j < _grid[0].Count; j++)
                {
                    newRow.Add(NewSeat(i, j, ref isChanged));
                }
                nextLayout._grid.Add(newRow);
            }

            return isChanged;
        }

        private char NewSeat(int i, int j, ref bool isChanged)
        {
            var currentSeat = _grid[i][j];
            var newSeat = currentSeat;
            switch (currentSeat)
            {
                case Empty when CountOccupiedNeighbors(i, j) == 0:
                    newSeat = Occupied;
                    isChanged = true;
                    break;
                case Occupied when CountOccupiedNeighbors(i, j) >= 4:
                    newSeat = Empty;
                    isChanged = true;
                    break;
            }

            return newSeat;
        }

        private int CountOccupiedNeighbors(int row, int col)
        {
            return GetNeighbors(row, col).Count(n => n == Occupied);
        }

        private IEnumerable<char> GetNeighbors(int row, int col)
        {
            var coords =
                from x in new[] { -1, 0, 1 }
                from y in new[] { -1, 0, 1 }
                where (x, y) != (0, 0)
                select (r: row + x, c: col + y);

            var seats = coords
                .Where(c => IsValidRowIndex(c.r) && IsValidColIndex(c.c))
                .Select(c => _grid[c.r][c.c]);

            return seats;
        }

        private bool IsValidRowIndex(int row) => row >= 0 && row < _grid.Count;

        private bool IsValidColIndex(int col) => col >= 0 && col < _grid[0].Count;

        public int CountAllOccupied()
        {
            var count = _grid
                .SelectMany(c => c)
                .Count(c => c == Occupied);

            return count;
        }

        public override string ToString()
        {
            return string.Join("\n", _grid.Select(row => string.Join("", row)));
        }
    }
}
