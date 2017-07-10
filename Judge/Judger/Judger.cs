using System.Collections.Generic;
using Judge.Checkers;
using Judge.Executors;
using Judge.Models;
using Ninject;

namespace Judge
{
    public class Judger
    {

        private List<string> _results = new List<string>();
        private ConfigurationService _service = new ConfigurationService();
        private FileFactory _factory;
        private IChecker _checker;
        private TimeAndMemoryChecker _limitChecker = new TimeAndMemoryChecker();
        private Problem _problem;
        private ExecutingOptions _options;
        private Submit _submit;
        Protocol _protocol = new Protocol();

        public string BuildedFileName { get; private set; }


        public Judger(FileFactory factory, Problem problem, Submit submit)
        {
            _factory = factory;
            _problem = problem;
            _options = problem.Options;
            _submit = submit;
            _checker = JudgeProcess.ApprKernel.Get<IChecker>();
        }

        public void Assessment(string pathToSolve, Problem problem, ExecuteConfiguration configuration)
        {

            foreach (var solve in problem.Tests)
            {
                Executor exe = new Executor();
                var executeOutput = exe.Execute(pathToSolve, solve.Test, _options, configuration.StartArgument);

                var testVerdict = _limitChecker.CheckTime(executeOutput, _options);
                testVerdict = _limitChecker.CheckMemory(executeOutput, _options);
                if (testVerdict.Verdict == TypeVerdicts.OK)
                {
                    if (_checker.Check(solve.Answer, executeOutput.Result))
                        testVerdict.UpdateVerdict(TypeVerdicts.OK);
                    else
                        testVerdict.UpdateVerdict(TypeVerdicts.WrongAnswer);
                }
                _protocol.Results.Add(solve, testVerdict);

            }
        }

        public Protocol Judge()
        {
            ProgramBuilder builder = new ProgramBuilder();
            builder.Create(_submit.SourceLanguage, _factory, _submit.SourceCode);
            _protocol.Submit = _submit;
            _protocol.CompilationResult = builder.CompilationResult;
            

            if (_protocol.CompilationResult.ExitCode == 0)
                Assessment(_protocol.CompilationResult.Result != "INTERPRETER" ? builder.Path + ".exe" : builder.Path, _problem, builder.GetExecuteConfiguration());
            else
                Logger.Logger.Log.Info("Build Error");

            return _protocol;
        }
    }
}