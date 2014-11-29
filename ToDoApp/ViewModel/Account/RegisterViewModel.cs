using System.ComponentModel.DataAnnotations;
using ToDoApp.Core;

namespace ToDoApp.UI.ViewModel.Account
{
	public class RegisterViewModel
	{
		[Required]
		[StringLength(50)]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Required]
		[StringLength(50)]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Required]
		[EmailAddress]
		[StringLength(100)]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "Email Address")]
		public string Email { get; set; }

		[Required]
		[StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }
	}
}
