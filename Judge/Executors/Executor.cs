using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Judge.Executors;
using Judge.Models;

namespace Judge
{
    public class Executor : IExecutor
    {
        public ExecutionOutput executionOutput;

        public ExecutionOutput Execute(string path, string input, ExecutingOptions option, string startArguments)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            long memory = 0;
            Process solve = new Process();

            Task executing = new Task(() =>
            {
                //Init 

                
                solve.StartInfo = new ProcessStartInfo(path);
                solve.StartInfo.CreateNoWindow = true;
                solve.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                solve.StartInfo.RedirectStandardInput = true;
                solve.StartInfo.RedirectStandardOutput = true;
                solve.StartInfo.UseShellExecute = false;

                if (startArguments != "")
                    solve.StartInfo.Arguments = startArguments + ".txt";

                solve.Start();

                //Memory
                Task memoryCheck = new Task(() =>
                {
                    while (!token.IsCancellationRequested)
                    {
                        memory = Math.Max(solve.WorkingSet64, memory);
                        Thread.Sleep(25);
                    }
                });
                memoryCheck.Start();


                // Math.Max(0.5, TL*1.5)+0.5

                // Input
                solve.StandardInput.WriteLine(input);


                //byte
                //ToDo: new memory thread 5oms

                //Output
                string result = solve.StandardOutput.ReadToEnd();
                solve.WaitForExit();
                int exitCode = solve.ExitCode;

                //Time
                TimeSpan execitionTime = TimeSpan.FromMilliseconds((int)watch.Elapsed.TotalMilliseconds);

                executionOutput = new ExecutionOutput(execitionTime, new MemorySpan(memory), result, exitCode);
                cancelTokenSource.Cancel();
            }, token);
            executing.Start();

            for (int i = 0; i < option.TimeLimit.Seconds; i++)
                Thread.Sleep(100);

            if (!token.IsCancellationRequested)
            {
                cancelTokenSource.Cancel();
                solve.Kill();
                executionOutput = new ExecutionOutput(TimeSpan.FromMilliseconds((int)watch.Elapsed.TotalMilliseconds), new MemorySpan(-1), "TL", -1);
            }
            return executionOutput;
        }
    }
}