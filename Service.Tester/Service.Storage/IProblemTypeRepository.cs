using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Service.Storage.Entities;

namespace Service.Storage
{
    public interface IProblemTypeRepository
    {
        ProblemType Get(Expression<Func<ProblemType, bool>> predicate);
        IEnumerable<ProblemType> GetAll();
        void Create(ProblemType type);
        void Delete(ProblemType type);
    }
}