using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingSelection.Entities;

namespace BookingSelection.Dal
{
    public interface IRepository<T> where T:IEntity
    {
        T GetItemById(Guid id);
        IEnumerable<T> GetItemsByQuery(Func<T, bool> filter);
        IEnumerable<T> GetItems();
        void AddItem(T item);
        void RemoveItem(Guid id);
    }
}
