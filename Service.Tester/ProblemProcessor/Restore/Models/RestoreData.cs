namespace ProblemProcessor.Restore.Models
{
    public class RestoreData : ProblemData
    {
        public override object GetAdditionalData()
        {
            return new { };
        }
    }
}