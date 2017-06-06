using System.Collections.Generic;
using Judge.Executors;

namespace Judge
{
    public class Problem
    {
        public List<TestCase> Tests = new List<TestCase>();
        public ExecutingOptions Options { get; private set; }

        public Problem(ExecutingOptions options)
        {
            Options = options;
        }
    }
}
