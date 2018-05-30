using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using ProblemProcessor;
using ProblemProcessor.Restore.Models;
using ProblemProcessor.Solutions;
using Service.InputDataGenerator;
using Service.Runner.Interfaces;
using WebApp.Models;
using WebApp.Models.BlackBox;
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
        private readonly IRunner _runner;
        private readonly Dictionary<DataGeneratorType, IDataCreator> _generators;

        public ProblemsController(IProblemService problemService, ISolutionsService solutionsService, Dictionary<DataGeneratorType, IDataCreator> generators, IRunner runner)
        {
            _problemService = problemService;
            _solutionsService = solutionsService;
            _generators = generators;
            _runner = runner;
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
                        var descRestoreDataViewModel = new DescRestoreDataViewModel();
                        var generator = _generators[viewModel.GeneratorType];

                        var generatedData = generator.CreateData();

                        if (problem is RestoreData data && viewModel is DescRestoreDataViewModel temp)
                        {
                            if (data.AdditionalData.IsInput)
                                temp.InputData = generatedData;
                            else
                            {
                                var output = _runner.Run(temp.SourceCode, generatedData).Trim('\n', '\r');
                                temp.OutputData = output;
                            }
                            descRestoreDataViewModel = temp;
                        }

                        return View(descRestoreDataViewModel);
                    }
                case ProblemTypes.BlackBox:
                    {
                        var viewModel = BuildBlackBoxViewModel(id, problem, userId);
                        return View(viewModel);
                    }
            }

            return View("Error", new ErrorViewModel { RequestId = "Такого типа задания не нашлось. УПССССС" });
        }

        public IActionResult Create(ICreateProblemViewModel problemViewModel)
        {
            _problemService.Create(problemViewModel.Adapt<ProblemData>());
            return RedirectToAction("Index", "Problemset");
        }

        [HttpPost]
        public string Check([FromBody]UserAnswer answer)
        {

            return _runner.Run(answer.SourceCode, answer.Input);
        }

        private IDescProblemViewModel BuildBlackBoxViewModel(Guid id, ProblemData problem, Guid userId)
        {
            var viewModel = problem.Adapt<DescBlackBoxViewModel>();
            return BuildSubmissions(id, userId, viewModel);
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

        public class UserAnswer
        {
            public string SourceCode { get; set; }
            public string Input { get; set; }
        }
    }
}