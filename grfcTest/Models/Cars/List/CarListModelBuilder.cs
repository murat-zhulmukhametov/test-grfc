using System.Linq;
using grfcTest.DataLayer.Entities.Cars;
using grfcTest.DataLayer.Entities.CarWorkLinks;

namespace grfcTest.Models.Cars.List
{
    public class CarListModelBuilder : ICarListModelBuilder
    {
        private readonly ICarRepository carRepository;

        public CarListModelBuilder(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public CarListModel Build()
        {
            var cars = carRepository.All();

            var modelList = cars.Select(car => new CarListItemModel()
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Number = car.Number
            }).ToList();

            return new CarListModel(modelList);
        }
    }
}