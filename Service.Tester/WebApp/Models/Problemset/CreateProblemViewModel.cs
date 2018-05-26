using System;
using ProblemProcessor;

namespace WebApp.Models.Problemset
{
    public interface CreateProblemViewModel
    {
        Guid Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }
        DataGeneratorType GeneratorType { get; set; }

        ProblemProcessor.ProblemTypes Type { get; set; }
    }
}