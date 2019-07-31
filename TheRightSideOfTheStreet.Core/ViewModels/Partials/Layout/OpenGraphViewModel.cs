using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models.DocumentTypes;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.Layout
{
	public class OpenGraphViewModel
	{
		public OpenGraphViewModel(IPageContext<IPage> context)
		{
			OgTitle = context.CurrentPage.OGtitle;
			OgDescription = context.CurrentPage.OGdescription;
			OgImage = context.CurrentPage.OGimage.AsViewModel();
		}

		#region OpenGraph
		public string OgTitle { get; }
		public string OgDescription { get; }
		public ImageViewModel OgImage { get; }
		#endregion
	}
}
