using ToDoApp.UI.ViewModel.Task;

namespace ToDoApp.UI.Mappers.Task.Interfaces
{
	public interface IRetrieveTaskListMapper
	{
		TaskListViewModel BuildViewModel(string email);
	}
}