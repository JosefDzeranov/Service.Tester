using System;
using System.Collections.Generic;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using ProblemProcessor;
using ProblemProcessor.CodeCorrector.Models;
using Service.InputDataGenerator;
using Service.Runner.Interfaces;
using WebApp.Models.CodeCorrector;

namespace WebApp.Controllers
{
    public class CodeCorrectorController : Controller
    {
        private readonly IProblemService _problemService;
        private readonly IRunner _runner;
        private readonly Dictionary<DataGeneratorType, IDataCreator> _generators;

        public CodeCorrectorController(IProblemService problemService, IRunner runner, Dictionary<DataGeneratorType, IDataCreator> generators)
        {
            _problemService = problemService;
            _runner = runner;
            _generators = generators;
        }


        public IActionResult Index()
        {
            return
            View();
        }

        public IActionResult Create(CreateCodeCorrectorViewModel model)
        {
            try
            {
                var problem = model.Adapt<CodeCorrectorData>();
                _problemService.Create(problem);
                return RedirectToAction("Index", "Problemset");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View("Error");
            }
        }

        public IActionResult Check(DescCodeCorrectorViewModel viewModel)
        {
            var generator = _generators[viewModel.Type];
            var input = generator.CreateData();

            var outPutUser = _runner.Run(viewModel.IncorrectSourceCode, input).Trim('\n', '\r');
            var outPutRight = _runner.Run(viewModel.SourceCode, input).Trim('\n', '\r');

            ViewBag.Input = input;
            ViewBag.outPutUser = outPutUser;
            ViewBag.outPutRight = outPutRight;

            return View();
        }
    }
}