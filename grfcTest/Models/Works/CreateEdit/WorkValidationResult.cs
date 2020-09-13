using System.Web.Mvc;
using grfcTest.DataLayer.Entities.Works;

namespace grfcTest.Models.Works.CreateEdit
{
    public class WorkValidationResult
    {
        public ModelStateDictionary ModelState { get; set; }
        public Work Work { get; set; }

        public WorkValidationResult(ModelStateDictionary modelState, Work work)
        {
            ModelState = modelState;
            Work = work;
        }
    }
}