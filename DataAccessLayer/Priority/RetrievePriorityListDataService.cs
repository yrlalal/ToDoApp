using System.Collections.Generic;
using System.Linq;
using ToDoApp.Data.Model;
using ToDoApp.Data.Services.Priority.Interface;

namespace ToDoApp.Data.Services.Priority
{
	public class RetrievePriorityListDataService : IRetrievePriorityListDataService
	{
		private readonly TaskDb _taskDatabase;

		public RetrievePriorityListDataService()
		{
			_taskDatabase = new TaskDb();
		}

		public IList<string> Execute()
		{
			return _taskDatabase.Priorities.OrderBy(p => p.PriorityId).Select(p => p.PriorityText).ToList();
		}
	}
}
