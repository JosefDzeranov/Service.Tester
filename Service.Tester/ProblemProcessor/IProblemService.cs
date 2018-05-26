using System.Collections.Generic;

namespace ProblemProcessor
{
    public interface IProblemService
    {
        void Create(ProblemData problem);
        IEnumerable<ProblemData> GetAll();
    }
}