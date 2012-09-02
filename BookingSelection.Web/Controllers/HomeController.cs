using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookingSelection.Web.Infrastructure;
using BookingSelection.Web.Infrastructure.Mappers;
using BookingSelection.Web.Models;
using Common.Messages.Commands;
using NServiceBus;

namespace BookingSelection.Web.Controllers
{
    public class HomeController : RepositoryController
    {

        public IBus Bus { get; set; }

        [HttpGet]
        public ActionResult Index(string DeviationId)
        {
            ViewBag.Message = "Här lägger du upp vilka bokningar som ska kopplas till avvikelsen.";
            var model = new BookingModel { DeviationId = DeviationId };
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(int bookingTypeId, string DeviationId)
        {
            var bookings = BookingRepository.GetItemsByQuery(item => item.BookingTypeId == bookingTypeId);
            var bookingMapper = new BookingMapper();
            var model = bookings.Select(bookingMapper.MapToModel);
            model.Select(item => item.DeviationId = DeviationId);
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateSelection(Guid[] BookingId, string DeviationId)
        {
            var command = new AddBookingsCommand
            {
                Bookings = BookingId.ToList(),
                DeviationId = Guid.Parse(DeviationId)
            };
            Bus.Send(command);
            ViewBag.Saved = "Sparat!";
            return RedirectToAction("Index", "Home");
        }
       
    }
}
