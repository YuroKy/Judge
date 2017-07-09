using System;
using System.Collections.Generic;
using System.IO;
using Judge.Checkers;
using Judge.Executors;
using Judge.Models;

namespace Judge
{
    class Program
    {
        public static void Main(string[] args)
        {
            string code = "var a, b:integer; BEGIN readln(a, b); writeln(a + b); END.";
            Problem problem = new Problem(new ExecutingOptions(new TimeSpan(0, 0, 0, 2, 0), new MemorySpan(10000000)));
            problem.Tests.Add(new TestCase("5 5", "10"));
            JudgeProcess jp = new JudgeProcess("E:\\Judge\\");

            jp.Run(problem, new Submit(code, "Pascal"));

            foreach (var protocol in jp.GetProtocolCurrentTest().Results)
            {
                Console.WriteLine(protocol.Value.Verdict);
                Console.WriteLine(protocol.Value.UsedMemory.TotalKilobytes);
                Console.WriteLine(protocol.Value.UsedTime.TotalMilliseconds);
                Console.WriteLine(protocol.Value.ExitCode);
                Console.WriteLine("==============================================");
                
            }
        }

        /*
         
            main - (listen queue) - when get package then process it -> (listen queue)
            
            system - handle commands - exit

            IoC-container - autofac, ninject
            Logging - log4net, nlogger

         */
    }
}