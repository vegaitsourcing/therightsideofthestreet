using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class ResetPasswordFormController :  BasePageController<ResetPasswordForm>
	{
		public ActionResult ResetPasswordForm(ResetPasswordForm model)
		{
			
			return CurrentTemplate(new ResetPasswordViewModel(CreatePageContext(model)));
		}
	}
}
