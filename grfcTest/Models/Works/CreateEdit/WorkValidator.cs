using System;
using System.Web.Mvc;
using Castle.Core.Internal;
using grfcTest.DataLayer.Entities.Works;

namespace grfcTest.Models.Works.CreateEdit
{
    public class WorkValidator : IWorkValidator
    {
        private readonly IWorkRepository workRepository;

        public WorkValidator(IWorkRepository workRepository)
        {
            this.workRepository = workRepository;
        }

        public WorkValidationResult ValidateOnCreate(WorkForm form, ModelStateDictionary modelState)
        {
            Validate(form, modelState);

            return new WorkValidationResult(modelState, new Work());
        }

        public WorkValidationResult ValidateOnEdit(Guid id, WorkForm form, ModelStateDictionary modelState)
        {
            Validate(form, modelState);

            var work = workRepository.Find(id);

            if(work == null) throw new Exception("Работа не найдена");

            return new WorkValidationResult(modelState, work);
        }

        private void Validate(WorkForm form, ModelStateDictionary modelState)
        {
            if (form.Description.IsNullOrEmpty())
            {
                modelState.AddModelError("Form.Description", "Поле не может быть пустым");
            }
        }
    }
}