using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.dec06
{
    public class DayOfDec06 : DayOfDec
    {
        public void Run(IEnumerable<string> lines)
        {
            var res = GetGroupsAnswers(lines, AddStuff)
                .Select(s => s.Count)
                .Sum();

            Console.WriteLine(res);
            Console.ReadKey();
        }


        private static IEnumerable<ISet<char>> GetGroupsAnswers(IEnumerable<string> lines, Action<ISet<char>, string> updateGroup)
        {
            var groups = new List<ISet<char>>();
            var group = new HashSet<char>();
            foreach (var line in lines)
            {
                if (line == "")
                {
                    groups.Add(group);
                    group = new HashSet<char>();
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
    }
}
