using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.dec08
{
    class Machine
    {
        private List<Instruction> Instructions { get; }

        private int Accumulator { get; set; } = 0;


        public Machine(IEnumerable<string> lines)
        {
            Instructions = lines.Select(line => new Instruction(line)).ToList();
        }

        public int Execute()
        {
            int next = 0;
            Instruction act = Instructions[next];
            while (!act.Visited)
            {
                act.Visited = true;
                next += act.Operation(this, act.Argument);
                act = Instructions[next];
            }

            return Accumulator;
        }


        //operations
        private int Acc(int arg)
        {
            Accumulator += arg;
            return 1;
        }

        private int Jmp(int arg) => arg;

        private int Nop(int arg) => 1;


        private class Instruction
        {
            public Func<Machine, int, int> Operation { get; set; } // returns next operation's offset
            public int Argument { get; set; }
            public bool Visited { get; set; } = false;

            public Instruction(string line)
            {
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Operation = OperationsByName[parts[0]];
                Argument = int.Parse(parts[1]);
            }

            private static Dictionary<string, Func<Machine, int, int>> OperationsByName => new Dictionary<string, Func<Machine, int, int>>
            {
                ["acc"] = (Machine m, int arg) => m.Acc(arg),
                ["jmp"] = (Machine m, int arg) => m.Jmp(arg),
                ["nop"] = (Machine m, int arg) => m.Nop(arg)
                // Java: Machine::acc  <->  (int arg) => this.jmp(arg),  // this::jmp
                // c++: std::mem_fn(&Machine::acc)
            };
        }
    }
}
