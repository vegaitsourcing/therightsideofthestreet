using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Models.Extensions
{
	/// <summary>
	/// <see cref="UmbracoHelper"/> extension methods for domain access.
	/// </summary>
	public static class UmbracoHelperDomainExtensions
	{
		/// <summary>
		/// Returns root node of the domain provided <paramref name="helper"/> is associated with.
		/// </summary>
		/// <typeparam name="T">Type of domain root node to return.</typeparam>
		/// <param name="helper">Umbraco helper.</param>
		/// <returns>Domain root node or the first node in the content tree.</returns>
		public static T TypedContentAtDomainRoot<T>(this UmbracoHelper helper) where T : class, IPublishedContent
		{
			// Finds appropriate Umbraco domain for current request URL
			IEnumerable<IDomain> validDomains = helper.UmbracoContext.Application.Services.DomainService.GetAll(false)
																	 .Where(d => helper.UmbracoContext.HttpContext.Request.Url.AbsoluteUri.Contains(d.DomainName));
			IDomain domain = validDomains.Any() ? validDomains.Aggregate((mostSpecific, d) => d.DomainName.Length > mostSpecific.DomainName.Length ? d : mostSpecific) : null;

			// Retrieves either the current root node for the domain or the first root node in the content tree
			return (domain != null && domain.RootContentId.HasValue) ? helper.TypedContent(domain.RootContentId.Value).OfType<T>() :
																	   helper.TypedContentAtRoot().OfType<T>().FirstOrDefault();
		}
	}
}
