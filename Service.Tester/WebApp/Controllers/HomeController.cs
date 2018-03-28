using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Domain.Context;
using Service.Domain.Entities;
using Service.Domain.ExtraModels;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _dbContext;

        public HomeController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
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

        public IActionResult FirstStart()
        {
            _dbContext.ProblemTypes.AddRange(GetAllProblemTypes());
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private List<ProblemType> GetAllProblemTypes()
        {
            return new List<ProblemType>
            {
                new ProblemType {Name = ProblemTypes.TraceTable, FullName = "Трассировочная таблица"},
                new ProblemType {Name = ProblemTypes.BlackBox, FullName = "Черный ящик"},
                new ProblemType {Name = ProblemTypes.None, FullName = "Неизвестно"}
            };
        }
    }
}
