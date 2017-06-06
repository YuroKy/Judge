using System;
using Judge.Models;

namespace Judge.Executors
{
    public struct ExecutingOptions
    {
        public TimeSpan TimeLimit { get; set; }
        public MemorySpan MemoryLimit { get; set; }
        public ExecutingOptions(TimeSpan tl, MemorySpan ml)
        {
            this.TimeLimit = tl;
            this.MemoryLimit = ml;
        }
    }
}
