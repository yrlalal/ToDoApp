using System.Web.Optimization;

namespace ToDoApp.UI
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new StyleBundle("~/Content/todoapp.bundledcss.min").Include(
							"~/Content/site.css",
							"~/Content/table.css"));

			bundles.Add(new ScriptBundle("~/bundles/todoapp.bundledscripts.min").Include(
							"~/Scripts/custom/Shared.js"));
		}
	}
}