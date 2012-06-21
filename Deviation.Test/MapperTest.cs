using System;
using Deviation.Entities;
using Deviation.Web.Mappers;
using Deviation.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Deviation.Test
{
    [TestClass]
    public class MapperTest
    {
        [TestMethod]
        public void TestMapper()
        {
            var entity = new Entities.Deviation
                             {
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
    }
}
