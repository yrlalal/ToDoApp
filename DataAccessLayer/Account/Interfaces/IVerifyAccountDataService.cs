namespace ToDoApp.Data.Services.Account.Interfaces
{
	public interface IVerifyAccountDataService
	{
		bool Execute(string email, string password);
	}
}