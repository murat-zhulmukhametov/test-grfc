using System;

namespace grfcTest.DataLayer.Entities.CarWorkLinks
{
    public class CarWorkLinkFactory : ICarWorkLinkFactory
    {
        public CarWorkLink Create(Guid carId, Guid workId, DateTime date)
        {
            return new CarWorkLink()
            {
                Id = Guid.NewGuid(),
                CarId = carId,
                WorkId = workId,
                Date = date
            };
        }
    }
}