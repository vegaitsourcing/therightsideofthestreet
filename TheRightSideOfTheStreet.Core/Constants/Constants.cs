namespace TheRightSideOfTheStreet.Core.Constants
{
	public static class Constants
	{
		public const string TempDataSuccess= "success";
		public const string TempDataFail = "fail";
		public const string PaswordRegex = "^(?=.*[0-9]+.*)(?=.*[a-zA-Z]+.*)[0-9a-zA-Z]{6,}$";
		public const string FacebookRegex = @"(?:(?:http|https):\/\/)?(?:www.)?facebook.com\/(?:(?:\w)*#!\/)?(?:pages\/)?(?:[?\w\-]*\/)?(?:profile.php\?id=(?=\d.*))?([\w\.-]*)?";
		public const string InstagramRegex = @"https?:\/\/(www\.)?instagram\.com\/([A-Za-z0-9_](?:(?:[A-Za-z0-9_]|(?:\.(?!\.))){0,28}(?:[A-Za-z0-9_]))?)";
		public const string YoutubeRegex = @"(?:https|http)\:\/\/(?:[\w]+\.)?youtube\.com\/(?:c\/|channel\/|user\/)?([a-zA-Z0-9_\-]{1,})";

	}
}
