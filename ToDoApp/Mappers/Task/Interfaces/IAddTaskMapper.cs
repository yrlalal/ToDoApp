using ToDoApp.UI.ViewModel.Task;

namespace ToDoApp.UI.Mappers.Task.Interfaces
{
	public interface IAddTaskMapper
	{
		TaskViewModel BuildViewModel();
		void MapViewModel(TaskViewModel viewModel, string email);
	}
}