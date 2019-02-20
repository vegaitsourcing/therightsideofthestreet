using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent
{
	public class RankingTableViewModel : INestedContentViewModel
	{
		public RankingTableViewModel(INestedContentContext<RankingTable> context)
		{
			AthleteImage = context.NestedContent.AthleteImage.AsViewModel();
			AthleteFullName = context.NestedContent.AthleteFullName;
			CrewLogo = context.NestedContent.CrewLogo.AsViewModel();
			CrewName = context.NestedContent.CrewName;
			City = context.NestedContent.City;
			ParticipantsNumber = context.NestedContent.ParticipantsNumber;
			Points = context.NestedContent.Points;

		}

		public ImageViewModel AthleteImage { get; }
		public string AthleteFullName { get; }
		public ImageViewModel CrewLogo { get; }
		public string CrewName { get; }
		public string City { get; }
		public int ParticipantsNumber { get; }
		public int Points { get; }
	}

	

}
