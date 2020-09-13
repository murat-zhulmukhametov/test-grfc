using System;

namespace grfcTest.Models.Works.Item
{
    public interface IWorkItemModelBuilder
    {
        WorkItemModel Build(Guid id);
    }
}