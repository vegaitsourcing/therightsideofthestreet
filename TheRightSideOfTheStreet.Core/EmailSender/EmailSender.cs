using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace TheRightSideOfTheStreet.Core.EmailSender
{
	public class SmtpEmailSender : IDisposable
	{
		public SmtpEmailSender()
		{
			// Getting the information from web config, smtp section.
			Smtp = new SmtpClient();
		}

		public SmtpClient Smtp { get; }

		public void SendEmail(string senderEmail, string subject, string body, string recieverEmail, IEnumerable<Attachment> attachments = null)
		{
			using (MailMessage mail = new MailMessage(senderEmail, recieverEmail))
			{
				mail.Subject = subject;
				mail.Body = body;
				

				if (attachments != null)
				{
					foreach (Attachment attachment in attachments)
					{
						mail.Attachments.Add(attachment);
					}
				}

				Smtp.Send(mail);
			}
		}

		public void Dispose()
		{
			Smtp.Dispose();
		}
	}
}
