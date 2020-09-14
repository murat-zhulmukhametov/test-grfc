using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace grfcTest.Models.Cars.CreateEdit
{
    public class CarEditModel
    {
        public Guid? Id { get; set; }
        public CarForm Form { get; set; }
        public IList<SelectListItem> EngineTypesList { get; set; }
        public IList<SelectListItem> WorksList { get; set; }

        public CarEditModel(Guid? id, CarForm form, IList<SelectListItem> engineTypesList, IList<SelectListItem> worksList)
        {
            Id = id;
            Form = form;
            EngineTypesList = engineTypesList;
            WorksList = worksList;
        }
    }
}