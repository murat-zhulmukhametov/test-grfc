using System;

namespace grfcTest.DataLayer.Entities.CarWorkLinks
{
    public interface ICarWorkLinkFactory
    {
        CarWorkLink Create(Guid carId, Guid workId, DateTime date);
    }
}