using ProblemProcessor.CodeCorrector.Models;

namespace ProblemProcessor.CodeCorrector
{
    public interface ICodeCorrectorService
    {
        void Save(CodeCorrectorData data);
    }
}