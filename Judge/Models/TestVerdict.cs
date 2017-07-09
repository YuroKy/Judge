using System;

namespace Judge.Models
{
    public class TestVerdict
    {
        public MemorySpan UsedMemory { get; private set; }
        public TimeSpan UsedTime { get; private set; }
        public int ExitCode { get; private set; }
        public TypeVerdicts Verdict { get; private set; }

       public TestVerdict(MemorySpan usedMemory, TimeSpan usedTime, int exitCode, TypeVerdicts verdict)
        {
            this.UsedMemory = usedMemory;
            this.UsedTime = usedTime;
            this.ExitCode = exitCode;
            this.Verdict = verdict;
        }

        public void UpdateVerdict(TypeVerdicts verdict)
        {
            this.Verdict = verdict;
        }
       

    }
    public enum TypeVerdicts
    {
        OK = 1,
        TimeLimit,
        MemoryLimit,
        WrongAnswer,
        RuntimeError,
        SystemError,
        Skipped
    }
}
