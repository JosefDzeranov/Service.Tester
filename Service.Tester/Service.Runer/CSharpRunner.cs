using Service.Runner.Interfaces;

namespace Service.Runner
{
    public class CSharpRunner : IRunner
    {
        private readonly IBuilderProcessor _builderProcessor;
        private int timeOut = 2000;
        public CSharpRunner(IBuilderProcessor builderProcessor)
        {
            this._builderProcessor = builderProcessor;
        }

        public string Run()
        {
            var process = _builderProcessor.GetProcess();
            process.Start();
            process.WaitForExit(timeOut);
            return process.StandardOutput.ReadToEnd();
        }
    }
}