using System;
using System.Collections.Generic;

namespace grfcTest.DataLayer.Entities.Cars
{
    public interface ICarRepository
    {
        Car Find(Guid id);
        IList<Car> All();
    }
}