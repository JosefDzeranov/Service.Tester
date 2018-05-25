using System;

namespace ProblemProcessor.Restore.Models
{
    public class RestoreData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string SourceCode { get; set; }
        public string GeneratorType { get; set; }
    }
}