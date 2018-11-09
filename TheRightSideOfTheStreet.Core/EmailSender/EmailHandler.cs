﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using TheRightSideOfTheStreet.Common;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.Forms;
using Umbraco.Core.Logging;

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

			return SendEmail(senderEmail, subject.ToString(), body.ToString(), adminEmailAddress, null);
		}

		public bool BlogComment(string emailFrom, string fullName, string adminEmailAddress, string blogLink)
		{
			StringBuilder subject = new StringBuilder();
			subject.Append("Komentar za odobrenje poslao: - ");
			subject.Append(fullName);

			StringBuilder body = new StringBuilder();
			body.AppendLine("Komentar koji ceka odobrenje se nalazi na sledecem linku:");
			body.AppendLine($"Blog Comment Link: {blogLink}");

			string senderEmial = emailFrom;

			return SendEmail(senderEmial, subject.ToString(), body.ToString(), adminEmailAddress, null);


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
			body.AppendLine($"Adresa: {member.Address}");
			body.AppendLine($"Telefon: {member.MblNumber}");
			body.AppendLine($"E-mail: {member.Email}");

			IEnumerable<Attachment> attachments = new List<Attachment>()
			{
				new Attachment(member.Picture.InputStream, member.Picture.FileName, member.Picture.ContentType)
			};

			string senderEmail = member.Email;

			return SendEmail(senderEmail, subject.ToString(), body.ToString(), adminEmailAddress, attachments);
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
			body.AppendLine($"Poslat je novi zahtev za registraciju");
			body.Append($"Zahtev mozete odobriti putem ovog linka: {newAthleteMemberLink}");

			string senderEmail = athlete.Email;

			return SendEmail(senderEmail, subject.ToString(), body.ToString(), adminEmailAddress, null);
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