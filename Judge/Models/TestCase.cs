namespace Judge
{
    public class TestCase
    {
        public string Test { get; set; }
        public string Answer { get; set; }
        public TestCase(string test, string answer)
        {
            this.Test = test;
            this.Answer = answer + "\r\n";
        }
    }
}
