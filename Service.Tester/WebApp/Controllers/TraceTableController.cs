using System;
using System.Linq;
using System.Security.Claims;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using ProblemProcessor;
using ProblemProcessor.Solutions;
using ProblemProcessor.TraceTable.Models;
using Service.Runner.Interfaces;
using WebApp.Models.TraceTable;

namespace WebApp.Controllers
{
    public class TraceTableController : Controller
    {
        private readonly IProblemService _problemService;
        private readonly IRunner _runner;
        private readonly ISolutionsService _solutionsService;
        public TraceTableController(IProblemService problemService, IRunner runner, ISolutionsService solutionsService)
        {
            _problemService = problemService;
            _runner = runner;
            _solutionsService = solutionsService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTraceTableViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var problem = model.Adapt<TraceTableData>();
                    _problemService.Create(problem);

                    return RedirectToAction("Index", "Problemset");
                }
                catch
                {
                    return View("Error");
                }
            }

            return View("DisplayTemplates/CreateTraceTableViewModel", model);
        }

        [HttpPost]
        public IActionResult Check(DescTraceTableViewModel viewModel)
        {
            viewModel.Row = viewModel.Row.Where(x => !string.IsNullOrEmpty(x)).ToList();

            var answer = _runner.Run(viewModel.SourceCodeForCheck);
            answer = answer.Replace("\r\n", " ").Trim();

            var userResult = string.Join(" ", viewModel.Row.Skip(viewModel.Variables.Count)).Trim();

            var result = TestResults.WA;

            if (answer == userResult)
            {
                result = TestResults.Ok;
            }

            Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId);

            var solution = new Solution
            {
                Result = result,
                UserId = userId,
                Input = userResult,
                ProblemId = viewModel.Id,
                SendTime = DateTime.Now
            };
            _solutionsService.Save(solution);

            return RedirectToAction("Description", "Problems", new { viewModel.Id });
        }
    }
}