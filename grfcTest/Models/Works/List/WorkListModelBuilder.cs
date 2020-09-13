using System.Linq;
using grfcTest.DataLayer.Entities.Works;

namespace grfcTest.Models.Works.List
{
    public class WorkListModelBuilder : IWorkListModelBuilder
    {
        private readonly IWorkRepository workRepository;

        public WorkListModelBuilder(IWorkRepository workRepository)
        {
            this.workRepository = workRepository;
        }

        public WorkListModel Build()
        {
            var works = workRepository.All();

            var modelList = works.Select(work => new WorkListItemModel()
            {
                Id = work.Id,
                Description = work.Description,
                EngineType = work.EngineType
            }).ToList();

            return new WorkListModel(modelList);
        }
    }
}