using System.Diagnostics;
using Judge.Models;
using Ninject;
using Judge.IOC;

namespace Judge
{
    public class Compiler
    {
        private string _path;
        private string _command;
        private string _name;
        public LanguageType Type { get; private set; }
        IExecutor compiler = JudgeProcess.ApprKernel.Get<IExecutor>();

        public Compiler(string name, string path, string command, LanguageType type)
        {
            this._path = path;
            this._command = command;
            this._name = name;
            this.Type = type;
        }

        public string GetName() { return _name;}
        public string GetPath() { return _path; }
        public string GetCommand() { return _command; }

        public void UpdateCommand(string input, string output)
        {
            this._command = this._command.Replace("{input}", input);
            this._command = this._command.Replace("{output}", output);
        }

        public CompilationResult Compile()
        {
            Process compiler = new Process();
            compiler.StartInfo = new ProcessStartInfo(this._path);
            compiler.StartInfo.CreateNoWindow = true;
            compiler.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            compiler.StartInfo.RedirectStandardInput = true;
            compiler.StartInfo.RedirectStandardOutput = true;
            compiler.StartInfo.UseShellExecute = false;
            compiler.StartInfo.Arguments = _command;
            compiler.Start();
            string result = compiler.StandardOutput.ReadToEnd();
            compiler.WaitForExit();
            var exitCode = compiler.ExitCode;
     
            return new CompilationResult(exitCode, result);
        }
    }
}
/*
*
* 
*   Language + SourceCode ->    Execution file
*     C                            1) compile     2) C:/judger/submit/1/program.exe
*     I                                           1) C:/programs/compilers/python.exe C:/judger/submit/1/program.txt
*
*     ProgramBuilder
*     var pb = ProgramBuilder.Create()
*         .Build()  // returns 
*/
