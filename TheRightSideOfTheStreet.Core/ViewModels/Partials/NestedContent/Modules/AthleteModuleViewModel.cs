using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels.Partials.NestedContent.Modules
{
	public class AthleteModuleViewModel : IModulesNestedContentViewModel
	{
		public AthleteModuleViewModel(INestedContentContext<AthleteModule> context)
		{
			Title = context.NestedContent.Title;
		}

		public string Title { get; }
		
	}
}
