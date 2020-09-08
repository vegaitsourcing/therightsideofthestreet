using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Common;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;

namespace TheRightSideOfTheStreet.Core.EmailSender
{
	public class EmailHandler
	{

		public bool ExerciseGroupRequest(string emailFrom, string fullName, string adminEmailAddress)
		{
			if (string.IsNullOrEmpty(adminEmailAddress)) adminEmailAddress = AppSettings.AdminEmailAdress;

			StringBuilder subject = new StringBuilder();
			subject.Append("Zahtev za snimanje spota - ");
			subject.Append(fullName);

			StringBuilder body = new StringBuilder();
			body.AppendLine($"Ime i prezime: {fullName}");
			body.AppendLine($"E-mail: {emailFrom}");

			string senderEmail = emailFrom;

			return SendEmail(senderEmail, subject.ToString(), MvcHtmlString.Create(body.ToString().Replace("\n", "<br/>")).ToString(), adminEmailAddress, null);
		}

		public bool BlogComment(string emailFrom, string fullName, string adminEmailAddress, string blogLink)
		{
			StringBuilder subject = new StringBuilder();
			subject.Append("Komentar za odobrenje poslao: - ");
			subject.Append(fullName);

			StringBuilder body = new StringBuilder();
			body.AppendLine("Komentar koji ceka odobrenje se nalazi na sledecem linku:");
			body.AppendLine($"Blog Comment Link: <a href='{blogLink}'>{fullName}</a>");

			string senderEmial = emailFrom;

			return SendEmail(senderEmial, subject.ToString(), MvcHtmlString.Create(body.ToString().Replace("\n", "<br/>")).ToString(), adminEmailAddress, null);


		}

		public bool TrySendRegistrationMail(IMember athlete, string adminEmailAddress)
		{
			if (string.IsNullOrEmpty(adminEmailAddress)) adminEmailAddress = AppSettings.AdminEmailAdress;

			StringBuilder subject = new StringBuilder();
			subject.Append($"Registracija odobrena {athlete.Name}");
			StringBuilder body = new StringBuilder();
			body.AppendLine($"Vasa registracija je odobrena. Mozete se ulogovati sa vasim novim nalogom.");
			body.Append(Environment.NewLine);
			body.AppendLine($"Pozdrav,");
			body.Append(Environment.NewLine);
			body.AppendLine($"Prava Strana Ulice admin tim.");
			string recieverEmail = athlete.Email;

			return SendEmail(adminEmailAddress, subject.ToString(), MvcHtmlString.Create(body.ToString().Replace("\n", "<br/>")).ToString(), recieverEmail, null);
		}

		public bool WorkoutParksRequest(WorkoutParksFormViewModel model, string adminEmailAddress, string Url)
		{
			if (string.IsNullOrEmpty(adminEmailAddress)) adminEmailAddress = AppSettings.AdminEmailAdress;

			StringBuilder subject = new StringBuilder();
			subject.Append("Zahtev za registrovanje parka ");

			StringBuilder body = new StringBuilder();
			body.AppendLine($"Na sledecem linku mozete pogledati lokaciju parka - <a href={Url}>Park</a>");


			return SendEmail(adminEmailAddress, subject.ToString(), body.ToString(), adminEmailAddress, null);

		}

		public bool SendResetPasswordEmail(string adminEmailAddress, string emailTo, string resetLink)
		{
			if (string.IsNullOrEmpty(adminEmailAddress)) adminEmailAddress = AppSettings.AdminEmailAdress;

			StringBuilder subject = new StringBuilder();
			subject.Append("Reset your password");

			StringBuilder body = new StringBuilder();
			body.AppendLine($"You have requested to reset your password, please click on the link bellow: <a href='{resetLink}'>Reset Password Link</a>");



			return SendEmail(adminEmailAddress, subject.ToString(), body.ToString(), emailTo, null);
		}

