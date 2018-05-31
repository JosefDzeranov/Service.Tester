using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProblemProcessor;
using WebApp.Models.Problemset;

namespace WebApp.Models.TraceTable
{
    public class CreateTraceTableViewModel : ICreateProblemViewModel
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
        [Required]
        public string SourceCodeForCheck { get; set; }
        public IList<string> Variables { get; set; }
        [Required]
        public IList<string> Row { get; set; }
    }

    public class TableData
    {
        public IList<string> Variables { get; set; }
        public IList<string> Row { get; set; }
    }
}