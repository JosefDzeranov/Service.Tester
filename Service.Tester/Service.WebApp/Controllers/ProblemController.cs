using Microsoft.AspNetCore.Mvc;

namespace Service.WebApp.Controllers
{
    public class ProblemController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}