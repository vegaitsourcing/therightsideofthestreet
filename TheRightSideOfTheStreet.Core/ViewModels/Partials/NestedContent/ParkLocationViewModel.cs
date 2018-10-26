using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent
{
	public class ParkLocationViewModel: INestedContentViewModel
	{
		public ParkLocationViewModel(INestedContentContext<ParkLocation> context)
		{
			ParkName = context.NestedContent.ParkName;
			Latitude = context.NestedContent.Location.Position.ToWgs84().Latitude;
			Longitude = context.NestedContent.Location.Position.ToWgs84().Longitude;
			Link = context.NestedContent.Link;
		}

		public string ParkName { get; }
		public double Latitude { get; }
		public double Longitude { get; }
		public string Link { get; }
	}
}
