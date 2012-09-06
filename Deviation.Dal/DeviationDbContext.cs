using System.Data.Entity;

namespace Deviation.Dal
{
	public class DeviationDbContext : DbContext
	{
		public DbSet<Entities.Deviation> Deviation { get; set; }
		public DbSet<Entities.Booking> Booking { get; set; }

		//public DeviationDbContext()
		//{
		//    Configuration.LazyLoadingEnabled = false;
		//}
	}
}