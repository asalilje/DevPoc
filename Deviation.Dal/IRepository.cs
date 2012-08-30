using System;
using System.Collections.Generic;
using Deviation.Entities;

namespace Deviation.Dal
{
    public interface IRepository<T> where T : IEntity
    {
        T GetItemById(Guid id);
        IEnumerable<T> GetItemsByQuery(Func<T, bool> filter);
        IEnumerable<T> GetItems();
        void AddItem(T item);
        void RemoveItem(Guid id);

    }
}