using System.Collections.Generic;
using System.Linq;
using ToDoApp.Data.Model;
using ToDoApp.Data.Services.Category.Interface;

namespace ToDoApp.Data.Services.Category
{
	public class RetrieveCategoryListDataService : IRetrieveCategoryListDataService
	{
		private readonly TaskDb _taskDatabase;

		public RetrieveCategoryListDataService()
		{
			_taskDatabase = new TaskDb();
		}

		public IList<string> Execute()
		{
			return _taskDatabase.Categories.OrderBy(c => c.CategoryId).Select(c => c.CategoryText).ToList();
		}
	}
}
