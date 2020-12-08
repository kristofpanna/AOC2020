
using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.dec07
{
    public class DayOfDec07 : DayOfDec
    {
        public void Run(IEnumerable<string> lines)
        {
            var res = Part1(lines);

            Console.WriteLine(res);
            Console.ReadKey();
        }

        public int Part1(IEnumerable<string> lines)
        {
            ProcessRules(lines);
            ISet<Bag> reachables = ReachableBagsFrom("shiny gold");

            return reachables.Count - 1;
        }

        public int Part2(IEnumerable<string> lines)
        {
            ProcessRules(lines);
            return CountContent(GetOrCreateBag("shiny gold"));
        }

        public Dictionary<string, Bag> BagByColor { get; set; } = new Dictionary<string, Bag>();

        private void ProcessRules(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                ProcessRule(line);
            }
        }

        private void ProcessRule(string line)
        {
            string color = ExtractColor(line);
            var bag = GetOrCreateBag(color);

            List<(int, string)> contentsAsStrings = ExtractContent(line);
            foreach (var (contentQuantity, contentColor) in contentsAsStrings)
            {
                Bag contentBag = GetOrCreateBag(contentColor);

                contentBag.CanBeCarriedIn.Add(bag);
                bag.Content.Add((contentQuantity, contentBag));
            }
        }

        public static string ExtractColor(string line)
        {
            var parts = line.Split(' ');
            return string.Join(' ', parts[..2]);
        }

        public static List<(int, string)> ExtractContent(string line)
        {
            if (line.Contains("no other"))
            {
                return new List<(int, string)>();
            }

            var parts = line.Split(' ');
            return parts
                .Skip(4)
                .Select((part, i) => (part, i))
                .GroupBy(t => t.i / 4, t => t.part)
                .Select(g => (int.Parse(g.First()), string.Join(' ', g.Skip(1).Take(2))))
                .ToList();
        }

        private Bag GetOrCreateBag(string color)
        {
            if (BagByColor.ContainsKey(color))
            {
                return BagByColor[color];
            }
            else
            {
                var bag = new Bag(color);
                BagByColor[color] = bag;

                return bag;
            }
        }

        /// <summary>
        /// Bags that can contain the given bag.
        /// </summary>
        /// <param name="color">color of the bag</param>
        /// <returns>set of bags (including the given one)</returns>
        private ISet<Bag> ReachableBagsFrom(string color)
        {
            var todo = new HashSet<Bag> { GetOrCreateBag(color) };
            var done = new HashSet<Bag>();

            while (todo.Any())
            {
                var bag = todo.First();
                todo.Remove(bag);

                todo.UnionWith(bag.CanBeCarriedIn);
                done.Add(bag);
            }

            return done;
        }

        /// <summary>
        /// Count how many bags are contained in total in the given bag (including the given one).
        /// </summary>
        private static int CountContent(Bag bag)
        {
            var count = bag.Content
                .Select(t => t.Item1 * (CountContent(t.Item2) + 1))
                .Sum();

            return count;
        }
    }
}
