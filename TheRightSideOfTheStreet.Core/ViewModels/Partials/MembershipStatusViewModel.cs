using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials
{
	public class MembershipStatusViewModel
	{
		public MembershipStatusViewModel(MembershipStatus content)
		{
			Icon = content.Icon.AsViewModel();
			Status = content.Status;
			Details = content.Details;
			Link = content.Link;
			Image = content.Image.AsViewModel();
		}

		public ImageViewModel Icon { get; }
		public string Status { get; }
		public string Details { get; }
		public string Link { get; }
		public ImageViewModel Image { get; }
	}
}