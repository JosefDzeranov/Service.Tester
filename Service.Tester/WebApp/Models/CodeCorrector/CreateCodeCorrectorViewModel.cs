using System;
using WebApp.Models.Problems;

namespace WebApp.Models.CodeCorrector
{
    public class CreateCodeCorrectorViewModel : ICreateProblemViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CorrectSourceCode { get; set; }
        public string IncorrectSourceCode { get; set; }
        public DataGeneratorType GeneratorType { get; set; }
    }
}