using System;

namespace WebApp.Models.Problems
{
    public abstract class DescProblemViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}