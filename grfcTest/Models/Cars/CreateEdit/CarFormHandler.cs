using grfcTest.DataLayer.Entities;
using grfcTest.DataLayer.Entities.Cars;
using grfcTest.DataLayer.Entities.CarWorkLinks;
using grfcTest.DataLayer.Infrastructure;
using System;

namespace grfcTest.Models.Cars.CreateEdit
{
    public class CarFormHandler : ICarFormHandler
    {
        private readonly IEntityRepository<IgrfcEntity> entityRepository;
        private readonly ICarFactory carFactory;
        private readonly ICarWorkLinkFactory carWorkLinkFactory;
        private readonly ICarWorkLinkRepository carWorkLinkRepository;

        public CarFormHandler(IEntityRepository<IgrfcEntity> entityRepository, ICarFactory carFactory, ICarWorkLinkFactory carWorkLinkFactory, ICarWorkLinkRepository carWorkLinkRepository)
        {
            this.entityRepository = entityRepository;
            this.carFactory = carFactory;
            this.carWorkLinkFactory = carWorkLinkFactory;
            this.carWorkLinkRepository = carWorkLinkRepository;
        }

        public Guid HandleCreate(CarForm form)
        {
            var car = carFactory.Create(form.Brand, form.Model, form.Number, form.EngineType);

            entityRepository.InsertOnSave(car);

            foreach (var work in form.Works)
            {
                var link = carWorkLinkFactory.Create(car.Id, work.Id, work.Date);

                entityRepository.InsertOnSave(link);
            }

            entityRepository.SaveChanges();

            return car.Id;
        }

        public void HandleEdit(CarForm form, CarValidationResult valResult)
        {
            var car = valResult.Car;

            car.Brand = form.Brand;
            car.Model = form.Model;
            car.Number = form.Number;
            car.EngineType = form.EngineType;

            var linksFromDb = carWorkLinkRepository.GetByCarId(car.Id);

            entityRepository.DeleteRangeOnSave(linksFromDb);

            foreach (var work in form.Works)
            {
                var link = carWorkLinkFactory.Create(car.Id, work.Id, work.Date);

                entityRepository.InsertOnSave(link);
            }

            entityRepository.SaveChanges();
        }


    }
}