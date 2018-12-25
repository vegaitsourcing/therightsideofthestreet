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
			public static string PostCommentFailed => UmbracoHelper.GetDictionaryValue("BlogDetails.PostCommentFailed");
			public static string LoginForPostingComment => UmbracoHelper.GetDictionaryValue("BlogDetails.LoginForPostingComment");

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
			public static string SubscriptionFooterMessage => UmbracoHelper.GetDictionaryValue("NewsletterModule.FooterMessage");
			public static string Success => UmbracoHelper.GetDictionaryValue("NewsletterModule.Success");
			public static string Fail => UmbracoHelper.GetDictionaryValue("NewsletterModule.Fail");
		}


		public static class UmbracoValidation
		{
			public static string Required => UmbracoHelper.GetDictionaryValue("UmbracoValidation.Required");
			public static string StringLenght => UmbracoHelper.GetDictionaryValue("UmbracoValidation.StringLength");
			public static string EmailAddress => UmbracoHelper.GetDictionaryValue("UmbracoValidation.EmailAddress");
			public static string ImageExtension => UmbracoHelper.GetDictionaryValue("UmbracoValidation.ImageExtension");
			public static string ImageMaxSize => UmbracoHelper.GetDictionaryValue("UmbracoValidation.ImageMaxSize");
			public static string PasswordMatch => UmbracoHelper.GetDictionaryValue("UmbracoValidation.PasswordMatch");
			public static string Password => UmbracoHelper.GetDictionaryValue("UmbracoValidation.Password");
			public static string MultipleImageMaxSize => UmbracoHelper.GetDictionaryValue("UmbracoValidation.MultipleImageMaxSize");
			public static string Url => UmbracoHelper.GetDictionaryValue("UmbracoValidation.Url");
			public static string PasswordFormat => UmbracoHelper.GetDictionaryValue("UmbracoValidation.PasswordFormat");
			public static string FacebookProfile => UmbracoHelper.GetDictionaryValue("UmbracoValidation.FacebookProfile");
			public static string YoutubeProfile => UmbracoHelper.GetDictionaryValue("UmbracoValidation.YoutubeProfile");
			public static string InstagramProfile => UmbracoHelper.GetDictionaryValue("UmbracoValidation.InstagramProfile");
			public static string DuplicateEmailAddress => UmbracoHelper.GetDictionaryValue("UmbracoValidation.DuplicateEmailAddress");
		}


		public static class AthleteMember
		{
			public static string SportVision => UmbracoHelper.GetDictionaryValue("AthleteMember.SportVision");
			public static string ImportantAchievements => UmbracoHelper.GetDictionaryValue("AthleteMember.ImportantAchievements");
			public static string Status => UmbracoHelper.GetDictionaryValue("AthleteMember.Status");
			public static string Crew => UmbracoHelper.GetDictionaryValue("AthleteMember.Crew");
		}

		public static class AthleteForm
		{
			public static string DescribeYourself => UmbracoHelper.GetDictionaryValue("AthleteForm.DescribeYourself");
			public static string Image => UmbracoHelper.GetDictionaryValue("AthleteForm.Image");
			public static string NotableAchievements => UmbracoHelper.GetDictionaryValue("AthleteForm.NotableAchievements");
			public static string SaveButton => UmbracoHelper.GetDictionaryValue("AthleteForm.SaveButton");
			public static string AchievementsAdd => UmbracoHelper.GetDictionaryValue("AthleteForm.AchievementsAdd");
			public static string IntroduceYourself => UmbracoHelper.GetDictionaryValue("AthleteForm.IntroduceYourself");
			public static string VisionOfSport => UmbracoHelper.GetDictionaryValue("AthleteForm.VisionOfSport");
			public static string Password => UmbracoHelper.GetDictionaryValue("AthleteForm.Password");
			public static string ConfirmPassword => UmbracoHelper.GetDictionaryValue("AthleteForm.ConfirmPassword");
			public static string Crews => UmbracoHelper.GetDictionaryValue("AthleteForm.Crew");
			public static string Country => UmbracoHelper.GetDictionaryValue("AthleteForm.Country");
			public static string City => UmbracoHelper.GetDictionaryValue("AthleteForm.City");
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
			public static string ShowMore => UmbracoHelper.GetDictionaryValue("AthleteLanding.ShowMore");
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
			public static string Logout => UmbracoHelper.GetDictionaryValue("LoginForm.LogOut");
			public static string ForgottenPassword => UmbracoHelper.GetDictionaryValue("LoginForm.ForgottenPassword");
			public static string ResetPassword => UmbracoHelper.GetDictionaryValue("LoginForm.ResetPassword");
			public static string ResetPasswordFailed => UmbracoHelper.GetDictionaryValue("LoginForm.ResetPasswordFailed");
			public static string MemberLocked => UmbracoHelper.GetDictionaryValue("LoginForm.MemberLocked");
		}

		public static class Footer
		{
			public static string ContactUs => UmbracoHelper.GetDictionaryValue("Footer.ContactUs");
		}

		public static class AthleteModule
		{
			public static string Instagram => UmbracoHelper.GetDictionaryValue("AthleteModule.FollowInstagram");
			public static string Facebook => UmbracoHelper.GetDictionaryValue("AthleteModule.FollowFacebook");
			public static string Youtube => UmbracoHelper.GetDictionaryValue("AthleteModule.FollowYoutube");
			public static string Find => UmbracoHelper.GetDictionaryValue("AthleteModule.Find");
		}

		public static class Banner
		{
			public static string FollowUs => UmbracoHelper.GetDictionaryValue("Banner.FollowUs");
		}

		public static class CrewsModule
		{
			public static string Search => UmbracoHelper.GetDictionaryValue("CrewsModule.Search");
			public static string Find => UmbracoHelper.GetDictionaryValue("CrewsModule.Find");
			public static string ShowMore => UmbracoHelper.GetDictionaryValue("CrewsModule.ShowMore");
			public static string BackTo => UmbracoHelper.GetDictionaryValue("CrewsModule.BackTo");
		}

		public static class ForgottenPassword
		{
			public static string Send => UmbracoHelper.GetDictionaryValue("ForgottenPassword.Send");
		}

		public static class LeagueForm
		{
			public static string Crews => UmbracoHelper.GetDictionaryValue("LeagueForm.Crews");
			public static string Participate => UmbracoHelper.GetDictionaryValue("LeagueForm.Participate");
			public static string SendRequest => UmbracoHelper.GetDictionaryValue("LeagueForm.SendRequest");
		}

		public static class SWLeague
		{
			public static string Link => UmbracoHelper.GetDictionaryValue("SWLeague.Competition");
			public static string ScoringSystem => UmbracoHelper.GetDictionaryValue("SWLeague.ScoringSystem");
			public static string City => UmbracoHelper.GetDictionaryValue("SWLeague.City");
			public static string FullName => UmbracoHelper.GetDictionaryValue("SWLeague.FullName");
			public static string Crew => UmbracoHelper.GetDictionaryValue("SWLeague.Crew");
			public static string Points => UmbracoHelper.GetDictionaryValue("SWLeague.Points");

		}

		private static UmbracoHelper UmbracoHelper => new UmbracoHelper(UmbracoContext.Current);

	}
}
