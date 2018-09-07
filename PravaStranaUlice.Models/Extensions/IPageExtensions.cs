using Umbraco.Web;
using PravaStranaUlice.Common.Extensions;
using PravaStranaUlice.Models.DocumentTypes;

namespace PravaStranaUlice.Models.Extensions
{
	/// <summary>
	/// <see cref="IPage"/> extension methods.
	/// </summary>
	public static class IPageExtensions
	{
		/// <summary>
		///	Returns <paramref name="page"/> SEO title or <paramref name="page"/> title if SEO title is not specified.
		/// </summary>
		/// <param name="page">The page.</param>
		/// <returns><paramref name="page"/> SEO title or <paramref name="page"/> title if SEO title is not specified.</returns>
		public static string GetSeoTitle(this IPage page)
			=> !page.SeoTitle.IsNullOrEmpty() ? page.SeoTitle : page.GetTitle();

		/// <summary>
		/// Returns formatted <paramref name="page"/> SEO title, based on specified <paramref name="format"/> and <paramref name="discardTitleForHomePage"/> flag.
		/// </summary>
		/// <param name="page">The page.</param>
		/// <param name="brandName">Brand name to use in the SEO title.</param>
		/// <param name="format">Format to use. First placeholder is used for SEO title, and second one for brand name.</param>
		/// <param name="discardTitleForHomePage">If <c>true</c> only brand name will be used for Home Page SEO title.</param>
		/// <returns>Formatted <paramref name="page"/> SEO title.</returns>
		public static string GetFormattedSeoTitle(this IPage page, string brandName, string format = "{0} | {1}", bool discardTitleForHomePage = true)
		{
			if (brandName.IsNullOrWhiteSpace()) return page.GetSeoTitle();

			string seoTitle = (discardTitleForHomePage && page.IsHome()) ? page.SeoTitle : page.GetSeoTitle();
			if (seoTitle.IsNullOrWhiteSpace())
			{
				return brandName;
			}

			return string.Format(format, seoTitle, brandName);
		}

		/// <summary>
		/// Checks if specified <paramref name="page"/> is Home Page.
		/// </summary>
		/// <param name="page">The page.</param>
		/// <returns><c>true</c> if specified <paramref name="page"/> is Home Page, otherwise <c>false</c>.</returns>
		public static bool IsHome(this IPage page)
			=> (page is IHomePage) && (page.Id == page.GetHome<IHomePage>().Id);

		/// <summary>
		/// Returns sidebar navigation root node for the specified <paramref name="page"/>.
		/// </summary>
		/// <typeparam name="T">Type of the sidebar navigation root node.</typeparam>
		/// <param name="page">The page.</param>
		/// <returns>Sidebar navigation root node.</returns>
		public static T GetSideBarNavigationRoot<T>(this IPage page) where T : class, INavigationNode
			=> page?.AncestorOrSelf<T>(Constants.SideBarNavigationRootLevel);
	}
}
