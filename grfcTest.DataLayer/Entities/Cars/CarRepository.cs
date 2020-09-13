using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using grfcTest.DataLayer.Infrastructure;

namespace grfcTest.DataLayer.Entities.Cars
{
    public class CarRepository : ICarRepository
    {
        private readonly IEntityRepository<IgrfcEntity> entityRepository;

        public CarRepository(IEntityRepository<IgrfcEntity> entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public Car Find(Guid id)
        {
            return entityRepository.GetTable<Car>().FirstOrDefault(car => car.Id == id);
        }

        public IList<Car> All()
        {
            return entityRepository.GetTable<Car>().ToList();
        }
    }
}