using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Service.Storage.Context;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(DatabaseContext dbContext)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
