using System.Web.Mvc;
using ToDoApp.UI.Mappers.Task.Interfaces;
using ToDoApp.UI.ViewModel.Task;

namespace ToDoApp.UI.Controllers
{
    public class TaskController : Controller
    {
		private readonly IAddTaskMapper _addTaskMapper;
		private readonly IRetrieveTaskListMapper _retrieveTaskListMapper;
    	private readonly IEditTaskMapper _editTaskMapper;
    	private readonly IDeleteTaskMapper _deleteTaskMapper;

		public TaskController(IAddTaskMapper addTaskMapper, IRetrieveTaskListMapper retrieveTaskListMapper, IEditTaskMapper editTaskMapper, IDeleteTaskMapper deleteTaskMapper)
		{
			_addTaskMapper = addTaskMapper;
			_retrieveTaskListMapper = retrieveTaskListMapper;
			_editTaskMapper = editTaskMapper;
			_deleteTaskMapper = deleteTaskMapper;
		}

		[HttpGet]
        public ActionResult List()
        {
            return View(_retrieveTaskListMapper.BuildViewModel(HttpContext.User.Identity.Name));
        }

		[HttpGet]
		public ActionResult Add()
		{
			return View(_addTaskMapper.BuildViewModel());
		}

		[HttpPost]
		public ActionResult Add(TaskViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				_addTaskMapper.MapViewModel(viewModel, HttpContext.User.Identity.Name);
				return RedirectToAction("List");
			}
			return View(viewModel);
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			return View(_editTaskMapper.BuildViewModel(id));
		}

		[HttpPost]
		public ActionResult Edit(int id, TaskViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				_editTaskMapper.MapViewModel(id, viewModel);
				return RedirectToAction("List");
			}
			return View(viewModel);
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			_deleteTaskMapper.DeleteTask(id);
			return RedirectToAction("List");
		}

		[HttpGet]
		public JsonResult ListDetails()
		{
			return Json(_retrieveTaskListMapper.BuildViewModel(HttpContext.User.Identity.Name), JsonRequestBehavior.AllowGet);
		}
    }
}
