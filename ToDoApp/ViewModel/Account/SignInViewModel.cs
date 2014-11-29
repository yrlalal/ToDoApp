using System.ComponentModel.DataAnnotations;
using ToDoApp.Core;

namespace ToDoApp.UI.ViewModel.Account
{
	public class SignInViewModel
	{
		[Required]
		[EmailAddress]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "Email Address")]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }
	}
}