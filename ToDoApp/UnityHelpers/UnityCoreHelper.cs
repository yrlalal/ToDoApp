using Microsoft.Practices.Unity;
using ToDoApp.Core.Helpers;
using ToDoApp.Core.Interface;

namespace ToDoApp.UI.UnityHelpers
{
	public class UnityCoreHelper
	{
		public void Configure(IUnityContainer container)
		{
			container.RegisterType<IHttpContextWrapper, HttpContextWrapper>();
		}
	}
}