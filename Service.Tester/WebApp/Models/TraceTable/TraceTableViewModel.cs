using System;
using WebApp.Models.Problems;

namespace WebApp.Models.TraceTable
{
    public class TraceTableViewModel : ICreateProblemViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BreakPointLine { get; set; }
        public string SourceCode { get; set; }
    }
}