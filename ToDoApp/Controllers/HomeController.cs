using System.Web.Mvc;
using ToDoApp.Mappers;
using System.Linq;
using ToDoApp.Model;

namespace ToDoApp.Controllers
{
    public class HomeController : Controller
    {
    	private HomeIndexMapper _mapper;

		public HomeController()
		{
			_mapper = new HomeIndexMapper();
		}

		[HttpGet]
        public ActionResult Index()
        {
            return View("Index", _mapper.BuildViewModel());
        }

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(ToDoItem item)
		{
			ToDoRepository.Instance.ToDoItems.Add(item);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			var toDoItem = _mapper.BuildViewModel().ToDoItems.FirstOrDefault(item => item.Id == id);
			return View("Edit", toDoItem);
		}

		[HttpPost]
		public ActionResult Edit(int id, ToDoItem toDoItem)
		{
			var toDoItems = _mapper.BuildViewModel().ToDoItems;
			var itemToDelete = toDoItems.FirstOrDefault(item => item.Id == id);
			toDoItems.Remove(itemToDelete);
			toDoItems.Add(toDoItem);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			var toDoItems = _mapper.BuildViewModel().ToDoItems;
			var toDoItem = toDoItems.FirstOrDefault(item => item.Id == id);
			toDoItems.Remove(toDoItem);
			return RedirectToAction("Index");
		}
    }
}
