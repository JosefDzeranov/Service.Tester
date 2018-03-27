using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;
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
        public ActionResult Details(Guid id)
        {
            var problem = _dbContext.Problems.FirstOrDefault(x => x.Id == id);
            return View(problem);
        }

        // GET: Problems/Create
        public ActionResult Create()
        {
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
        public ActionResult Edit(Guid id)
        {
            var problem = _dbContext.Problems.FirstOrDefault(x => x.Id == id);
            return View(problem);
        }

        // POST: Problems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, Problem problem)
        {
            try
            {
                if (problem.Id != id)
                    return new NotFoundResult();

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
        public ActionResult Delete(Guid id)
        {
            var findProblem = _dbContext.Problems.FirstOrDefault(x => x.Id == id);
            return View(findProblem);
        }

        // POST: Problems/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, Problem problem)
        {
            try
            {
                if (problem.Id != id)
                    return new NotFoundResult();

                var findProblem = _dbContext.Problems.FirstOrDefault(x => x.Id == id);
                if (findProblem != null)
                {
                    _dbContext.Problems.Remove(findProblem);
                    _dbContext.SaveChanges();
                }
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch (Exception exception)
            {
                return View(nameof(Error));
            }
        }
    }
}