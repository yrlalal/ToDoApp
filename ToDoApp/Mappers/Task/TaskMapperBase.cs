using System.Collections.Generic;
using System.Web.Mvc;
using ToDoApp.Data.Services.Category.Interface;
using ToDoApp.Data.Services.Priority.Interface;
using ToDoApp.Data.Services.Status.Interface;

namespace ToDoApp.UI.Mappers.Task
{
	public abstract class TaskMapperBase
	{
		private readonly IRetrieveCategoryListDataService _retrieveCategoryListDataService;
		private readonly IRetrievePriorityListDataService _retrievePriorityListDataService;
		private readonly IRetrieveStatusListDataService _retrieveStatusListDataService;

		protected TaskMapperBase(IRetrieveCategoryListDataService retrieveCategoryListDataService, IRetrievePriorityListDataService retrievePriorityListDataService,
			IRetrieveStatusListDataService retrieveStatusListDataService)
		{
			_retrieveCategoryListDataService = retrieveCategoryListDataService;
			_retrievePriorityListDataService = retrievePriorityListDataService;
			_retrieveStatusListDataService = retrieveStatusListDataService;
		}

		protected IEnumerable<SelectListItem> getCategoryList()
		{
			IList<SelectListItem> selectListItems = new List<SelectListItem>();
			selectListItems.Add(new SelectListItem { Text = string.Empty, Value = string.Empty });
			foreach (var category in _retrieveCategoryListDataService.Execute())
			{
				selectListItems.Add(new SelectListItem { Text = category, Value = category });
			}
			return selectListItems;
		}

		protected IEnumerable<SelectListItem> getStatusList()
		{
			IList<SelectListItem> selectListItems = new List<SelectListItem>();
			selectListItems.Add(new SelectListItem {Text = string.Empty, Value = string.Empty});
			foreach (var status in _retrieveStatusListDataService.Execute())
			{
				selectListItems.Add(new SelectListItem {Text = status, Value = status});
			}
			return selectListItems;
		}

		protected IEnumerable<SelectListItem> getPriorityList()
		{
			IList<SelectListItem> selectListItems = new List<SelectListItem>();
			selectListItems.Add(new SelectListItem {Text = string.Empty, Value = string.Empty});
			foreach (var priority in _retrievePriorityListDataService.Execute())
			{
				selectListItems.Add(new SelectListItem {Text = priority, Value = priority});
			}
			return selectListItems;
		}
	}
}