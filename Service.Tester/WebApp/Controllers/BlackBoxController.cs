using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProblemProcessor;
using ProblemProcessor.BlackBox.Models;
using WebApp.Extensions;
using WebApp.Models.BlackBox;
using WebApp.Models.Problemset;

namespace WebApp.Controllers
{
    public class BlackBoxController : Controller
    {
        private readonly IProblemService _problemService;

        public BlackBoxController(IProblemService problemService)
        {
            _problemService = problemService;
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
    }
}