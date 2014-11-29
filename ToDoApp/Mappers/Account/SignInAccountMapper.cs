using ToDoApp.Data.Services.Account.Interfaces;
using ToDoApp.UI.Mappers.Account.Interfaces;
using ToDoApp.UI.ViewModel.Account;

namespace ToDoApp.UI.Mappers.Account
{
	public class SignInAccountMapper : ISignInAccountMapper
	{
		private readonly IVerifyAccountDataService _verifyAccountDataService;

		public SignInAccountMapper(IVerifyAccountDataService verifyAccountDataService)
		{
			_verifyAccountDataService = verifyAccountDataService;
		}

		public SignInViewModel BuildViewModel()
		{
			return new SignInViewModel();
		}

		public bool SignIn(SignInViewModel viewModel)
		{
			return _verifyAccountDataService.Execute(viewModel.Email, viewModel.Password);
		}
	}
}