using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRightSideOfTheStreet.Common.Extensions;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent.Modules
{
	public class WorkoutParksModuleViewModel : IModulesNestedContentViewModel
	{
		public WorkoutParksModuleViewModel(INestedContentContext<WorkoutParksModule> context)
		{
			Title = context.NestedContent.Title;
			Locations = context.NestedContent.Locations?.Select(lo => context.WithNestedContent(lo).AsViewModel<LocationViewModel>()).AsList();
		}

		public string Title { get; }
		public IList<LocationViewModel> Locations { get; }
	}
}
