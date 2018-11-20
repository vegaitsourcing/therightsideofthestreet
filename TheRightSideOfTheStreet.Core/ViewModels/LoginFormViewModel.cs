using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class LoginViewModel : PageViewModel
	{
		public LoginViewModel(IPageContext<LoginForm> context) : base(context)
		{
			ResetPassword = context.ResetPassword.Url;
			RegisterForm = context.AthleteForm.Url;
		}

		public string ResetPassword { get; }
		public string RegisterForm { get; }
	}
}
