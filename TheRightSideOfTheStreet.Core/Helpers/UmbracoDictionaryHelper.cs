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
		private static UmbracoHelper UmbracoHelper => new UmbracoHelper(UmbracoContext.Current);
	}
}
