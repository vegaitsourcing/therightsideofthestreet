using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Models;
using Umbraco.Core;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class LoginViewModel : PageViewModel
	{
		public LoginViewModel(IPageContext<LoginForm> context) : base(context)
		{
			ForgottenPassword = context.ForgottenPassword.Url;
			ResetPassword = context.ResetPassword.Url;
			RegisterForm = context.AthleteForm.Url;
			CurrentPageAlias = context.CurrentPage.DocumentTypeAlias;
		}

		public string ForgottenPassword { get; }
		public string ResetPassword { get; }
		public string RegisterForm { get; }
		public string CurrentPageAlias { get; }
		public string ExerciseGroupAlias => nameof(ExerciseGroupViewModel).RemoveViewModelSuffix().ToFirstLower();
	}
}
