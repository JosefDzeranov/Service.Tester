using System;
using System.Collections.Generic;
using System.Linq;
using Mapster;
using Newtonsoft.Json;
using ProblemProcessor.CodeCorrector.Models;
using ProblemProcessor.Restore.Models;
using ProblemProcessor.TraceTable.Models;
using Service.Storage;
using Service.Storage.Entities;

using StorageProblemTypes = Service.Storage.ExtraModels.ProblemTypes;

namespace ProblemProcessor
{
    public class ProblemService : IProblemService
    {
        private readonly IProblemRepository _problemRepository;
        private readonly IProblemTypeRepository _problemTypeRepository;


        public ProblemService(IProblemRepository problemRepository, IProblemTypeRepository problemTypeRepository)
        {
            _problemRepository = problemRepository;
            _problemTypeRepository = problemTypeRepository;
        }

        public void Create(ProblemData data)
        {
            var problem = ToStorageEntity(data);
            _problemRepository.Create(problem);
        }

        public IEnumerable<ProblemData> GetAll()
        {
            var problems = _problemRepository.GetAll();
            return problems.Select(p => new ProblemData
            {
                Id = p.Id,
                Name = p.Name,
                Type = p.Type.Type.Adapt<ProblemTypes>(),
            });
        }

        public ProblemData Get(Guid id)
        {
            var problem = _problemRepository.Get(id);
            switch (problem.Type.Type)
            {
                case StorageProblemTypes.CodeCorrector:
                    {
                        var additionalData = JsonConvert.DeserializeObject<CodeCorrectorAdditionalData>(problem.SpecificData);
                        return new CodeCorrectorData
                        {
                            Id = problem.Id,
                            Name = problem.Name,
                            Description = problem.Description,
                            Type = problem.Type.Type.Adapt<ProblemTypes>(),
                            GeneratorType = problem.GeneratorType,
                            AdditionalData = additionalData
                        };
                    }
            }

            return null;
        }

        private Problem ToStorageEntity(ProblemData data)
        {
            var problem = new Problem
            {
                Description = data.Description,
                LastModifiedTime = DateTime.UtcNow,
                Name = data.Name,
                GeneratorType = data.GeneratorType
            };
            problem.Type = _problemTypeRepository.Get(x => x.Type.ToString() == data.Type.ToString());
            problem.SpecificData = JsonConvert.SerializeObject(data.GetAdditionalData());
            return problem;
        }

        public void GetDescription(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}