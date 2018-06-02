using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Service.Storage.Context;
using Service.Storage.Entities;

namespace Service.Storage
{
    public class ProblemRepository : IProblemRepository
    {
        private readonly DatabaseContext _dbContext;

        public ProblemRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Problem problem)
        {
            _dbContext.Problems.Add(problem);
            _dbContext.SaveChanges();
        }

        public Problem Get(Guid id)
        {
            return _dbContext.Problems.Include(x => x.Type).SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Problem> GetAll()
        {
            return _dbContext.Problems.Include(x => x.Type).ToList();
        }

        public void Update(Problem problem)
        {
            _dbContext.Problems.Update(problem);
        }

        public void Delete(Guid id)
        {
            var problem = Get(id);
            if (problem != null)
            {
                _dbContext.Problems.Remove(problem);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Problem> Find(Expression<Func<Problem, bool>> predicate)
        {
            return _dbContext.Problems.Include(x => x.Type).Where(predicate);
        }
    }
}