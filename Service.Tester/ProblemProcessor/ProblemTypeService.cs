using System;
using System.Collections.Generic;
using System.Linq;
using Mapster;
using Service.Storage;

namespace ProblemProcessor
{
    public class ProblemTypeService : IProblemTypeService
    {
        private readonly IProblemTypeRepository _typeRepository;

        public ProblemTypeService(IProblemTypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public IEnumerable<ProblemType> GetAll()
        {
            var allTypes = _typeRepository.GetAll();
            return allTypes.Select(t => t.Adapt<ProblemType>());
        }

        public ProblemType Get(Guid id)
        {
            return _typeRepository.Get(x => x.Id == id).Adapt<ProblemType>();
        }

        public ProblemType Get(ProblemTypes type)
        {
            return _typeRepository.Get(x => x.Type.ToString() == type.ToString()).Adapt<ProblemType>();
        }
    }
}