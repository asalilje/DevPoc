using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OV.Web.Infrastructure;
using OV.Web.Models;

namespace OV.Web.Controllers
{
	public class HomeController : RepositoryController
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Worklist";

			var model = new DeviationModel
			            {
			            	DeviationId = Guid.NewGuid(),
			            	DeviationName = "Test",
			            	DeviationTypeId = 1,
			            	ValidFrom = DateTime.Now,
			            	ValidTo = DateTime.Now
			            };

			var mapper = new OVMapper();
			var entity = mapper.MapToEntity(model);
			OVRepository.AddItem(entity);

			var list = GetWorklist();

			return View(list);
		}

		private IEnumerable<DeviationModel> GetWorklist()
		{
			var entities = OVRepository.GetItems();
			var mapper = new OVMapper();
			var model = entities.Select(mapper.MapToModel);
			return model;
		}

	}
}
