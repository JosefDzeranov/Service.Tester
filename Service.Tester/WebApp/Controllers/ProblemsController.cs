using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.EntityFrameworkCore;
using Service.Domain.Context;
using Service.Domain.Entities;
using Service.Domain.ExtraModels;
using WebApp.Extensions;
using WebApp.Models.Problems;
using WebApp.Models.TraceTable;

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
            var problems = _dbContext.Problems.Select(x => new ProblemViewModel
            {
                Id = x.Id,
                Type = x.Type.FullName,
                Name = x.Name,
                LastModifiedTime = x.LastModifiedTime,
                Tags = x.Tags
            });
            return View(problems);
        }

        // GET: Problems/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
                return NotFound();

            var problem = _dbContext.Problems.Include(x => x.Type).FirstOrDefault(x => x.Id == id);
            return View(problem.ToProblemViewModel());
        }

        // GET: Problems/Create
        public ActionResult Create()
        {
            //var problemTypes = _dbContext.ProblemTypes.ToList();
            //ViewBag.TypeIds = new SelectList(problemTypes, "Id", "FullName");
            return View("TraceTable");
        }

        // POST: Problems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTraceTableProblem(TraceTableViewModel item)
        {
            try
            {
                var problem = item.ToBo();
                SetProblemType(problem, ProblemTypes.TraceTable);

                _dbContext.Problems.Add(problem);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("TraceTable");
            }
        }

        private void SetProblemType(Problem problem, ProblemTypes type)
        {
            var problemType = _dbContext.ProblemTypes.FirstOrDefault(x => x.Name == type);
            problem.Type = problemType ?? throw new InvalidOperationException();
            problem.TypeId = problemType?.Id;
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

            var findProblem = _dbContext.Problems.Include(x => x.Type).FirstOrDefault(x => x.Id == id).ToProblemViewModel();

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
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(nameof(Error));
            }
        }
    }
}