using System;
using System.Web.Mvc;
using Common.Messages;
using Common.Messages.Commands;
using Deviation.Web.Infrastructure.Mappers;
using Deviation.Web.Models;
using NServiceBus;

namespace Deviation.Web.Controllers
{
	public class DeviationController : RepositoryController
	{

		public IBus Bus { get; set; }

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
			DeviationRepository.Save();
			Bus.Send<CreateDeviationCommand>(cmd =>
			                                 {
			                                 	cmd.Id = entity.DeviationId;
			                                 	cmd.DeviationName = entity.DeviationName;
			                                 	cmd.DeviationTypeId = entity.DeviationTypeId;
			                                 	cmd.ValidFrom = entity.DateInterval.ValidFrom;
			                                 	cmd.ValidTo = entity.DateInterval.ValidTo;
                                                cmd.Status = DeviationStatus.Created;
			                                 }
				);
			
			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public ActionResult Edit(Guid deviationId)
		{
			var entity = DeviationRepository.GetItem(deviationId);
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
			DeviationRepository.Save();

            Bus.Send<UpdateDeviationCommand>(cmd =>
            {
                cmd.Id = entity.DeviationId;
                cmd.DeviationName = entity.DeviationName;
                cmd.DeviationTypeId = entity.DeviationTypeId;
                cmd.ValidFrom = entity.DateInterval.ValidFrom;
                cmd.ValidTo = entity.DateInterval.ValidTo;
                cmd.Status = DeviationStatus.Updated;
            });
			return RedirectToAction("Index", "Home");
		}
	}
}