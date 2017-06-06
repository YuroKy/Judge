using System.Collections.Generic;

namespace Judge.Models
{
    public class Protocol
    {
        public Submit Submit { get; set; }
        public Dictionary<TestCase, TestVerdict> Results = new Dictionary<TestCase, TestVerdict>();
        public CompilationResult CompilationResult { get; set; }
    }
}
