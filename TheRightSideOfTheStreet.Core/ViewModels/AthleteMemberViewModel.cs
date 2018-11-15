using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Common.Extensions;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class AthleteMemberViewModel : PageViewModel
	{
		public AthleteMemberViewModel(IPageContext<AthleteLanding> context, AthleteMember content) : base(context)
		{
			FullName = content.FullName;
			ProfileImage = content.ProfileImage.AsViewModel();
			Biography = content.Biography;
			Vision = content.Vision;
			Achievements = content.Achievements.FirstOrDefault().Split('|');
			Images = content.Images.AsViewModel<ImageViewModel>().AsList();
			Country = content.Country;
			Country = content.City;
			FacebookProfile = content.FacebookProfile;
			InstagramProfile = content.InstagramProfile;
			YoutubeProfile = content.YoutubeProfile;
			Crew = content.Crew?.CrewName;
			Status = content.Status?.Status;

		}

		public string FullName { get; }
		public ImageViewModel ProfileImage { get; }
		public string Biography { get; }
		public string Vision { get; }
		public string[] Achievements { get; }
		public IList<ImageViewModel> Images { get; }
		public string Country { get; set; }
		public string City { get; }
		public string FacebookProfile { get; }
		public string InstagramProfile { get; }
		public string YoutubeProfile { get; }
		public string Crew { get; }
		public string Status { get; }

	
	}
}