		public bool MemberLockedSendMail(LoginFormViewModel model, string emailFrom, string adminEmailAddress, string fullName, string athleteMemberLink)
		{
			if (string.IsNullOrEmpty(adminEmailAddress)) adminEmailAddress = AppSettings.AdminEmailAdress;

			StringBuilder subject = new StringBuilder();
			subject.Append("Zakljucana lozinka");

			StringBuilder body = new StringBuilder();
			body.AppendLine($"Clan cija je lozinka zakljucana:{fullName}");
			body.AppendLine($" Profil mozete pogledati putem linka - <a href={athleteMemberLink}>{fullName}</a>");

			string senderEmail = emailFrom;

			return SendEmail(emailFrom, subject.ToString(), body.ToString(), adminEmailAddress, null);

		}


		/// <summary>
		/// Sends Contact Us request.
		/// </summary
		public bool BecomeMemberContactUsRequest(BecomeMemberFormViewModel member, string adminEmailAddress)
		{
			if (string.IsNullOrEmpty(adminEmailAddress)) adminEmailAddress = AppSettings.AdminEmailAdress;

			StringBuilder subject = new StringBuilder();
			subject.Append("Zahtev za članstvo - ");
			subject.Append(member.Name);
			subject.Append($" { member.Surname}");

			StringBuilder body = new StringBuilder();
			body.Append($"Ime i prezime: {member.Name}");
			body.AppendLine($" {member.Surname}");
			body.AppendLine($"Datum rodjenja: {member.Dob}");
			body.AppendLine($"Status: {member.Status}");
			body.AppendLine($"Državljanstvo: {member.Nationality}");
			body.AppendLine($"Grad: {member.City}");
			body.AppendLine($"Ekipa: {member.CrewName}");
			body.AppendLine($"Adresa: {member.Address}");
			body.AppendLine($"Telefon: {member.MblNumber}");
			body.AppendLine($"E-mail: {member.Email}");

			IEnumerable<Attachment> attachments = new List<Attachment>()
			{
				new Attachment(member.Picture.InputStream, member.Picture.FileName, member.Picture.ContentType)
			};

			string senderEmail = member.Email;

			return SendEmail(senderEmail, subject.ToString(), MvcHtmlString.Create(body.ToString().Replace("\n", "<br/>")).ToString(), adminEmailAddress, attachments);
		}

	

		/// <summary>
		/// Sends Contact Us request.
		/// </summary
		public bool AthleteRegistrationRequest(ShowYourselfFormViewModel athlete, string adminEmailAddress, string newAthleteMemberLink)
		{
			if (string.IsNullOrEmpty(adminEmailAddress)) adminEmailAddress = AppSettings.AdminEmailAdress;

			StringBuilder subject = new StringBuilder();
			subject.Append("Zahtev za registraciju - ");
			subject.Append(athlete.Name);
			subject.Append($" { athlete.Surname}");

			StringBuilder body = new StringBuilder();
			body.AppendLine($"Poslat je novi zahtev za registraciju atlete.");
			body.AppendLine($" Zahtev možete pogledati i odobriti putem linka - <a href={newAthleteMemberLink}>{athlete.Name} {athlete.Surname}</a>");

			string senderEmail = athlete.Email;

			return SendEmail(senderEmail, subject.ToString(), MvcHtmlString.Create(body.ToString().Replace("\n", "<br/>")).ToString(), adminEmailAddress, null);
		}

		public bool CrewIntroduceRequest(IntroduceCrewFormViewModel crew, string adminEmailAddress)
		{
			if (string.IsNullOrEmpty(adminEmailAddress)) adminEmailAddress = AppSettings.AdminEmailAdress;

			StringBuilder subject = new StringBuilder();
			subject.Append("Predstavljanje ekipe - ");
			subject.Append(crew.CrewName);

			StringBuilder body = new StringBuilder();
			body.AppendLine($"Poslati su podaci o ekipi:");
			body.AppendLine($"Ime ekipe: {crew.CrewName}");
			body.AppendLine($"Mesto: {crew.CrewCity}");
			body.AppendLine($"Priča: {crew.CrewStory}");
			body.AppendLine($"Dostignuća: {crew.CrewAchievements}");
			body.AppendLine($"E-mail ekipe: {crew.CrewEmail}");

			List<Attachment> attachments = new List<Attachment>();

			if (crew.Images != null && crew.Images.Any() && crew.Images[0] != null)
			{				
				foreach (var image in crew.Images)
				{
					var attachment = new Attachment(image.InputStream, image.FileName, image.ContentType);
					attachments.Add(attachment);
				}
			}

			string senderEmail = crew.CrewEmail;

			return SendEmail(senderEmail, subject.ToString(), MvcHtmlString.Create(body.ToString().Replace("\n", "<br/>")).ToString(), adminEmailAddress, attachments);
		}

