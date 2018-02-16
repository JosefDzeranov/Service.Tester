using System;
using System.Diagnostics;
using System.IO;
using Service.Common;
using Service.Runner.Interfaces;

namespace Service.Runner
{
    public class CSharpProcessBuilder : IBuilderProcessor
    {
        private readonly Process _process;

        public CSharpProcessBuilder()
        {
            _process = new Process();
        }

        public void BuildProcessWithRedirectStandartInput(string workingDirectory, string fileName)
        {
            _process.StartInfo.RedirectStandardInput = true;
            BuildProcessWithoutRedirectStandartInput(workingDirectory, fileName);
        }

        public void BuildProcessWithoutRedirectStandartInput(string workingDirectory, string fileName)
        {
            _process.StartInfo.WorkingDirectory = workingDirectory;
            _process.StartInfo.FileName = Path.Combine(workingDirectory, fileName);
            _process.StartInfo.RedirectStandardOutput = true;
        }

        public void BuildProcess(string fileName)
        {
            var workingDirectory = DefaultValues.CompilePath;
            BuildProcessWithRedirectStandartInput(workingDirectory, fileName);
        }

        public Process GetProcess()
        {
            return _process;
        }

        public void AddProcessExitEventHandler(EventHandler exitHandler)
        {
            _process.EnableRaisingEvents = true;
            _process.Exited += exitHandler;
        }
    }
}