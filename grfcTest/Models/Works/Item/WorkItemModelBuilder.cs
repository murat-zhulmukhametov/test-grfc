using System;
using grfcTest.DataLayer.Entities.Works;

namespace grfcTest.Models.Works.Item
{
    public class WorkItemModelBuilder : IWorkItemModelBuilder
    {
        private readonly IWorkRepository workRepository;

        public WorkItemModelBuilder(IWorkRepository workRepository)
        {
            this.workRepository = workRepository;
        }

        public WorkItemModel Build(Guid id)
        {
            var item = workRepository.Find(id);

            if (item == null) throw new Exception("Работа не найдена");

            return new WorkItemModel()
            {
                Id = item.Id,
                Description = item.Description,
                EngineType = item.EngineType
            };

        }
    }
}