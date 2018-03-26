<<<<<<< HEAD
﻿using System;
=======
﻿using AttributeRouting;
>>>>>>> master
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
<<<<<<< HEAD
        public IActionResult Run(string sourceCode, string fileName = "Test")
        {
            var compileResult = compilerService.Compile(sourceCode, fileName);
=======
        public IActionResult Compile(string sourceCode)
        {
            var compileResult = _compilerService.Compile(sourceCode, "Test");
>>>>>>> master
            return Ok(compileResult);
        }
    }
}