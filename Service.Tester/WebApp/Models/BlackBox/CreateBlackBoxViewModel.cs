using System;
using WebApp.Models.Problemset;

namespace WebApp.Models.BlackBox
{
    public class CreateBlackBoxViewModel : ICreateProblemViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}