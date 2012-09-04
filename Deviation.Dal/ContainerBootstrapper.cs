using StructureMap;

namespace Deviation.Dal
{
    public  class ContainerBootstrapper : IBootstrapper
    {
 
		public void BootstrapStructureMap()
		{
			ObjectFactory.Initialize(reg => reg.For<IRepository<Entities.Deviation>>()
											   .Use<DeviationRepository>()
											   .Ctor<DeviationDbContext>());
		}
	}
}