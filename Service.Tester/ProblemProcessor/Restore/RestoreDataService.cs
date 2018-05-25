using System;
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
                Name = data.Name
            };
            ProblemTypesHelper.SetProblemType(_dbContext, problem, ProblemTypes.RestoreData);

            var additioanalData = new
            {
                data.SourceCode,
                data.GeneratorType
            };
            problem.SpecificData = JsonConvert.SerializeObject(additioanalData);
            return problem;
        }
    }
}