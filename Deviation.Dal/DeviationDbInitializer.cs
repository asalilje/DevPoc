using System.Data.Entity;

namespace Deviation.Dal
{
	public class DeviationDbInitializer : DropCreateDatabaseIfModelChanges<DeviationDbContext>
	{
	}
}