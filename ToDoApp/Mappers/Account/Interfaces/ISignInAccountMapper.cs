using ToDoApp.UI.ViewModel.Account;

namespace ToDoApp.UI.Mappers.Account.Interfaces
{
	public interface ISignInAccountMapper
	{
		SignInViewModel BuildViewModel();
		bool SignIn(SignInViewModel viewModel);
	}
}