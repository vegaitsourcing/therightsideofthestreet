using System.Collections.Generic;
using System.Linq;
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
			ParkLocation = context.NestedContent.ParkLocation
				?.Select(p => context.WithNestedContent(p).AsViewModel<ParkLocationViewModel>())
				.ToList();
		}

		public string City { get; }
		public IReadOnlyList<ParkLocationViewModel> ParkLocation { get; }
	}
}
