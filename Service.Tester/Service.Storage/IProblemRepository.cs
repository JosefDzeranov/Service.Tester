using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Service.Storage.Entities;

namespace Service.Storage
{
    public interface IProblemRepository
    {
        void Create(Problem problem);
        void Delete(Guid id);
        IEnumerable<Problem> Find(Expression<Func<Problem, bool>> predicate);
        Problem Get(Guid id);
        IEnumerable<Problem> GetAll();

        void Update(Problem problem);
    }
}