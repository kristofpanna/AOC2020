using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.dec06
{
    public class DayOfDec06 : DayOfDec
    {
        public void Run(IEnumerable<string> lines)
        {
            var res = Part2(lines);

            Console.WriteLine(res);
            Console.ReadKey();
        }

        public static int Part1(IEnumerable<string> lines)
        {
            return GetGroupsAnswers(lines, () => new HashSet<char>(), AddStuff)
                .Select(s => s.Count)
                .Sum(); // 6542
        }

        public static int Part2(IEnumerable<string> lines)
        {
            return GetGroupsAnswers(lines, () => new HashSet<char>(AllLetters()), CommonPart)
                .Select(s => s.Count)
                .Sum(); // 3299
        }

        private static IEnumerable<char> AllLetters()
        {
            return Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c);
        }


        private static IEnumerable<ISet<char>> GetGroupsAnswers(IEnumerable<string> lines, Func<ISet<char>> init, Action<ISet<char>, string> updateGroup)
        {
            var groups = new List<ISet<char>>();
            var group = init();
            foreach (var line in lines)
            {
                if (line == "")
                {
                    groups.Add(group);
                    group = init();
                }
                else
                {
                    updateGroup(group, line);
                }
            }

            return groups;
        }

        private static void AddStuff(ISet<char> group, string line)
        {
            group.UnionWith(line);
        }

        private static void CommonPart(ISet<char> group, string line)
        {
            group.IntersectWith(line);
        }
    }
}
