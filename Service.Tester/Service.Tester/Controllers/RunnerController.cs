using Microsoft.AspNetCore.Mvc;

namespace Service.Tester.Controllers
{
    public class RunnerController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}