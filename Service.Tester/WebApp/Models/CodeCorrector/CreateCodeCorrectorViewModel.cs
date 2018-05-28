using System;
using ProblemProcessor;
using WebApp.Models.Problemset;

namespace WebApp.Models.CodeCorrector
{
    public class CreateCodeCorrectorViewModel : ICreateProblemViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DataGeneratorType GeneratorType { get; set; }
        public ProblemTypes Type { get; set; }
        public string SourceCode { get; set; }
        public string IncorrectSourceCode { get; set; }
    }
}