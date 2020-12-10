
using System;
using System.Collections.Generic;

namespace AOC2020.dec08
{
    public class DayOfDec08 : DayOfDec
    {
        public void Run(IEnumerable<string> lines)
        {
            var res = Part1(lines);

            Console.WriteLine(res);
            Console.ReadKey();
        }

        public static int Part1(IEnumerable<string> lines)
        {
            var machine = new Machine(lines);
            machine.ExecuteUntilLoop();

            return machine.Accumulator;
        }

        public static int Part2(IEnumerable<string> lines)
        {
            var machine = new Machine(lines);

            for (var i = 0; i < machine.Instructions.Count; i++)
            {
                var m = new Machine(machine);
                var instruction = m.Instructions[i];
                if (instruction.OperationName == "acc")
                    continue;

                instruction.ChangeOperation();
                if (!m.ExecuteUntilLoop())
                    return m.Accumulator;
            }

            return -1;
        }
    }
}
    