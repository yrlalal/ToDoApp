using System;
using System.Linq;
using ToDoApp.Data.Services.Account.Interfaces;

namespace ToDoApp.Data.Services.Account
{
	public class VerifyAccountDataService : AccountDataServiceBase, IVerifyAccountDataService
	{
		public bool Execute(string email, string password)
		{
			string encodedPassword = getEncodedPassword(password);
			return _taskDatabase.Accounts.Any(account => string.Compare(account.Email, email, StringComparison.OrdinalIgnoreCase) == 0 && account.Password == encodedPassword);
		}
	}
}
