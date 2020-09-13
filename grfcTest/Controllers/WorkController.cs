using grfcTest.Models.Works.CreateEdit;
using grfcTest.Models.Works.Item;
using grfcTest.Models.Works.List;
using System;
using System.Web.Mvc;

namespace grfcTest.Controllers
{
    public class WorkController : Controller
    {
        private readonly IWorkListModelBuilder workListModelBuilder;
        private readonly IWorkItemModelBuilder workItemModelBuilder;
        private readonly IWorkEditModelBuilder workEditModelBuilder;
        private readonly IWorkValidator workValidator;
        private readonly IWorkFormHandler workFormHandler;
        public WorkController(IWorkListModelBuilder workListModelBuilder, 
            IWorkItemModelBuilder workItemModelBuilder, 
            IWorkEditModelBuilder workEditModelBuilder, 
            IWorkValidator workValidator, 
            IWorkFormHandler workFormHandler)
        {
            this.workListModelBuilder = workListModelBuilder;
            this.workItemModelBuilder = workItemModelBuilder;
            this.workEditModelBuilder = workEditModelBuilder;
            this.workValidator = workValidator;
            this.workFormHandler = workFormHandler;
        }

        public ActionResult List()
        {
            return View("List", workListModelBuilder.Build());
        }

        public ActionResult Item(Guid id)
        {
            return View("Item", workItemModelBuilder.Build(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Form", workEditModelBuilder.BuildNew());
        }

        [HttpPost]
        public ActionResult Create(WorkForm form)
        {
            var valResult = workValidator.ValidateOnCreate(form, ModelState);

            if (valResult.ModelState.IsValid)
            {
                var id = workFormHandler.HandleCreate(form);
                return RedirectToAction("Item", new {id});
            }

            return View("Form", workEditModelBuilder.BuildByForm(null, form));
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View("Form", workEditModelBuilder.BuildEdit(id));
        }

        [HttpPost]
        public ActionResult Edit(Guid id, WorkForm form)
        {
            var valResult = workValidator.ValidateOnEdit(id, form, ModelState);

            if (valResult.ModelState.IsValid)
            {
                workFormHandler.HandleEdit(form, valResult);
                return RedirectToAction("Item", new {id});
            }

            return View("Form", workEditModelBuilder.BuildByForm(id, form));
        }
    }
}