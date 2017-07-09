using System;
using Judge.Models;

namespace Judge.Executors
{
    public struct ExecutingOptions
    {
        public TimeSpan TimeLimit { get; set; }
        public MemorySpan MemoryLimit { get; set; }
        public ExecutingOptions(TimeSpan timeLimit, MemorySpan memoryLimit)
        {
            this.TimeLimit = timeLimit;
            this.MemoryLimit = memoryLimit;
        }
    }
}
