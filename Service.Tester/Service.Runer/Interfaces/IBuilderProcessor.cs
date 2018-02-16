using System;
using System.Diagnostics;

namespace Service.Runner.Interfaces
{
    public interface IBuilderProcessor
    {
        void BuildProcessWithRedirectStandartInput(string workingDirectory, string fileName);

        void BuildProcessWithoutRedirectStandartInput(string workingDirectory, string fileName);
        void BuildProcess(string fileName);
        Process GetProcess();
        void AddProcessExitEventHandler(EventHandler exitHandler);
    }
}