using System.Web.Mvc;
using Deviation.Logic;
using StructureMap;

namespace Deviation.Web.Controllers
{
    public class RepositoryController : Controller
    {

		public IRepository<Entities.Deviation> DeviationRepository { get; private set; }

    	protected RepositoryController()
    	{
			DeviationRepository = ObjectFactory.GetInstance<IRepository<Entities.Deviation>>();
    	}

    }
}
