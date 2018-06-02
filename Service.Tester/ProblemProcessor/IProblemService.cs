using System;
using System.Collections.Generic;

namespace ProblemProcessor
{
    public interface IProblemService
    {
        void Create(ProblemData problem);
        IEnumerable<ProblemData> GetAll();

        ProblemData Get(Guid id);

        void Delete(Guid id);
    }
}