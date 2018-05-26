using System;

namespace ProblemProcessor
{
    public abstract class ProblemData
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public ProblemTypes Type { get; set; }

        public string SourceCode { get; set; }

        public string GeneratorType { get; set; }
        public abstract object GetAdditionalData();
    }
}