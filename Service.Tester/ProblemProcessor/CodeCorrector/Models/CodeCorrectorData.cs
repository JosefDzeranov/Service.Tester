namespace ProblemProcessor.CodeCorrector.Models
{
    public class CodeCorrectorData : ProblemData
    {
        public string IncorrectSourceCode { get; set; }

        public override object GetAdditionalData()
        {
            return new { IncorrectSourceCode };
        }
    }
}