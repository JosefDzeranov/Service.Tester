using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceCode = @"int a = Convert.ToInt16(Console.ReadLine());
            int b = Convert.ToInt16(Console.ReadLine());
            if (a > b)
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(b);
            }
            ";

            var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);

            string[] identifierNames = syntaxTree.GetRoot().DescendantNodes()
                .OfType<VariableDeclaratorSyntax>().Select(v => v.Identifier.Text)
                .Concat(syntaxTree.GetRoot().DescendantNodes().OfType<ParameterSyntax>().Select(p => p.Identifier.Text))
                .ToArray();

            foreach (var variable in identifierNames)
            {
                Console.WriteLine(variable);
            }

            //// Compile
            ////var roslynCompiler = new RoslynCompiler();
            ////const string fileName = "testApp.exe";
            ////var result = roslynCompiler.Compile(DefaultValues.sourceCode, exeName: fileName);
            ////var workingDirectory = result.PathToAssembly;
            ////Console.WriteLine(workingDirectory);

            ////var processBuilder = new CSharpProcessBuilder();
            ////processBuilder.BuildProcessWithRedirectStandartInput(workingDirectory, fileName);
            //////var runner = new CSharpRunner();
            //////Console.WriteLine(runner.Run(processBuilder));

            //var fileName = "test.exe";
            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.UseShellExecute = false;
            //startInfo.RedirectStandardInput = true;
            //startInfo.RedirectStandardOutput = true;
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //startInfo.FileName = Path.Combine(DefaultValues.CompilePath, fileName);

            //Process process = new Process();
            //process.StartInfo = startInfo;
            //process.Start();

            //process.StandardInput.WriteLine("sample");
            //process.WaitForExit(1000);
            //var readToEnd = process.StandardOutput.ReadToEnd();
            //process.Close();
            //Console.WriteLine(readToEnd);

        }
    }
}
