using PravaStranaUlice.Models.DocumentTypes.Compositions;
using PravaStranaUlice.Models.DocumentTypes.Nodes.Items.NestedContent;
using PravaStranaUlice.Web.Contexts;
using System;

namespace PravaStranaUlice.Web.Extensions
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
	}
}