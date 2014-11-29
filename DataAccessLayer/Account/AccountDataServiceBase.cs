using System.Security.Cryptography;
using System.Text;
using ToDoApp.Data.Model;

namespace ToDoApp.Data.Services.Account
{
	public abstract class AccountDataServiceBase
	{
		protected readonly TaskDb _taskDatabase;

		protected AccountDataServiceBase()
		{
			_taskDatabase = new TaskDb();
		}

		protected static string getEncodedPassword(string password)
		{
			byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
			using (var shaManaged = new SHA256Managed())
			{
				passwordBytes = shaManaged.ComputeHash(passwordBytes);
				return Encoding.ASCII.GetString(passwordBytes);
			}
		}
	}
}
