using System;
using Newtonsoft.Json;
using ProblemProcessor.CodeCorrector.Models;
using Service.Storage.Context;
using Service.Storage.Entities;
using Service.Storage.ExtraModels;

namespace ProblemProcessor.CodeCorrector
{
    public class CodeCorrectorService : ICodeCorrectorService
    {
        private readonly DatabaseContext _dbContext;

        public CodeCorrectorService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save(CodeCorrectorData data)
        {
            var problem = CreateProblem(data);
            _dbContext.Problems.Add(problem);
            _dbContext.SaveChanges();
        }
        private Problem CreateProblem(CodeCorrectorData data)
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
                data.CorrectSourceCode,
                data.IncorrectSourceCode,
                data.GeneratorType
            };
            problem.SpecificData = JsonConvert.SerializeObject(additioanalData);
            return problem;
        }
    }
}