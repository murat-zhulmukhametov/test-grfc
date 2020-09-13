using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using grfcTest.DataLayer.Common;
using grfcTest.DataLayer.Entities.Works;

namespace grfcTest.Models.Works.SelectList
{
    public class WorkSelectListModelBuilder : IWorkSelectListModelBuilder
    {
        private readonly IWorkRepository workRepository;

        public WorkSelectListModelBuilder(IWorkRepository workRepository)
        {
            this.workRepository = workRepository;
        }

        public IList<SelectListItem> Build(EngineType engineType)
        {
            var works = workRepository.GetByEngine(engineType);

            var result = new List<SelectListItem>
            {
                new SelectListItem() {Text = "Выберите тип обслуживания", Disabled = true, Selected = true}
            };

            result.AddRange(works
                .Select(work => new SelectListItem() {Text = work.Description, Value = work.Id.ToString()})
                .ToList());

            return result;

        }
    }
}