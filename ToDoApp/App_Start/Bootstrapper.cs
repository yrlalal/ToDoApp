using System.Web.Mvc;
using Microsoft.Practices.Unity;
using ToDoApp.UI.UnityHelpers;
using Unity.Mvc3;

namespace ToDoApp.UI
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();        
			new UnityDataServiceHelper().Configure(container);
			new UnityMapperHelper().Configure(container);
			new UnityCoreHelper().Configure(container);
            return container;
        }
    }
}