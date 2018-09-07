using System.Collections.Generic;
using System.Linq;
using Umbraco.Web;
using PravaStranaUlice.Common.Extensions;
using PravaStranaUlice.Models.DocumentTypes;

namespace PravaStranaUlice.Models.Extensions
{
	/// <summary>
	/// <see cref="INavigationNode"/> extension methods.
	/// </summary>
	public static class INavigationNodeExtensions
	{
		/// <summary>
		/// Returns <paramref name="node"/> title or <paramref name="node"/> name if title is not specified.
		/// </summary>
		/// <param name="node">The navigation node.</param>
		/// <returns><paramref name="node"/> title or <paramref name="node"/> name if title is not specified.</returns>
		public static string GetTitle(this INavigationNode node)
			=> !node.Title.IsNullOrEmpty() ? node.Title : node.Name;

		/// <summary>
		/// Returns Site root node.
		/// </summary>
		/// <typeparam name="T">Type of Site root node to return.</typeparam>
		/// <param name="node">The navigation node.</param>
		/// <returns>Site root node.</returns>
		public static T GetRoot<T>(this INavigationNode node) where T : class, IRootNode
			=> node?.AncestorOrSelf<T>(1);

		/// <summary>
		/// Returns Home Page.
		/// </summary>
		/// <typeparam name="T">Type of Home Page node to return.</typeparam>
		/// <param name="node">The navigation node.</param>
		/// <returns>Home Page.</returns>
		public static T GetHome<T>(this INavigationNode node) where T : class, IHomePage
			=> node.GetRoot<IRootNode>().GetHome<T>();

		/// <summary>
		/// Returns navigation items for the provided <paramref name="node"/>.
		/// </summary>
		/// <typeparam name="T">Type of the navigation items to return.</typeparam>
		/// <param name="node">The navigation node.</param>
		/// <returns>Navigation items for the provided <paramref name="node"/>.</returns>
		public static IEnumerable<T> GetNavigationItems<T>(this INavigationNode node) where T : class, INavigationNode
			=> node.Children<T>(c => !c.HideFromSiteNavigation);

		/// <summary>
		/// Returns navigation items for the provided <paramref name="node"/> depending on specified max level of navigation items.
		/// </summary>
		/// <typeparam name="T">Type of the navigation items to return.</typeparam>
		/// <param name="node">The navigation node.</param>
		/// <param name="maxLevel">The max level of navigation items.</param>
		/// <returns>Navigation items if <paramref name="node"/> level is less than specified max level, otherwise empty sequence.</returns>
		public static IEnumerable<T> GetNavigationItems<T>(this INavigationNode node, int maxLevel) where T : class, INavigationNode
			=> (node?.Level ?? int.MaxValue) < maxLevel ? node.GetNavigationItems<T>() : Enumerable.Empty<T>();

		/// <summary>
		/// Checks if provided <paramref name="node"/> contains navigation items.
		/// </summary>
		/// <typeparam name="T">Type of the navigation items to check.</typeparam>
		/// <param name="node">The navigation node.</param>
		/// <returns><c>true</c> if there are navigation items under the <paramref name="node"/>, otherwise <c>false</c>.</returns>
		public static bool HasNavigationItems<T>(this INavigationNode node) where T : class, INavigationNode
			=> node.GetNavigationItems<T>().Any();

		/// <summary>
		/// Checks if provided <paramref name="node"/> is active for navigation purposes.
		/// </summary>
		/// <param name="node">The navigation node.</param>
		/// <returns><c>true</c> if <paramref name="node"/> is considered as active, otherwise <c>false</c>.</returns>
		public static bool IsActive(this INavigationNode node)
			=> UmbracoContext.Current?.PublishedContentRequest?.PublishedContent?.Path.ContainsValue(node.Id) ?? false;

		/// <summary>
		/// Returns sitemap items from the provided <paramref name="node"/>.
		/// </summary>
		/// <typeparam name="T">Type of sitemap nodes to return.</typeparam>
		/// <param name="node">The navigation node.</param>
		/// <returns>Sitemap items for the provided <paramref name="node"/>.</returns>
		public static IEnumerable<T> GetSitemapItems<T>(this INavigationNode node) where T : class, INavigationNode
			=> node.Children<T>(c => !c.HideFromSitemap);

		/// <summary>
		/// Returns sitemap items from the provided <paramref name="node"/> depending on specified max level of navigation items.
		/// </summary>
		/// <typeparam name="T">Type of sitemap nodes to return.</typeparam>
		/// <param name="node">The navigation node.</param>
		/// <param name="maxLevel">The max level of navigation items.</param>
		/// <returns>Sitemap items if <paramref name="node"/> level is less than specified max level, otherwise empty sequence.</returns>
		public static IEnumerable<T> GetSitemapItems<T>(this INavigationNode node, int maxLevel) where T : class, INavigationNode
			=> (node?.Level ?? int.MaxValue) < maxLevel ? node.GetSitemapItems<T>() : Enumerable.Empty<T>();
	}
}
