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
            var process = CSharpProcessBuilder.BuildProcess("qweqwe");

            Assert.IsNotNull(process);
        }

        [Test]
        public void BuildProcess_SetValues_GetSameValues()
        {
            //var processBuilder = new CSharpProcessBuilder();
            //var workingDirectory = "D://test";
            //var fileName = "app.exe";

            //processBuilder.BuildProcess(workingDirectory, fileName);
            //var process = processBuilder.GetProcess();

            //Assert.IsNotNull(process);
            //Assert.AreEqual(workingDirectory, process.StartInfo.WorkingDirectory);
            //Assert.AreEqual(Path.Combine(workingDirectory, fileName), process.StartInfo.FileName);
        }
    }
}