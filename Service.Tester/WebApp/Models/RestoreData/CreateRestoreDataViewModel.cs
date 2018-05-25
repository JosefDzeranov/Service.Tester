using System;
using WebApp.Models.Problems;

namespace WebApp.Models.RestoreData
{
    public class CreateRestoreDataViewModel : ICreateProblemViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string SourceCode { get; set; }
        public string Input { get; set; }
        public DataGeneratorType GeneratorType { get; set; }
    }
}