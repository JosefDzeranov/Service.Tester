using System;
using System.Collections.Generic;

namespace ProblemProcessor.Solutions
{
    public interface ISolutionsService
    {
        void Save(Solution solution);
        IEnumerable<Solution> Get(Guid problemId, Guid userId);
    }
}