using Judge.Models;

namespace Judge
{
    public class ProgramBuilder
    {
        public string Path { get; set; }
        public string StartArgument { get; set; }
        public CompilationResult CompilationResult { get; private set; }


        private ConfigurationService _service = new ConfigurationService();

        public void Create(string languageName, FileFactory factory, string sourceCode)
        {
            Compiler compiler = _service.GetCompilerByName(languageName);
            

            if (compiler.Type == LanguageType.сompiler)
            {
                Path = factory.CreateFileAndGetFileName(sourceCode);
                compiler.UpdateCommand(Path, Path);
                CompilationResult = compiler.Compile();
            }
            else
            {
                Path = compiler.GetPath();
                StartArgument = factory.CreateFileAndGetFileName(sourceCode);
                CompilationResult = new CompilationResult(0, "INTERPRETER");
            }

        }

        public ExecuteConfiguration GetExecuteConfiguration()
        {
            return new ExecuteConfiguration(Path, StartArgument);
        }
    }
}