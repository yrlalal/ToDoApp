using ToDoApp.ViewModel;

namespace ToDoApp.Mappers
{
	public class HomeIndexMapper
	{
		public HomeIndexViewModel BuildViewModel()
		{
			var viewModel = new HomeIndexViewModel();
			viewModel.ToDoItems = ToDoRepository.Instance.ToDoItems;
			return viewModel;
		}
	}
}