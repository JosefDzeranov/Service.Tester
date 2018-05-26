using System;
using ProblemProcessor;

namespace WebApp.Models.Problemset
{
    public class ProblemTypeViewModel
    {
        public Guid Id { get; set; }

        public ProblemTypes Type { get; set; }

        public string Name { get; set; }
    }
}
