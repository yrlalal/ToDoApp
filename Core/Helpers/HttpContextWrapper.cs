using System.Web;
using ToDoApp.Core.Interface;

namespace ToDoApp.Core.Helpers
{
	public class HttpContextWrapper : IHttpContextWrapper
	{
		public string UserName { get { return HttpContext.Current.User.Identity.Name; } }
	}
}
