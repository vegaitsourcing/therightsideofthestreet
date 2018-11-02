using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class LoginFormController : BasePageController<LoginForm>
	{
		public ActionResult LoginForm(LoginForm model)
		{
			Members.Logout();
			return CurrentTemplate(new LoginViewModel(CreatePageContext(model)));
		}
	}
}