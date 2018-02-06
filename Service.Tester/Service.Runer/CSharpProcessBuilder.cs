using System;
using System.Diagnostics;
using System.IO;
using Service.Runner.Interfaces;

namespace Service.Runner
{
    public class CSharpProcessBuilder : IProcessor
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

        void IProcessor.BuildProcess(string workingDirectory, string fileName)
        {
            process.StartInfo.WorkingDirectory = workingDirectory;
            process.StartInfo.FileName = Path.Combine(workingDirectory, fileName);
            process.StartInfo.RedirectStandardOutput = true;
        }

        public void AddProcessExitEventHandler(EventHandler exitHandler)
        {
            process.EnableRaisingEvents = true;
            process.Exited += exitHandler;
        }
    }
}