using System;
using System.Linq;
using Deviation.Entities;
using Deviation.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace Deviation.Test
{
    [TestClass]
    public class RepositoryTest
    {

        [TestInitialize]
        public void TestInit()
        {
            ContainerBootstrapper.BootstrapStructuremap();
        }

        public IRepository<Entities.Deviation> Repository
        {
            get { return ObjectFactory.GetInstance<IRepository<Entities.Deviation>>(); }
        }

        public Entities.Deviation CreateDeviation(int typeId = 1)
        {
            return new Entities.Deviation
            {
                DeviationId = Guid.NewGuid(),
                DateInterval = new DateInterval
                {
                    ValidFrom = DateTime.Now,
                    ValidTo = DateTime.Now.AddDays(12)
                },
                DeviationTypeId = typeId,
                DeviationName = "Timetable change today"
            };
        }

        [TestMethod]
        public void GetRepoWithIoC()
        {
            Assert.IsInstanceOfType(Repository, typeof(IRepository<Entities.Deviation>));
        }

        [TestMethod]
        public void AddDeviations()
        {

            const int count = 2;
            for (var i = 0; i < count; i++)
                Repository.AddItem(CreateDeviation());

            Assert.AreEqual(count, Repository.GetItems().Count());

        }

        [TestMethod]
        public void AddAndRemoveDeviation()
        {
            var deviation = CreateDeviation();
            Repository.AddItem(deviation);
            Repository.RemoveItem(deviation.DeviationId);

            Assert.AreEqual(0, Repository.GetItems().Count());
        }

        [TestMethod]
        public void AddAndGetDeviationById()
        {
            var deviation = CreateDeviation();
            Repository.AddItem(deviation);
            var item = Repository.GetItemById(deviation.DeviationId);

            Assert.AreEqual(deviation, item);
        }

        [TestMethod]
        public void AddAndGetDeviationsByQuery()
        {
            const int count = 5;
            for (var i = 0; i < count; i++)
                Repository.AddItem(CreateDeviation(i));

            var items = Repository.GetItemsByQuery(deviation => deviation.DeviationTypeId == 3);
            Assert.AreEqual(1, items.Count());
        }


    }
}