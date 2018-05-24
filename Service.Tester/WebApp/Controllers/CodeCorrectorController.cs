using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Create()
        {
            return View();
        }
    }
}