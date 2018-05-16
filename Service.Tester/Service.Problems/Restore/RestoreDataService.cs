using Service.Problems.Restore.Models;

namespace Service.Problems.Restore
{
    public class RestoreDataService : IRestoreDataService
    {
        private readonly DatabaseContext _dbContext;

        public RestoreDataService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save(RestoreData problem)
        {
            if (problem.Output != null)
            {
                problem.Output = CalculateOutputData(problem.SourceCode, problem.Input);
            }
        }

        private string CalculateOutputData(string sourceCode, string input)
        {
            return null;
        }
    }
}