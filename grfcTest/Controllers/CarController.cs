using grfcTest.Models.Cars.CreateEdit;
using grfcTest.Models.Cars.Item;
using grfcTest.Models.Cars.List;
using System;
using System.Web.Mvc;
using grfcTest.DataLayer.Common;
using grfcTest.Models.Works.SelectList;

namespace grfcTest.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarListModelBuilder carListModelBuilder;
        private readonly ICarItemModelBuilder carItemModelBuilder;
        private readonly ICarEditModelBuilder carEditModelBuilder;
        private readonly ICarValidator carValidator;
        private readonly ICarFormHandler carFormHandler;
        private readonly IWorkSelectListModelBuilder workSelectListModelBuilder;

        public CarController(ICarListModelBuilder carListModelBuilder,
            ICarItemModelBuilder carItemModelBuilder,
            ICarEditModelBuilder carEditModelBuilder,
            ICarValidator carValidator,
            ICarFormHandler carFormHandler, 
            IWorkSelectListModelBuilder workSelectListModelBuilder)
        {
            this.carListModelBuilder = carListModelBuilder;
            this.carItemModelBuilder = carItemModelBuilder;
            this.carEditModelBuilder = carEditModelBuilder;
            this.carValidator = carValidator;
            this.carFormHandler = carFormHandler;
            this.workSelectListModelBuilder = workSelectListModelBuilder;
        }

        public ActionResult List()
        {
            return View("List", carListModelBuilder.Build());
        }

        public ActionResult Item(Guid id)
        {
            return View("Item", carItemModelBuilder.Build(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Form", carEditModelBuilder.BuildNew());
        }

        [HttpPost]
        public ActionResult Create(CarForm form)
        {
            var valResult = carValidator.ValidateOnCreate(form, ModelState);

            if (valResult.ModelState.IsValid)
            {
                var id = carFormHandler.HandleCreate(form);
                return RedirectToAction("Item", new { id });
            }

            return View("Form", carEditModelBuilder.BuildByForm(null, form));
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View("Form", carEditModelBuilder.BuildEdit(id));
        }

        [HttpPost]
        public ActionResult Edit(Guid id, CarForm form)
        {
            var valResult = carValidator.ValidateOnEdit(id, form, ModelState);

            if (valResult.ModelState.IsValid)
            {
                carFormHandler.HandleEdit(form, valResult);
                return RedirectToAction("Item", new { id });
            }

            return View("Form", carEditModelBuilder.BuildByForm(id, form));
        }

        public JsonResult GetWorks(EngineType type)
        {
            var list = workSelectListModelBuilder.Build(type);

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}