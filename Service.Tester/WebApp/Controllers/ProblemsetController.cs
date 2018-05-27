using System;
using System.Linq;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProblemProcessor;
using WebApp.Extensions;
using WebApp.Models.Problemset;

namespace WebApp.Controllers
{
    public class ProblemsetController : Controller
    {
        private readonly IProblemService _problemService;
        private readonly IProblemTypeService _problemTypeService;


        public ProblemsetController(IProblemService problemService, IProblemTypeService problemTypeService)
        {
            _problemService = problemService;
            _problemTypeService = problemTypeService;
        }

        [Authorize]
        public ActionResult Index()
        {
            var problems = _problemService.GetAll().Select(x => new ProblemViewModel
            {
                Id = x.Id,
                Type = x.Type.ToString(),
                Name = x.Name,
            });
            return View(problems);
        }

        // GET: Problems/Details/5
        //public ActionResult Details(Guid? id)
        //{
        //    if (id == null)
        //        return NotFound();

        //    var problem = _dbContext.Problems.Include(x => x.Type).FirstOrDefault(x => x.Id == id);
        //    return View(problem.ToProblemViewModel());
        //}

        //[HttpGet]
        //[Authorize]
        //public ActionResult Edit(Guid? id)
        //{
        //    if (id == null)
        //        return NotFound();

        //    var problem = _dbContext.Problems.FirstOrDefault(x => x.Id == id);
        //    return View(problem);
        //}

        //// POST: Problems/Edit/5
        //[HttpPost]
        //[Authorize]
        //public ActionResult Edit(Problem problem)
        //{
        //    try
        //    {
        //        _dbContext.Problems.Update(problem);
        //        _dbContext.SaveChanges();
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Problems/Delete/5
        //[ActionName("Delete")]
        //[Authorize]
        //public ActionResult ConfirmDelete(Guid? id)
        //{
        //    if (id == null)
        //        return NotFound();

        //    var findProblem = _dbContext.Problems.Include(x => x.Type).FirstOrDefault(x => x.Id == id).ToProblemViewModel();

        //    return View(findProblem);
        //}

        //// POST: Problems/Delete/5
        //[HttpPost]
        //[Authorize]
        //public ActionResult Delete(Guid? id)
        //{
        //    try
        //    {
        //        if (id == null)
        //            return NotFound();

        //        var phone = new Problem { Id = id.Value };
        //        _dbContext.Entry(phone).State = EntityState.Deleted;
        //        _dbContext.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (Exception)
        //    {
        //        return View(nameof(Error));
        //    }
        //}

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateProblem(CreateProblemViewModel problemViewModel)
        {
            _problemService.Create(problemViewModel.Adapt<ProblemData>());
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Guid id)
        {
            var generatorTypes = DataGeneratorTypeExtensions.ToViewModel();
            ViewBag.GeneratorType = new SelectList(generatorTypes, nameof(DataGeneratorTypeViewModel.Name),
                nameof(DataGeneratorTypeViewModel.Description));

            return View(GetProblemViewModel(id));

        }

        private CreateProblemViewModel GetProblemViewModel(Guid problemTypeId)
        {
            if (problemTypeId == null)
                throw new ArgumentNullException(nameof(problemTypeId));

            var problemType = _problemTypeService.Get(problemTypeId);
            var createProblemViewModel = ProblemTypeExtensions.GetProblemByType(problemType.Type);
            return createProblemViewModel;
        }

        #region Selecting problem type
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult SelectProblemType()
        {
            var problemTypes = _problemTypeService.GetAll().Select(t => t.Adapt<ProblemTypeViewModel>());
            ViewBag.Types = new SelectList(problemTypes, nameof(ProblemTypeViewModel.Id), nameof(ProblemTypeViewModel.Name));
            return View();
        }
        #endregion
    }
}