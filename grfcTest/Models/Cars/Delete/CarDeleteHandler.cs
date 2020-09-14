using System;
using grfcTest.DataLayer.Entities;
using grfcTest.DataLayer.Entities.Cars;
using grfcTest.DataLayer.Infrastructure;

namespace grfcTest.Models.Cars.Delete
{
    public class CarDeleteHandler : ICarDeleteHandler
    {
        private readonly IEntityRepository<IgrfcEntity> entityRepository;
        private readonly ICarRepository carRepository;

        public CarDeleteHandler(IEntityRepository<IgrfcEntity> entityRepository, ICarRepository carRepository)
        {
            this.entityRepository = entityRepository;
            this.carRepository = carRepository;
        }

        public void HandleDelete(Guid id)
        {
            var car = carRepository.Find(id);

            if(car == null) throw new Exception("Автомобиль не найден");

            entityRepository.DeleteOnSave(car);
            entityRepository.SaveChanges();
        }
    }
}