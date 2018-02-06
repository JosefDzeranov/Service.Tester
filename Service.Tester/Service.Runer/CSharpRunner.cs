using Service.Runner.Interfaces;

namespace Service.Runner
{
    public class CSharpRunner : IRunner
    {
        private readonly IProcessor processor;

        public CSharpRunner(IProcessor processor)
        {
            this.processor = processor;
        }

        public string Run()
        {
            var process = processor.GetProcess();
            process.Start();
            process.WaitForExit();
            return process.StandardOutput.ReadToEnd();
        }
    }
}