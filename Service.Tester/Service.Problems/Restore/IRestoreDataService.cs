using Service.Problems.Restore.Models;

namespace Service.Problems.Restore
{
    public interface IRestoreDataService
    {
        void Save(RestoreData problem);
    }
}