using PravaStranaUlice.Models;
using PravaStranaUlice.Web.Contexts;

namespace PravaStranaUlice.Web.ViewModels.Partials.NestedContent
{
	public class SocialLinkViewModel : INestedContentViewModel
	{
		public SocialLinkViewModel(INestedContentContext<SocialLink> context)
		{
			Type = context.NestedContent.Type;
			Link = context.NestedContent.Link;
		}

		public string Type { get; }
		public string Link { get; }
	}
}