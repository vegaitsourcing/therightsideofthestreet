using System.Net.Mail;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms;

namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Forms
{
	public class BecomeMemberFormController : BaseSurfaceController
	{
		[ChildActionOnly]
		public ActionResult BecomeMemberForm(BecomeMemberFormViewModel model)
		{
			return PartialView(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SubmitForm(BecomeMemberFormViewModel model)
		{
			if (ModelState.IsValid)
			{
				SendEmail(model);
				return RedirectToCurrentUmbracoPage();
			}
			return CurrentUmbracoPage();
		}

		private void SendEmail(BecomeMemberFormViewModel model)
		{
			MailMessage message = new MailMessage(model.Email, "admin@admin.com")
			{
				Subject = string.Format("Enquiry from {0} {1}", model.Name, model.Surname),
				Body = string.Format(model.Name + " " + model.Surname + "\n" + model.Dob + "\n" + model.Nationality
									+ "\n" + model.Adress + "\n" + model.MblNumber + "\n" + model.Email)
			};

			SmtpClient client = new SmtpClient();
			client.Send(message);
		}
	}
}
