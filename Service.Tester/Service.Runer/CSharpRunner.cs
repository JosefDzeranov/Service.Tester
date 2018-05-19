using System;
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

        public string Run(IBuilderProcessor builderProcessor)
        {
            var process = builderProcessor.GetProcess();
            process.Start();
            process.WaitForExit(TimeOut);
            return process.StandardOutput.ReadToEnd();
        }

        public string Run(IBuilderProcessor builderProcessor, string input)
        {
            var process = builderProcessor.GetProcess();
            process.Start();
            process.StandardInput.Write(input);
            process.WaitForExit(TimeOut);
            return process.StandardOutput.ReadToEnd();
        }

        public string Run(string sourceCode, string input)
        {
            var fileName = Guid.NewGuid().ToString();
            var result = _compiler.Compile(sourceCode, fileName);
            if (!result.IsCompile)
                throw new Exception(result.ToString());
            var builder = new CSharpProcessBuilder();
            builder.BuildProcess(fileName);
            return Run(builder, input);
        }
    }
}