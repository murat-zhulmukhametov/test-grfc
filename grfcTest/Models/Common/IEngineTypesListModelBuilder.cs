using System.Collections.Generic;
using System.Web.Mvc;

namespace grfcTest.Models.Common
{
    public interface IEngineTypesListModelBuilder
    {
        IList<SelectListItem> Build();
    }
}