using System.Web.Mvc;
using DataAccessServices;
using ToDoApp.Mappers;
using System.Linq;
using ToDoApp.Model;

namespace ToDoApp.Controllers
{
    public class TaskController : Controller
    {
    	private TaskIndexMapper _mapper;

		public TaskController()
		{
			_mapper = new TaskIndexMapper();
		}

		[HttpGet]
        public ActionResult List()
        {
            return View(_mapper.BuildViewModel());
        }

		[HttpGet]
		public ActionResult Add()
		{
			return View(new ToDoItem());
		}

		[HttpPost]
		public ActionResult Add(ToDoItem item)
		{
			string date = string.IsNullOrEmpty(item.DueDateMonth) && string.IsNullOrEmpty(item.DueDateDay) && string.IsNullOrEmpty(item.DueDateYear)
			              	? string.Empty : item.DueDateMonth + "/" + item.DueDateDay + "/" + item.DueDateYear;
			new TaskDataServices().AddTask(item.Description, date, item.Category, item.Priority, item.Status, "testId");
			return RedirectToAction("List");
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			var toDoItem = _mapper.BuildViewModel().ToDoItems.FirstOrDefault(item => item.Id == id);
			return View(toDoItem);
		}

		[HttpPost]
		public ActionResult Edit(int id, ToDoItem item)
		{
			new TaskDataServices().EditTask(id, item.Description, item.DueDateMonth + "/" + item.DueDateDay + "/" + item.DueDateYear, item.Category, item.Priority, item.Status,
			                     "testId");
			return RedirectToAction("List");
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			new TaskDataServices().DeleteTask(id);
			return RedirectToAction("List");
		}

		[HttpGet]
		public ActionResult ListByDueDate()
		{
			return View("List", _mapper.BuildViewModelByDueDate());
		}
    }
}
