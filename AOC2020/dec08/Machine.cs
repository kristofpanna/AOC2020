using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.dec08
{
    class Machine
    {
        public List<Instruction> Instructions { get; }

        public int Accumulator { get; set; } = 0;


        public Machine(IEnumerable<string> lines)
        {
            Instructions = lines.Select(line => new Instruction(line)).ToList();
        }

        public Machine(Machine other)
        {
            Instructions = other.Instructions.Select(ins => new Instruction(ins)).ToList();
        }

        // retuns: is infinite loop
        public bool ExecuteUntilLoop()
        {
            int next = 0;
            Instruction act = Instructions[next];
            while (!act.Visited)
            {
                act.Visited = true;

                var operation = OperationsByName[act.OperationName];
                next += operation(act.Argument);

                if (next == Instructions.Count)
                    return false;
                //if (next > Instructions.Count || next < 0)
                //    return true; // (not loop, but not immediately after the last -> bad)

                act = Instructions[next];
            }

            return true;
        }


        //operations
        private int Acc(int arg)
        {
            Accumulator += arg;
            return 1;
        }

        private int Jmp(int arg) => arg;

        private int Nop(int arg) => 1;

        private Dictionary<string, Func<int, int>> OperationsByName => new Dictionary<string, Func<int, int>>
        {
            ["acc"] = Acc,
            ["jmp"] = Jmp,
            ["nop"] = Nop
        };

        public class Instruction
        {
            public string OperationName { get; set; }

            //public Func<Machine, int, int> Operation { get; set; } // returns next operation's offset
            public int Argument { get; set; }
            public bool Visited { get; set; } = false;

            public void ChangeOperation()
            {
                OperationName = OperationName == "jmp" ? "nop" : "jmp";
            }

            public Instruction(string line)
            {
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                OperationName = parts[0];
                Argument = int.Parse(parts[1]);
            }

            public Instruction(Instruction other)
            {
                OperationName = other.OperationName;
                Argument = other.Argument;
            }

            /* // <3
            private static Dictionary<string, Func<Machine, int, int>> OperationsByName => new Dictionary<string, Func<Machine, int, int>>
            {
                ["acc"] = (Machine m, int arg) => m.Acc(arg),
                ["jmp"] = (Machine m, int arg) => m.Jmp(arg),
                ["nop"] = (Machine m, int arg) => m.Nop(arg)
                // Java: Machine::acc  <->  (int arg) => this.jmp(arg),  // this::jmp
                // c++: std::mem_fn(&Machine::acc)
            };
            */
        }
    }
}
