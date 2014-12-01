using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using ToDoApp.Core.Interface;
using ToDoApp.UI.Controllers;
using ToDoApp.UI.Mappers.Task.Interfaces;

namespace ToDoApp.UI.Tests.Controllers
{
	[TestClass]
	public class TaskControllerTests
	{
		private IAddTaskMapper _addTaskMapper;
		private IRetrieveTaskListMapper _retrieveTaskListMapper;
		private IEditTaskMapper _editTaskMapper;
		private IDeleteTaskMapper _deleteTaskMapper;
		private IHttpContextWrapper _httpContextWrapper;
		private TaskController _taskController;

		[TestInitialize]
		public void TestInitialize()
		{
			_addTaskMapper = MockRepository.GenerateStrictMock<IAddTaskMapper>();
			_retrieveTaskListMapper = MockRepository.GenerateStrictMock<IRetrieveTaskListMapper>();
			_editTaskMapper = MockRepository.GenerateStrictMock<IEditTaskMapper>();
			_deleteTaskMapper = MockRepository.GenerateStrictMock<IDeleteTaskMapper>();
			_httpContextWrapper = MockRepository.GenerateStrictMock<IHttpContextWrapper>();
			_taskController = new TaskController(_addTaskMapper, _retrieveTaskListMapper, _editTaskMapper, _deleteTaskMapper, _httpContextWrapper);
		}

		[TestCleanup]
		public void TestCleanup()
		{
			_addTaskMapper.VerifyAllExpectations();
			_retrieveTaskListMapper.VerifyAllExpectations();
			_editTaskMapper.VerifyAllExpectations();
			_deleteTaskMapper.VerifyAllExpectations();
			_httpContextWrapper.VerifyAllExpectations();
		}

		[TestMethod]
		public void List_OnGet_Success_Test()
		{
			const string email = "test@email.com";
			_httpContextWrapper.Expect(w => w.UserName).Return(email);
			_retrieveTaskListMapper.Expect(mapper => mapper.BuildViewModel(email));
			var result = _taskController.List() as ViewResult;
			Assert.AreEqual("List", result.ViewName);
		}

		[TestMethod]
		public void Add_OnGet_Success_Test()
		{
			_addTaskMapper.Expect(mapper => mapper.BuildViewModel());
			var result = _taskController.Add() as ViewResult;
			Assert.AreEqual("Add", result.ViewName);
		}
	}
}
