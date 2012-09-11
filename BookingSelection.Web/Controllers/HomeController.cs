using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;
using BookingSelection.Web.Infrastructure.Mappers;
using BookingSelection.Web.Models;
using Common.Messages;
using Common.Messages.Commands;
using NServiceBus;

namespace BookingSelection.Web.Controllers
{
    public class HomeController : RepositoryController
    {

        public IBus Bus { get; set; }

        [HttpGet]
        public ActionResult Index(string deviationId, string message)
        {
            ViewBag.Message = "Här lägger du upp vilka bokningar som ska kopplas till avvikelsen.";
        	ViewBag.Saved = message;
            var model = new BookingModel { DeviationId = deviationId };
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(int bookingTypeId, string deviationId)
        {
            var bookings = BookingRepository.GetItemsByQuery(item => item.BookingTypeId == bookingTypeId);
            var bookingMapper = new BookingMapper();
            var model = bookings.Select(bookingMapper.MapToModel);
            model.Select(item => item.DeviationId = deviationId);
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateSelection(Guid[] bookingId, string deviationId)
        {
        	var bookings = new Collection<Booking>();

			foreach(var id in bookingId)
			{
				bookings.Add(new Booking {BookingId = id});
			}

            var bookingsAdded = new AddBookingsCommand
            {
                Bookings = bookings,
                DeviationId = Guid.Parse(deviationId)
            };
            
			Bus.Send(bookingsAdded);

            return RedirectToAction("Index", "Home", new {deviationId = deviationId, message = "Sparat!"});
        }
       
    }
}
