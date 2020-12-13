using System.Collections.Generic;
using System.Linq;

namespace AOC2020.dec11
{
    public class SeatLayout
    {
        private const char Floor = '.';
        private const char Empty = 'L';
        private const char Occupied = '#';

        public enum NeighborMode 
        {
            Around,
            FirstToSee
        }

        private readonly List<List<char>> _grid;
        private readonly int _occupiedToEmptyMin;
        private readonly NeighborMode _neighborMode;

        public SeatLayout(IEnumerable<string> lines, int occupiedToEmptyMin = 4, NeighborMode neighborMode = NeighborMode.Around)
        {
            _grid = lines.Select(line => line.ToList()).ToList();
            _occupiedToEmptyMin = occupiedToEmptyMin;
            _neighborMode = neighborMode;
        }

        private SeatLayout(SeatLayout otherLayout)
        {
            _grid = new List<List<char>>(); // !!! :/
            _occupiedToEmptyMin = otherLayout._occupiedToEmptyMin;
            _neighborMode = otherLayout._neighborMode;
        }

        /// <summary>
        /// Get next state of the seat layout based on the rules.
        /// </summary>
        /// <param name="nextLayout">out param for next state</param>
        /// <returns>if next state is different from this</returns>
        public bool GetNextState(out SeatLayout nextLayout)
        {
            bool isChanged = false;
            nextLayout = new SeatLayout(this);
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
            var place = (i, j);
            var currentSeat = _grid[i][j];
            var newSeat = currentSeat;
            switch (currentSeat)
            {
                case Empty when CountOccupiedNeighbors(place) == 0:
                    newSeat = Occupied;
                    isChanged = true;
                    break;
                case Occupied when CountOccupiedNeighbors(place) >= _occupiedToEmptyMin:
                    newSeat = Empty;
                    isChanged = true;
                    break;
            }

            return newSeat;
        }

        private int CountOccupiedNeighbors((int, int) place)
        {
            return GetNeighbors(place).Count(n => n == Occupied);
        }

        private IEnumerable<char> GetNeighbors((int, int) place)
        {
            return _neighborMode == NeighborMode.Around 
                ? GetNeighborsAround(place) 
                : GetNeighborsFirstToSee(place);
        }

        private IEnumerable<char> GetNeighborsAround((int, int) place)
        {
            var seats = Directions()
                .Select(dir => AddDirectionToPlace(place, dir))
                .Where(IsValidPlace)
                .Select(place => _grid[place.row][place.col]);

            return seats;
        }
        private static IEnumerable<(int x, int y)> Directions()
        {
            return
                from x in new[] { -1, 0, 1 }
                from y in new[] { -1, 0, 1 }
                where (x, y) != (0, 0)
                select (x, y);
        }

        private static (int row, int col) AddDirectionToPlace((int row, int col) place, (int x, int y) direction)
        {
            return (place.row + direction.x, place.col + direction.y);
        }

        private bool IsValidPlace((int row, int col) coords)
        {
            return IsValidRowIndex(coords.row) && IsValidColIndex(coords.col);
        }

        private bool IsValidRowIndex(int row) => row >= 0 && row < _grid.Count;

        private bool IsValidColIndex(int col) => col >= 0 && col < _grid[0].Count;

        private IEnumerable<char> GetNeighborsFirstToSee((int, int) place)
        {
            return Directions().Select(dir => GetFirstSeatInDirection(place, dir));
        }

        private char GetFirstSeatInDirection((int, int) place, (int, int) direction)
        {
            var nextPlace = AddDirectionToPlace(place, direction);
            if (!IsValidPlace(nextPlace)) 
                return '_';

            var nextSeat = _grid[nextPlace.row][nextPlace.col];
            return nextSeat == Floor ? GetFirstSeatInDirection(nextPlace, direction) : nextSeat;
        }

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
