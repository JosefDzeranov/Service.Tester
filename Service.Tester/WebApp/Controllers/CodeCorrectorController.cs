using Mapster;
using Microsoft.AspNetCore.Mvc;
using ProblemProcessor.CodeCorrector;
using ProblemProcessor.CodeCorrector.Models;
using WebApp.Models.CodeCorrector;

namespace WebApp.Controllers
{
    public class CodeCorrectorController : Controller
    {
        // GET
        private readonly ICodeCorrectorService _codeCorrectorService;

        public CodeCorrectorController(ICodeCorrectorService codeCorrectorService)
        {
            _codeCorrectorService = codeCorrectorService;
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
                _codeCorrectorService.Save(problem);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}