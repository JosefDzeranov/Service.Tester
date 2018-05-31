using System.Collections.Generic;

namespace ProblemProcessor.TraceTable.Models
{
    public class TraceTableData : ProblemData
    {
        public TraceTableAdditionalData AdditionalData { get; set; }
        public override object GetAdditionalData()
        {
            return new
            {
                AdditionalData.SourceCodeForCheck,
                AdditionalData.SourceCode,
                AdditionalData.Row,
                AdditionalData.Variables
            };
        }
    }
    public class TraceTableAdditionalData
    {
        public string SourceCode { get; set; }
        public string SourceCodeForCheck { get; set; }
        public IList<string> Variables { get; set; }
        public IList<string> Row { get; set; }
    }
}