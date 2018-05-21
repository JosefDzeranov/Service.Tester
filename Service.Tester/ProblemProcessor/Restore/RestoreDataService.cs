using System;
using System.Linq;
using Newtonsoft.Json;
using ProblemProcessor.Restore.Models;
using Service.Runner.Interfaces;
using Service.Storage.Context;
using Service.Storage.Entities;
using Service.Storage.ExtraModels;

namespace ProblemProcessor.Restore
{
    public class RestoreDataService : IRestoreDataService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IRunner _runner;

        public RestoreDataService(DatabaseContext dbContext, IRunner runner)
        {
            _dbContext = dbContext;
            _runner = runner;
        }

        public void Save(RestoreData data)
        {
            if (data.Output == null)
            {
                data.Output = CalculateOutputData(data.SourceCode, data.Input);
            }

            var problem = CreateProblem(data);

            _dbContext.Problems.Add(problem);
            _dbContext.SaveChanges();
        }

        private Problem CreateProblem(RestoreData data)
        {
            var problem = new Problem
            {
                Description = data.Description,
                LastModifiedTime = DateTime.UtcNow,
                Name = data.Name,
            };
            SetProblemType(problem, ProblemTypes.RestoreData);

            var additioanalData = new
            {
                data.SourceCode,
                data.Input,
                data.Output
            };
            problem.SpecificData = JsonConvert.SerializeObject(additioanalData);
            return problem;
        }

        private void SetProblemType(Problem problem, ProblemTypes type)
        {
            var problemType = _dbContext.ProblemTypes.FirstOrDefault(x => x.Name == type);
            problem.Type = problemType ?? throw new InvalidOperationException();
            problem.TypeId = problemType.Id;
        }
        private string CalculateOutputData(string sourceCode, string input)
        {
            return _runner.Run(sourceCode, input);
        }
    }
}