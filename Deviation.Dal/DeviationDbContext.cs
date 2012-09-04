using System.Data.Entity;

namespace Deviation.Dal
{
	public class DeviationDbContext : DbContext
	{
		public DbSet<Entities.Deviation> Deviation { get; set; }
	}
}