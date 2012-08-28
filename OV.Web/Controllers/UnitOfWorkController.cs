using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OV.Dal;
using OV.Entitites;
using StructureMap;

namespace OV.Web.Controllers
{
    public class UnitOfWorkController : Controller
    {
    	
		protected UnitOfWork UnitOfWork { get; private set; }

    	protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			UnitOfWork = new UnitOfWork();
		}

		protected override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			if(filterContext.IsChildAction)
				return;

			if(filterContext.Exception != null)
				return;

			if(UnitOfWork != null)
				UnitOfWork.Dispose();
		}

    }
}
