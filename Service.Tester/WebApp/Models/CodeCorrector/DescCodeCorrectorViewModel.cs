using System;
using WebApp.Models.Problems;

namespace WebApp.Models.CodeCorrector
{
    public class DescCodeCorrectorViewModel : IDescProblemViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IncorrectSourceCode { get; set; }
    }
}