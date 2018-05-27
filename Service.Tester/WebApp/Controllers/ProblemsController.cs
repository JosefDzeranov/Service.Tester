using System;
using System.Linq;
using System.Security.Claims;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using ProblemProcessor;
using ProblemProcessor.Solutions;
using WebApp.Models.CodeCorrector;
using WebApp.Models.Problems;
using WebApp.Models.Problemset;

namespace WebApp.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemService _problemService;
        private readonly ISolutionsService _solutionsService;

        public ProblemsController(IProblemService problemService, ISolutionsService solutionsService)
        {
            _problemService = problemService;
            _solutionsService = solutionsService;
        }

        // GET
        public IActionResult Description(Guid id)
        {
            var problem = _problemService.Get(id);
            var descProblem = new DescCodeCorrectorViewModel();
            Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId);

            if (problem.Type == ProblemTypes.CodeCorrector)
            {
                descProblem = problem.Adapt<DescCodeCorrectorViewModel>();
                var solutions = _solutionsService.Get(id, userId);
                descProblem.Submissions = solutions.Select(x =>
                    new Submission
                    {
                        Solution = x.Input,
                        SendTime = x.SendTime,
                        Status = x.Result.ToString()
                    }).ToList();
            }
            return View(descProblem);
        }


        public IActionResult Create(CreateProblemViewModel problemViewModel)
        {
            _problemService.Create(problemViewModel.Adapt<ProblemData>());
            return RedirectToAction("Index", "Problemset");
        }
    }
}