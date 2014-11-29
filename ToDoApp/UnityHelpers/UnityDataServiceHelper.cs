using Microsoft.Practices.Unity;
using ToDoApp.Data.Services.Account;
using ToDoApp.Data.Services.Account.Interfaces;
using ToDoApp.Data.Services.Category;
using ToDoApp.Data.Services.Category.Interface;
using ToDoApp.Data.Services.Priority;
using ToDoApp.Data.Services.Priority.Interface;
using ToDoApp.Data.Services.Status;
using ToDoApp.Data.Services.Status.Interface;
using ToDoApp.Data.Services.Task;
using ToDoApp.Data.Services.Task.Interfaces;

namespace ToDoApp.UI.UnityHelpers
{
	public class UnityDataServiceHelper
	{
		public void Configure(IUnityContainer container)
		{
			container.RegisterType<IAddAccountDataService, AddAccountDataService>();
			container.RegisterType<IVerifyAccountDataService, VerifyAccountDataService>();

			container.RegisterType<IRetrieveCategoryListDataService, RetrieveCategoryListDataService>();

			container.RegisterType<IRetrievePriorityListDataService, RetrievePriorityListDataService>();

			container.RegisterType<IRetrieveStatusListDataService, RetrieveStatusListDataService>();

			container.RegisterType<ICreateTaskDataService, CreateTaskDataService>();
			container.RegisterType<IRetrieveTaskListDataService, RetrieveTaskListDataService>();
			container.RegisterType<IRetrieveTaskDataService, RetrieveTaskDataService>();
			container.RegisterType<IUpdateTaskDataService, UpdateTaskDataService>();
			container.RegisterType<IDeleteTaskDataService, DeleteTaskDataService>();
		}
	}
}