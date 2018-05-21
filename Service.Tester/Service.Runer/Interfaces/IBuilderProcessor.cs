using System.Diagnostics;

namespace Service.Runner.Interfaces
{
    public interface IBuilderProcessor
    {
        Process BuildProcess(string fileName);
    }
}