using grfcTest.DataLayer.Entities.Works;
using grfcTest.Models.Common;
using System;

namespace grfcTest.Models.Works.CreateEdit
{
    public class WorkEditModelBuilder : IWorkEditModelBuilder
    {
        private readonly IWorkRepository workRepository;
        private readonly IEngineTypesListModelBuilder engineTypesListModelBuilder;

        public WorkEditModelBuilder(IWorkRepository workRepository, IEngineTypesListModelBuilder engineTypesListModelBuilder)
        {
            this.workRepository = workRepository;
            this.engineTypesListModelBuilder = engineTypesListModelBuilder;
        }

        public WorkEditModel BuildNew()
        {
            return new WorkEditModel(null, new WorkForm(), engineTypesListModelBuilder.Build());
        }

        public WorkEditModel BuildEdit(Guid id)
        {
            var work = workRepository.Find(id);

            var form = new WorkForm()
            {
                Description = work.Description,
                EngineType = work.EngineType
            };

            return new WorkEditModel(id, form, engineTypesListModelBuilder.Build());
        }

        public WorkEditModel BuildByForm(Guid? id, WorkForm form)
        {
            return new WorkEditModel(id, form, engineTypesListModelBuilder.Build());
        }

    }
}