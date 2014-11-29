namespace ToDoApp.Data.Services.Account.Interfaces
{
	public interface IAddAccountDataService
	{
		bool Execute(string firstName, string lastName, string email, string password);
	}
}