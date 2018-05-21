using System.Diagnostics;
using System.IO;
using Service.Common;

namespace Service.Runner
{
    public static class CSharpProcessBuilder
    {
        public static Process BuildProcess(string fileName)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = Path.Combine(DefaultValues.CompilePath, fileName);

            Process process = new Process();
            process.StartInfo = startInfo;
            return process;
        }
    }
}