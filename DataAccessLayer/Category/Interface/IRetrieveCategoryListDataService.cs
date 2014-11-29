using System.Collections.Generic;

namespace ToDoApp.Data.Services.Category.Interface
{
	public interface IRetrieveCategoryListDataService
	{
		IList<string> Execute();
	}
}
