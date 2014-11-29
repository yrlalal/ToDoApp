namespace ToDoApp.Data.Services.Task.Interfaces
{
	public interface IDeleteTaskDataService
	{
		void Execute(long taskId);
	}
}