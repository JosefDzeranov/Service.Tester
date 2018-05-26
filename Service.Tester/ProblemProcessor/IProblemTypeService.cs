using System;
using System.Collections.Generic;

namespace ProblemProcessor
{
    public interface IProblemTypeService
    {
        IEnumerable<ProblemType> GetAll();
        ProblemType Get(Guid id);
        ProblemType Get(ProblemTypes type);
    }
}