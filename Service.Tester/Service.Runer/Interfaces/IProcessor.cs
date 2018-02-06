using System;
using System.Diagnostics;

namespace Service.Runner.Interfaces
{
    public interface IProcessor
    {
        void BuildProcess(string workingDirectory, string fileName);
        Process GetProcess();
        void AddProcessExitEventHandler(EventHandler exitHandler);
    }
}