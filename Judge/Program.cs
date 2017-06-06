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
            //TEST
            string root = "E:\\Judge\\";
            FileFactory factory = new FileFactory(root);
            string code = File.ReadAllText(root + "sum.pas");
            Submit submit = new Submit(code, "Pascal");

            Problem sum = new Problem(new ExecutingOptions(TimeSpan.FromSeconds(5), new MemorySpan(256 * 1024 * 1024)));
            sum.Tests = new List<TestCase> {
                new TestCase("55555555555555555 5", "10"),
                new TestCase("3 9", "12"),
                new TestCase("3 6", "9"),
                new TestCase("5 5", "10"),
                new TestCase("3 9", "12"),
                new TestCase("3 6", "9")
            };

    
            IChecker checker = new StringChecker();
            Judger judger = new Judger(factory,checker, sum, submit);
            Protocol protocol = judger.Judge();

            Console.WriteLine(protocol.CompilationResult.ExitCode);
            Console.WriteLine(protocol.CompilationResult.Result);
            

            foreach (var result in protocol.Results.Values)
            {
                Console.WriteLine("Verdict:{0}\tMemory:{1}MB\tExecuting Time:{2}ms\tExitCode:{3}", result.Verdict,
                    result.UsedMemory.TotalMegabytes, result.UsedTime.TotalSeconds, result.ExitCode);
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