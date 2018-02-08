using System;
using Microsoft.CSharp.RuntimeBinder;
using Service.Compilation.Roslyn;
using Service.Runner;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Compile
            var roslynCompiler = new RoslynCompiler();
            const string fileName = "testApp.exe";
            var result = roslynCompiler.Compile(DefaultValues.sourceCode, exeName: fileName);
            var workingDirectory = result.PathToAssembly;
            Console.WriteLine(workingDirectory);

            var process = new CSharpProcessBuilder();
            process.BuildProcess(workingDirectory, fileName);
            var runner = new CSharpRunner(process);
            Console.WriteLine(runner.Run());
        }
    }
}
