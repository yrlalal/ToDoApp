using System;
using ToDoApp.Data.Services.Account.Interfaces;
using System.Linq;

namespace ToDoApp.Data.Services.Account
{
	public class AddAccountDataService : AccountDataServiceBase, IAddAccountDataService
	{
		public bool Execute(string firstName, string lastName, string email, string password)
		{
			if (_taskDatabase.Accounts.Any(account => string.Compare(account.Email, email, StringComparison.OrdinalIgnoreCase) == 0))
				return false;
			_taskDatabase.AddToAccounts(new Model.Account { FirstName = firstName, LastName = lastName, Email = email, 
				Password = getEncodedPassword(password), LastUpdateDateTime = DateTime.Now, AddDateTime = DateTime.Now });
			_taskDatabase.SaveChanges();
			return true;
		}
	}
}
