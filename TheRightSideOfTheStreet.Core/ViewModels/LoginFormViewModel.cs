using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class LoginViewModel : PageViewModel
	{
		public LoginViewModel(IPageContext<LoginForm> context) : base(context)
		{
			ForgottenPassword = context.ForgottenPassword.Url;
			ResetPassword = context.ResetPassword.Url;
			RegisterForm = context.AthleteForm.Url;

		}

		public string ForgottenPassword { get; }
		public string ResetPassword { get; }
		public string RegisterForm { get; }
	}
}
