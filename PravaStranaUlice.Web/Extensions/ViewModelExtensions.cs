using PravaStranaUlice.Common.Extensions;
using PravaStranaUlice.Models;
using PravaStranaUlice.Models.DocumentTypes;
using PravaStranaUlice.Models.DocumentTypes.Nodes.Items.NestedContent;
using PravaStranaUlice.Web.Contexts;
using PravaStranaUlice.Web.ViewModels.Partials.Layout;
using PravaStranaUlice.Web.ViewModels.Partials.NestedContent;
using PravaStranaUlice.Web.ViewModels.Shared;
using RJP.MultiUrlPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PravaStranaUlice.Web.Extensions
{
	public static class ViewModelExtensions
	{
		public static LinkViewModel AsLinkViewModel(this string text)
			=> !text.IsNullOrWhiteSpace() ? new LinkViewModel(string.Empty, text) : default(LinkViewModel);

		public static LinkViewModel AsLinkViewModel(this string url, string text, string target = null)
			=> !url.IsNullOrWhiteSpace() ? new LinkViewModel(url, text) : default(LinkViewModel);

		public static LinkViewModel AsViewModel(this Link link)
			=> link != null ? new LinkViewModel(link) : default(LinkViewModel);

		public static LinkViewModel AsLinkViewModel(this IPage node, string target = null)
			=> node != null ? new LinkViewModel(node, target) : default(LinkViewModel);

		public static LanguageLinkViewModel AsViewModel(this IPage page, string language)
			=> page != null ? new LanguageLinkViewModel(page, language) : default(LanguageLinkViewModel);

		public static ImageViewModel AsViewModel(this Image image)
			=> image != null ? new ImageViewModel(image) : default(ImageViewModel);

		public static TextViewModel AsViewModel(this string text)
			=> !text.IsNullOrWhiteSpace() ? new TextViewModel(text) : default(TextViewModel); 

		public static TNestedContentViewModel AsViewModel<TNestedContentViewModel>(this INestedContentContext<INestedContent> nestedContentContext, string classSuffix = "ViewModel")
			where TNestedContentViewModel : INestedContentViewModel
		{
			if (nestedContentContext == null) return default(TNestedContentViewModel);

			Type baseType = typeof(TNestedContentViewModel);
			string modelTypeName = $"{baseType.Namespace}.{nestedContentContext.NestedContent.GetType().Name}{classSuffix}";

			return (TNestedContentViewModel)Activator.CreateInstance(Assembly.GetAssembly(baseType).GetType(modelTypeName), nestedContentContext);
		}

		public static TNestedContentViewModel AsViewModel<TNestedContentViewModel>(this INestedContent nestedContent, string classSuffix = "ViewModel")
			where TNestedContentViewModel : INestedContentViewModel
		{
			if (nestedContent == null) return default(TNestedContentViewModel);

			Type baseType = typeof(TNestedContentViewModel);
			string modelTypeName = $"{baseType.Namespace}.{nestedContent.GetType().Name}{classSuffix}";

			return (TNestedContentViewModel)Activator.CreateInstance(Assembly.GetAssembly(baseType).GetType(modelTypeName), nestedContent);
		}

		//public static BannerViewModel AsViewModel(this ICompositionContext<IBanner> compositionContext,
		//    string classSuffix = "ViewModel")
		//{
		//    if (compositionContext == null) return default(BannerViewModel);

		//    return new BannerViewModel(compositionContext);
		//}

		public static PrimaryNavigationItemViewModel AsNavigationViewModel(this IPage page) => page != null ? new PrimaryNavigationItemViewModel(page) : null;

		public static IEnumerable<PrimaryNavigationItemViewModel> AsNavigationViewModel(this IEnumerable<IPage> pages) 
			=> pages?.Where(p => p != null).Select(AsNavigationViewModel) ?? Enumerable.Empty<PrimaryNavigationItemViewModel>();

		//public static XMLSitemapItemViewModel AsXMLSitemapItemViewModel(this IPage page)
		//	=> page != null ? new XMLSitemapItemViewModel(page) : null;
        
	}
}