namespace ProblemProcessor.CodeCorrector.Models
{
    public class CodeCorrectorData : ProblemData
    {
        public string CorrectSourceCode { get; set; }
        public string IncorrectSourceCode { get; set; }
    }
}