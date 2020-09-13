using System;

namespace grfcTest.Models.Works.CreateEdit
{
    public interface IWorkEditModelBuilder
    {
        WorkEditModel BuildNew();
        WorkEditModel BuildEdit(Guid id);
        WorkEditModel BuildByForm(Guid? id, WorkForm form);
    }
}