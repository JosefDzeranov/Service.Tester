using System;
using Service.Domain.Entities;
using WebApp.Models.Problems;
using WebApp.Models.TraceTable;

namespace WebApp.Extensions
{
    public static class ProblemExtensions
    {
        public static ProblemViewModel ToProblemViewModel(this Problem problem)
        {
            return new ProblemViewModel
            {
                Id = problem.Id,
                Type = problem.Type.FullName,
                Name = problem.Name,
                Description = problem.Description,
                LastModifiedTime = problem.LastModifiedTime,
                Tags = problem.Tags
            };
        }

        public static Problem ToBo(this TraceTableViewModel problem)
        {
            return new Problem
            {
                Id = Guid.NewGuid(),
                Name = problem.Name,
                LastModifiedTime = DateTime.UtcNow,
                Description = problem.Description
            };
        }
    }
}