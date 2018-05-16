using Service.Storage.Entities;
using WebApp.Models.Problems;

namespace WebApp.Extensions
{
    public static class ProblemTypeExtensions
    {
        public static ProblemTypeViewModel ToViewModel(this ProblemType type)
        {
            return new ProblemTypeViewModel()
            {
                Id = type.Id,
                Name = type.FullName
            };
        }
    }
}