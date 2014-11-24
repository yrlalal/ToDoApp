using System.Collections.Generic;
using System.Linq;

namespace DataAccessServices
{
	public class StaticDataServices
	{
		private readonly TaskDb _taskDatabase;

		public StaticDataServices()
		{
			_taskDatabase = new TaskDb();
		}

		public IList<string> GetCategoryList()
		{
			return _taskDatabase.Categories.OrderBy(c => c.CategoryId).Select(c => c.CategoryText).ToList();
		}

		public IList<string> GetStatusList()
		{
			return _taskDatabase.Status.OrderBy(s => s.StatusId).Select(s => s.StatusText).ToList();
		}

		public IList<string> GetPriorityList()
		{
			return _taskDatabase.Priorities.OrderBy(p => p.PriorityId).Select(p => p.PriorityText).ToList();
		}
	}
}
