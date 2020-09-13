using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace grfcTest.Models.Works.CreateEdit
{
    public class WorkEditModel
    {
        public Guid? Id { get; set; }
        public WorkForm Form { get; set; }
        public IList<SelectListItem> EngineTypesList { get; set; }

        public WorkEditModel(Guid? id, WorkForm form, IList<SelectListItem> engineTypesList)
        {
            Id = id;
            Form = form;
            EngineTypesList = engineTypesList;
        }
    }
}