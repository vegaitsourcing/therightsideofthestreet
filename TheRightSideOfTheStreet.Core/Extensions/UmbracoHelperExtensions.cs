﻿using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Models.DocumentTypes;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.Extensions
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

		public static IBlogPageContext<T> CreateBlogPageContext<T>(this UmbracoHelper helper, T page) where T : class, IBlogPage
		   => new BlogPageContext<T>(page, helper);
	}
}