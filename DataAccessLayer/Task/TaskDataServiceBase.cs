using System;
using System.Linq;
using ToDoApp.Data.Model;

namespace ToDoApp.Data.Services.Task
{
	public class TaskDataServiceBase
	{
		protected readonly TaskDb _taskDatabase;

		protected TaskDataServiceBase()
		{
			_taskDatabase = new TaskDb();
		}

		protected long getAccountId(string email)
		{
			long accountId = _taskDatabase.Accounts.Where(c => string.Compare(c.Email, email, StringComparison.OrdinalIgnoreCase) == 0)
									.Select(c => c.AccountId).FirstOrDefault();
			if (accountId == 0)
				throw new Exception(string.Format("Email not found - {0}", email));
			return accountId;
		}

		protected short? getCategoryId(string category)
		{
			short? categoryId = null;
			if (!string.IsNullOrEmpty(category))
			{
				short id = _taskDatabase.Categories.Where(c => string.Compare(c.CategoryText, category, StringComparison.OrdinalIgnoreCase) == 0)
								.Select(c => c.CategoryId).FirstOrDefault();
				if (id == 0)
					throw new Exception(string.Format("Category not found - {0}", category));
				categoryId = id;
			}
			return categoryId;
		}

		protected short? getStatusId(string status)
		{
			short? statusId = null;
			if (!string.IsNullOrEmpty(status))
			{
				short id = _taskDatabase.Status.Where(s => string.Compare(s.StatusText, status, StringComparison.OrdinalIgnoreCase) == 0)
								.Select(s => s.StatusId).FirstOrDefault();
				if (id == 0)
					throw new Exception(string.Format("Status not found - {0}", status));
				statusId = id;
			}
			return statusId;
		}

		protected short? getPriorityId(string priority)
		{
			short? priorityId = null;
			if (!string.IsNullOrEmpty(priority))
			{
				short id = _taskDatabase.Priorities.Where(p => string.Compare(p.PriorityText, priority, StringComparison.OrdinalIgnoreCase) == 0)
								.Select(p => p.PriorityId).FirstOrDefault();
				if (id == 0)
					throw new Exception(string.Format("Priority not found - {0}", priority));
				priorityId = id;
			}
			return priorityId;
		}

		protected DateTime? convertToDateTime(string date)
		{
			DateTime? nullableDateTime = null;
			if (!string.IsNullOrEmpty(date))
			{
				DateTime dateTime;
				if (!DateTime.TryParse(date, out dateTime))
					throw new Exception(string.Format("Invalid format for input date - {0}", date));
				nullableDateTime = dateTime;
			}
			return nullableDateTime;
		}
	}
}
