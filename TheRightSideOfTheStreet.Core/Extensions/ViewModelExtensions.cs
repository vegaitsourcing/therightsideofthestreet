using RJP.MultiUrlPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TheRightSideOfTheStreet.Common.Extensions;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Core.ViewModels.Partials;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.Layout;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.DocumentTypes;
using TheRightSideOfTheStreet.Models.DocumentTypes.Nodes.Items.NestedContent;
using Umbraco.Core.Models;
using TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent.Modules;
using TheRightSideOfTheStreet.Models.DocumentTypes.Compositions;

namespace TheRightSideOfTheStreet.Core.Extensions
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

		public static BlogDetailsViewModel AsViewModel(this IBlogPageContext<BlogDetails> blogPageContext, string classSuffix = "ViewModel")
		{
			if (blogPageContext == null) return default(BlogDetailsViewModel);

			return new BlogDetailsViewModel(blogPageContext);
		}
		
		public static IModulesNestedContentViewModel AsViewModel(this INestedContentContext<IModuleNestedContent> nestedContentContext, string classSuffix = "ViewModel")
		{
			if (nestedContentContext == null) return default(IModulesNestedContentViewModel);

			Type baseType = typeof(IModulesNestedContentViewModel);
			string modelTypeName = $"{baseType.Namespace}.{nestedContentContext.NestedContent.GetType().Name}{classSuffix}";

			return (IModulesNestedContentViewModel)Activator.CreateInstance(Assembly.GetAssembly(baseType).GetType(modelTypeName), nestedContentContext);
		}

		public static IEnumerable<T> AsViewModel<T>(this IEnumerable<IPublishedContent> items, string classSuffix = "ViewModel")
			where T : class
		{
			if (items == null) return Enumerable.Empty<T>();

			return items.Where(pc => pc != null).Select(pc => (T)Activator.CreateInstance(typeof(T), pc));
		}
		
		public static BannerViewModel AsViewModel(this ICompositionContext<Banner> compositionContext, string classSuffix = "ViewModel")
		{
		    if (compositionContext == null) return default(BannerViewModel);

			return new BannerViewModel(compositionContext);
		}
		public static CrewViewModel AsViewModel(this Crew crew)
			=> crew != null ? new CrewViewModel(crew) : default(CrewViewModel);

		public static MembershipStatusViewModel AsViewModel(this MembershipStatus status)
			=> status != null ? new MembershipStatusViewModel(status) : default(MembershipStatusViewModel);

		public static ExerciseCategoryViewModel AsViewModel(this ExerciseCategory context, string classSuffix = "ViewModel")
		{
			if (context == null) return default(ExerciseCategoryViewModel);

			return new ExerciseCategoryViewModel(context);
		}

		public static PrimaryNavigationItemViewModel AsNavigationViewModel(this IPage page) => page != null ? new PrimaryNavigationItemViewModel(page) : null;

		public static IEnumerable<PrimaryNavigationItemViewModel> AsNavigationViewModel(this IEnumerable<IPage> pages)
			=> pages?.Where(p => p != null).Select(AsNavigationViewModel) ?? Enumerable.Empty<PrimaryNavigationItemViewModel>();

		//public static XMLSitemapItemViewModel AsXMLSitemapItemViewModel(this IPage page)
		//	=> page != null ? new XMLSitemapItemViewModel(page) : null;

	}
}