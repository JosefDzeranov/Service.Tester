using System;

namespace ProblemProcessor
{
    public class ProblemData
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public ProblemTypes Type { get; set; }

        public string GeneratorType { get; set; }

        public virtual object GetAdditionalData()
        {
            return new { };
        }
    }
}