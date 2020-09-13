using System;
using System.Collections.Generic;
using System.Linq;
using grfcTest.DataLayer.Entities.Cars;
using grfcTest.DataLayer.Entities.CarWorkLinks;
using grfcTest.DataLayer.Entities.Works;

namespace grfcTest.Models.Cars.Item
{
    public class CarItemModelBuilder : ICarItemModelBuilder
    {
        private readonly ICarRepository carRepository;
        private readonly ICarWorkLinkRepository carWorkLinkRepository;
        private readonly IWorkRepository workRepository;

        public CarItemModelBuilder(ICarRepository carRepository, ICarWorkLinkRepository carWorkLinkRepository, IWorkRepository workRepository)
        {
            this.carRepository = carRepository;
            this.carWorkLinkRepository = carWorkLinkRepository;
            this.workRepository = workRepository;
        }

        public CarItemModel Build(Guid id)
        {
            var car = carRepository.Find(id);

            if(car == null) throw new Exception("Машина не найдена");

            var links = carWorkLinkRepository.GetByCarId(id);

            var workIds = links.Select(link => link.WorkId);

            var works = workRepository.GetByIds(workIds);

            var workList = new List<CarWorkItemModel>();

            foreach (var link in links)
            {
                var workInLink = works.FirstOrDefault(work => work.Id == link.WorkId);

                workList.Add(new CarWorkItemModel(){ Date = link.Date.ToString("dd/MM/yyyy HH:mm"), Description = workInLink?.Description });
            }

            return new CarItemModel(id, car.Brand, car.Model, car.Number, car.EngineType, workList);
        }
    }
}