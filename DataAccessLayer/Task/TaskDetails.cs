using System;

namespace ToDoApp.Data.Services.Task
{
	public class TaskDetails
	{
		public long Id { get; set; }
		public string Description { get; set; }
		public DateTime? DueDate { get; set; }
		public string Category { get; set; }
		public string Status { get; set; }
		public string Priority { get; set; }
		public DateTime LastUpdateDateTime { get; set; }
		public DateTime AddDateTime { get; set; }
		public short? CategoryId;
		public short? PriorityId;
		public short? StatusId;
	}
}
