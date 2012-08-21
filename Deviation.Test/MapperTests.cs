using System;
using System.Linq;
using Deviation.Entities;
using Deviation.Web.Infrastructure.Mappers;
using Deviation.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Deviation.Test
{
    [TestClass]
    public class MapperTests
    {
        [TestMethod]
        public void TestMapperMapToModel()
        {
            var entity = new Entities.Deviation
                             {
								 DeviationId = Guid.NewGuid(),
                                 DateInterval = new DateInterval
                                                    {
                                                        ValidFrom = DateTime.Now, 
                                                        ValidTo = DateTime.Now.AddDays(12)
                                                    },
                                 DeviationTypeId = 1,
                                 DeviationName = "Timetable change today"
                             };
            var mapper = new DeviationMapper();
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
				DeviationId = Guid.NewGuid()
			};

			var mapper = new DeviationMapper();
			var entity = mapper.MapToEntity(model);

			Assert.AreEqual(entity.DeviationName, model.DeviationName);


		}
    }
}
