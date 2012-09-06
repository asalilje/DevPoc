using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Deviation.Web.Infrastructure.Mappers;
using Deviation.Web.Models;

namespace Deviation.Web.Controllers
{
    public class HomeController : RepositoryController
    {

        public ActionResult Index()
        {
            ViewBag.Message = "Här skapar och ändrar du avvikelser.";
        	var model = GetDeviationList();
            return View(model);
        }


        private IEnumerable<DeviationModel> GetDeviationList()
        {
            var deviationList = DeviationRepository.GetItems();
            var mapper = new DeviationMapper();
            var deviationModelList = deviationList.ToList().Select(mapper.MapToModel).ToList();
            return deviationModelList;
        }
    }
}
