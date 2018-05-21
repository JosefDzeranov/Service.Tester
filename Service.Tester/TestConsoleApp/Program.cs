using System;
using System.Diagnostics;
using System.IO;
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
            //var roslynCompiler = new RoslynCompiler();
            //const string fileName = "testApp.exe";
            //var result = roslynCompiler.Compile(DefaultValues.sourceCode, exeName: fileName);
            //var workingDirectory = result.PathToAssembly;
            //Console.WriteLine(workingDirectory);

            //var processBuilder = new CSharpProcessBuilder();
            //processBuilder.BuildProcessWithRedirectStandartInput(workingDirectory, fileName);
            ////var runner = new CSharpRunner();
            ////Console.WriteLine(runner.Run(processBuilder));

            var fileName = "test.exe";
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = Path.Combine(DefaultValues.CompilePath, fileName);

            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();

            process.StandardInput.WriteLine("sample");
            process.WaitForExit(1000);
            var readToEnd = process.StandardOutput.ReadToEnd();
            process.Close();
            Console.WriteLine(readToEnd);

        }
    }
}
