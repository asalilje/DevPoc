using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using OV.Entitites;

namespace OV.Dal
{
	public class OVDbContext: DbContext, IDbContext
	{

		public DbSet<Deviation> Deviation { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}


		public new IDbSet<T> Set<T>() where T : class
		{
			return base.Set<T>();
		}


		public new DbEntityEntry<T> Entry<T>(T item) where T : class
		{
			return base.Entry(item);
		}
	}
}