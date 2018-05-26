using System;
using Service.Storage;
using Service.Storage.Entities;
using Service.Storage.ExtraModels;

namespace ProblemProcessor
{
    public class ProblemTypesHelper
    {
        private readonly IProblemTypeRepository _repository;

        public ProblemTypesHelper(IProblemTypeRepository repository)
        {
            this._repository = repository;
        }

        //public static void SetProblemType(Problem problem, ProblemType type)
        //{
        //    problem.Type = type ?? throw new InvalidOperationException();
        //    problem.TypeId = type.Id;
        //}

        //public static ProblemType GetProblemType( ProblemTypes type)
        //{
        //    return _repository.Get(x => x.Type == type);
        //}
    }
}