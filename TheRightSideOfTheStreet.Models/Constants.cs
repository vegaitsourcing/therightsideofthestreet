namespace TheRightSideOfTheStreet.Models
{
	/// <summary>
	/// Constant values used in models.
	/// </summary>
	public static class Constants
	{
		/// <summary>
		/// Depth level of Home Page which can be different on multi-language sites.
		/// </summary>
		public const int HomePageLevel = 1;

		/// <summary>
		/// Root segment of Home Page XPath.
		/// </summary>
		public const string HomePageXPathRoot = "/root/";       // TODO: If Home Page is not in the root of the site, change this value (e.g. to "//").

		/// <summary>
		/// Home Page document type alias for XPath.
		/// </summary>
		public const string HomePageXPathAlias = "website";		// TODO: Update to the name of Home Page model class (if not Home).

		/// <summary>
		/// Depth level of SideBar navigation root node.
		/// </summary>
		public const int SideBarNavigationRootLevel = HomePageLevel + 1;

		/// <summary>
		/// Max depth level of pages included in Sitemap XML.
		/// </summary>
		public const int SitemapXMLPageMaxLevel = 100;
	}
}
