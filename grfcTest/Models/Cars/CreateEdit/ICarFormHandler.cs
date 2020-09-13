using System;

namespace grfcTest.Models.Cars.CreateEdit
{
    public interface ICarFormHandler
    {
        Guid HandleCreate(CarForm form);
        void HandleEdit(CarForm form, CarValidationResult valResult);
    }
}