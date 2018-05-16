using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.EntityFrameworkCore;
using Service.Domain.Context;
using Service.Domain.Entities;
using Service.Domain.ExtraModels;
using WebApp.Extensions;
using WebApp.Models.BlackBox;
using WebApp.Models.Problems;
using WebApp.Models.RestoreData;
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

        [HttpGet]
        [Authorize]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var problem = _dbContext.Problems.FirstOrDefault(x => x.Id == id);
            return View(problem);
        }

        // POST: Problems/Edit/5
        [HttpPost]
        [Authorize]
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
        [Authorize]
        public ActionResult ConfirmDelete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var findProblem = _dbContext.Problems.Include(x => x.Type).FirstOrDefault(x => x.Id == id).ToProblemViewModel();

            return View(findProblem);
        }

        // POST: Problems/Delete/5
        [HttpPost]
        [Authorize]
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

        [HttpPost]
        public ActionResult Create(Guid id)
        {
            return View(GetProblemViewModel(id));
        }

        private ICreateProblemViewModel GetProblemViewModel(Guid problemTypeId)
        {
            if (problemTypeId == null)
                throw new ArgumentNullException(nameof(problemTypeId));
            var problemType = _dbContext.ProblemTypes.SingleOrDefault(x => x.Id == problemTypeId);

            switch (problemType?.Name)
            {
                case ProblemTypes.TraceTable: return new TraceTableViewModel();
                case ProblemTypes.BlackBox: return new CreateBlackBoxViewModel();
                default: return new CreateRestoreDataViewModel();
            }
        }

        #region Selecting problem type
        [HttpGet]
        public IActionResult SelectProblemType()
        {
            var problemTypes = _dbContext.ProblemTypes.ToList().Select(x => x.ToViewModel());
            ViewBag.Types = new SelectList(problemTypes, nameof(ProblemTypeViewModel.Id), nameof(ProblemTypeViewModel.Name));
            return View();
        }
        #endregion
    }
}