using System.Collections.Generic;
using System.Web.Mvc;
using grfcTest.DataLayer.Common;

namespace grfcTest.Models.Works.SelectList
{
    public interface IWorkSelectListModelBuilder
    {
        IList<SelectListItem> Build(EngineType engineType);
    }
}