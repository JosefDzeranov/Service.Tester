using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ProblemsController : Controller
    {
        // GET
        public IActionResult Description()
        {
            return View();
        }
    }
}