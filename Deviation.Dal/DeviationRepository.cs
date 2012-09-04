using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Deviation.Dal
{
	public class DeviationRepository : IRepository<Entities.Deviation>
	{

		private DeviationDbContext _dbContext;

		private IDbSet<Entities.Deviation> DbSet { get { return _dbContext.Deviation; } }

		public DeviationRepository(DeviationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Entities.Deviation GetItem(Guid id)
		{
			return DbSet.Find(id);
		}

		public IQueryable<Entities.Deviation> GetItems()
		{
			return DbSet.AsQueryable();
		}

		public IQueryable<Entities.Deviation> GetItemsByFilter(Expression<Func<Entities.Deviation, bool>> filter)
		{
			return GetItems().Where(filter).AsQueryable();
		}

		public void AddItem(Entities.Deviation item)
		{
			DbSet.Add(item);
		}

		public void RemoveItem(Guid id)
		{
			var item = DbSet.Find(id);
			RemoveItem(item);
		}


		public void RemoveItem(Entities.Deviation item)
		{
			var entry = _dbContext.Entry(item);
			if(entry.State == EntityState.Detached)
				DbSet.Attach(item);
			DbSet.Remove(item);
		}


		public void UpdateItem(Entities.Deviation item)
		{
			DbSet.Attach(item);
			var entry = _dbContext.Entry(item);
			entry.State = EntityState.Modified;
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

			if(!disposing)
				return;

			if(_dbContext == null)
				return;

			_dbContext.Dispose();
			_dbContext = null;
			_disposed = true;
		}
	}
}