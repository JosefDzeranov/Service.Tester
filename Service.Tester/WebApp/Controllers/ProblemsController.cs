using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.EntityFrameworkCore;
using Service.Domain.Context;
using Service.Domain.Entities;

namespace WebApp.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly DatabaseContext _dbContext;

        public ProblemsController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Problems
        public ActionResult Index()
        {
            var problems = _dbContext.Problems.ToList();
            return View(problems);
        }

        // GET: Problems/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
                return NotFound();

            var problem = _dbContext.Problems.FirstOrDefault(x => x.Id == id);
            return View(problem);
        }

        // GET: Problems/Create
        public ActionResult Create()
        {
            var problemTypes = _dbContext.ProblemTypes.ToList();
            ViewBag.TypeIds = new SelectList(problemTypes, "Id", "FullName");
            return View();
        }

        // POST: Problems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Problem problem)
        {
            try
            {
                _dbContext.Problems.Add(problem);
                _dbContext.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Problems/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var problem = _dbContext.Problems.FirstOrDefault(x => x.Id == id);
            return View(problem);
        }

        // POST: Problems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Problem problem)
        {
            try
            {
                _dbContext.Problems.Update(problem);
                _dbContext.SaveChanges();
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Problems/Delete/5
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var findProblem = _dbContext.Problems.FirstOrDefault(x => x.Id == id);
            return View(findProblem);
        }

        // POST: Problems/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid? id)
        {
            try
            {
                if (id == null)
                    return NotFound();

                var phone = new Problem { Id = id.Value };
                _dbContext.Entry(phone).State = EntityState.Deleted;
                _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(nameof(Error));
            }
        }
    }
}