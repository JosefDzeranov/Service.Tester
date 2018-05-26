using ProblemProcessor;
using System;
using System.Collections.Generic;
using WebApp.Models.BlackBox;
using WebApp.Models.CodeCorrector;
using WebApp.Models.Problemset;
using WebApp.Models.RestoreData;
using WebApp.Models.TraceTable;

namespace WebApp.Extensions
{
    public static class ProblemTypeExtensions
    {
        private static Dictionary<ProblemTypes, CreateProblemViewModel> _mapping =
            new Dictionary<ProblemTypes, CreateProblemViewModel>()
            {
                {ProblemTypes.TraceTable, new CreateTraceTableViewModel()},
                {ProblemTypes.BlackBox, new CreateBlackBoxViewModel()},
                {ProblemTypes.RestoreData, new CreateRestoreDataViewModel()},
                {ProblemTypes.CodeCorrector, new CreateCodeCorrectorViewModel()}
            };

        public static CreateProblemViewModel GetProblemByType(ProblemTypes problemType)
        {
            if (!_mapping.ContainsKey(problemType))
                throw new Exception($"{problemType} is not found");

            return _mapping[problemType];
        }


    }
}