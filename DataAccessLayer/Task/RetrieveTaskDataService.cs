using System.Linq;
using ToDoApp.Data.Services.Task.Interfaces;

namespace ToDoApp.Data.Services.Task
{
	public class RetrieveTaskDataService : TaskDataServiceBase, IRetrieveTaskDataService
	{
		public TaskDetails Execute(int id)
		{
			TaskDetails taskDetails = null;
			var selectedTask = _taskDatabase.Tasks.FirstOrDefault(task => task.AccountId == id);
			if(selectedTask != null)
				taskDetails = new TaskDetails
			       		{
			       			Id = selectedTask.TaskId,
			       			Description = selectedTask.Description,
			       			DueDate = selectedTask.DueDate,
			       			LastUpdateDateTime = selectedTask.LastUpdateDateTime,
			       			AddDateTime = selectedTask.AddDateTime,
			       			Category = selectedTask.Category == null ? string.Empty : selectedTask.Category.CategoryText,
			       			Priority = selectedTask.Priority == null ? string.Empty : selectedTask.Priority.PriorityText,
			       			Status = selectedTask.Status == null ? string.Empty : selectedTask.Status.StatusText
			       		};
			return taskDetails;
		}
	}
}
