using AttributeRouting;
using Microsoft.AspNetCore.Mvc;
using Service.Compilation.Interfaces;
using Service.Tester.Data;

namespace Service.Tester.Controllers
{

    [RoutePrefix(RouteConsts.VersionPrefix)]
    public class CompileController : Controller
    {
        private readonly ICompiler _compilerService;

        public CompileController(ICompiler compilerService)
        {
            this._compilerService = compilerService;
        }

        [HttpPost]
        public IActionResult Compile(string sourceCode)
        {
            var compileResult = _compilerService.Compile(sourceCode, "Test");
            return Ok(compileResult);
        }
    }
}