using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Deviation.Logic;
using Deviation.Web.Mappers;
using Deviation.Web.Models;

namespace Deviation.Web.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Message = "Här skapar och ändrar du avvikelser.";

            //var deviationRepository = DeviationRepository.Instance;
            //var deviationList = deviationRepository.List();
            //var mapper = new DeviationMapper();
            //var deviationModelList = deviationList.ToList().Select(mapper.MapToModel);
            //var model = new DeviationModel {DeviationList = deviationModelList};
            //return View(model);
            return View();
        }

        [HttpPost]
        public ActionResult Index(DeviationModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.DeviationId = Guid.NewGuid();
            var mapper = new DeviationMapper();
            var entity = mapper.MapToEntity(model);
            //DeviationRepository.Instance.Add(entity);
            return RedirectToAction("Index");
     
        }

        [HttpPost]
        public ActionResult Delete(Guid deviationId)
        {
            //DeviationRepository.Instance.Delete(deviationId);
            return RedirectToAction("Index");
        }

 
    }
}
