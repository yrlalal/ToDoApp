using System.Web.Mvc;
using System.Web.Security;
using ToDoApp.UI.Mappers.Account.Interfaces;
using ToDoApp.UI.ViewModel.Account;

namespace ToDoApp.UI.Controllers
{
    public class AccountController : Controller
    {
    	private readonly IRegisterAccountMapper _registerAccountMapper;
    	private readonly ISignInAccountMapper _signInAccountMapper;

		public AccountController(IRegisterAccountMapper registerAccountMapper, ISignInAccountMapper signInAccountMapper)
		{
			_registerAccountMapper = registerAccountMapper;
			_signInAccountMapper = signInAccountMapper;
		}

		[HttpGet]
		[AllowAnonymous]
        public ActionResult Register()
		{
			return View(_registerAccountMapper.BuildViewModel());
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult Register(RegisterViewModel viewModel)
		{
			if (!ModelState.IsValid)
				return View(viewModel);
			if (!_registerAccountMapper.RegisterAccount(viewModel))
			{
				ModelState.AddModelError("AccountExistsError", "An account already exists for the email you entered.");
				return View(viewModel);
			}
			FormsAuthentication.SetAuthCookie(viewModel.Email, false);
			return RedirectToAction("List", "Task");
		}

    	[HttpGet]
		[AllowAnonymous]
		public ActionResult SignIn(string returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			return View(_signInAccountMapper.BuildViewModel());
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult SignIn(SignInViewModel viewModel, string returnUrl)
		{
			if (!ModelState.IsValid)
				return View(viewModel);
			if(!_signInAccountMapper.SignIn(viewModel))
			{
				ModelState.AddModelError("AccountNotFound", "The email or password you entered is incorrect.");
				return View(viewModel);
			}
			FormsAuthentication.SetAuthCookie(viewModel.Email, false);
			return redirectToLocal(returnUrl);
		}

    	[HttpGet]
		public void SignOut()
		{
			FormsAuthentication.SignOut();
			FormsAuthentication.RedirectToLoginPage();
		}

		private ActionResult redirectToLocal(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			return RedirectToAction("List", "Task");
		}
    }
}
