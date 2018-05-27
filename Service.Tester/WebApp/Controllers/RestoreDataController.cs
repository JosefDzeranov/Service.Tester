using System;
using System.Collections.Generic;
using System.Security.Claims;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProblemProcessor;
using ProblemProcessor.Restore.Models;
using ProblemProcessor.Solutions;
using Service.InputDataGenerator;
using Service.Runner.Interfaces;
using WebApp.Models;
using WebApp.Models.RestoreData;

namespace WebApp.Controllers
{
    public class RestoreDataController : Controller
    {
        private readonly IProblemService _problemService;
        private readonly Dictionary<DataGeneratorType, IDataCreator> _generators;
        private readonly IRunner _runner;
        private readonly ISolutionsService _solutionsService;

        public RestoreDataController(IProblemService problemService, Dictionary<DataGeneratorType, IDataCreator> generators, IRunner runner, ISolutionsService solutionsService)
        {
            _problemService = problemService;
            _generators = generators;
            _runner = runner;
            _solutionsService = solutionsService;
        }


        // POST: RestoreData/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(CreateRestoreDataViewModel model)
        {
            try
            {
                var problem = model.Adapt<RestoreData>();
                _problemService.Create(problem);
                return RedirectToAction("Index", "Problemset");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        public IActionResult Check(DescRestoreDataViewModel viewModel)
        {
            var input = viewModel.InputData;
            try
            {
                var problemId = viewModel.Id;
                Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId);

                var outPutRight = _runner.Run(viewModel.SourceCode, input).Trim('\n', '\r');
                var result = TestResults.WA;
                var outPutUser = viewModel.OutputData;

                if (outPutRight == outPutUser)
                {
                    result = TestResults.Ok;
                }

                var solution = new Solution
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