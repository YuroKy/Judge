using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Judge.Checkers
{
    public class StringChecker : IChecker
    {
        public bool Check(string input, string output)
        {
            return DeleteLine(input) == DeleteLine(output);
        }

        private string DeleteLine(string input)
        {
            if (input.Length > 0)
                if (input[input.Length - 1] == '\n')
                    return input.Substring(0, input.Length - 2);
            return input;
        }
    }
}
