using System;
using System.Collections.Generic;
using ProblemProcessor;

namespace WebApp.Models.Problems
{
    public interface IDescProblemViewModel
    {
        Guid Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }
        DataGeneratorType Type { get; set; }
        List<Submission> Submissions { get; set; }
    }
}