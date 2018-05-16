using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProblemProcessor.Restore;
using ProblemProcessor.Restore.Models;
using WebApp.Models.RestoreData;

namespace WebApp.Controllers
{
    public class RestoreDataController : Controller
    {
        private readonly IRestoreDataService _restoreDataService;

        public RestoreDataController(IRestoreDataService restoreDataService)
        {
            _restoreDataService = restoreDataService;
        }

        // GET: RestoreData
        public ActionResult Index()
        {
            return View();
        }

        // GET: RestoreData/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RestoreData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestoreData/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRestoreDataViewModel model)
        {
            try
            {
                var problem = model.Adapt<RestoreData>();
                _restoreDataService.Save(problem);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RestoreData/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RestoreData/Edit/5
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

        // GET: RestoreData/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RestoreData/Delete/5
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