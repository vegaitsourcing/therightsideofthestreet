using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Web.Contexts;
using Umbraco.Web;

namespace PravaStranaUlice.Web.Extensions
{
    /// <summary>
	/// <see cref="UmbracoHelper"/> extension methods.
	/// </summary>
	public static class UmbracoHelperExtensions
    {
        public static ISiteContext CreateSiteContext(this UmbracoHelper helper)
            => new SiteContext(helper);

        public static IPageContext<T> CreatePageContext<T>(this UmbracoHelper helper, T page) where T : class, IPage
            => new PageContext<T>(page, helper);
    }
}