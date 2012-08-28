using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace OV.Dal
{
	public interface IDbContext
	{
		IDbSet<T> Set<T>() where T : class;
		DbEntityEntry<T> Entry<T>(T item) where T : class;
		int SaveChanges();
		void Dispose();
	}
}