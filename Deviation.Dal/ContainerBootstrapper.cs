using StructureMap;

namespace Deviation.Dal
{
    public static class ContainerBootstrapper
    {
        public static void BootstrapStructuremap()
        {
            ObjectFactory.Initialize(reg =>
                                         {
                                             reg.ForSingletonOf<IDataContext<Entities.Deviation>>().Add<DeviationDataContext>();
                                             reg.For<IRepository<Entities.Deviation>>().Add<DeviationRepository>().Ctor<IDataContext<Entities.Deviation>>();
                                         });
        }
        

    }
}