		public bool FanRegistrationRequest(ShowYourselfFormFanViewModel fan, string adminEmailAddress, string newAthleteMemberLink)
		{
			if (string.IsNullOrEmpty(adminEmailAddress)) adminEmailAddress = AppSettings.AdminEmailAdress;

			StringBuilder subject = new StringBuilder();
			subject.Append("Zahtev za registraciju - ");
			subject.Append(fan.Name);
			subject.Append($" { fan.Surname}");

			StringBuilder body = new StringBuilder();
			body.AppendLine($"Poslat je novi zahtev za registraciju fana.");
			body.AppendLine($" Zahtev možete pogledati i odobriti putem linka - <a href={newAthleteMemberLink}>{fan.Name} {fan.Surname}</a>");

			string senderEmail = fan.Email;

			return SendEmail(senderEmail, subject.ToString(), MvcHtmlString.Create(body.ToString().Replace("\n", "<br/>")).ToString(), adminEmailAddress, null);
		}

		public bool CompetitionRequest(LeaguesFormViewModel model, string adminEmailAddress)
		{
			if (string.IsNullOrEmpty(adminEmailAddress)) adminEmailAddress = AppSettings.AdminEmailAdress;
			StringBuilder subject = new StringBuilder();
			subject.Append("Zahtev za takmicenje u ligi ");

			StringBuilder body = new StringBuilder();
			body.Append($"Ime i prezime: {model.Name}");
			body.AppendLine($" {model.Surname}");
			body.AppendLine($"Email: {model.Email}");
			body.AppendLine($"Ekipa: {model.Crews}");
			body.AppendLine($"Grad: {model.City}");


			IEnumerable<Attachment> attachments = new List<Attachment>()
			{
				new Attachment(model.ProfilePicture.InputStream, model.ProfilePicture.FileName, model.ProfilePicture.ContentType)
			};

			string senderEmail = model.Email;
			return SendEmail(senderEmail, subject.ToString(), MvcHtmlString.Create(body.ToString().Replace("\n", "<br/>")).ToString(), adminEmailAddress, attachments);

		}

		/// <summary>
		/// Tries to send email three times, third time using the sender email address from Web.Config.
		/// </summary>
		private bool SendEmail(string senderEmail, string subject, string body, string recieverEmail, IEnumerable<Attachment> attachments)
		{
			try
			{
				SendSmptEmail(senderEmail, subject, body, recieverEmail, attachments);
				return true;
			}
			catch (Exception ex1)
			{
				try
				{
					LogHelper.Error<EmailHandler>($"Error on first try to send email on adress {recieverEmail}", ex1);
					SendSmptEmail(senderEmail, subject, body, recieverEmail, attachments);
					return true;
				}
				catch (Exception ex2)
				{
					try
					{
						LogHelper.Error<EmailHandler>($"Error on first try to send email on adress {recieverEmail}", ex2);
						SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");

						SendSmptEmail(senderEmail, subject, body, recieverEmail, attachments);
						return true;
					}
					catch (Exception ex3)
					{
						LogHelper.Error<EmailHandler>($"Error sending email", ex3);
						return false;
					}

				}
			}
		}

		/// <summary>
		/// Send mail.
		/// </summary
		private void SendSmptEmail(string senderEmail, string subject, string body, string recieverEmail, IEnumerable<Attachment> attachments)
		{
			using (SmtpEmailSender email = new SmtpEmailSender())
			{
				email.SendEmail(senderEmail, subject, body, recieverEmail, attachments);
			}
		}
	}
}