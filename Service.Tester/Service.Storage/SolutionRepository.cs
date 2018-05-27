using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Service.Storage.Context;
using Service.Storage.Entities;

namespace Service.Storage
{
    public class SolutionRepository : ISolutionRepository
    {
        private readonly DatabaseContext _databaseContext;

        public SolutionRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Create(Solution solution)
        {
            _databaseContext.Solutions.Add(solution);
            _databaseContext.SaveChanges();
        }

        public IEnumerable<Solution> Get(Expression<Func<Solution, bool>> expression)
        {
            return _databaseContext.Solutions.Where(expression);
        }
    }
}