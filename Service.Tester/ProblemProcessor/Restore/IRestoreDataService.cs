using ProblemProcessor.Restore.Models;

namespace ProblemProcessor.Restore
{
    public interface IRestoreDataService
    {
        void Save(RestoreData problem);
    }
}