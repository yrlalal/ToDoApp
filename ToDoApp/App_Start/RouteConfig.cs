using System.Web.Mvc;
using System.Web.Routing;

namespace ToDoApp.UI
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.IgnoreRoute("{*contents}", new { contents = @".*\.(aspx|png|swf|gif|jpg|jpeg|css|js|htm|html|xml|ico)(/.*)?" });
			routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Task", action = "List", id = UrlParameter.Optional }
			);
		}
	}
}