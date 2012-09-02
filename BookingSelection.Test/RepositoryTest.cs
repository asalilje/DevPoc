using System;
using System.Linq;
using BookingSelection.Dal;
using BookingSelection.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace BookingSelection.Test
{
    [TestClass]
    public class RepositoryTest
    {
        [TestInitialize]
        public void TestInit()
        {
            ContainerBootstrapper.BootstrapStructuremap();
        }

        public IRepository<Booking> Repository
        {
            get { return ObjectFactory.GetInstance<IRepository<Booking>>(); }
        }

        public Booking CreateBooking()
        {
            return new Booking
            {
                BookingId = Guid.NewGuid(),
                BookingNumber = "11111"
            };
        }

        [TestMethod]
        public void GetRepoWithIoC()
        {
            Assert.IsInstanceOfType(Repository, typeof(IRepository<Booking>));
        }

        [TestMethod]
        public void AddBookings()
        {
            var repoCount = Repository.GetItems().Count();

            const int count = 2;
            for (var i = 0; i < count; i++)
                Repository.AddItem(CreateBooking());

            var newCount = Repository.GetItems().Count();

            Assert.AreEqual(repoCount + count, newCount);

        }

        [TestMethod]
        public void AddAndRemoveBooking()
        {
            var repoCount = Repository.GetItems().Count();

            var booking = CreateBooking();
            Repository.AddItem(booking);
            Repository.RemoveItem(booking.BookingId);

            var newCount = Repository.GetItems().Count();

            Assert.AreEqual(newCount, repoCount);
        }

        [TestMethod]
        public void AddAndGetBookingById()
        {
            var booking = CreateBooking();
            Repository.AddItem(booking);
            var item = Repository.GetItemById(booking.BookingId);

            Assert.AreEqual(booking, item);
        }

        [TestMethod]
        public void AddAndGetBookingsByQuery()
        {
            const int count = 5;
            for (var i = 0; i < count; i++)
                Repository.AddItem(CreateBooking());

            var items = Repository.GetItemsByQuery(booking => booking.BookingNumber == "11111");
            //Assert.AreEqual(count, items);
        }


    }
}
