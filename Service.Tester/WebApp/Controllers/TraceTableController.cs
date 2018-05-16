using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Storage.Context;
using Service.Storage.Entities;
using Service.Storage.ExtraModels;
using WebApp.Extensions;
using WebApp.Models.TraceTable;

namespace WebApp.Controllers
{
    public class TraceTableController : Controller
    {
        private readonly DatabaseContext _dbContext;

        public TraceTableController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: TraceTable
        public ActionResult Index()
        {
            return View();
        }

        // GET: TraceTable/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: TraceTable/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TraceTableViewModel traceTableViewModel)
        {
            try
            {
                var problem = traceTableViewModel.ToBo();
                SetProblemType(problem, ProblemTypes.TraceTable);
                var additioanalData = new
                {
                    traceTableViewModel.BreakPointLine,
                    traceTableViewModel.SourceCode,
                };
                problem.SpecificData = JsonConvert.SerializeObject(additioanalData);

                _dbContext.Problems.Add(problem);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", "Problems");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: TraceTable/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TraceTable/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TraceTable/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TraceTable/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        private void SetProblemType(Problem problem, ProblemTypes type)
        {
            var problemType = _dbContext.ProblemTypes.FirstOrDefault(x => x.Name == type);
            problem.Type = problemType ?? throw new InvalidOperationException();
            problem.TypeId = problemType.Id;
        }


    }
}