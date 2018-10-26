using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent
{
	public class LocationViewModel: INestedContentViewModel
	{
		public LocationViewModel(INestedContentContext<Location> context)
		{
			City = context.NestedContent.City;
			ParkLocation = context.NestedContent.ParkLocation?.AsViewModel<ParkLocationViewModel>();
		}

		public string City { get; }
		public ParkLocationViewModel ParkLocation { get; }
	}
}
