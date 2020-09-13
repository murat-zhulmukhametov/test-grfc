using System;
using System.Web.Mvc;
using Castle.Core.Internal;
using grfcTest.DataLayer.Entities.Cars;

namespace grfcTest.Models.Cars.CreateEdit
{
    public class CarValidator : ICarValidator
    {
        private readonly ICarRepository carRepository;

        public CarValidator(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public CarValidationResult ValidateOnCreate(CarForm form, ModelStateDictionary modelState)
        {
            Validate(form, modelState);

            return new CarValidationResult(modelState, new Car());
        }

        public CarValidationResult ValidateOnEdit(Guid id, CarForm form, ModelStateDictionary modelState)
        {
            Validate(form, modelState);

            var car = carRepository.Find(id);

            if(car == null) throw new Exception("Автомобиль не найден");

            return new CarValidationResult(modelState, car);
        }

        private void Validate(CarForm form, ModelStateDictionary modelState)
        {
            if (form.Brand.IsNullOrEmpty())
            {
                modelState.AddModelError("Form.Brand", "Поле не может быть пустым");
            }
        }
    }
}