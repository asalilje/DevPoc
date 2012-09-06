using System.Data.Entity;
using Deviation.Dal;
using NServiceBus;

namespace Deviation.Bus
{
	public class ServerEndpoint : IWantToRunAtStartup
	{

		public void Run()
		{
			Database.SetInitializer<DeviationDbContext>(null);
		}

		public void Stop()
		{
			
		}
	}
}