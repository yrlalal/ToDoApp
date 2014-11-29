using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApp.Data.Services.Task.Interfaces;

namespace ToDoApp.Data.Services.Task
{
	public class RetrieveTaskListDataService : TaskDataServiceBase, IRetrieveTaskListDataService
	{
		public IList<TaskDetails> Execute(string email)
		{
			long accountId = getAccountId(email);
			var tasks = _taskDatabase.Tasks.Where(c => c.AccountId == accountId).ToList();
			return tasks.Select(task => new TaskDetails
			                            	{
												Id = task.TaskId,
												Description = task.Description,
												DueDate = task.DueDate,
												LastUpdateDateTime = task.LastUpdateDateTime,
												AddDateTime = task.AddDateTime,
												Category = task.Category == null ? string.Empty : task.Category.CategoryText,
												Priority = task.Priority == null ? string.Empty : task.Priority.PriorityText,
												Status = task.Status == null ? string.Empty : task.Status.StatusText
											}).OrderBy(task => task.DueDate).ToList();
		}
	}
}
