using System;
using Judge.Models;

namespace Judge
{
    public class ExecutionOutput
    {
        public TimeSpan Time { get; private set; }
        public MemorySpan Memory { get; private set; }
        public string Result { get; private set; }
        public string Verdict { get; set; }
        public int ExitCode { get; private set; }
        public ExecutionOutput(TimeSpan time, MemorySpan memory, string result, int exitCode)
        {
            this.Time = time;
            this.Memory = memory;
            this.Result = result;
            this.ExitCode = exitCode;
        }

    }
}
