using System.Linq;
using ToDoApp.Data.Services.Task.Interfaces;

namespace ToDoApp.Data.Services.Task
{
	public class DeleteTaskDataService : TaskDataServiceBase, IDeleteTaskDataService
	{
		public void Execute(long taskId)
		{
			var taskToDelete = _taskDatabase.Tasks.FirstOrDefault(t => t.TaskId == taskId);
			if (taskToDelete == null) return;
			_taskDatabase.Tasks.DeleteObject(taskToDelete);
			_taskDatabase.SaveChanges();
		}
	}
}
