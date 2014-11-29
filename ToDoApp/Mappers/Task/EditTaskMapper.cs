using System;
using ToDoApp.Data.Services.Category.Interface;
using ToDoApp.Data.Services.Priority.Interface;
using ToDoApp.Data.Services.Status.Interface;
using ToDoApp.Data.Services.Task.Interfaces;
using ToDoApp.UI.Mappers.Task.Interfaces;
using ToDoApp.UI.ViewModel.Task;

namespace ToDoApp.UI.Mappers.Task
{
	public class EditTaskMapper : TaskMapperBase, IEditTaskMapper
	{
		private readonly IUpdateTaskDataService _updateTaskDataService;
		private readonly IRetrieveTaskDataService _retrieveTaskDataService;

		public EditTaskMapper(IUpdateTaskDataService updateTaskDataService, IRetrieveTaskDataService retrieveTaskDataService, IRetrieveCategoryListDataService retrieveCategoryListDataService,
			IRetrievePriorityListDataService retrievePriorityListDataService, IRetrieveStatusListDataService retrieveStatusListDataService)
			: base(retrieveCategoryListDataService, retrievePriorityListDataService, retrieveStatusListDataService)
		{
			_updateTaskDataService = updateTaskDataService;
			_retrieveTaskDataService = retrieveTaskDataService;
		}

		public TaskViewModel BuildViewModel(int id)
		{
			var taskDetail = _retrieveTaskDataService.Execute(id);
			if(taskDetail == null)
				throw new Exception(string.Format("A task with id [{0}] is not found", id));
			return new TaskViewModel
			{
				Id = taskDetail.Id,
				Description = taskDetail.Description,
				DueDate = !taskDetail.DueDate.HasValue ? string.Empty : taskDetail.DueDate.Value.ToShortDateString(),
				Category = taskDetail.Category,
				Priority = taskDetail.Priority,
				Status = taskDetail.Status,
				CategoryList = getCategoryList(),
				PriorityList = getPriorityList(),
				StatusList = getStatusList()
			};
		}

		public void MapViewModel(int id, TaskViewModel viewModel)
		{
			_updateTaskDataService.Execute(id, viewModel.Description, viewModel.DueDate, viewModel.Category, viewModel.Priority, viewModel.Status);
		}
	}
}