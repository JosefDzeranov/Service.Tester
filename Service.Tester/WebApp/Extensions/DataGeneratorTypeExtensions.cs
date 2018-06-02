using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProblemProcessor;
using WebApp.Models.Problemset;

namespace WebApp.Extensions
{
    public static class DataGeneratorTypeExtensions
    {
        public static SelectList GetGenerateTypes()
        {
            var generatorTypes = DataGeneratorTypeExtensions.ToViewModel();
            return new SelectList(generatorTypes, nameof(DataGeneratorTypeViewModel.Name),
                nameof(DataGeneratorTypeViewModel.Description));
        }

        public static ICollection<DataGeneratorTypeViewModel> ToViewModel()
        {
            var name = Enum.GetNames(typeof(DataGeneratorType));
            return name.Select(x => new DataGeneratorTypeViewModel
            {
                Name = x,
                Description = GetDescription(x)
            }).ToList();
        }

        private static string GetDescription(string dataGeneratorTypeName)
        {
            switch (dataGeneratorTypeName)
            {
                case "OneNumber":
                    return "Одно число";
                case "OneString":
                    return "Одна строка";

                case "TwoNumbersOnLineCreator":
                    return "Два числа на одной строке";
                case "TwoStringsOnLineCreator":
                    return "Две строки на одной строке";

                case "OneNumberInLineAndMoreNumbersInSecondLineCreator":
                    return "Одной число на первой строке, числа на второй строке через пробел, " +
                           "кол-во которых равно первому числу";
                case "OneNumberInLineAndMoreStringsInSecondLineCreator":
                    return "Одной число на первой строке, строки на второй строке через пробел, "
                           + "кол-во которых равно первому числу";

                case "OneNumberAndMoreNumbersOnEchLineCreator":
                    return "Одной число на первой строке,  число в следующих строках. " +
                           "Кол-во этих строк равно первому числу";
                case "OneNumberAndMoreStringsOnEchLineCreator":
                    return "Одной число на первой строке,  Строка в следующих строках. " +
                           "Кол-во этих строк равно первому числу";
            }

            return null;
        }
    }
}