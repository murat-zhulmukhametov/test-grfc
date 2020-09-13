using System;
using grfcTest.DataLayer.Common;

namespace grfcTest.DataLayer.Entities.Cars
{
    public class CarFactory : ICarFactory
    {
        public Car Create(string brand, string model, string number, EngineType engineType)
        {
            return new Car()
            {
                Id = Guid.NewGuid(),
                Brand = brand,
                Model = model,
                Number = number,
                EngineType = engineType
            };

        }
    }
}