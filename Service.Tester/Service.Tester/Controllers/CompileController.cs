using System;
using Microsoft.AspNetCore.Mvc;
using Service.Compilation.Interfaces;

namespace Service.Tester.Controllers
{
    public class CompileController : Controller
    {
        private readonly ICompiler compilerService;

        public CompileController(ICompiler compilerService)
        {
            this.compilerService = compilerService;
        }

        [HttpPost]
        public IActionResult Run(string sourceCode, string fileName = "Test")
        {
            var compileResult = compilerService.Compile(sourceCode, fileName);
            return Ok(compileResult);
        }
    }
}