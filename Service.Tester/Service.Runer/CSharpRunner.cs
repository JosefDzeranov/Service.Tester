using System;
using System.Diagnostics;
using Service.Runner.Compilation.Interfaces;
using Service.Runner.Interfaces;

namespace Service.Runner
{
    public class CSharpRunner : IRunner
    {
        private const int TimeOut = 2000;
        private readonly ICompiler _compiler;

        public CSharpRunner(ICompiler compiler)
        {
            _compiler = compiler;
        }

        private string Run(Process process, string input)
        {
            process.Start();
            process.StandardInput.WriteLine(input);
            process.WaitForExit(TimeOut);
            var readToEnd = process.StandardOutput.ReadToEnd();
            process.Close();

            return readToEnd;
        }

        public string Run(string sourceCode, string input)
        {
            var fileName = $"{Guid.NewGuid()}.exe";
            var result = _compiler.Compile(sourceCode, fileName);
            if (!result.IsCompile)
                throw new Exception(result.ToString());

            var process = CSharpProcessBuilder.BuildProcess(fileName);
            return Run(process, input);
        }
    }
}