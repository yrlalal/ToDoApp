using ToDoApp.Data.Services.Task.Interfaces;
using ToDoApp.UI.Mappers.Task.Interfaces;

namespace ToDoApp.UI.Mappers.Task
{
	public class DeleteTaskMapper : IDeleteTaskMapper
	{
		private readonly IDeleteTaskDataService _deleteTaskDataService;

		public DeleteTaskMapper(IDeleteTaskDataService deleteTaskDataService)
		{
			_deleteTaskDataService = deleteTaskDataService;
		}

		public void DeleteTask(int id)
		{
			_deleteTaskDataService.Execute(id);
		}
	}
}