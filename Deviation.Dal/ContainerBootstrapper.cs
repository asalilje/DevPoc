using StructureMap;

namespace Deviation.Dal
{
    public static class ContainerBootstrapper
    {
        public static void BootstrapStructuremap()
        {
            ObjectFactory.Initialize(reg =>
                                         {
                                             reg.ForSingletonOf<IDataContext<Entities.Deviation>>()
                                                 .Use<DeviationDataContext>();
                                             reg.For<IRepository<Entities.Deviation>>()
                                                 .Use<DeviationRepository>()
                                                 .Ctor<IDataContext<Entities.Deviation>>()
                                                 .IsTheDefault();
                                         });
        }
        

    }
}