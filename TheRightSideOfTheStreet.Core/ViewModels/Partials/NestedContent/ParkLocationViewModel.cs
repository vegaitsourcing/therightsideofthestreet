using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.ViewModels.Shared;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent
{
	public class ParkLocationViewModel: INestedContentViewModel
	{
		public ParkLocationViewModel(INestedContentContext<ParkLocation> context)
		{
			ParkName = context.NestedContent.ParkName;
			//Location = context.NestedContent.Location;
			Link = context.NestedContent.Link;
		}

		public string ParkName { get; }
		//public  Location { get; }
		public string Link { get; }
	}
}
