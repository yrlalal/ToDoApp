using System;
using ToDoApp.Data.Services.Task.Interfaces;

namespace ToDoApp.Data.Services.Task
{
	public class CreateTaskDataService : TaskDataServiceBase, ICreateTaskDataService
	{
		public void Execute(string taskDescription, string dueDate, string category, string priority, string status, string email)
		{
			var currentDateTime = DateTime.Now;
			var accountId = getAccountId(email);
			_taskDatabase.AddToTasks(new Model.Task { Description = taskDescription, 
												CategoryId = getCategoryId(category),
												StatusId = getStatusId(status),
												PriorityId = getPriorityId(priority),
												AccountId = accountId,
												DueDate = convertToDateTime(dueDate),
												LastUpdateDateTime = currentDateTime,
												AddDateTime = currentDateTime,
			});
			_taskDatabase.SaveChanges();
		}
	}
}
