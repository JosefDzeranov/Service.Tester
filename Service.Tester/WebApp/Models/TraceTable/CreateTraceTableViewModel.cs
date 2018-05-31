using System;
using System.Collections;
using System.Collections.Generic;
using ProblemProcessor;
using WebApp.Models.Problemset;

namespace WebApp.Models.TraceTable
{
    public class CreateTraceTableViewModel : ICreateProblemViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DataGeneratorType GeneratorType { get; set; }
        public ProblemTypes Type { get; set; }
        public string SourceCode { get; set; }
        public string SourceCodeForCheck { get; set; }
        public IList<string> Variables { get; set; }
        public IList<string> Row { get; set; }
    }

    public class TableData
    {
        public IList<string> Variables { get; set; }
        public IList<string> Row { get; set; }
    }
}