using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ToDoApp.Core
{
	public class EmailAddressAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var email = value as string;
			if(string.IsNullOrEmpty(email) || !isValidEmail(email))
				return new ValidationResult("Please enter a valid email address.");
			return null;
		}

		private bool isValidEmail(string email)
		{
			var regex = new Regex(@"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");
			return regex.IsMatch(email);
		}
	}
}
