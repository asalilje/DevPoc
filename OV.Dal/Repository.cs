using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using OV.Entitites;

namespace OV.Dal
{
	public class Repository<T> : IRepository<T> where T: class, IEntity
	{

		private IDbContext _dbContext;

		private IDbSet<T> DbSet
		{
			get { return _dbContext.Set<T>(); }
		}

		public Repository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IQueryable<T> GetItems()
		{
			return DbSet.AsQueryable();
		}

		public IQueryable<T> GetItemsByFilter(Expression<Func<T, bool>> filter)
		{
			return GetItems().Where(filter);
		}

		public T GetItem(int id)
		{
			return DbSet.Find(id);
		}

		public void UpdateItem(T item)
		{
			DbSet.Attach(item);
			var entry = _dbContext.Entry(item);
			entry.State = EntityState.Modified;
		}

		public void AddItem(T item)
		{
			DbSet.Add(item);
		}

		public void RemoveItem(int id)
		{
			var item = DbSet.Find(id);
			RemoveItem(item);
		}

		public void RemoveItem(T item)
		{
			var entry = _dbContext.Entry(item);
			if(entry.State == EntityState.Detached)
				DbSet.Attach(item);
			DbSet.Remove(item);
		}

		public void Save()
		{
			_dbContext.SaveChanges();
		}


		private bool _disposed;

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if(_disposed)
				return;

			if (!disposing)
				return;

			if(_dbContext == null)
				return;

			_dbContext.Dispose();
			_dbContext = null;
			_disposed = true;
		}

		
	}
}