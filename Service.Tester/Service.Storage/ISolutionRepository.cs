using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Service.Storage.Entities;

namespace Service.Storage
{
    public interface ISolutionRepository
    {
        void Create(Solution solution);
        IEnumerable<Solution> Get(Expression<Func<Solution, bool>> expression);
    }
}