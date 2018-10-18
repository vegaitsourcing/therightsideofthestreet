using Umbraco.Core.Models;
using Umbraco.Web;
using TheRightSideOfTheStreet.Models.Extensions;

namespace TheRightSideOfTheStreet.Core.Extensions
{
	/// <summary>
	/// <see cref="UmbracoContext"/> extension methods.
	/// </summary>
	public static class UmbracoContextExtensions
	{
		/// <summary>
		/// Returns root node of the domain provided <paramref name="context"/> is associated with.
		/// </summary>
		/// <param name="context">Umbraco Context.</param>
		/// <returns>Domain root node or the first node in the content tree.</returns>
		public static IPublishedContent TypedContentAtDomainRoot(this UmbracoContext context)
			=> new UmbracoHelper(context).TypedContentAtDomainRoot<IPublishedContent>();
	}
}
