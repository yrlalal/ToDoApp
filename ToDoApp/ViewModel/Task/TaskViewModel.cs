using System.Collections.Generic;
using System.Web.Mvc;

namespace ToDoApp.UI.ViewModel.Task
{
	public class TaskViewModel : TaskModel
	{
		public IEnumerable<SelectListItem> CategoryList { get; set; }
		public IEnumerable<SelectListItem> StatusList { get; set; }
		public IEnumerable<SelectListItem> PriorityList { get; set; }
	}
}