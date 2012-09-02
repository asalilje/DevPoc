using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BookingSelection.Entities;

namespace BookingSelection.Dal
{
    public class BookingSelectionDataContext : IDataContext<Booking>
    {

        private ICollection<Booking> _collection;

        public ICollection<Booking> Collection { get { return _collection; } }

        public BookingSelectionDataContext()
        {
            _collection = GetBootstrapBookings();
        }

        private static ICollection<Booking> GetBootstrapBookings()
        {
            var bookings = new Collection<Booking> {
                    new Booking { BookingId = Guid.NewGuid(), BookingNumber = "12345", BookingTypeId = 1 },
                    new Booking { BookingId = Guid.NewGuid(), BookingNumber = "23456", BookingTypeId = 2 },
                    new Booking { BookingId = Guid.NewGuid(), BookingNumber = "34567", BookingTypeId = 1 },
                    new Booking { BookingId = Guid.NewGuid(), BookingNumber = "45678", BookingTypeId = 2 },
                    new Booking { BookingId = Guid.NewGuid(), BookingNumber = "56789", BookingTypeId = 1 },
                    new Booking { BookingId = Guid.NewGuid(), BookingNumber = "67890", BookingTypeId = 2 },
                    new Booking { BookingId = Guid.NewGuid(), BookingNumber = "78901", BookingTypeId = 1 },
                    new Booking { BookingId = Guid.NewGuid(), BookingNumber = "89012", BookingTypeId = 2 },
                    new Booking { BookingId = Guid.NewGuid(), BookingNumber = "90123", BookingTypeId = 1 },
                    new Booking { BookingId = Guid.NewGuid(), BookingNumber = "01234", BookingTypeId = 2 }
            };
            return bookings;
        }


    }
}
