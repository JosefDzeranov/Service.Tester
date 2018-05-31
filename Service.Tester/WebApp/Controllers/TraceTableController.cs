using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProblemProcessor;
using ProblemProcessor.TraceTable.Models;
using WebApp.Models.TraceTable;

namespace WebApp.Controllers
{
    public class TraceTableController : Controller
    {
        private readonly IProblemService _problemService;

        public TraceTableController(IProblemService problemService)
        {
            _problemService = problemService;
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
        public ActionResult Create(CreateTraceTableViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var problem = model.Adapt<TraceTableData>();
                    _problemService.Create(problem);

                    return RedirectToAction("Index", "Problemset");
                }
                catch
                {
                    return View("Error");
                }
            }

            return View("DisplayTemplates/CreateTraceTableViewModel", model);
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
    }
}