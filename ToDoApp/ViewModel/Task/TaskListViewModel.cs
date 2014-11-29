using System.Collections.Generic;

namespace ToDoApp.UI.ViewModel.Task
{
	public class TaskListViewModel
	{
		private IList<TaskModel> _taskList;

		public IList<TaskModel> TaskList
		{
			get { return _taskList ?? (_taskList = new List<TaskModel>()); }
			set { _taskList = value; }
		}
	}
}