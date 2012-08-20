using OV.Entitites;
using StructureMap;

namespace OV.Logic
{
	public static class ContainerBootstrapper
	{
		
		public static void BootstrapStructuremap()
		{
			ObjectFactory.Initialize(
				reg =>
				{
					reg.ForSingletonOf<IDataContext<Deviation>>().Add<OVDataContext>();
					reg.For<IRepository<Deviation>>().Add<OVRepository>().Ctor<IDataContext<Deviation>>();
				});
		}

	}
}