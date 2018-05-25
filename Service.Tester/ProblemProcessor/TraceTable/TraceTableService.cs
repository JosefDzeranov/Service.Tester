using Newtonsoft.Json;
using ProblemProcessor.TraceTable.Models;
using Service.Storage.ExtraModels;

namespace ProblemProcessor.TraceTable
{
    public class TraceTableService:ITraceTableService
    {
        public void Save(TraceTableData data)
        {
            var problem = traceTableViewModel.ToBo();
            SetProblemType(problem, ProblemTypes.TraceTable);
            var additioanalData = new
            {
                traceTableViewModel.BreakPointLine,
                traceTableViewModel.SourceCode,
                traceTableViewModel.GeneratorType
            };
            problem.SpecificData = JsonConvert.SerializeObject(additioanalData);

            _dbContext.Problems.Add(problem);
            _dbContext.SaveChanges();

            throw new System.NotImplementedException();
        }
    }
}