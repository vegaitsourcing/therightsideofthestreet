using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.Helpers
{
	public static class UmbracoDictionaryHelper
	{
		public static class BlogDetails
		{
			public static string Previous => UmbracoHelper.GetDictionaryValue("BlogDetails.Previous");
			public static string Back => UmbracoHelper.GetDictionaryValue("BlogDetails.Back");
			public static string Comments => UmbracoHelper.GetDictionaryValue("BlogDetails.Comments");
			public static string PostComment => UmbracoHelper.GetDictionaryValue("BlogDetails.PostComment");
			public static string Comment => UmbracoHelper.GetDictionaryValue("BlogDetails.Comment");
			public static string Next => UmbracoHelper.GetDictionaryValue("BlogDetails.Next");
		}

		public static class BecomeMember
		{
			public static string BecomeMemberbutton => UmbracoHelper.GetDictionaryValue("BecomeMember.BecomeMemberButton");
			public static string Name => UmbracoHelper.GetDictionaryValue("BecomeMember.Name");
			public static string Surname => UmbracoHelper.GetDictionaryValue("BecomeMember.Surname");
			public static string Address => UmbracoHelper.GetDictionaryValue("BecomeMember.Address");
			public static string Email => UmbracoHelper.GetDictionaryValue("BecomeMember.Email");
			public static string Nationality => UmbracoHelper.GetDictionaryValue("BecomeMember.Nationality");
			public static string MblNumber => UmbracoHelper.GetDictionaryValue("BecomeMember.MblNumber");
			public static string UploadPicture => UmbracoHelper.GetDictionaryValue("BecomeMember.UploadPicture");
			public static string Dob => UmbracoHelper.GetDictionaryValue("BecomeMember.Dob");
			public static string DobRegex => UmbracoHelper.GetDictionaryValue("BecomeMember.DobRegex");
			public static string PickButton => UmbracoHelper.GetDictionaryValue("BecomeMember.PickButton");
			public static string Picture => UmbracoHelper.GetDictionaryValue("BecomeMember.Picture");
			public static string RequestSuccess => UmbracoHelper.GetDictionaryValue("BecomeMember.RequestSuccess");
			public static string RequestFailed => UmbracoHelper.GetDictionaryValue("BecomeMember.RequestFailed");
		}

		public static class NewsletterModule
		{
			public static string SubscriptionMessage => UmbracoHelper.GetDictionaryValue("NewsletterModule.SubscriptionMessage");
			public static string SubscribeButton => UmbracoHelper.GetDictionaryValue("NewsletterModule.SubscribeButton");
		}


		public static class UmbracoValidation
		{
			public static string Required => UmbracoHelper.GetDictionaryValue("UmbracoValidation.Required");
			public static string StringLenght => UmbracoHelper.GetDictionaryValue("UmbracoValidation.StringLength");
			public static string EmailAddress => UmbracoHelper.GetDictionaryValue("UmbracoValidation.EmailAddress");
			public static string ImageExtension => UmbracoHelper.GetDictionaryValue("UmbracoValidation.ImageExtension");
			public static string ImageMaxSize => UmbracoHelper.GetDictionaryValue("UmbracoValidation.ImageMaxSize");
			public static string Password => UmbracoHelper.GetDictionaryValue("UmbracoValidation.Password");
		}


		public static class AthleteMember
		{
			public static string SportVision => UmbracoHelper.GetDictionaryValue("AthleteMember.SportVision");
			public static string ImportantAchievements => UmbracoHelper.GetDictionaryValue("AthleteMember.ImportantAchievements");
			public static string Status => UmbracoHelper.GetDictionaryValue("AthleteMember.Status");
			public static string Crew => UmbracoHelper.GetDictionaryValue("AthleteMember.Crew");
		}

		public static class ExerciseGroup
		{
			public static string Step => UmbracoHelper.GetDictionaryValue("ExerciseGroup.Step");
			public static string SendRequest => UmbracoHelper.GetDictionaryValue("ExerciseGroup.SendRequest");
			public static string LogIn => UmbracoHelper.GetDictionaryValue("ExerciseGroup.LogInButton");
			public static string SentSuccess => UmbracoHelper.GetDictionaryValue("ExerciseGroup.SentRequestSuccess");
			public static string SentFail => UmbracoHelper.GetDictionaryValue("ExerciseGroup.SentRequestFail");
		}

		public static class AtheleLanding
		{
			public static string IntroduceYourself => UmbracoHelper.GetDictionaryValue("AthleteLanding.IntroduceYourself");
			public static string Search => UmbracoHelper.GetDictionaryValue("AthleteLanding.Search");
		}

		public static class LoginForm
		{
			public static string EmailAddress => UmbracoHelper.GetDictionaryValue("LoginForm.EmailAddress");
			public static string Password => UmbracoHelper.GetDictionaryValue("LoginForm.Password");
			public static string LogIn => UmbracoHelper.GetDictionaryValue("LoginForm.LogIn");
			public static string Register => UmbracoHelper.GetDictionaryValue("LoginForm.Register");
			public static string WithoutAccount => UmbracoHelper.GetDictionaryValue("LoginForm.WithoutAccount");
			public static string LoginSuccess => UmbracoHelper.GetDictionaryValue("LoginForm.LoginSuccess");
			public static string LoginFailed => UmbracoHelper.GetDictionaryValue("LoginForm.LoginFailed");


		}

		private static UmbracoHelper UmbracoHelper => new UmbracoHelper(UmbracoContext.Current);
	}
}
