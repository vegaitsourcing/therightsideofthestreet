using TheRightSideOfTheStreet.Models.DocumentTypes.Compositions;
using TheRightSideOfTheStreet.Models.DocumentTypes.Nodes.Items.NestedContent;
using TheRightSideOfTheStreet.Core.Contexts;
using System;
using TheRightSideOfTheStreet.Models.DocumentTypes;

namespace TheRightSideOfTheStreet.Core.Extensions
{
	/// <summary>
	/// <see cref="ISiteContext"/> extension methods.
	/// </summary>
	public static class ISiteContextExtensions
	{
		public static INestedContentContext<T> WithNestedContent<T>(this ISiteContext siteContext, T nestedContent) where T : class, INestedContent
		{
			if (nestedContent == null) return default(INestedContentContext<T>);

			return (INestedContentContext<T>)Activator.CreateInstance(typeof(NestedContentContext<>).MakeGenericType(nestedContent.GetType()), nestedContent, siteContext);
		}
		
		public static ICompositionContext<T> WithComposition<T>(this ISiteContext siteContext, T composition)
			where T : class, ICompositions
		{
			if (composition == null) return default(ICompositionContext<T>);

			return (ICompositionContext<T>)Activator.CreateInstance(typeof(CompositionContext<>).MakeGenericType(composition.GetType()), composition, siteContext);
		}

		public static IBlogPageContext<T> WithBlogPage<T>(this ISiteContext siteContext, T blogPage)
			where T : class, IBlogPage
		{
			if (blogPage == null) return default(IBlogPageContext<T>);

			return (IBlogPageContext<T>)Activator.CreateInstance(typeof(BlogPageContext<>).MakeGenericType(blogPage.GetType()), blogPage, siteContext);
		}
	}
}