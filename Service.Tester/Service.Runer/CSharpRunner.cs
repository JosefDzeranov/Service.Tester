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

        public string Run(string sourceCode, string input)
        {
            string fileName = Compile(sourceCode);

            var process = CSharpProcessBuilder.BuildProcess(fileName);

            return Run(process, input);
        }

        public string Run(string sourceCode)
        {
            string fileName = Compile(sourceCode);

            var process = CSharpProcessBuilder.BuildProcess(fileName, false);

            return Run(process);
        }

        private string Compile(string sourceCode)
        {
            var fileName = $"{Guid.NewGuid()}.exe";
            var result = _compiler.Compile(sourceCode, fileName);
            if (!result.IsCompile)
                throw new Exception(result.ToString());
            return fileName;
        }

        private string Run(Process process)
        {
            process.Start();
            process.WaitForExit(TimeOut);
            var readToEnd = process.StandardOutput.ReadToEnd();
            process.Close();

            return readToEnd;
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
    }
}