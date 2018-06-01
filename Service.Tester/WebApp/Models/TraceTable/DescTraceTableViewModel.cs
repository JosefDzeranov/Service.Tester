using System;
using System.Collections.Generic;
using ProblemProcessor;
using WebApp.Models.Problems;

namespace WebApp.Models.TraceTable
{
    public class DescTraceTableViewModel : IDescProblemViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DataGeneratorType GeneratorType { get; set; }
        public List<Submission> Submissions { get; set; }
        public string SourceCode { get; set; }
        public string SourceCodeForCheck { get; set; }


        public IList<string> Variables { get; set; }
        public IList<string> Row { get; set; }
    }
}