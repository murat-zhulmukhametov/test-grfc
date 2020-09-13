using System;
using System.Web.Mvc;

namespace grfcTest.Models.Cars.CreateEdit
{
    public interface ICarValidator
    {
        CarValidationResult ValidateOnCreate(CarForm form, ModelStateDictionary modelState);
        CarValidationResult ValidateOnEdit(Guid id, CarForm form, ModelStateDictionary modelState);
    }
}