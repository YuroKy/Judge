using Judge.Logger;
using System;
using System.Collections.Generic;
using Judge.Checkers;
using Judge.Models;
using Ninject;
using Judge.IOC;

namespace Judge
{
    public class JudgeProcess
    {
        private string _root;
        private FileFactory _factory;
        private LogUpdater _logUpdater;
        private List<Protocol> _protocolList = new List<Protocol>();
        public static IKernel ApprKernel = new StandardKernel(new CheckerNinjectModule(), new ExecutorNinjectModule());


        public JudgeProcess(string root)
        {
            _root = root;
            _factory = new FileFactory(_root);
            _logUpdater = new LogUpdater();
        }

        public void Run(Problem problem, Submit submit)
        {
            Logger.Logger.InitLogger();
            Logger.Logger.Log.Info(String.Format("Solve ID:{0}", _factory.GetId()));

            Judger judger = new Judger(_factory, problem, submit);
            Protocol protocol = judger.Judge();

            Logger.Logger.Log.Info(String.Format("Sumbit Info\nLanguage:{0}\nSource code:{1}", protocol.Submit.SourceLanguage, protocol.Submit.SourceCode));
            Logger.Logger.Log.Info(String.Format("Build info\nBuild Result:{1}\nExit code:{0}", protocol.CompilationResult.ExitCode, protocol.CompilationResult.Result));
            Logger.Logger.Log.Info("Verdict info");

            foreach (var result in protocol.Results.Values)
            {
                string x = String.Format("Verdict:{0}\tMemory:{1}KB\tExecuting Time:{2}s\tExitCode:{3}", result.Verdict,
                    result.UsedMemory.TotalKilobytes, result.UsedTime.TotalSeconds, result.ExitCode);

                Logger.Logger.Log.Info(x);
            }

            _protocolList.Add(protocol);
            _logUpdater.UpdateConfig();
        }

        public Protocol GetProtocolCurrentTest()
        {
            return _protocolList[_protocolList.Count - 1];
        }
        public List<Protocol> GetProtocolList()
        {
            return _protocolList;
        }
    }
}
