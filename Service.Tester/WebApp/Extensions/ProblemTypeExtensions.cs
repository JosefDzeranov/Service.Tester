using System;
using System.Collections.Generic;
using Service.Storage.Entities;
using Service.Storage.ExtraModels;
using WebApp.Models.BlackBox;
using WebApp.Models.CodeCorrector;
using WebApp.Models.Problemset;
using WebApp.Models.RestoreData;
using WebApp.Models.TraceTable;

namespace WebApp.Extensions
{
    public static class ProblemTypeExtensions
    {
        private static Dictionary<ProblemTypes, ICreateProblemViewModel> _mapping =
            new Dictionary<ProblemTypes, ICreateProblemViewModel>()
            {
                {ProblemTypes.TraceTable, new CreateTraceTableViewModel()},
                {ProblemTypes.BlackBox, new CreateBlackBoxViewModel()},
                {ProblemTypes.RestoreData, new CreateRestoreDataViewModel()},
                {ProblemTypes.CodeCorrector, new CreateCodeCorrectorViewModel()}
            };

        public static ProblemTypeViewModel ToViewModel(this ProblemType type)
        {
            return new ProblemTypeViewModel
            {
                Id = type.Id,
                Name = type.FullName
            };
        }

        public static ICreateProblemViewModel Mapping(ProblemTypes problemType)
        {
            if (!_mapping.ContainsKey(problemType))
                throw new Exception($"{problemType} is not found");

            return _mapping[problemType];
        }


    }
}