using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ToDoApp.Core.Helpers
{
	public static class MvcExtensions
	{
		public static MvcForm BeginHorizontalForm(this HtmlHelper helper)
		{
			return helper.BeginForm(null, null, FormMethod.Post, new {@class = "form-horizontal", @role="form"});
		}
		public static MvcForm BeginSignInForm(this HtmlHelper helper)
		{
			return helper.BeginForm(null, null, FormMethod.Post, new { @class = "form-signin", @role = "form" });
		}
	}
}