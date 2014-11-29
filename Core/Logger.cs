using System;
using System.Diagnostics;
using ToDoApp.Core.Interface;

namespace ToDoApp.Core
{
	public class Logger : ILogger
	{
		public void Log(Exception exception)
		{
			var log = new EventLog();
			log.Source = "Application";
			string message = string.Format("Message: {0} \r\n Stack Trace: {1} \r\n Inner Exception Message: {2} \r\n Inner Exception Stack Trace: {3}", 
											exception.Message,
											exception.StackTrace,
											exception.InnerException == null ? string.Empty : exception.InnerException.Message,
											exception.InnerException == null ? string.Empty : exception.InnerException.StackTrace);
			log.WriteEntry(message, EventLogEntryType.Error);
		}
	}
}
