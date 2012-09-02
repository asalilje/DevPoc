using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingSelection.Entities;
using StructureMap;

namespace BookingSelection.Dal
{
    public class ContainerBootstrapper
    {
        public static void BootstrapStructuremap()
        {
            ObjectFactory.Initialize(reg =>
                    { 
                        reg.ForSingletonOf<IDataContext<Booking>>().Add<BookingSelectionDataContext>();
                        reg.For<IRepository<Booking>>().Add<BookingRepository>().Ctor<IDataContext<Booking>>();
                    });
        }
    }
}
