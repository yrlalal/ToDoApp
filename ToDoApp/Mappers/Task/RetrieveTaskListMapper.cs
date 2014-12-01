using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApp.Data.Services.Task;
using ToDoApp.Data.Services.Task.Interfaces;
using ToDoApp.UI.Mappers.Task.Interfaces;
using ToDoApp.UI.ViewModel.Task;

namespace ToDoApp.UI.Mappers.Task
{
	public class RetrieveTaskListMapper : IRetrieveTaskListMapper
	{
		private readonly IRetrieveTaskListDataService _retrieveTaskListDataService;

		public RetrieveTaskListMapper(IRetrieveTaskListDataService retrieveTaskListDataService)
		{
			_retrieveTaskListDataService = retrieveTaskListDataService;
		}

		public TaskListViewModel BuildViewModel(string email)
		{
			return new TaskListViewModel {TaskList = buildTaskList(email)};
		}

		private IList<TaskModel> buildTaskList(string email)
		{
			IList<TaskDetails> taskDetails = _retrieveTaskListDataService.Execute(email);
			return taskDetails.Select(taskDetail => new TaskModel
			{
				Id = taskDetail.Id,
				Description = taskDetail.Description,
				DueDate = getDueDateAsString(taskDetail.DueDate),
				Category = taskDetail.Category,
				Priority = taskDetail.Priority,
				Status = taskDetail.Status,
				DueDateDisplayString = getDueDateDisplayString(getDueDateAsString(taskDetail.DueDate)),
				IsDueToday = isDueToday(getDueDateAsString(taskDetail.DueDate)),
				CategoryId = taskDetail.CategoryId,
				PriorityId = taskDetail.PriorityId,
				StatusId = taskDetail.StatusId
			}).ToList();
		}

		private string getDueDateAsString(DateTime? dueDate)
		{
			return !dueDate.HasValue ? string.Empty : dueDate.Value.ToShortDateString();
		}

		private string getDueDateDisplayString(string dueDate)
		{
			string dueDateDisplayString = dueDate;
			if (isDueToday(dueDate))
				dueDateDisplayString = "Today";
			else if (isDueTomorrow(dueDate))
				dueDateDisplayString = "Tomorrow";
			return dueDateDisplayString;
		}

		private bool isDueToday(string dueDate)
		{
			return dueDate == DateTime.Today.ToShortDateString();
		}

		private bool isDueTomorrow(string dueDate)
		{
			return dueDate == DateTime.Today.AddDays(1).ToShortDateString();
		}
	}
}