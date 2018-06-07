using System;
using System.Collections.Generic;
using Service.Storage.Entities;

namespace Service.Storage
{
    public interface IProblemRepository
    {
        void Create(Problem problem);
        void Delete(Guid id);
        Problem Get(Guid id);
        IEnumerable<Problem> GetAll();
    }
}