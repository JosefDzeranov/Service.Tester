using System;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using ProblemProcessor;
using WebApp.Models.CodeCorrector;
using WebApp.Models.Problemset;

namespace WebApp.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemService _problemService;

        public ProblemsController(IProblemService problemService)
        {
            _problemService = problemService;
        }

        // GET
        public IActionResult Description(Guid id)
        {
            var problem = _problemService.Get(id);
            var descProblem = new DescCodeCorrectorViewModel();
            
            if (problem.Type == ProblemTypes.CodeCorrector)
                descProblem = problem.Adapt<DescCodeCorrectorViewModel>();
            return View(descProblem);
        }


        public IActionResult Create(CreateProblemViewModel problemViewModel)
        {
            _problemService.Create(problemViewModel.Adapt<ProblemData>());
            return RedirectToAction("Index", "Problemset");
        }
    }
}