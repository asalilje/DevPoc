using System;
using System.Data.Entity;
using NServiceBus;
using OV.Dal;

namespace OV.Bus
{
	public class ServerEndpoint : IWantToRunAtStartup
	{

		public void Run()
		{
			Database.SetInitializer<OVDbContext>(null);	
			Console.WriteLine("OV bus started...");
		}

		public void Stop()
		{
		}
	}
}