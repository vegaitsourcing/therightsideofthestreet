using PravaStranaUlice.Models.DocumentTypes;

namespace PravaStranaUlice.Models.Extensions
{
	/// <summary>
	/// <see cref="IRootNode"/> extension methods.
	/// </summary>
	public static class IRootNodeExtensions
	{
		/// <summary>
		/// Returns Home Page.
		/// </summary>
		/// <typeparam name="T">Type of Home Page node to return.</typeparam>
		/// <param name="root">Site root node.</param>
		/// <returns>Home Page.</returns>
		public static T GetHome<T>(this IRootNode root) where T : class, IHomePage
			=> root as T;   // TODO: Change implementation of this method when Home page is not in the root of the site (i.e. for multi-language sites or when some kind of special Site node is in the root).
	}
}
