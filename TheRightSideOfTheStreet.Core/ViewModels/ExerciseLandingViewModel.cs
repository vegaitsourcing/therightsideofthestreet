using System.Collections.Generic;
using System.Linq;
using TheRightSideOfTheStreet.Core.Contexts;
using TheRightSideOfTheStreet.Core.Extensions;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.ViewModels
{
	public class ExerciseLandingViewModel : PageViewModel
	{
		public ExerciseLandingViewModel(IPageContext<ExerciseLanding> context) : base(context)
		{
			ExerciseLevel = context.Page.Children.AsViewModel<ExerciseLevelViewModel>().ToList();
		}

		public IList<ExerciseLevelViewModel> ExerciseLevel { get; }
	}
}
