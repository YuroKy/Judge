using System;

namespace Judge.Models
{
    public class TestVerdict
    {
        public MemorySpan UsedMemory { get; private set; }
        public TimeSpan UsedTime { get; private set; }
        public int ExitCode { get; private set; }
        public string Verdict { get; private set; }

       public TestVerdict(MemorySpan usedMemory, TimeSpan usedTime, int exitCode, string Verdict)
        {
            this.UsedMemory = usedMemory;
            this.UsedTime = usedTime;
            this.ExitCode = exitCode;
            this.Verdict = Verdict;
        }

        public void UpdateVerdict(string verdict)
        {
            this.Verdict = verdict;
        }
        public enum  TypeVerdicts
        {
            TimeLimit, MemoryLimit, WrongAnswer, OK, Skipped 
        }

    }
}
