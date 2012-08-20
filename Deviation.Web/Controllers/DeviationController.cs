using System;
using System.Web.Mvc;
using Deviation.Web.Infrastructure.Mappers;
using Deviation.Web.Models;

namespace Deviation.Web.Controllers
{
	public class DeviationController : RepositoryController
	{
		[HttpGet]
		public ActionResult Create()
		{
			var model = new DeviationModel();
			return View(model);
		}

		[HttpPost]
		public ActionResult Create(DeviationModel model)
		{
			if(!ModelState.IsValid)
			{
				return View(model);
			}

			model.DeviationId = Guid.NewGuid();
			var mapper = new DeviationMapper();
			var entity = mapper.MapToEntity(model);
			DeviationRepository.AddItem(entity);
			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public ActionResult Edit(Guid deviationId)
		{
			var entity = DeviationRepository.GetItemById(deviationId);
			var mapper = new DeviationMapper();
			var model = mapper.MapToModel(entity);
			return View(model);
		}

		[HttpPost]
		public ActionResult Edit(DeviationModel model)
		{
			if(!ModelState.IsValid)
				return View(model);
			
			var mapper = new DeviationMapper();
			var entity = mapper.MapToEntity(model);
			DeviationRepository.AddItem(entity);
			return RedirectToAction("Index", "Home");
		}
	}
}