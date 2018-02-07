using System.IO;
using NUnit.Framework;

namespace Service.Runner.Test
{
    [TestFixture]
    public class CSharpProcessBuilderTest
    {
        [Test]
        public void GetProcess_GetValue_NotNull()
        {
            var processBuilder = new CSharpProcessBuilder();

            var process = processBuilder.GetProcess();

            Assert.IsNotNull(process);
        }

        [Test]
        public void BuildProcess_SetValues_GetSameValues()
        {
            var processBuilder = new CSharpProcessBuilder();
            var workingDirectory = "D://test";
            var fileName = "app.exe";

            processBuilder.BuildProcess(workingDirectory, fileName);
            var process = processBuilder.GetProcess();

            Assert.IsNotNull(process);
            Assert.AreEqual(workingDirectory, process.StartInfo.WorkingDirectory);
            Assert.AreEqual(Path.Combine(workingDirectory, fileName), process.StartInfo.FileName);
        }

        [Test]
        public void AddProcessExitEventHandler_SetDelegate_EnableRaisingEventsIsTrue()
        {
            var processBuilder = new CSharpProcessBuilder();

            processBuilder.AddProcessExitEventHandler(delegate { });
            var process = processBuilder.GetProcess();

            Assert.IsNotNull(process);
            Assert.AreEqual(true, process.EnableRaisingEvents);
        }
    }
}