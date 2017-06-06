namespace Judge
{
    public class Submit
    {
        public string SourceCode { get; private set; }
        public string SourceLanguage { get; private set; }

        public Submit(string sourceCode, string sourceLanguage)
        {
            this.SourceCode = sourceCode;
            this.SourceLanguage = sourceLanguage;
        }
    }
}
