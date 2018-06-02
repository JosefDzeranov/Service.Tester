using System;
using System.Collections.Generic;
using ProblemProcessor;

namespace WebApp.Models.Problems
{
    public class DeleteProblemViewModel:IDescProblemViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DataGeneratorType GeneratorType { get; set; }
        public List<Submission> Submissions { get; set; }
    }
}