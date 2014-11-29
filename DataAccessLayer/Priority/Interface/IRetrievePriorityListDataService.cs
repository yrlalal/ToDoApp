using System.Collections.Generic;

namespace ToDoApp.Data.Services.Priority.Interface
{
	public interface IRetrievePriorityListDataService
	{
		IList<string> Execute();
	}
}
