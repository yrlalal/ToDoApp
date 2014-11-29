using ToDoApp.UI.ViewModel.Account;

namespace ToDoApp.UI.Mappers.Account.Interfaces
{
	public interface IRegisterAccountMapper
	{
		RegisterViewModel BuildViewModel();
		bool RegisterAccount(RegisterViewModel viewModel);
	}
}