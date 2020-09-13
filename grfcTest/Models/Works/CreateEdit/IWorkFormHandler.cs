using System;

namespace grfcTest.Models.Works.CreateEdit
{
    public interface IWorkFormHandler
    {
        Guid HandleCreate(WorkForm form);
        void HandleEdit(WorkForm form, WorkValidationResult valResult);
    }
}