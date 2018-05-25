using System;
using Newtonsoft.Json;
using ProblemProcessor.TraceTable.Models;
using Service.Storage.Context;
using Service.Storage.Entities;
using Service.Storage.ExtraModels;

namespace ProblemProcessor.TraceTable
{
    public class TraceTableService : ITraceTableService
    {
        private readonly DatabaseContext _dbContext;

        public TraceTableService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save(TraceTableData data)
        {
            var problem = CreateProblem(data);
            _dbContext.Problems.Add(problem);
            _dbContext.SaveChanges();
        }


        private Problem CreateProblem(TraceTableData data)
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