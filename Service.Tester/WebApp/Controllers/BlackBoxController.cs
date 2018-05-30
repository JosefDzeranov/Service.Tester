using System;
using System.Collections.Generic;
using System.Security.Claims;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProblemProcessor;
using ProblemProcessor.BlackBox.Models;
using ProblemProcessor.Solutions;
using Service.InputDataGenerator;
using Service.Runner.Interfaces;
using WebApp.Extensions;
using WebApp.Models.BlackBox;
using WebApp.Models.Problemset;

namespace WebApp.Controllers
{
    public class BlackBoxController : Controller
    {
        private readonly IRunner _runner;
        private readonly IProblemService _problemService;
        private readonly Dictionary<DataGeneratorType, IDataCreator> _generators;
        private readonly ISolutionsService _solutionsService;

        public BlackBoxController(IProblemService problemService, IRunner runner, Dictionary<DataGeneratorType, IDataCreator> generators, ISolutionsService solutionsService)
        {
            _problemService = problemService;
            _runner = runner;
            _generators = generators;
            _solutionsService = solutionsService;
        }

        public IActionResult Create(CreateBlackBoxViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var problem = model.Adapt<BlackBoxData>();
                    _problemService.Create(problem);
                    return RedirectToAction("Index", "Problemset");

                }
                catch
                {
                    return View("Error");
                }
            }
            var generatorTypes = DataGeneratorTypeExtensions.ToViewModel();
            ViewBag.GeneratorType = new SelectList(generatorTypes, nameof(DataGeneratorTypeViewModel.Name),
                nameof(DataGeneratorTypeViewModel.Description));
            return View("DisplayTemplates/CreateRestoreDataViewModel", model);
        }

        public IActionResult Check(DescBlackBoxViewModel model)
        {
            var problemId = model.Id;
            Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId);
            var result = TestResults.WA;

            var userCode = model.Answer;
            var correctCode = model.SourceCode;

            var input = _generators[model.GeneratorType].CreateData();

            var outPutRight = _runner.Run(correctCode, input).Trim('\n', '\r');
            var outPutUser = "";
            try
            {
                outPutUser = _runner.Run(userCode, input).Trim('\n', '\r');
            }
            catch
            {
                result = TestResults.CE;
            }

            if (result != TestResults.CE && outPutRight == outPutUser)
            {
                result = TestResults.Ok;
            }
            var solution = new Solution
            {
                Result = result,
                UserId = userId,
                Input = userCode,
                ProblemId = problemId,
                SendTime = DateTime.Now
            };
            _solutionsService.Save(solution);

            return RedirectToAction("Description", "Problems", new { model.Id });
        }
    }
}