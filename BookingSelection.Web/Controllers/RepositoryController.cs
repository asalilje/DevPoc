using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookingSelection.Dal;
using BookingSelection.Entities;
using StructureMap;

namespace BookingSelection.Web.Controllers
{
    public class RepositoryController : Controller
    {

        public IRepository<Booking> BookingRepository { get; private set; }

        protected RepositoryController()
        {
            BookingRepository = ObjectFactory.GetInstance<IRepository<Booking>>();
        }

    }
}
