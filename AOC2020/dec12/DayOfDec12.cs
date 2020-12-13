
using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.dec12
{
    public class DayOfDec12 : DayOfDec
    {
        public void Run(IEnumerable<string> lines)
        {
            var res = Part1(lines);

            Console.WriteLine(res);
            Console.ReadKey();
        }

        public static int Part1(IEnumerable<string> lines)
        {
            var start = new ShipState();
            var end = lines
                .Select(GetAction)
                .Aggregate(start, (state, action) => state.DoAction(action));

            return end.DistanceFromOrigo();
        }

        public static int Part2(IEnumerable<string> lines)
        {
            return 0;
        }

        private static (char, int) GetAction(string line)
        {
            var actionKind = line[0];
            var howMuch = int.Parse(line[1..]);

            return (actionKind, howMuch);
        }

        private enum Direction
        {
            N = 0,
            E = 1,
            S = 2,
            W = 3
        }

        private static Dictionary<Direction, (int x, int y)> CoordsByDirection => new Dictionary<Direction, (int x, int y)>
        {
            [Direction.N] = (0, 1),
            [Direction.E] = (1, 0),
            [Direction.S] = (0, -1),
            [Direction.W] = (-1, 0)
        };

        private static Dictionary<char, Direction> DirectionsByMoveActionKind => new Dictionary<char, Direction>
        {
            ['N'] = Direction.N,
            ['E'] = Direction.E,
            ['S'] = Direction.S,
            ['W'] = Direction.W
        };

        private static bool IsMoveAction(char actionKind)
        {
            return DirectionsByMoveActionKind.ContainsKey(actionKind);
        }


        private class ShipState
        {
            public (int x, int y) Place { get; set; } = (0, 0);

            public Direction Heading { get; set; } = Direction.E;

            public ShipState()
            {
            }

            public ShipState(ShipState other)
            {
                Place = other.Place;
                Heading = other.Heading;
            }

            public int DistanceFromOrigo() => Math.Abs(Place.x) + Math.Abs(Place.y);

            public ShipState DoAction((char actionKind, int howMuch) action)
            {
                if (IsMoveAction(action.actionKind))
                    return Move(action);

                if (action.actionKind == 'F')
                    return Forward(action);

                return Turn(action);
            }

            private ShipState Move((char actionKind, int howMuch) action)
            {
                var direction = DirectionsByMoveActionKind[action.actionKind];
                return MoveToDirection(action, direction);
            }

            private ShipState MoveToDirection((char actionKind, int howMuch) action, Direction direction)
            {
                var newState = new ShipState(this);
                var dirCoords = CoordsByDirection[direction];
                var move = (dirCoords.x * action.howMuch, dirCoords.y * action.howMuch);
                newState.Place = Util.AddCoords(newState.Place, move);

                return newState;
            }

            private ShipState Forward((char actionKind, int howMuch) action)
            {
                return MoveToDirection(action, Heading);
            }

            private ShipState Turn((char actionKind, int howMuch) action)
            {
                var newState = new ShipState(this);

                var sign = action.actionKind == 'R' ? 1 : -1;
                newState.Heading = (Direction)(((int)(newState.Heading) + sign * action.howMuch / 90 + 4) % 4);

                return newState;
            }
        }
    }
}