using System;
using System.Linq;
using OV.Entitites;

namespace OV.Dal
{
	public interface IRepository<T> : IDisposable where T: IEntity	
	{
		IQueryable<T> GetItems();
		void AddItem(T item);
		void RemoveItem(int id);
		T GetItem(int id);
		void UpdateItem(T item);
		void Save();
	}
}