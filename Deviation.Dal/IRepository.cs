using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Deviation.Entities;

namespace Deviation.Dal
{
    public interface IRepository<T> : IDisposable where T : IEntity
    {
		IQueryable<T> GetItems();
		IQueryable<T> GetItemsByFilter(Expression<Func<T, bool>> filter);
		void AddItem(T item);
		void RemoveItem(Guid id);
    	void RemoveItem(T item);
		T GetItem(Guid id);
		void UpdateItem(T item);
		void Save();
    }
}