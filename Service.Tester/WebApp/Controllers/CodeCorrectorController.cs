using Microsoft.AspNetCore.Mvc;
using WebApp.Models.CodeCorrector;

namespace WebApp.Controllers
{
    public class CodeCorrectorController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }

        public IActionResult Create(CreateCodeCorrectorViewModel model)
        {

            return View();
        }
    }
}