using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OV.Dal;
using OV.Entitites;
using OV.Web.Infrastructure;
using OV.Web.Models;
using PagedList;

namespace OV.Web.Controllers
{
	public class HomeController : UnitOfWorkController
	{

		public ActionResult Index(int? page)
		{
			ViewBag.Message = "Worklist";

			var list = GetWorklist();

			const int pageSize = 3;
			var pageNumber = page ?? 1;

			return View(list.ToPagedList(pageNumber, pageSize));
		}

		private IEnumerable<DeviationModel> GetWorklist()
		{
			var entities = UnitOfWork.DeviationRepository.GetItems().ToList();
			var mapper = new OVMapper();
			return entities.ToList().Select(mapper.MapToModel).ToList();
		}

	}
}
