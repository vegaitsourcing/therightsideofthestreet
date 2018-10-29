using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.Helpers
{
	public static class UmbracoDictionaryHelper
	{
		public static class BlogDetails
		{
			public static string Previous = UmbracoHelper.GetDictionaryValue("BlogDetails.Previous");
			public static string Back = UmbracoHelper.GetDictionaryValue("BlogDetails.Back");
			public static string Comments = UmbracoHelper.GetDictionaryValue("BlogDetails.Comments");
			public static string PostComment = UmbracoHelper.GetDictionaryValue("BlogDetails.PostComment");
			public static string Comment = UmbracoHelper.GetDictionaryValue("BlogDetails.Comment");
			public static string Next = UmbracoHelper.GetDictionaryValue("BlogDetails.Next");

		}

		public static class AthleteMember
		{
			public static string SportVision => UmbracoHelper.GetDictionaryValue("AthleteMember.SportVision");
			public static string ImportantAchievements => UmbracoHelper.GetDictionaryValue("AthleteMember.ImportantAchievements");
			public static string Status => UmbracoHelper.GetDictionaryValue("AthleteMember.Status");
			public static string Crew => UmbracoHelper.GetDictionaryValue("AthleteMember.Crew");
		}

		private static UmbracoHelper UmbracoHelper => new UmbracoHelper(UmbracoContext.Current);
	}
}
