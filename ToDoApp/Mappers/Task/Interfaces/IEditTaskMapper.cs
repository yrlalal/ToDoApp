using ToDoApp.UI.ViewModel.Task;

namespace ToDoApp.UI.Mappers.Task.Interfaces
{
	public interface IEditTaskMapper
	{
		TaskViewModel BuildViewModel(int id);
		void MapViewModel(int id, TaskViewModel viewModel);
	}
}