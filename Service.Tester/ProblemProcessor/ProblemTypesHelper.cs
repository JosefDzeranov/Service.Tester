using System;
using System.Linq;
using Service.Storage.Context;
using Service.Storage.Entities;
using Service.Storage.ExtraModels;

namespace ProblemProcessor
{
    public class ProblemTypesHelper
    {
        public static void SetProblemType(DatabaseContext dbContext, Problem problem, ProblemTypes type)
        {
            var problemType = dbContext.ProblemTypes.FirstOrDefault(x => x.Name == type);
            problem.Type = problemType ?? throw new InvalidOperationException();
            problem.TypeId = problemType.Id;
        }
    }
}