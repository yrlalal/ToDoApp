using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessServices.Interfaces;

namespace DataAccessServices
{
	public class TaskDataServices : ITaskDataServices
	{
		private readonly TaskDb _taskDatabase;

		public TaskDataServices()
		{
			_taskDatabase = new TaskDb();
		}

		public IList<TaskDetails> GetTasks(string userId)
		{
			long credentialsId = getCredentialsId(userId);
			var tasks = _taskDatabase.Tasks.Where(c => c.CredentialsId == credentialsId).ToList();
			return tasks.Select(task => new TaskDetails
			                            	{
												Id = task.TaskId,
												Description = task.Description,
												DueDate = task.DueDate,
												LastUpdateDateTime = task.LastUpdateDateTime,
												AddDateTime = task.AddDateTime,
												Category = task.Category == null ? string.Empty : task.Category.CategoryText,
												Priority = task.Priority == null ? string.Empty : task.Priority.PriorityText,
												Status = task.Status == null ? string.Empty : task.Status.StatusText
			                            	}).ToList();
		}

		public void AddTask(string taskDescription, string dueDate, string category, string priority, string status, string userId)
		{
			var currentDateTime = DateTime.Now;
			var credentialsId = getCredentialsId(userId);
			_taskDatabase.AddToTasks(new Task { Description = taskDescription, 
												CategoryId = getCategoryId(category),
												StatusId = getStatusId(status),
												PriorityId = getPriorityId(priority),
												CredentialsId = credentialsId,
												DueDate = convertToDateTime(dueDate),
												LastUpdateDateTime = currentDateTime,
												AddDateTime = currentDateTime,
			});
			_taskDatabase.SaveChanges();
		}

		public void EditTask(long taskId, string taskDescription, string dueDate, string category, string priority, string status, string userId)
		{
			Task taskToEdit = _taskDatabase.Tasks.FirstOrDefault(t => t.TaskId == taskId);
			if (taskToEdit != null)
			{
				taskToEdit.Description = taskDescription;
				taskToEdit.DueDate = convertToDateTime(dueDate);
				taskToEdit.CategoryId = getCategoryId(category);
				taskToEdit.PriorityId = getPriorityId(priority);
				taskToEdit.StatusId = getStatusId(status);
				_taskDatabase.SaveChanges();
			}
		}

		public void DeleteTask(long taskId)
		{
			Task taskToDelete = _taskDatabase.Tasks.FirstOrDefault(t => t.TaskId == taskId);
			if (taskToDelete != null)
			{
				_taskDatabase.Tasks.DeleteObject(taskToDelete);
				_taskDatabase.SaveChanges();
			}
		}

		private long getCredentialsId(string userId)
		{
			long credentialsId = _taskDatabase.Credentials.Where(c => string.Compare(c.UserId, userId, StringComparison.OrdinalIgnoreCase) == 0)
									.Select(c => c.CredentialsId).FirstOrDefault();
			if (credentialsId == 0)
				throw new Exception(string.Format("UserId not found - {0}", userId));
			return credentialsId;
		}

		private short? getCategoryId(string category)
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

		private short? getStatusId(string status)
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

		private short? getPriorityId(string priority)
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

		private DateTime? convertToDateTime(string date)
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
