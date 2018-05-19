using System;
using Service.Common;
using Service.Runner;
using Service.Runner.Compilation.Roslyn;

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

            var processBuilder = new CSharpProcessBuilder();
            processBuilder.BuildProcessWithRedirectStandartInput(workingDirectory, fileName);
            //var runner = new CSharpRunner();
            //Console.WriteLine(runner.Run(processBuilder));
        }
    }
}
