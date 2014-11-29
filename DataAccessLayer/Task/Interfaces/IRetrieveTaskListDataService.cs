using System.Collections.Generic;

namespace ToDoApp.Data.Services.Task.Interfaces
{
	public interface IRetrieveTaskListDataService
	{
		IList<TaskDetails> Execute(string email);
	}
}