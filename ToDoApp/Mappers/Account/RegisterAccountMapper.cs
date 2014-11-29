using ToDoApp.Data.Services.Account.Interfaces;
using ToDoApp.UI.Mappers.Account.Interfaces;
using ToDoApp.UI.ViewModel.Account;

namespace ToDoApp.UI.Mappers.Account
{
	public class RegisterAccountMapper : IRegisterAccountMapper
	{
		private readonly IAddAccountDataService _addAccountDataService;

		public RegisterAccountMapper(IAddAccountDataService addAccountDataService)
		{
			_addAccountDataService = addAccountDataService;
		}

		public RegisterViewModel BuildViewModel()
		{
			return new RegisterViewModel();
		}

		public bool RegisterAccount(RegisterViewModel viewModel)
		{
			return _addAccountDataService.Execute(viewModel.FirstName, viewModel.LastName, viewModel.Email, viewModel.Password);
		}
	}
}