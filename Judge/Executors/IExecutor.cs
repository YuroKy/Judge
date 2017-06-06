using System;
using Judge.Executors;
using Judge.Models;

namespace Judge
{
    public interface IExecutor
    {
        /// <summary>
        /// Will be filled out by Yurii
        /// </summary>
        /// <param name="path">Path to executable file</param>
        /// <param name="input">Input data for execution</param>
        /// <param name="options"></param>
        /// <returns>Output data of execution</returns>
        ExecutionOutput Execute(string path, string input, ExecutingOptions options, string startArguments);
    }



    public class ExecutionResult
    {
        /*
         * Output -> OK/WA
         * Code -> RE
         * Time -> TL
         * Memory -> ML
         */
    }

    /*
     HardTimeLimit = MAX(2, 2*TimeLimit)
     */
}
