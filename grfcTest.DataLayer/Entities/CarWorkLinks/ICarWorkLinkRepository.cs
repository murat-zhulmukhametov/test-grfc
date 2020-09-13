using System;
using System.Collections.Generic;

namespace grfcTest.DataLayer.Entities.CarWorkLinks
{
    public interface ICarWorkLinkRepository
    {
        IList<CarWorkLink> GetByCarId(Guid carId);
    }
}