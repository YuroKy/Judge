namespace Judge.Models
{
    public class CompilationResult
    {
        public int ExitCode { get; private set; }
        public string Result { get; private set; }

        public CompilationResult(int exitCode, string result)
        {
            this.ExitCode = exitCode;
            this.Result = result;
        }
    }
}
