using System;
using System.Diagnostics;

namespace Service.Runner.Interfaces
{
    public interface IBuilderProcessor
    {
        void BuildProcess(string workingDirectory, string fileName);
        Process GetProcess();
        void AddProcessExitEventHandler(EventHandler exitHandler);
    }
}