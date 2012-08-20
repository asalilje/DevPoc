using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OV.Entitites;
using OV.Logic;
using StructureMap;

namespace OV.Web.Controllers
{
    public class RepositoryController : Controller
    {

		public IRepository<Deviation> OVRepository { get; private set; }

		protected RepositoryController()
		{
			OVRepository = ObjectFactory.GetInstance<IRepository<Deviation>>();
		}

    }
}
