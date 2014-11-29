namespace ToDoApp.Data.Services.Task.Interfaces
{
	public interface IRetrieveTaskDataService
	{
		TaskDetails Execute(int id);
	}
}