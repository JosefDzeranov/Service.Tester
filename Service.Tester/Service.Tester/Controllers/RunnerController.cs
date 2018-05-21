using System;
using AttributeRouting;
using Microsoft.AspNetCore.Mvc;
using Service.Runner;
using Service.Runner.Compilation.Interfaces;
using Service.Runner.Interfaces;
using Service.Tester.Data;

namespace Service.Tester.Controllers
{
    [RoutePrefix(RouteConsts.VersionPrefix)]
    public class RunnerController : Controller
    {
        private readonly IRunner _runnerService;
        private readonly ICompiler _compiler;


        public RunnerController(IRunner runnerService, ICompiler compiler)
        {
            _runnerService = runnerService;
            _compiler = compiler;
        }

        [HttpPost]
        public TesterApiResult<string> Run([FromBody]string source, [FromBody]string input)
        {
            var filename = Guid.NewGuid().ToString();
            var compileResult = _compiler.Compile(source, filename);
            if (!compileResult.IsCompile)
                return new TesterApiResult<string>(compileResult.ToString());

            //IBuilderProcessor builderProcessor = CSharpProcessBuilder();
            //builderProcessor.BuildProcess(filename);
            //var resulRun = _runnerService.Run(source, input);
            //return new TesterApiResult<string>(resulRun)
            return null;
        }
    }
}