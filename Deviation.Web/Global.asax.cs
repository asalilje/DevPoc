using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Deviation.Dal;
using Deviation.Web.Infrastructure.Injection;
using NServiceBus;

namespace Deviation.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ContainerBootstrapper.BootstrapStructuremap();

			// NServiceBus configuration
			Configure.With()
				.DefaultBuilder()
				.ForMvc()
				.XmlSerializer()
				.Log4Net()
				.MsmqTransport()
					.IsTransactional(false)
					.PurgeOnStartup(true)
				.UnicastBus()
					.ImpersonateSender(false)
				.CreateBus()
				.Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install());

        }
    }
}