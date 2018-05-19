using Service.Runner.Compilation.Interfaces;
using Service.Runner.Interfaces;

namespace Service.Runner
{
    public class CSharpRunner : IRunner
    {
        private int timeOut = 2000;
        private readonly ICompiler _compiler;

        public string Run(IBuilderProcessor builderProcessor)
        {
            var process = builderProcessor.GetProcess();
            process.Start();
            process.WaitForExit(timeOut);
            return process.StandardOutput.ReadToEnd();
        }

        public string Run(IBuilderProcessor builderProcessor, string input)
        {
            var process = builderProcessor.GetProcess();
            process.Start();
            process.StandardInput.Write(input);
            process.WaitForExit(timeOut);
            return process.StandardOutput.ReadToEnd();
        }

        public string Run(string sourceCode, string input)
        {
            throw new System.NotImplementedException();
        }
    }
}