using System;
using System.ComponentModel.DataAnnotations;
using ProblemProcessor;
using WebApp.Models.Problemset;

namespace WebApp.Models.BlackBox
{
    public class CreateBlackBoxViewModel : ICreateProblemViewModel
    {
        public Guid Id { get; set; }
        
        [Required] 
        public string Name { get; set; }
        
        [Required] 
        public string Description { get; set; }
        
        public DataGeneratorType GeneratorType { get; set; }
        
        public ProblemTypes Type { get; set; }

        [Required] 
        public string SourceCode { get; set; }
    }
}