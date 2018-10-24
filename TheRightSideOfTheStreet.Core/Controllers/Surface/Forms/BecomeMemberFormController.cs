using System.Configuration;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Common;
using TheRightSideOfTheStreet.Core.Constants;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Forms
{
	public class BecomeMemberFormController : BaseSurfaceController
	{
		[ChildActionOnly]
		public ActionResult BecomeMemberForm()
		{
			return PartialView(new BecomeMemberFormViewModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SubmitForm(BecomeMemberFormViewModel model)
		{
			string code = AppSettings.ImageExtensions;
			if (!ModelState.IsValid)
			{
				return CurrentUmbracoPage();
			}

			Settings settings = Umbraco.GetSettings(CurrentPage.Site().Id);
			SendEmail(model, settings.AdminEmailAddress);
			TempData[Constants.Constants.TempDataSuccess] = "success";
			return CurrentUmbracoPage();
		}

		private void SendEmail(BecomeMemberFormViewModel model, string adminEmailAddress)
		{
			MailMessage message = new MailMessage
			{
				From = new MailAddress(model.Email)
			};
			
			message.To.Add(new MailAddress(adminEmailAddress ?? AppSettings.AdminEmailAdress));
			message.Subject = string.Format($"Enquiry from {model.Name} {model.Surname}");
			message.Body = string.Format(model.Name + " " + model.Surname + "\n" + model.Dob + "\n" + model.Nationality
								+ "\n" + model.Address + "\n" + model.MblNumber + "\n" + model.Email);
			message.Attachments.Add(new Attachment(model.Picture.InputStream, model.Picture.FileName, model.Picture.ContentType));

			SmtpClient client = new SmtpClient("localhost", 25);

			client.Send(message);
		}
		
	}
}
