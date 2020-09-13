using System;

namespace grfcTest.Models.Cars.CreateEdit
{
    public interface ICarEditModelBuilder
    {
        CarEditModel BuildNew();
        CarEditModel BuildEdit(Guid id);
        CarEditModel BuildByForm(Guid? id, CarForm form);
    }
}