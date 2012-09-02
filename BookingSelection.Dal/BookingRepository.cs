using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingSelection.Entities;

namespace BookingSelection.Dal
{
    public class BookingRepository : IRepository<Booking>
    {

        private readonly IDataContext<Booking> _dataContext;

        public BookingRepository(IDataContext<Booking> dataContext)
        {
            _dataContext = dataContext;
        }

        public Booking GetItemById(Guid id)
        {
            return _dataContext.Collection.SingleOrDefault(item => item.BookingId == id);
        }

        public IEnumerable<Booking> GetItemsByQuery(Func<Booking, bool> filter)
        {
            return _dataContext.Collection.Where(filter);
        }

        public IEnumerable<Booking> GetItems()
        {
            return _dataContext.Collection;
        }

        public void AddItem(Booking item)
        {
            if (_dataContext.Collection.Any(booking => booking.BookingId == item.BookingId))
                _dataContext.Collection.Remove(_dataContext.Collection.Single(booking => booking.BookingId == item.BookingId));

            _dataContext.Collection.Add(item);
        }

        public void RemoveItem(Guid id)
        {
            _dataContext.Collection.Remove(_dataContext.Collection.SingleOrDefault(booking => booking.BookingId == id));
        }
    }
}
