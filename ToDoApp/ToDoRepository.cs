using System.Collections.Generic;
using ToDoApp.Model;

namespace ToDoApp
{
	public class ToDoRepository
	{
		private static ToDoRepository _repository;
		private IList<ToDoItem> _toDoItems;

		private ToDoRepository()
		{
			ToDoItems.Add(new ToDoItem { Id = 1, Description = "Buy Milk", Category = "Groceries", DueDate = "11/20/2014", Priority = Priority.Medium, Status = Status.NotStarted });
			ToDoItems.Add(new ToDoItem { Id = 2, Description = "Buy Eggs", Category = "Groceries", DueDate = "11/20/2014", Priority = Priority.Medium, Status = Status.NotStarted });
			ToDoItems.Add(new ToDoItem { Id = 3, Description = "Buy Vegetables", Category = "Groceries", DueDate = "11/20/2014", Priority = Priority.Medium, Status = Status.NotStarted });
		}

		public static ToDoRepository Instance
		{
			get { return _repository ?? (_repository = new ToDoRepository()); }
			set { _repository = value; }
		}

		public IList<ToDoItem> ToDoItems
		{
			get { return _toDoItems ?? (_toDoItems = new List<ToDoItem>()); }
			set { _toDoItems = value; }
		}
	}
}