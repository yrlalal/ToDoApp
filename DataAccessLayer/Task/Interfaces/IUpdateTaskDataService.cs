namespace ToDoApp.Data.Services.Task.Interfaces
{
	public interface IUpdateTaskDataService
	{
		void Execute(long taskId, string taskDescription, string dueDate, string category, string priority, string status);
	}
}