using grfcTest.DataLayer.Entities.Cars;
using grfcTest.DataLayer.Entities.CarWorkLinks;
using grfcTest.DataLayer.Entities.Works;
using grfcTest.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace grfcTest.Models.Cars.CreateEdit
{
    public class CarEditModelBuilder : ICarEditModelBuilder
    {
        private readonly ICarRepository carRepository;
        private readonly ICarWorkLinkRepository carWorkLinkRepository;
        private readonly IWorkRepository workRepository;
        private readonly IEngineTypesListModelBuilder engineTypesListModelBuilder;

        public CarEditModelBuilder(ICarRepository carRepository,IEngineTypesListModelBuilder engineTypesListModelBuilder, ICarWorkLinkRepository carWorkLinkRepository, IWorkRepository workRepository)
        {
            this.carRepository = carRepository;
            this.engineTypesListModelBuilder = engineTypesListModelBuilder;
            this.carWorkLinkRepository = carWorkLinkRepository;
            this.workRepository = workRepository;
        }

        public CarEditModel BuildNew()
        {
            return new CarEditModel(null, new CarForm(), engineTypesListModelBuilder.Build(), BuildWorkList());
        }

        public CarEditModel BuildEdit(Guid id)
        {
            var car = carRepository.Find(id);

            if(car == null) throw new Exception("Автомобиль не найден");

            var links = carWorkLinkRepository.GetByCarId(id);

            var carWorkList = links.Select(link => new CarWorkForm() {Date = link.Date, WorkId = link.WorkId, Id = link.Id}).ToList();

            var form = new CarForm()
            {
                Brand = car.Brand,
                Model = car.Model,
                Number = car.Number,
                EngineType = car.EngineType,
                Works = carWorkList
            };

            return new CarEditModel(id, form, engineTypesListModelBuilder.Build(), BuildWorkList());

        }

        public CarEditModel BuildByForm(Guid? id, CarForm form)
        {
            return new CarEditModel(id, form, engineTypesListModelBuilder.Build(), BuildWorkList());
        }

        private IList<SelectListItem> BuildWorkList()
        {
            var works = workRepository.All();

            return works.Select(work => new SelectListItem() {Text = work.Description, Value = work.Id.ToString()})
                .ToList();
        }
    }
}