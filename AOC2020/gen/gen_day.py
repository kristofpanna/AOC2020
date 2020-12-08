import os

print("hi")
DAY = "08"      ### TODO arg, 2 digits

# generate class and input file into project
dir_path = "../dec{day}".format(day=DAY)
os.mkdir(dir_path)

input_name = "test{day}.txt".format(day=DAY)
with open(os.path.join(dir_path, input_name), "w") as out:
    pass
    
input_ex_name = "example{day}.txt".format(day=DAY)
with open(os.path.join(dir_path, input_ex_name), "w") as out:
    pass
    
### TODO modify \AOC2020\AOC2020.csproj   -> copy always

### TODO modify \AOC2020\Properties\launchSettings.json   ->       "commandLineArgs": "./dec06/test06.txt"
### TODO modify \AOC2020\Program.cs 


class_name = "DayOfDec{day}.cs".format(day=DAY)
with open(os.path.join(dir_path, class_name), "w") as out:
   out.write("""
using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.dec{day}
{{
    public class DayOfDec{day} : DayOfDec
    {{
        public void Run(IEnumerable<string> lines)
        {{
            var res = Part1(lines);

            Console.WriteLine(res);
            Console.ReadKey();
        }}

        public static int Part1(IEnumerable<string> lines)
        {{
            return 0;
        }}

        public static int Part2(IEnumerable<string> lines)
        {{
            return 0;
        }}
    }}
}}
    """.format(day=DAY))
   
# generate test into test project
test_dir_path = "../../AOC2020Tests/dec{day}".format(day=DAY)
os.mkdir(test_dir_path)

test_class_name = "DayOfDec{day}Tests.cs".format(day=DAY)
with open(os.path.join(test_dir_path, test_class_name), "w") as out:
   out.write("""
using AOC2020.dec{day};
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace AOC2020Tests.dec{day}
{{
    [TestClass()]
    public class DayOfDec{day}Tests
    {{
        private const string PersonalInput = @"./dec{day}/test{day}.txt";
        private const string ExampleInput = @"./dec{day}/example{day}.txt";

        [TestMethod()]
        public void TestPart1_ExampleInput()
        {{
            IEnumerable<string> lines = File.ReadLines(ExampleInput);

            var res = DayOfDec{day}.Part1(lines);

            Assert.AreEqual(-1, res);
        }}

        [TestMethod()]
        public void TestPart1()
        {{
            IEnumerable<string> lines = File.ReadLines(PersonalInput);

            var res = DayOfDec{day}.Part1(lines);

            Assert.AreEqual(-1, res);
        }}
        
        [TestMethod()]
        public void TestPart2_ExampleInput()
        {{
            IEnumerable<string> lines = File.ReadLines(ExampleInput);

            var res = DayOfDec{day}.Part2(lines);

            Assert.AreEqual(-1, res);
        }}

        [TestMethod()]
        public void TestPart2()
        {{
            IEnumerable<string> lines = File.ReadLines(PersonalInput);

            var res = DayOfDec{day}.Part2(lines);

            Assert.AreEqual(-1, res);
        }}
    }}
}}
    """.format(day=DAY))

 
print("yeah")