namespace ProblemProcessor.BlackBox.Models
{
    public class BlackBoxData : ProblemData
    {
        public BlackBoxAdditionalData AdditionalData { get; set; }

        public override object GetAdditionalData()
        {
            return new { AdditionalData.SourceCode };
        }
    }
    public class BlackBoxAdditionalData
    {
        public string SourceCode { get; set; }
    }
}