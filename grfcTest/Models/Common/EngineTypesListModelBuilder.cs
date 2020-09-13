using grfcTest.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace grfcTest.Models.Common
{
    public class EngineTypesListModelBuilder : IEngineTypesListModelBuilder
    {
        public IList<SelectListItem> Build()
        {
            var result = new List<SelectListItem>
            {
                new SelectListItem() {Text = "Выберите тип двигателя", Disabled = true, Selected = true}
            };

            foreach (var type in Enum.GetValues(typeof(EngineType)))
            {
                result.Add(new SelectListItem(){ Text = type.ToString(), Value = type.ToString() });
            }

            return result;
        }
    }
}