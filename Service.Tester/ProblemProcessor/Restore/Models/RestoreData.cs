namespace ProblemProcessor.Restore.Models
{
    public class RestoreData : ProblemData
    {
        public RestoreDataAdditionalData AdditionalData { get; set; }


        public override object GetAdditionalData()
        {
            return new { AdditionalData.SourceCode, AdditionalData.IsInput };
        }
    }
    public class RestoreDataAdditionalData
    {
        public string SourceCode { get; set; }
        public bool IsInput { get; set; }
    }
}