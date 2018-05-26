using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Service.Storage.Context;
using Service.Storage.Entities;

namespace Service.Storage
{
    public class ProblemTypeRepository : IProblemTypeRepository
    {
        private readonly DatabaseContext _dbContext;

        public ProblemTypeRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProblemType Get(Expression<Func<ProblemType, bool>> predicate)
        {
            return _dbContext.ProblemTypes.SingleOrDefault(predicate);
        }

        public IEnumerable<ProblemType> GetAll()
        {
            return _dbContext.ProblemTypes;
        }
    }
}