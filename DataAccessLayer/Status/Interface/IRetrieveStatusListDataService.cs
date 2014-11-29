using System.Collections.Generic;

namespace ToDoApp.Data.Services.Status.Interface
{
	public interface IRetrieveStatusListDataService
	{
		IList<string> Execute();
	}
}
