using System;

namespace grfcTest.Models.Cars.Item
{
    public interface ICarItemModelBuilder
    {
        CarItemModel Build(Guid id);
    }
}