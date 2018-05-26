namespace ProblemProcessor.CodeCorrector.Models
{
    public class CodeCorrectorData : ProblemData
    {
        public CodeCorrectorAdditionalData AdditionalData { get; set; }

        public override object GetAdditionalData()
        {
            return new { AdditionalData.SourceCode, AdditionalData.IncorrectSourceCode };
        }
    }

    public class CodeCorrectorAdditionalData
    {
        public string SourceCode { get; set; }
        public string IncorrectSourceCode { get; set; }
    }
}