using Microsoft.Practices.Unity;
using ToDoApp.UI.Mappers.Account;
using ToDoApp.UI.Mappers.Account.Interfaces;
using ToDoApp.UI.Mappers.Task;
using ToDoApp.UI.Mappers.Task.Interfaces;

namespace ToDoApp.UI.UnityHelpers
{
	public class UnityMapperHelper
	{
		public void Configure(IUnityContainer container)
		{
			container.RegisterType<IRegisterAccountMapper, RegisterAccountMapper>();
			container.RegisterType<ISignInAccountMapper, SignInAccountMapper>();

			container.RegisterType<IAddTaskMapper, AddTaskMapper>();
			container.RegisterType<IRetrieveTaskListMapper, RetrieveTaskListMapper>();
			container.RegisterType<IEditTaskMapper, EditTaskMapper>();
			container.RegisterType<IDeleteTaskMapper, DeleteTaskMapper>();
		}
	}
}