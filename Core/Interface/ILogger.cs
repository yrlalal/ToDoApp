using System;

namespace ToDoApp.Core.Interface
{
	public interface ILogger
	{
		void Log(Exception exception);
	}
}
