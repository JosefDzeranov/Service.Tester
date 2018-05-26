using System;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using ProblemProcessor;
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
        public IActionResult Description(Guid Id)
        {

            return View();
        }


        public IActionResult Create(CreateProblemViewModel problemViewModel)
        {
            _problemService.Create(problemViewModel.Adapt<ProblemData>());
            return RedirectToAction("Index", "Problemset");
        }
    }
}