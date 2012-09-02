using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deviation.Dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace Deviation.Test
{
    [TestClass]
    public class StructureMapTest
    {
        
        
        [TestMethod]
        public void TestRegistry()   {
        
            ObjectFactory.Initialize(reg =>
                                         {
                                             reg.ForSingletonOf<IDataContext<Entities.Deviation>>()
                                                 .Use<DeviationDataContext>();
                                             reg.ForSingletonOf<IRepository<Entities.Deviation>>()
                                                 .Use<DeviationRepository>()
                                                 .Ctor<IDataContext<Entities.Deviation>>();
                                         });

            ObjectFactory.AssertConfigurationIsValid();
    
        }

    }
}
