using System.ComponentModel.DataAnnotations;

namespace ToDoApp.UI.ViewModel.Task
{
	public class TaskModel
	{
		public long Id { get; set; }
		[Required]
		[StringLength(100)]
		public string Description { get; set; }
		public string Priority { get; set; }
		public string Category { get; set; }
		public string Status { get; set; }
		public string DueDate { get; set; }
		[Display(Name = "Due Date")]
		public string DueDateDisplayString { get; set; }
		public bool IsDueToday { get; set; }
		public short? CategoryId;
		public short? PriorityId;
		public short? StatusId;
	}
}