using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProblemProcessor.TraceTable;
using ProblemProcessor.TraceTable.Models;
using WebApp.Models.TraceTable;

namespace WebApp.Controllers
{
    public class TraceTableController : Controller
    {
        private readonly ITraceTableService _traceTableService;

        public TraceTableController(ITraceTableService traceTableService)
        {
            _traceTableService = traceTableService;
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
                var problem = traceTableViewModel.Adapt<TraceTableData>();
                _traceTableService.Save(problem);

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
    }
}