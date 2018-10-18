using Umbraco.Web;
using TheRightSideOfTheStreet.Common.Extensions;
using TheRightSideOfTheStreet.Models.DocumentTypes;
using System.Collections.Generic;
using System.Linq;

namespace TheRightSideOfTheStreet.Models.Extensions
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
		public static T GetSideBarNavigationRoot<T>(this IPage page) where T : class, IPage
            => page?.AncestorOrSelf<T>(Constants.SideBarNavigationRootLevel);

        /// <summary>
		/// Returns <paramref name="node"/> title or <paramref name="node"/> name if title is not specified.
		/// </summary>
		/// <param name="node">The navigation node.</param>
		/// <returns><paramref name="node"/> title or <paramref name="node"/> name if title is not specified.</returns>
		public static string GetTitle(this IPage node)
            => !node.Title.IsNullOrEmpty() ? node.Title : node.Name;

        /// <summary>
        /// Returns Site root node.
        /// </summary>
        /// <typeparam name="T">Type of Site root node to return.</typeparam>
        /// <param name="node">The navigation node.</param>
        /// <returns>Site root node.</returns>
        public static T GetRoot<T>(this IPage node) where T : class, IRootNode
            => node?.AncestorOrSelf<T>(1);

        /// <summary>
        /// Returns Home Page.
        /// </summary>
        /// <typeparam name="T">Type of Home Page node to return.</typeparam>
        /// <param name="node">The navigation node.</param>
        /// <returns>Home Page.</returns>
        public static T GetHome<T>(this IPage node) where T : class, IHomePage
            => node.GetRoot<IRootNode>().GetHome<T>();

        /// <summary>
        /// Returns navigation items for the provided <paramref name="node"/>.
        /// </summary>
        /// <typeparam name="T">Type of the navigation items to return.</typeparam>
        /// <param name="node">The navigation node.</param>
        /// <returns>Navigation items for the provided <paramref name="node"/>.</returns>
        public static IEnumerable<T> GetNavigationItems<T>(this IPage node) where T : class, IPage
            => node.Children<T>(c => !c.HideFromSiteNavigation);

        /// <summary>
        /// Returns navigation items for the provided <paramref name="node"/> depending on specified max level of navigation items.
        /// </summary>
        /// <typeparam name="T">Type of the navigation items to return.</typeparam>
        /// <param name="node">The navigation node.</param>
        /// <param name="maxLevel">The max level of navigation items.</param>
        /// <returns>Navigation items if <paramref name="node"/> level is less than specified max level, otherwise empty sequence.</returns>
        public static IEnumerable<T> GetNavigationItems<T>(this IPage node, int maxLevel) where T : class, IPage
            => (node?.Level ?? int.MaxValue) < maxLevel ? node.GetNavigationItems<T>() : Enumerable.Empty<T>();

        /// <summary>
        /// Checks if provided <paramref name="node"/> contains navigation items.
        /// </summary>
        /// <typeparam name="T">Type of the navigation items to check.</typeparam>
        /// <param name="node">The navigation node.</param>
        /// <returns><c>true</c> if there are navigation items under the <paramref name="node"/>, otherwise <c>false</c>.</returns>
        public static bool HasNavigationItems<T>(this IPage node) where T : class, IPage
            => node.GetNavigationItems<T>().Any();

        /// <summary>
        /// Checks if provided <paramref name="node"/> is active for navigation purposes.
        /// </summary>
        /// <param name="node">The navigation node.</param>
        /// <returns><c>true</c> if <paramref name="node"/> is considered as active, otherwise <c>false</c>.</returns>
        public static bool IsActive(this IPage node)
            => UmbracoContext.Current?.PublishedContentRequest?.PublishedContent?.Path.ContainsValue(node.Id) ?? false;

    }
}
