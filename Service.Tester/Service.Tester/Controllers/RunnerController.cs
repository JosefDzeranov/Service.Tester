using System;
using System.Net;
using AttributeRouting;
using Microsoft.AspNetCore.Mvc;
using Service.Compilation.Interfaces;
using Service.Runner;
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

            IBuilderProcessor builderProcessor = new CSharpProcessBuilder();
            builderProcessor.BuildProcess(filename);
            var resulRun = _runnerService.Run(builderProcessor, input);
            return new TesterApiResult<string>(resulRun);
        }
    }
}