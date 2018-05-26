using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Service.Storage.Context;
using Service.Storage.Entities;
using Service.Storage.ExtraModels;
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
                new ProblemType {Type = ProblemTypes.None, Name = "Неизвестно"},
                new ProblemType {Type = ProblemTypes.TraceTable, Name = "Трассировочная таблица"},
                new ProblemType {Type = ProblemTypes.BlackBox, Name = "Черный ящик"},
                new ProblemType {Type = ProblemTypes.RestoreData, Name = "Восстановление данных"},
                new ProblemType {Type = ProblemTypes.CodeCorrector, Name = "Исправление кода"},
            };
        }
    }
}
