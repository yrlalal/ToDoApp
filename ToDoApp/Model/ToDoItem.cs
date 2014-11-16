using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Model
{
	public class ToDoItem
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public Priority Priority { get; set; }

		[Display(Name = "Due Date")]
		public string DueDate { get; set; }
		public string Category { get; set; }
		public Status Status { get; set; }
	}

	public enum Priority { Low, Medium, High, Urgent }
	public enum Status { NotStarted, InProcess, Complete }
}