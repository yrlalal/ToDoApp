using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DataAccessServices;
using DataAccessServices.Interfaces;
using ToDoApp.Model;
using ToDoApp.ViewModel;

namespace ToDoApp.Mappers
{
	public class TaskIndexMapper
	{
		private ITaskDataServices _taskServices;

		public TaskIndexMapper(ITaskDataServices services)
		{
			_taskServices = services;
		}

		public TaskIndexMapper() : this(new TaskDataServices())
		{
		}

		public TaskListViewModel BuildViewModel()
		{
			var viewModel = new TaskListViewModel();
			IList<TaskDetails> taskDetails = _taskServices.GetTasks("testId");
			viewModel.ToDoItems = buildToDoItems(taskDetails);
			return viewModel;
		}

		public TaskListViewModel BuildViewModelByDueDate()
		{
			var viewModel = new TaskListViewModel();
			IList<TaskDetails> taskDetails = _taskServices.GetTasks("testId").OrderBy(task => task.DueDate).ToList();
			viewModel.ToDoItems = buildToDoItems(taskDetails);
			return viewModel;
		}

		private IList<ToDoItem> buildToDoItems(IEnumerable<TaskDetails> taskDetails)
		{
			return taskDetails.Select(taskDetail => new ToDoItem
			{
				Category = taskDetail.Category,
				Description = taskDetail.Description,
				DueDateMonth = !taskDetail.DueDate.HasValue ? string.Empty : taskDetail.DueDate.Value.ToShortDateString().Split('/')[0],
				DueDateDay = !taskDetail.DueDate.HasValue ? string.Empty : taskDetail.DueDate.Value.ToShortDateString().Split('/')[1],
				DueDateYear = !taskDetail.DueDate.HasValue ? string.Empty : taskDetail.DueDate.Value.ToShortDateString().Split('/')[2],
				Id = taskDetail.Id,
				Priority = taskDetail.Priority,
				Status = taskDetail.Status
			}).ToList();
		}
	}
}