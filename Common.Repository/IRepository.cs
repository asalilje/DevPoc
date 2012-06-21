using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Deviation.Entities;

namespace Common.Repository
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