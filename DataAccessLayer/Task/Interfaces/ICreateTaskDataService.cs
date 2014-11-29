namespace ToDoApp.Data.Services.Task.Interfaces
{
	public interface ICreateTaskDataService
	{
		void Execute(string taskDescription, string dueDate, string category, string priority, string status, string email);
	}
}