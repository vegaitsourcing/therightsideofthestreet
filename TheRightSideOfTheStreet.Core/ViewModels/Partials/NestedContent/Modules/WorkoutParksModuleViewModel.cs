using System.Collections.Generic;
using System.Linq;
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
			IntroText = context.NestedContent.IntroText;
			Locations = context.NestedContent.Locations?.Select(lo => context.WithNestedContent(lo).AsViewModel<LocationViewModel>()).AsList();
		}

		public string Title { get; }
		public string IntroText { get; }
		public IList<LocationViewModel> Locations { get; }
	}
}
