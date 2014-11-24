using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ToDoApp
{
	public static class Extensions
	{
		public static MvcForm BeginHorizontalForm(this HtmlHelper helper)
		{
			return helper.BeginForm(null, null, FormMethod.Post, new {@class = "form-horizontal", @role="form"});
		}
	}
}