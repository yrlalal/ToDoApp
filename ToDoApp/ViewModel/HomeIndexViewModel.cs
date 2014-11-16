using System.Collections.Generic;
using ToDoApp.Model;

namespace ToDoApp.ViewModel
{
	public class HomeIndexViewModel
	{
		private IList<ToDoItem> _toDoItems;

		public IList<ToDoItem> ToDoItems
		{
			get { return _toDoItems ?? (_toDoItems = new List<ToDoItem>()); }
			set { _toDoItems = value; }
		}
	}
}