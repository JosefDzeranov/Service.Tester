using ProblemProcessor.TraceTable.Models;

namespace ProblemProcessor.TraceTable
{
    public interface ITraceTableService
    {
        void Save(TraceTableData data);
    }
}