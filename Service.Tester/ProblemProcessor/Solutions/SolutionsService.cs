using System;
using System.Collections.Generic;
using System.Linq;
using Mapster;
using Service.Storage;

namespace ProblemProcessor.Solutions
{
    public class SolutionsService : ISolutionsService
    {
        private readonly ISolutionRepository _solutionRepository;
        private readonly IProblemRepository _problemRepository;
        public SolutionsService(ISolutionRepository solutionRepository, IProblemRepository problemRepository)
        {
            _solutionRepository = solutionRepository;
            _problemRepository = problemRepository;
        }

        public void Save(Solution solution)
        {
            var problem = _problemRepository.Get(solution.ProblemId);
            var adapt = new Service.Storage.Entities.Solution
            {
                CreatedOn = solution.SendTime,
                Input = solution.Input,
                UserId = solution.UserId,
                TestResult = solution.Result.Adapt<Service.Storage.ExtraModels.TestResults>(),
                Problem = problem
            };
            _solutionRepository.Create(adapt);
        }

        public IEnumerable<Solution> Get(Guid problemId, Guid userId)
        {
            return _solutionRepository.Get(x => x.UserId == userId && x.Problem.Id == problemId)
                .Select(x => new Solution
                {
                    Result = x.TestResult.Adapt<TestResults>(),
                    ProblemId = x.Problem.Id,
                    UserId = x.UserId,
                    Input = x.Input,
                    SendTime = x.CreatedOn
                });
        }
    }
}