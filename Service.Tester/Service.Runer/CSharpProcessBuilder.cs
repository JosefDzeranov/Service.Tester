using System;
using System.Diagnostics;
using System.IO;
using Service.Runner.Interfaces;

namespace Service.Runner
{
    public class CSharpProcessBuilder : IBuilderProcessor
    {
        private readonly Process process;

        public CSharpProcessBuilder()
        {
            this.process = new Process();
        }

        public Process GetProcess()
        {
            return process;
        }

        public void BuildProcess(string workingDirectory, string fileName, bool redirectStandardInput = false)
        {
            process.StartInfo.WorkingDirectory = workingDirectory;
            process.StartInfo.FileName = Path.Combine(workingDirectory, fileName);
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = redirectStandardInput;
        }

        public void AddProcessExitEventHandler(EventHandler exitHandler)
        {
            process.EnableRaisingEvents = true;
            process.Exited += exitHandler;
        }
    }
}