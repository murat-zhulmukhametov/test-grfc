using grfcTest.DataLayer.Common;
using grfcTest.DataLayer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace grfcTest.DataLayer.Entities.Works
{
    public class WorkRepository : IWorkRepository
    {
        private readonly IEntityRepository<IgrfcEntity> entityRepository;

        public WorkRepository(IEntityRepository<IgrfcEntity> entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public IList<Work> All()
        {
            return entityRepository.GetTable<Work>().ToList();
        }

        public IList<Work> GetByIds(IEnumerable<Guid> ids)
        {
            return entityRepository.GetTable<Work>().Where(work => ids.Contains(work.Id)).ToList();
        }

        public IList<Work> GetByEngine(EngineType type)
        {
            return entityRepository.GetTable<Work>().Where(work => work.EngineType == type).ToList();
        }

        public Work Find(Guid id)
        {
            return entityRepository.GetTable<Work>().FirstOrDefault(work => work.Id == id);
        }
    }
}