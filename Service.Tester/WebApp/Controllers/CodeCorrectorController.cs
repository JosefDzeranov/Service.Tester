using System;
using System.Collections.Generic;
using System.Security.Claims;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProblemProcessor;
using ProblemProcessor.CodeCorrector.Models;
using ProblemProcessor.Solutions;
using Service.InputDataGenerator;
using Service.Runner.Interfaces;
using WebApp.Models;
using WebApp.Models.CodeCorrector;

namespace WebApp.Controllers
{
    public class CodeCorrectorController : Controller
    {
        private readonly IProblemService _problemService;
        private readonly IRunner _runner;
        private readonly Dictionary<DataGeneratorType, IDataCreator> _generators;
        private readonly ISolutionsService _solutionsService;

        public CodeCorrectorController(IProblemService problemService,
                                       IRunner runner,
                                       Dictionary<DataGeneratorType,
                                       IDataCreator> generators,
                                       ISolutionsService solutionsService)
        {
            _problemService = problemService;
            _runner = runner;
            _generators = generators;
            _solutionsService = solutionsService;
        }


        public IActionResult Index()
        {
            return
            View();
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize]
        public IActionResult Check(DescCodeCorrectorViewModel viewModel)
        {
            var generator = _generators[viewModel.GeneratorType];
            var input = generator.CreateData();
            try
            {
                var problemId = viewModel.Id;
                Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId);

                var outPutRight = _runner.Run(viewModel.SourceCode, input).Trim('\n', '\r');
                var result = TestResults.WA;
                var outPutUser = "";
                try
                {
                    outPutUser = _runner.Run(viewModel.IncorrectSourceCode, input).Trim('\n', '\r');
                }
                catch (Exception e)
                {
                    result = TestResults.CE;
                }

                if (outPutRight == outPutUser)
                {
                    result = TestResults.Ok;
                }

                var solution = new Solution()
                {
                    Result = result,
                    UserId = userId,
                    Input = input,
                    ProblemId = problemId,
                    SendTime = DateTime.Now
                };
                _solutionsService.Save(solution);

                return RedirectToAction("Description", "Problems", new { viewModel.Id });
            }
            catch (Exception e)
            {
                return View("Error", new ErrorViewModel() { RequestId = e.Message });
            }

        }
    }
}