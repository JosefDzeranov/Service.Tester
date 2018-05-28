using System;
using System.ComponentModel.DataAnnotations;
using ProblemProcessor;

namespace WebApp.Models.Problemset
{
    public interface ICreateProblemViewModel
    {
        Guid Id { get; set; }

        [Required]
        string Name { get; set; }

        [Required]
        string Description { get; set; }
        DataGeneratorType GeneratorType { get; set; }

        ProblemTypes Type { get; set; }
    }
}