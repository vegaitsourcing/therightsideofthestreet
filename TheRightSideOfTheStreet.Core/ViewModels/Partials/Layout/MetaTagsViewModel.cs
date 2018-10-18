using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Models.DocumentTypes;
using TheRightSideOfTheStreet.Models.Extensions;
using Umbraco.Web;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.Layout
{
	public class MetaTagsViewModel
	{
		public MetaTagsViewModel(IPageContext<IPage> context)
		{
			SeoTitle = context.Page.GetFormattedSeoTitle(context.Settings.SiteName);
			SeoDescription = context.Page.SeoDescription;
			CanonicalLink = context.Page.CanonicalLink?.Url ?? $"{context.Settings?.CanonicalDomain}{context.Page.UrlAbsolute()}"; //todo create extension method
			HideFromSearchEngines = context.Page.HideFromSearchEngines;
		}

		public string SeoTitle { get; }
		public string SeoDescription { get; }
		public string CanonicalLink { get; }
		public bool HideFromSearchEngines { get; }
	}
}