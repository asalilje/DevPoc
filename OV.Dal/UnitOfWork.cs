using System;
using OV.Entitites;

namespace OV.Dal
{
	public class UnitOfWork : IDisposable
	{

		private IDbContext _dbContext = new OVDbContext();
		private IRepository<Deviation> _deviationRepository;

		//fyll på med fler repositories om det behövs

		public IRepository<Deviation> DeviationRepository 
		{
		    get
		    {
		        _deviationRepository = _deviationRepository ?? new Repository<Deviation>(_dbContext);
		        return _deviationRepository;
		    }
		}

		public void Save()
		{
			_dbContext.SaveChanges();
		}



		private bool _disposed;

		protected void Dispose(bool disposing)
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

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}