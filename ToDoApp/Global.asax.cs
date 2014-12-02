using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ToDoApp.Core;

namespace ToDoApp.UI
{
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			Bootstrapper.Initialise();
			AuthConfig.RegisterAuth();
		}

		protected void Application_Error(Object sender, EventArgs e)
		{
			var exception = Server.GetLastError();
			if (exception == null)
				return;
			new Logger().Log(exception);
			Server.ClearError();
			Response.Redirect("~/Error.html", true);
		}
	}
}