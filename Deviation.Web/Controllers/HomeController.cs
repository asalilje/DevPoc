﻿using System;
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



        [HttpPost]
        public ActionResult Delete(Guid deviationId)
        {
			DeviationRepository.RemoveItem(deviationId);
            return RedirectToAction("Index");
        }

        private IEnumerable<DeviationModel> GetDeviationList()
        {
            var deviationList = DeviationRepository.GetItems();
            var mapper = new DeviationMapper();
            var deviationModelList = deviationList.ToList().Select(mapper.MapToModel);
            return deviationModelList;
        }
    }
}
