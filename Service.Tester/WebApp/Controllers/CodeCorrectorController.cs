using System;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using ProblemProcessor;
using ProblemProcessor.CodeCorrector;
using ProblemProcessor.CodeCorrector.Models;
using WebApp.Models.CodeCorrector;

namespace WebApp.Controllers
{
    public class CodeCorrectorController : Controller
    {
        // GET
        private readonly IProblemService _problemService;

        public CodeCorrectorController(IProblemService problemService)
        {
            _problemService = problemService;
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

        //public IActionResult Check()
    }
}