using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using grfcTest.DataLayer.Infrastructure;

namespace grfcTest.DataLayer.Entities.CarWorkLinks
{
    public class CarWorkLinkRepository : ICarWorkLinkRepository
    {
        private readonly IEntityRepository<IgrfcEntity> entityRepository;

        public CarWorkLinkRepository(IEntityRepository<IgrfcEntity> entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public IList<CarWorkLink> GetByCarId(Guid carId)
        {
            return entityRepository.GetTable<CarWorkLink>().Where(link => link.CarId == carId).ToList();
        }
    }
}