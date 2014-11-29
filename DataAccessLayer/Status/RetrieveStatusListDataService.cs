using System.Collections.Generic;
using System.Linq;
using ToDoApp.Data.Model;
using ToDoApp.Data.Services.Status.Interface;

namespace ToDoApp.Data.Services.Status
{
	public class RetrieveStatusListDataService : IRetrieveStatusListDataService
	{
		private readonly TaskDb _taskDatabase;

		public RetrieveStatusListDataService()
		{
			_taskDatabase = new TaskDb();
		}

		public IList<string> Execute()
		{
			return _taskDatabase.Status.OrderBy(s => s.StatusId).Select(s => s.StatusText).ToList();
		}
	}
}
