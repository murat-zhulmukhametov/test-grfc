using System;
using System.Web.Mvc;

namespace grfcTest.Models.Works.CreateEdit
{
    public interface IWorkValidator
    {
        WorkValidationResult ValidateOnCreate(WorkForm form, ModelStateDictionary modelState);
        WorkValidationResult ValidateOnEdit(Guid id, WorkForm form, ModelStateDictionary modelState);
    }
}