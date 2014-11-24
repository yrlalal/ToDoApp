using System.Collections.Generic;

namespace DataAccessServices.Interfaces
{
	public interface ITaskDataServices
	{
		IList<TaskDetails> GetTasks(string userId);
		void AddTask(string taskDescription, string dueDate, string category, string priority, string status, string userId);
		void DeleteTask(long taskId);
	}
}