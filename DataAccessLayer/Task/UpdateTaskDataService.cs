using System;
using System.Linq;
using ToDoApp.Data.Services.Task.Interfaces;

namespace ToDoApp.Data.Services.Task
{
	public class UpdateTaskDataService : TaskDataServiceBase, IUpdateTaskDataService
	{
		public void Execute(long taskId, string taskDescription, string dueDate, string category, string priority, string status)
		{
			var taskToEdit = _taskDatabase.Tasks.FirstOrDefault(t => t.TaskId == taskId);
			if (taskToEdit == null)
				throw new Exception(string.Format("A task with id [{0}] is not found", taskId));
			taskToEdit.Description = taskDescription;
			taskToEdit.DueDate = convertToDateTime(dueDate);
			taskToEdit.CategoryId = getCategoryId(category);
			taskToEdit.PriorityId = getPriorityId(priority);
			taskToEdit.StatusId = getStatusId(status);
			_taskDatabase.SaveChanges();
		}
	}
}
