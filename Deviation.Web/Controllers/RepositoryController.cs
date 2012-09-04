using System.Web.Mvc;
using Deviation.Dal;
using NServiceBus;
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

		protected override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			DeviationRepository.Dispose();
		}

    }
}
