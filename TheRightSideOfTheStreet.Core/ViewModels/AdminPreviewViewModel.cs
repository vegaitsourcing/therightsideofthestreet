using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;
using TheRightSideOfTheStreet.Models.Extensions;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class AdminPreviewViewModel
	{
		public AdminPreviewViewModel(IAthleteMemberContext<Admin> context)
		{
			PreviewImage = context.Member.ProfileImage?.AsViewModel();
			PreviewFullName = context.Member.FullName;
			PreviewFacebookProfile = context.Member.FacebookProfile;
			PreviewInstagramProfile = context.Member.InstagramProfile;
			PreviewYoutubeProfile = context.Member.YoutubeProfile;
			Url = $"{context.Landing.Url}{context.Member.GetScreenNameAdmin()}";

		}

		public ImageViewModel PreviewImage { get; }
		public string PreviewFullName { get; }
		public string PreviewFacebookProfile { get; }
		public string PreviewInstagramProfile { get; }
		public string PreviewYoutubeProfile { get; }
		public string Url { get;}
		
	}
}
