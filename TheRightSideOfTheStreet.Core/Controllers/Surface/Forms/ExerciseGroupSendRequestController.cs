﻿using System;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.EmailSender;
using TheRightSideOfTheStreet.Core.Helpers;
using TheRightSideOfTheStreet.Models;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.Controllers.Surface.Forms
{
	public class ExerciseGroupSendRequestController : BaseSurfaceController
	{
		[HttpPost]
		public string SendRequest(Guid settingsKey)
		{
			Settings settings = Umbraco.TypedContent(settingsKey).OfType<Settings>();

			string emailFrom = Members.CurrentUserName;
			string fullName = Members.GetCurrentMember().Name;
			string emailTo = settings.AdminEmailAddress;

			EmailHandler emailSender = new EmailHandler();

			bool sentMail = emailSender.ExerciseGroupRequest(emailFrom, fullName, emailTo);

			if (sentMail)
			{
				return UmbracoDictionaryHelper.ExerciseGroup.SentSuccess;
			}

			return UmbracoDictionaryHelper.ExerciseGroup.SentFail;
		}
	}
}
