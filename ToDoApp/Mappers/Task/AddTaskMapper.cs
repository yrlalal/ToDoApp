using ToDoApp.Data.Services.Category.Interface;
using ToDoApp.Data.Services.Priority.Interface;
using ToDoApp.Data.Services.Status.Interface;
using ToDoApp.Data.Services.Task.Interfaces;
using ToDoApp.UI.Mappers.Task.Interfaces;
using ToDoApp.UI.ViewModel.Task;

namespace ToDoApp.UI.Mappers.Task
{
	public class AddTaskMapper : TaskMapperBase, IAddTaskMapper
	{
		private readonly ICreateTaskDataService _createTaskDataService;

		public AddTaskMapper(ICreateTaskDataService createTaskDataService, IRetrieveCategoryListDataService retrieveCategoryListDataService, 
			IRetrievePriorityListDataService retrievePriorityListDataService, IRetrieveStatusListDataService retrieveStatusListDataService) 
			: base(retrieveCategoryListDataService, retrievePriorityListDataService, retrieveStatusListDataService)
		{
			_createTaskDataService = createTaskDataService;
		}

		public TaskViewModel BuildViewModel()
		{
			return new TaskViewModel
									{
										CategoryList = getCategoryList(),
										PriorityList = getPriorityList(),
										StatusList = getStatusList()
									};
		}

		public void MapViewModel(TaskViewModel viewModel, string email)
		{
			_createTaskDataService.Execute(viewModel.Description, viewModel.DueDate, viewModel.Category, viewModel.Priority, viewModel.Status, email);
		}
	}
}