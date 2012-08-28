using System;
using AutoMapper;
using Common.Logic;
using Common.Messages.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OV.Entitites;
using OV.Web.Infrastructure;
using OV.Web.Models;

namespace OV.Test
{
	[TestClass]
	public class MapperTests
	{
		[TestMethod]
		public void TestMapperMapToModel()
		{
			var entity = new Deviation
			{
				Id = Guid.NewGuid(),
				ValidFrom = DateTime.Now,
				ValidTo = DateTime.Now.AddDays(12),
				DeviationTypeId = 1,
				DeviationName = "Timetable change today"
			};
			var mapper = new OVMapper();
			var model = mapper.MapToModel(entity);

			Assert.AreEqual(entity.DeviationName, model.DeviationName);

		}


		[TestMethod]
		public void TestMapperMapToEntity()
		{
			var model = new DeviationModel
			{
				ValidFrom = DateTime.Now,
				ValidTo = DateTime.Now.AddDays(12),
				DeviationTypeId = 1,
				DeviationName = "Timetable change today",
				Id = Guid.NewGuid()
			};

			var mapper = new OVMapper();
			var entity = mapper.MapToEntity(model);

			Assert.AreEqual(entity.DeviationName, model.DeviationName);

		}

		[TestMethod]
		public void TestMapperMapCommandToEntity()
		{
			var command = new CreateDeviationCommand
			              {
			              		ValidFrom = DateTime.Now,
			              		ValidTo = DateTime.Now.AddDays(12),
			              		DeviationTypeId = 1,
			              		DeviationName = "Timetable change today",
			              		Id = Guid.NewGuid()
			              };

			Mapper.CreateMap<CreateDeviationCommand, Deviation>();
			var model = Mapper.Map<CreateDeviationCommand, Deviation>(command);
			Assert.AreEqual(model.DeviationName, command.DeviationName);

		}
	}
}