using System;
using NUnit.Framework;

namespace Service.Runner.Test
{
    [TestFixture]
    internal class CSharpRunnerTest
    {
        [Test]
        public void Run_NoBuildProcess_Exception()
        {
            var processBuilder = new CSharpProcessBuilder();
            var runner = new CSharpRunner(processBuilder);

            try
            {
                runner.Run();
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
        }
    }
}
