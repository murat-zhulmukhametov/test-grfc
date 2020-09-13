using System.Web.Mvc;
using grfcTest.DataLayer.Entities.Cars;

namespace grfcTest.Models.Cars.CreateEdit
{
    public class CarValidationResult
    {
        public ModelStateDictionary ModelState { get; set; }
        public Car Car { get; set; }

        public CarValidationResult(ModelStateDictionary modelState, Car car)
        {
            ModelState = modelState;
            Car = car;
        }
    }
}