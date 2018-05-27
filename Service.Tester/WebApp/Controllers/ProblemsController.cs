using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using ProblemProcessor;
using ProblemProcessor.Solutions;
using Service.InputDataGenerator;
using WebApp.Models;
using WebApp.Models.CodeCorrector;
using WebApp.Models.Problems;
using WebApp.Models.Problemset;
using WebApp.Models.RestoreData;

namespace WebApp.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemService _problemService;
        private readonly ISolutionsService _solutionsService;
        private readonly Dictionary<DataGeneratorType, IDataCreator> _generators;

        public ProblemsController(IProblemService problemService, ISolutionsService solutionsService, Dictionary<DataGeneratorType, IDataCreator> generators)
        {
            _problemService = problemService;
            _solutionsService = solutionsService;
            _generators = generators;
        }

        // GET
        public IActionResult Description(Guid id)
        {
            var problem = _problemService.Get(id);
            Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId);

            switch (problem.Type)
            {

                case ProblemTypes.CodeCorrector:
                    {
                        var viewModel = BuildDescCodeCorrectorViewModel(id, problem, userId);
                        return View(viewModel);
                    }
                case ProblemTypes.RestoreData:
                    {
                        var viewModel = BuildRestoreDataViewModel(id, problem, userId);

                        var generator = _generators[viewModel.GeneratorType];
                        var input = generator.CreateData();

                        var descRestoreDataViewModel = viewModel as DescRestoreDataViewModel;
                        if (descRestoreDataViewModel != null)
                            descRestoreDataViewModel.InputData = input;

                        return View(descRestoreDataViewModel);
                    }
            }

            return View("Error", new ErrorViewModel { RequestId = "Такого типа задания не нашлось. УПССССС" });
        }

        public IActionResult Create(CreateProblemViewModel problemViewModel)
        {
            _problemService.Create(problemViewModel.Adapt<ProblemData>());
            return RedirectToAction("Index", "Problemset");
        }


        private IDescProblemViewModel BuildDescCodeCorrectorViewModel(Guid id, ProblemData problem, Guid userId)
        {
            var viewModel = problem.Adapt<DescCodeCorrectorViewModel>();
            return BuildSubmissions(id, userId, viewModel);
        }

        private IDescProblemViewModel BuildRestoreDataViewModel(Guid id, ProblemData problem, Guid userId)
        {
            var viewModel = problem.Adapt<DescRestoreDataViewModel>();
            return BuildSubmissions(id, userId, viewModel);
        }

        private IDescProblemViewModel BuildSubmissions(Guid id, Guid userId, IDescProblemViewModel viewModel)
        {
            var solutions = _solutionsService.Get(id, userId);
            viewModel.Submissions = solutions.Select(x =>
                new Submission
                {
                    Solution = x.Input,
                    SendTime = x.SendTime,
                    Status = x.Result.ToString()
                }).ToList();
            return viewModel;
        }
    }
}