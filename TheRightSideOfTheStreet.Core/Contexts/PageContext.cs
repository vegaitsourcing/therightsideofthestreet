using System;
using TheRightSideOfTheStreet.Models.DocumentTypes;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.Contexts
{
	public class PageContext<T> : SiteContext, IPageContext<T> where T : class, IPage
    {
        public PageContext(T page, UmbracoHelper umbracoHelper) : base(umbracoHelper)
        {
            Page = page ?? throw new ArgumentNullException(nameof(page));
        }

        public T Page { get; }
    }
}