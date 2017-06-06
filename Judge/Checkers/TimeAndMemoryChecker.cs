using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Judge.Executors;
using Judge.Models;

namespace Judge.Checkers
{
    class TimeAndMemoryChecker
    {
        public TestVerdict CheckMemory(ExecutionOutput executionOutput, ExecutingOptions executingOptions)
        {
            string verdict = "OK";
            if (executionOutput.Memory.TotalKilobytes > executingOptions.MemoryLimit.TotalKilobytes)
                verdict = "ML";

            return new TestVerdict(executionOutput.Memory, executionOutput.Time, executionOutput.ExitCode, verdict);
        }

        public TestVerdict CheckTime(ExecutionOutput executionOutput, ExecutingOptions executingOptions)
        {
            string verdict = "OK";
            if (executionOutput.Time.TotalMilliseconds < executingOptions.TimeLimit.TotalMilliseconds)
                verdict = "TL";

            return new TestVerdict(executionOutput.Memory, executionOutput.Time, executionOutput.ExitCode, verdict);
        }
    }
}
