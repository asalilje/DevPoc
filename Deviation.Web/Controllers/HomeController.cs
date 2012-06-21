using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Repository;
using Deviation.Logic;
using Deviation.Web.Mappers;
using Deviation.Web.Models;
using StructureMap;

namespace Deviation.Web.Controllers
{
    public class HomeController : Controller
    {

    	private readonly IRepository<Entities.Deviation> _deviationRepository;

    	public HomeController()
    	{
			_deviationRepository = ObjectFactory.GetInstance<IRepository<Entities.Deviation>>();
    	}

        public ActionResult Index()
        {
            ViewBag.Message = "Här skapar och ändrar du avvikelser.";


        	var deviationList = _deviationRepository.GetItems();
            var mapper = new DeviationMapper();
            var deviationModelList = deviationList.ToList().Select(mapper.MapToModel);
            var model = new DeviationModel {DeviationList = deviationModelList};
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(DeviationModel model)
        {
            if (!ModelState.IsValid)
                return View(model);


            model.DeviationId = Guid.NewGuid();
            var mapper = new DeviationMapper();
            var entity = mapper.MapToEntity(model);
           _deviationRepository.AddItem(entity);
            return RedirectToAction("Index");
     
        }

        [HttpPost]
        public ActionResult Delete(Guid deviationId)
        {
			_deviationRepository.RemoveItem(deviationId);
            return RedirectToAction("Index");
        }

 
    }
}
